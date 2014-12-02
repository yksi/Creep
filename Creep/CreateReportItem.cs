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
    public partial class CreateReportItem : Form
    {
        private SpecifyReport parent;

        public CreateReportItem()
        {
            InitializeComponent();
        }

        public CreateReportItem(SpecifyReport parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            parent.dataGridView1.Rows.Add(this.title.Text, this.comboBox1.Text, this.checkBox1.Checked, this.textBox2.Text);
            this.Close();
        
        }
    }
}
