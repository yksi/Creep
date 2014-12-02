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
    public partial class CreateReport : Form
    {
        public CreateReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID = 0;
            int owner_id = Variator.Logged_In_User.getID();
            int recipient_id = 2;
            string title = this.repTitle.Text;
            string text = this.repText.Text;
            bool crea = false;
            bool doo  = false;
            int type_id = 1;

            //Report tmp_rep = new Report(ID,owner_id,recipient_id,title,text,crea, doo, type_id );
            //tmp_rep.save();
        }
    }
}
