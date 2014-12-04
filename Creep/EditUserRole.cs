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
    public partial class EditUserRole : Form
    {

        private List<List<object>> Users = User.temporary().all();
        private List<User> Ousers = new List<User>();
        private User current_user = new User();

        public EditUserRole()
        {
            InitializeComponent();

            foreach(List<object> user in Users)
            {
                Ousers.Add(new User(User.getMappedEntity(user)));
            }
            
            foreach(User user in Ousers)
            {
                comboBox1.Items.Add(user.ToString());
            }
        }

        private EditUserRole(User user) : this()
        {
            this.comboBox1.SelectedIndex = Ousers.IndexOf(user);
            this.comboBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            current_user.setRole(this.comboBox2.SelectedIndex);
            current_user.update();

            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_user = Ousers[comboBox1.SelectedIndex];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ManagedDepartments = Ousers[this.comboBox1.SelectedIndex].getManagedDepartments().Count;

            if (ManagedDepartments > 1) { MessageBox.Show("This user has " + ManagedDepartments.ToString() + " Managed Departments. Please reassign Departments Manager where " + Ousers[this.comboBox1.SelectedIndex].ToString() + " is Manager"); }
        
            else
            {
                Ousers[this.comboBox1.SelectedIndex].delete();

                List<List<object>> all_reports = Report.temporary().where("owner_id = " + Ousers[this.comboBox1.SelectedIndex].getID().ToString() + " and recipient_id = " + Ousers[this.comboBox1.SelectedIndex].getID().ToString());

                foreach(List<object> report in all_reports)
                {
                    (new Report(Report.getMappedEntity(report))).delete();
                }
            }
        }
    }
}
