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
    public partial class FillReport : Form
    {
        List<ReportItem> report_items = new List<ReportItem>();
        Report report_as_object = new Report();
        Report report = new Report();

        public FillReport()
        {
            InitializeComponent();
        }

        public FillReport(Dictionary<string, object> report)
        {
            InitializeComponent();
            this.report = new Report(report);
            this.reportTitleView.Text = report["title"].ToString();
            if (this.report.getIsFinished()) this.reportTitleView.Text += " (DONE)";
            else this.reportTitleView.Text += " (IN PROCESS)";
            this.reportDescView.Text = report["formatted_text"].ToString();
            this.reporterName.Text = (new User(User.getMappedEntity(User.temporary().find(int.Parse(report["owner_id"].ToString()))))).getName();
            this.report_assignee.Text = (new User(User.getMappedEntity(User.temporary().find(int.Parse(report["recipient_id"].ToString()))))).getName();
            this.due_date.Text = report["due_date"].ToString();
            this.reportContentView.AutoScroll = true;

            this.report_as_object = new Report(report);
            this.report_items = report_as_object.getReportItems();
 
            foreach(ReportItem report_item in this.report_items)
            {
                Label label = new Label();
                label.Text = report_item.getTitle();
                if (report_item.getType() != "Checkbox") this.reportContentView.Controls.Add(label);
                switch(report_item.getType())
                {

                        
                    case "Formatted text":
                    {
                        TextBox textBox = new TextBox();
                        textBox.Name = report_item.getID().ToString();
                        textBox.Multiline = true;
                        textBox.Height = 78;
                        textBox.Dock = DockStyle.Bottom;
                        textBox.Text = report_item.getValue();
                        textBox.ScrollBars = ScrollBars.Both;
                        label.AutoSize = true;
                        if( report_item != report_items[0] )
                        {
                            this.reportContentView.RowCount++;
                        }

                        this.reportContentView.Controls.Add(textBox);
                        
                        break;
                    }

                    case "Plain text":
                    {
                        TextBox textBox = new TextBox();
                        textBox.Text = report_item.getValue();
                        textBox.Bounds = new Rectangle(10, 10, 20, 30);
                        if (report_item != report_items[0])
                        {
                            this.reportContentView.RowCount++;
                        }

                        this.reportContentView.Controls.Add(textBox);

                        break;
                    }

                    case "List":
                    {
                        ListView listView = new ListView();
                        if (report_item != report_items[0])
                        {
                            this.reportContentView.RowCount++;
                        }

                        //if (reported) listView.;
                        //listView.Name = report_item.getID().ToString();
                        //textBox.Multiline = true;
                        //textBox.Height = 78;
                        //textBox.Dock = DockStyle.Bottom;
                        //textBox.Text = report_item.getValue();
                        //textBox.ScrollBars = ScrollBars.Both;

                        break;
                    }

                    case "Checkbox":
                    {
                        CheckBox checkBox = new CheckBox();
                        checkBox.Text = report_item.getTitle();
                        checkBox.Name = report_item.getID().ToString();
                        try
                        {
                            checkBox.Checked = Convert.ToBoolean(report_item.getValue()) ? true : false;
                        }
                        catch ( Exception exp)
                        {
                            Console.WriteLine(exp.Message);
                        }

                        if (report_item != report_items[0])
                        {
                            this.reportContentView.RowCount++;
                        }

                        this.reportContentView.Controls.Add(checkBox);
                       

                        break;
                    }
                }

                foreach(RowStyle style in this.reportContentView.RowStyles)
                {
                    style.SizeType = SizeType.AutoSize;
                }

                if (this.report.getIsFinished()) this.report_finish.Hide();
            }
        }

        private void FillReport_Load(object sender, EventArgs e)
        {

        }

        private void report_save_Click(object sender, EventArgs e)
        {
            int index = 0;
            this.report.setIsFinished(this.report_finish.Checked);
            report.update();

            foreach(ReportItem report_item in this.report_items)
            {
                var Element = this.reportContentView.Controls[report_item.getID().ToString()];
                
                if (Element is TextBox)
                {
                    report_items[index].setValue(Element.Text);
                }

                if(Element is CheckBox)
                {
                    CheckBox CheckElement = (CheckBox)Element;
                    if(CheckElement.Checked)
                    {
                        report_items[index].setValue("true");
                    }
                    else
                    {
                        report_items[index].setValue("false");
                    }  
                }
                report_items[index].update();
                index++;
            }
            this.Close();

            Variator.dash.updateReportsAssignedToMe();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.report.setIsDone(true);
            this.report.update();

        }
    }
}
