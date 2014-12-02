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
    partial class ChooseUser : Form
    {
        private CreateDepartment form_create_department;
        private User choosen_user = new User();
        List<List<object>> all_users = new List<List<object>>();

        public ChooseUser(CreateDepartment create_department, List<List<object>> all_users)
        {
            InitializeComponent();
            this.all_users = all_users;
            this.form_create_department = create_department;
        }

        private void ChooseUser_Load(object sender, EventArgs e)
        {
            foreach(List<object> user in this.all_users)
            {                
                User temp_user = new User(User.getMappedEntity(user));
                this.listView1.Items.Add(temp_user.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.listView1.SelectedItems.Count == 1)
            {
               User tmp_user = new User(User.getMappedEntity(all_users[this.listView1.SelectedIndices[0]]));
               if(this.form_create_department.departmentUserList.FindItemWithText(tmp_user.ToString()) == null)
               {
                   this.form_create_department.add_to_departments(tmp_user);
                   this.form_create_department.departmentUserList.Items.Add(tmp_user.ToString());
               }
               
            }
        }
    }
}
