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
    public partial class CreateItem : Form
    {
        public string[] self_params = new string[4];
        public SpecifyReport for_those { get;set; }

        public CreateItem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.self_params[0] = textBox1.Text;
            this.self_params[1] = textBox2.Text;
            this.self_params[2] = this.comboBox1.Text;
            this.self_params[3] = this.checkBox1.Text;

           //  this.for_those.repItms.Items.Add(this.self_params);
            this.Close();

            this.for_those.Show();
            

        }
    }
}
