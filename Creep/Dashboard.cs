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
    public partial class Dashboard : Form
    {
        private Connect connect = new Connect();
        public Dashboard()
        {
            if(connect.Open())
            {
                InitializeComponent();
            }
            
        }
    }
}
