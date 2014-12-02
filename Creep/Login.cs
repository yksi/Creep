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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;

            if (User.verifyPassword(this.emailLoginField.Text, this.passwordLoginField.Text))
            {
                this.Hide();
                List<Object> user = User.temporary().findBy("email", this.emailLoginField.Text);
                Variator.Logged_In_User = new User(int.Parse(user[0].ToString()), user[1].ToString(), user[2].ToString(), int.Parse(user[3].ToString()));
                Dashboard dash = new Dashboard();
                dash.Show();
                Variator.main = this;
                this.button1.Enabled = true;
            }

            else
            {
                MessageBox.Show("Email or password is invalid. Please try again or contact your administrator.");
                this.button1.Enabled = true;
            }
        }


    }
}
