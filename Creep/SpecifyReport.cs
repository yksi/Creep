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
    public partial class SpecifyReport : Form
    {
        private List<ReportType> report_types = new List<ReportType>();
        List<List<Object>> users;
        private Department current_department = new Department();
        private List<Department> all_departments = new List<Department> ();
        private List<User> DepUsers = new List<User>();
        public SpecifyReport()
        {
            InitializeComponent();

            List<Department> work_departments = Variator.Logged_In_User.getDepartments();
            List<Department> manage_departments = Variator.Logged_In_User.getManagedDepartments();
            this.all_departments = new List<Department>(work_departments.Count + manage_departments.Count);
            all_departments.AddRange(manage_departments);
            all_departments.AddRange(work_departments);

            List<List<object>> report_types = new List<List<object>>();
            report_types = ReportType.temporary().all();

            foreach(List<object> report_type in report_types)
            {
                ReportType tmprt = new ReportType(ReportType.getMappedEntity(report_type));
                this.report_type.Items.Add(tmprt.ToString());
                this.report_types.Add(tmprt);
            }

        }

        private void SpecifyReport_Load(object sender, EventArgs e)
        {
            foreach(Department dep in all_departments)
            {
                reportDepartment.Items.Add(dep.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (true)
            {

                List<ReportItem> report_items = new List<ReportItem>();

                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    if (row != this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1])
                    {
                        report_items.Add(new ReportItem(0, 0, row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[3].Value.ToString(), bool.Parse(row.Cells[2].Value.ToString())));
                    }
                }

                Report current_report = new Report(0, Variator.Logged_In_User.getID(), DepUsers[Asignee.SelectedIndex].getID(), this.textBox1.Text, this.textBox2.Text, false, false, this.report_types[this.report_type.SelectedIndex].getID(), "NULL", "NULL", this.dateTimePicker1.Value.ToString("yyyy-MM-dd"), all_departments[reportDepartment.SelectedIndex].getID());

                int id = current_report.save();
                foreach (ReportItem report_item in report_items)
                {
                    report_item.setReport(id);
                    report_item.save();
                }

                this.Close();
                Variator.dash.updateReportsAssignedToMe();
                Variator.dash.updateReportsReportedFromMe();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateReportItem new_item = new CreateReportItem(this);
            new_item.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reportDepartment_SelectedValueChanged(object sender, EventArgs e)
        {
            current_department = all_departments[reportDepartment.SelectedIndex];
            DepUsers = current_department.getUsers();
            Asignee.Items.Clear();
            foreach(User cur_user in DepUsers)
            {
                Asignee.Items.Add(cur_user.ToString());
            }
        }

        private void removeItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                this.dataGridView1.Rows.Remove(row);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Selected = true; 
        }
    }
}
