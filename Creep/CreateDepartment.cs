using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creep
{
    partial class CreateDepartment : Form
    {
        private List<User> department_users;
        private List<List<object>> AllUsers = new List<List<object>>();
        private Department department = null;

        public CreateDepartment()
        {
            InitializeComponent();
            this.AllUsers = User.temporary().all();
            foreach (List<object> user in this.AllUsers)
            {
                this.departmentManager.Items.Add((new User(User.getMappedEntity(user))).ToString());
            }
            department_users = new List<User>();
            
        }

        public CreateDepartment(Department department)
        {
            this.department = department;
            
            InitializeComponent();
            this.Text = "Edit Department";
            this.label1.Text = "Edit Department";
            
            this.departmentName.Text = department.getName();
            this.AllUsers = User.temporary().all();
            this.departmentManager.Items.Add(department.getManager().ToString());
            this.departmentManager.Text = this.departmentManager.Items[0].ToString();
            if (Variator.Logged_In_User.getRole() < 2) { this.departmentManager.Enabled = false; this.button5.Hide(); }
            department_users = this.department.getUsers();
            foreach(User department_user in department_users)
            {
                departmentUserList.Items.Add(department_user.ToString());
            }
            foreach (List<object> user in this.AllUsers)
            {
                this.departmentManager.Items.Add((new User(User.getMappedEntity(user))).ToString());
            }

        }

        public void add_to_departments(User user)
        {
            department_users.Add(user);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (this.departmentName.Text == "") { MessageBox.Show("Please specify Department name"); return; }
            else
            {

                if (this.departmentName.Text != "" && this.departmentManager.Text != null)
                {
                    User manager_user = this.department == null ? User.find(User.getIdFromToString(this.departmentManager.Text), true) : Variator.Logged_In_User;
                    Department current_department = this.department == null ? new Department(0, this.departmentName.Text, manager_user.getID()) : this.department;
                    int department_id = this.department == null ? current_department.save() : current_department.getID();
                    if (checkBox1.Checked && manager_user.getRole() < 1) { manager_user.setRole(1); manager_user.update(); }
                    if (this.department != null)
                    {
                        int index = 0;
                        foreach(ListViewItem WorkerItem in this.departmentUserList.Items)
                        {
                            UsersDepartment.temporary().deleteByIntAnd("user_id", this.department_users[index].getID(), "department_id", department.getID());
                            index++;
                        }
                        
                    }
                    
                    foreach (User user in this.department_users)
                    {
                        (new UsersDepartment(user.getID(), department_id)).save();
                    }

                    current_department.setName(this.departmentName.Text);
                    if(department != null) 
                    {
                        current_department.update();
                    } 
                    else current_department.save();

                    this.Close();
                    Variator.dash.InitializeDepartments();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChooseUser ch_u = new ChooseUser(this, AllUsers);
            ch_u.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = this.departmentUserList.SelectedIndices[0];
                
            this.departmentUserList.Items.RemoveAt(index);
            this.department_users.RemoveAt(index);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.department.delete();
            List<UsersDepartment> user_departs = new List<UsersDepartment> ();

            foreach( List<object> entity in UsersDepartment.temporary().findAllByInt("department_id", this.department.getID()) )
            {
                UsersDepartment user_depart = new UsersDepartment( UsersDepartment.getMappedEntity(entity) );
            }
        }
    }
}
