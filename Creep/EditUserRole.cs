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

        private void button1_Click(object sender, EventArgs e)
        {
            current_user.setRole(this.comboBox2.SelectedIndex != 2 ? this.comboBox2.SelectedIndex : 3);
            current_user.update();

            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_user = Ousers[comboBox1.SelectedIndex];
        }
    }
}
