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
    partial class ViewReport : Form
    {
        private Report report;
        public ViewReport(Report report)
        {
            this.report = report;
            InitializeComponent();
            if (this.report.getRecipientId() == Variator.Logged_In_User.getID()) { this.reportEdit.Show(); }
            if (this.report.getIsDone() || this.report.getIsExpired()) { this.reportEdit.Hide(); }
            string internal_HTML = "<h1>"+ report.getTitle() +"</h1>";
            if (report.getReporterId() != Variator.Logged_In_User.getID()) { doneReport.Hide(); delete.Hide(); }
            if(report.getIsFinished()) internal_HTML += "<h5 style='color: green'>" + this.report.getAsignee() + " finished this report at " + this.report.getUpdated() + "</h5>";
            internal_HTML += "<h5> Asignee: " + report.getAsignee() + "</h5>";
            internal_HTML += "<h5> Reporter: " + report.getReporter() + "</h5>";
            internal_HTML += "<h5> Created at: " + report.getCreated() + "</h5>";
            internal_HTML += "<h5> Updated at: " + report.getUpdated() + "</h5>";
            internal_HTML += "<h5> Expired at: " + report.getExpiredDate() + "</h5>";
            internal_HTML += "<h5> Report status: " + report.getStatusHTML()+ "</h5>";
            if (this.report.getIsDone()) { this.doneReport.Hide(); this.doneLabel.Text = "Done"; }
            foreach(ReportItem item in report.getReportItems())
            {
                internal_HTML += "<br/>";
                if(item.getType() == "Checkbox")
                {
                    internal_HTML += "<label><input type='checkbox' value='' disabled " + (report.getIsFinished() ? "checked" : "") + "/>" + item.getTitle() +"</label>";
                }

                if (item.getType() == "Formatted text")
                {
                    internal_HTML += item.getTitle() + "<br/><textarea readonly style='width: 100%' />" + item.getValue() + "</textarea>";
                }
            }

            this.webBrowser1.DocumentText =
                "<style> body { font-family: Arial; } </style><body><div>" +
                
                    internal_HTML

                + "</div></body>";

            this.webBrowser1.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.report.setIsDone(true);
            this.report.update();
            this.doneLabel.Text = "Done";
            this.doneReport.Hide();
        }

        private void reportEdit_Click(object sender, EventArgs e)
        {
            FillReport fill = new FillReport(this.report.getMappedEntity());
            fill.Show();
            this.Close();
            
        }

        private void delete_Click(object sender, EventArgs e)
        {

            this.report.delete();
            foreach(ReportItem report_item in this.report.getReportItems())
            {
                report_item.delete();
            }
            
            this.Close();
        }
    }
}
