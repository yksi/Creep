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
        private List<Dictionary<string, object>> reportsAssignedToMe = new List<Dictionary<string, object>>();
        private List<Dictionary<string, object>> reportsReported = new List<Dictionary<string, object>>();
        private Department current_department;
        private User see_user;
        private List<Department> departments = new List<Department>();
        List<Department> all_departments;

        public Dashboard()
        {
            if(connect.Open())
            {
                InitializeComponent();
                if (Variator.Logged_In_User.getRole() < 3) { this.MainMenuStrip.Items.RemoveAt(1); }
                updateUserInfo();
                this.notify.ShowBalloonTip(1);
                InitializeDepartments();
                updateReportsReportedFromMe();
                updateStatistics();
                Variator.dash = this;
            }
        }

        public void InitializeDepartments()
        {
            this.comboBox1.Items.Clear();
            List<Department> work_departments = Variator.Logged_In_User.getDepartments();
            List<Department> manage_departments = Variator.Logged_In_User.getManagedDepartments();
            this.all_departments = new List<Department>(work_departments.Count + manage_departments.Count);

            all_departments.AddRange(manage_departments);
            all_departments.AddRange(work_departments);

            foreach (Department department in all_departments)
            {
                this.comboBox1.Items.Add(department.ToString());
                this.departments.Add(department);
            }
        }

        public void updateDashDepartment()
        {
            if(current_department != null)
            {
                User manager = current_department.getManager();
                List<User> department_workers = current_department.getUsers();

                List<List<object>> Reports = Report.temporary().findAllByInt("department_id", current_department.getID());
                List<Report> OReports = new List<Report>();

                foreach (List<object> report in Reports)
                {
                    OReports.Add(new Report(Report.getMappedEntity(report)));
                }

                string innerHTML = "<H1> " + current_department.getName() + " </H1>";
                if (current_department.getManager().getID() == Variator.Logged_In_User.getID() || Variator.Logged_In_User.getRole() > 1) { innerHTML += "<a href='edit_current_department'> Edit Department </a>"; }
                innerHTML += "<h3> Manager <b>" + manager.getName() + "</b></h3>";

                innerHTML += "<h2> Department Workers </h2><ul>";
                foreach (User user in department_workers)
                {
                    innerHTML += "<li><a href='user:" + user.getID().ToString() + "'>" + user.getName() + " ( " + User.roleName(user.getRole()) + " )</a></li>";
                }
                innerHTML += "</ul>";
                
                innerHTML += "<h2> Department reports </h2><ul>";
                foreach (Report report in OReports)
                {
                    innerHTML += "<li><a href='report:" + report.getID().ToString() + "'>" + report.getTitle() + " ( " + report.getType() + " ) to " + report.getAsignee() + " " + "</a>" + report.getStatusHTML() + "</li>";
                }
                innerHTML += "</ul>";

                dep_info.Navigate("about:blank");
                dep_info.Document.OpenNew(false);
                dep_info.Document.Write("<body><style> body { font-family: Arial }</style><div>" + innerHTML + "</div> </body>");
                dep_info.Refresh();
                this.dash_tabs.SelectTab(1);

                
            }            
        }

        public void updateUserInfo()
        {
            User See = (see_user == null || see_user.getID() == Variator.Logged_In_User.getID()) ? Variator.Logged_In_User : see_user;

            List<List<object>> departments = Department.temporary().findAllByInt("manager_id", See.getID());
            List<List<object>> reports_created = Report.temporary().findAllByInt("owner_id", See.getID());
            List<List<object>> reports_recieved = Report.temporary().findAllByInt("recipient_id", See.getID());

            List<Department> OIDepartments = See.getDepartments();
            List<Department> Odepartments = new List<Department>();
            List<Report> OCreports_closed = new List<Report>();
            List<Report> OCreports_all = new List<Report>();
            List<Report> ORreports_closed = new List<Report>();
            List<Report> ORreports_all = new List<Report>();
            
            int closed_in_count = 0;
            int closed_ou_count = 0;

            foreach(List<object> department in departments )
            {
                Odepartments.Add(new Department(Department.getMappedEntity(department)));
            }

            foreach (List<object> report in reports_created)
            {
                Report tmp_report = new Report ( Report.getMappedEntity(report) );
                OCreports_all.Add(tmp_report);
                if (tmp_report.getIsDone()) { OCreports_closed.Add(tmp_report); closed_ou_count++; }
            }

            foreach (List<object> report in reports_recieved)
            {
                Report tmp_report = new Report(Report.getMappedEntity(report));
                ORreports_all.Add(tmp_report);
                if (tmp_report.getIsDone()) { ORreports_closed.Add(tmp_report); closed_in_count++; }
            }
            
            string innerHTML = "<H1> " + See.getName() + " </H1>";
            innerHTML += "<h3>" + User.roleName(See.getRole()) + "</h3>";

            innerHTML += "<h2> Created reports </h2><ul>";
            foreach(Report report in OCreports_all)
            {
                innerHTML += "<li><a href='report:" + report.getID().ToString() + "'>" + report.getTitle() + " ( " + report.getType() + " ) to " + report.getAsignee() + " " + "</a>" + report.getReporter() + " " + "</a>" + report.getStatusHTML() + "</li>";
            }
            innerHTML += "</ul>";

            innerHTML += "<h2> Asigned reports </h2><ul>";
            foreach (Report report in ORreports_all)
            {
                innerHTML += "<li><a href='report:" + report.getID().ToString() + "'>" + report.getTitle() + " ( " + report.getType() + " ) from " + report.getReporter() + " " + "</a>" + report.getStatusHTML() + "</li>";
            }
            innerHTML += "</ul>";

            innerHTML += "<h2> Departments, you are work in </h2><ul>";
            foreach (Department department in OIDepartments)
            {
                innerHTML += "<li><a href='department:" + department.getID().ToString() + "'>" + department.ToString() + "</a></li>";
            }
            innerHTML += "</ul>";

            innerHTML += "<h2> Departments, managed by you </h2><ul>";
            foreach (Department department in Odepartments)
            {
                innerHTML += "<li><a href='department:" + department.getID().ToString() + "'>" + department.ToString() + "<a></li>";
            }
            innerHTML += "</ul>";

            userInfo.Navigate("about:blank");
            userInfo.Document.OpenNew(false);
            userInfo.Document.Write("<body><style> body { font-family: Arial }</style><div>" + innerHTML + "</div> </body>");
            userInfo.Refresh();
            this.dash_tabs.SelectTab(0);
        }

        public void updateStatistics()
        {
            string innerHTML = "<h1>Statistics</h1>";
            innerHTML += "<h2>Departments statistic</h2>";
            innerHTML += "<table><tr><th>Department Name</th><th>Manager</th><th>Created Reports</th><th>Done Reports</th></tr>";
            foreach(Department department in this.all_departments)
            {
                innerHTML += "<tr><td><a href='department:" + department.getID().ToString() + "'>" + department.getName() + "</a></td>" +
                             "<td><a href='user:" + department.getManager().getID().ToString() + "'>" + department.getManager().getName() + "</a></td>" +
                             "<td>" + Report.temporary().findAllByInt("department_id", department.getID()).Count.ToString() + "</td>" +
                             "<td>" + Report.temporary().where(" `department_id` = " + department.getID().ToString() + " and `checked` = 1").Count.ToString() + "</td></tr>";

            }

            innerHTML += "</table>";
            innerHTML += "<h2>Workers</h2>";
            innerHTML += "<table><tr><th>Username</th><th>Role</th><th>Assigned Reports</th><th>Done Assigned Reports</th><th>Creted Reports</th><th>Done Created Reports</th></tr>";
            foreach (Department department in this.all_departments)
            {
                List<int> TemporaryUsersList = new List<int>();
                List<User> department_users = department.getUsers();

                foreach(User department_user in department_users)
                {
                    if (!TemporaryUsersList.Contains(department_user.getID()))
                    {
                        innerHTML += "<tr><td><a href='user:" + department_user.getID().ToString() + "'>" + department_user.getName() + "</a></td>" +
                                 "<td>" + User.roleName(department_user.getRole()) + "</td>" +
                                 "<td>" + Report.temporary().findAllByInt("recipient_id", department_user.getID()).Count.ToString() + "</td>" +
                                 "<td>" + Report.temporary().where(" `recipient_id` = " + department_user.getID().ToString() + " and `checked` = 1").Count.ToString() + "</td>" +
                                 "<td>" + Report.temporary().findAllByInt("owner_id", department_user.getID()).Count.ToString() + "</td>" +
                                 "<td>" + Report.temporary().where(" `owner_id` = " + department_user.getID().ToString() + " and `checked` = 1").Count.ToString() + "</td>" +
                                 "</tr>";

                        TemporaryUsersList.Add(department_user.getID());
                    }
                        
                }
            }

            statisticInfo.Navigate("about:blank");
            statisticInfo.Document.OpenNew(false);
            statisticInfo.Document.Write(Variator.getBodyHTMLFromString(innerHTML));
            statisticInfo.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateReport report = new CreateReport();
            report.Show();
        }

        public void updateReportsAssignedToMe()
        {
            List<List<Object>> reportsAssignedToMe = new List<List<object>>();
            reportsAssignedToMe = Report.temporary().findAllByInt("recipient_id", Variator.Logged_In_User.getID().ToString());

            this.reportAssignedToMeView.Clear();
            this.reportsAssignedToMe.Clear();
            foreach (List<object> report in reportsAssignedToMe)
            {
                Dictionary<string, object> mapped_report = Report.getMappedEntity(report);
                Report tmp_report = new Report(mapped_report);
                if(!tmp_report.getIsDone() && !tmp_report.getIsExpired())
                {
                    this.reportAssignedToMeView.Items.Add(tmp_report.getTitle() + " (" + tmp_report.getStatus() + ")");
                    this.reportsAssignedToMe.Add(mapped_report);
                }
            }

            this.Activate();
        }

        public void updateReportsReportedFromMe()
        {
            List<List<Object>> reportsReported = new List<List<object>>();
            reportsReported = Report.temporary().findAllByInt("owner_id", Variator.Logged_In_User.getID().ToString());

            this.ReportsReported.Clear();
            this.reportsReported.Clear();
            foreach (List<object> report in reportsReported)
            {
                Dictionary<string, object> mapped_report = Report.getMappedEntity(report);

                this.ReportsReported.Items.Add(new ListViewItem(mapped_report["title"].ToString()));
                this.reportsReported.Add(mapped_report);
            }

            this.Activate();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.label1.Text = Variator.Logged_In_User.getName() + "(" + User.roleName(Variator.Logged_In_User.getRole()) + ")\n" + Variator.Logged_In_User.getEmail();
            updateReportsAssignedToMe();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SpecifyReport report = new SpecifyReport();
            report.Show(); 
        }

        private void reportAssignedToMeView_ItemActivate(object sender, EventArgs e)
        {
            FillReport report_view = new FillReport(this.reportsAssignedToMe[this.reportAssignedToMeView.SelectedItems[0].Index]);
            report_view.Show();
            foreach(Form child in this.MdiChildren)
            {
                child.Close();
            }
        }

        private void reloadDash_Click(object sender, EventArgs e)
        {
            this.updateDash();
        }

        public void updateDash()
        {
            updateReportsAssignedToMe();
            updateReportsReportedFromMe();
            InitializeDepartments();
            updateUserInfo();
            updateStatistics();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateDepartment create_dep = new CreateDepartment();
            create_dep.Show();
        }

        private void actionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void notify_Click(object sender, EventArgs e)
        {
            if (!this.Visible) this.Show();
            else this.Hide();
        }

        private void ReportsReported_ItemActivate(object sender, EventArgs e)
        {
            ViewReport report_view = new ViewReport( new Report(this.reportsReported[this.ReportsReported.SelectedItems[0].Index]));
            report_view.Show();
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }

        private void AddDepartment_Click(object sender, EventArgs e)
        {
            CreateDepartment create_department = new CreateDepartment();
            create_department.Show();
        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            CreateUser createUser = new CreateUser();
            createUser.Show();
        }

        private void updateDashboard_Click(object sender, EventArgs e)
        {
            this.reloadDash_Click(sender, e);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.notify.Visible = false;
            Environment.Exit(0);
        }

        private void userInfo_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            string URL = e.Url.ToString();
            MessageBox.Show(URL);
        }

        private void userInfo_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string URL = e.Url.ToString();
            if (URL != "about:blank")
            {
                if (URL.IndexOf("report:") != -1) 
                {
                    ViewReport vrep = new ViewReport(new Report(Report.getMappedEntity(Report.temporary().find(int.Parse(URL.Replace("report:", ""))))));
                    vrep.Show();
                }

                else if (URL.IndexOf("department:") != -1)
                {
                    current_department = Department.find(int.Parse(URL.Replace("department:", "")), true);
                    updateDashDepartment();
                }

                e.Cancel = true;
            }
        }

        private void userInfo_Navigated_1(object sender, WebBrowserNavigatedEventArgs e)
        {
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Variator.main.Show();
            this.Close();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            this.current_department = this.departments[this.comboBox1.SelectedIndex];
            updateDashDepartment();
        }

        private void dep_info_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string URL = e.Url.ToString();
            if (URL != "about:blank")
            {
                this.Text = URL;

                if (URL.IndexOf("report:") != -1)
                {
                    ViewReport vrep = new ViewReport(new Report(Report.getMappedEntity(Report.temporary().find(int.Parse(URL.Replace("report:", ""))))));
                    vrep.Show();
                }

                else if (URL.IndexOf("user:") != -1)
                {
                    see_user = User.find(int.Parse(URL.Replace("user:", "")), true);
                    updateUserInfo();
                }

                else if (URL == "about:edit_current_department")
                {
                    CreateDepartment edit_department = new CreateDepartment(current_department);
                    edit_department.Show();
                }

                e.Cancel = true;
            }
        }

        private void statisticInfo_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string URL = e.Url.ToString();
            if (URL != "about:blank")
            {
                this.Text = URL;

                if (URL.IndexOf("report:") != -1)
                {
                    ViewReport vrep = new ViewReport(new Report(Report.getMappedEntity(Report.temporary().find(int.Parse(URL.Replace("report:", ""))))));
                    vrep.Show();
                }

                else if (URL.IndexOf("user:") != -1)
                {
                    see_user = User.find(int.Parse(URL.Replace("user:", "")), true);
                    updateUserInfo();
                }

                else if (URL.IndexOf("department:") != -1)
                {
                    current_department = Department.find(int.Parse(URL.Replace("department:", "")), true);
                    updateDashDepartment();
                }

                e.Cancel = true;
            }
        }

        private void BrowseUsers_Click(object sender, EventArgs e)
        {
            EditUserRole eur = new EditUserRole();
            eur.Show();
        }

        private void createReportTask_Click(object sender, EventArgs e)
        {
            this.button2_Click(sender, e);
        }


    }
}
