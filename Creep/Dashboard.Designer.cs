namespace Creep
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.reloadDash = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.createReportTask = new System.Windows.Forms.ToolStripMenuItem();
            this.updateDashboard = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.administrationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.AddDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.BrowseUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dash_reports = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.reportAssignedToMeView = new System.Windows.Forms.ListView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ReportsReported = new System.Windows.Forms.ListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dash_tabs = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.userInfo = new System.Windows.Forms.WebBrowser();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dep_info = new System.Windows.Forms.WebBrowser();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.statisticInfo = new System.Windows.Forms.WebBrowser();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.dash_reports.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.dash_tabs.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.reloadDash);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(970, 678);
            this.splitContainer1.SplitterDistance = 77;
            this.splitContainer1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Departtment";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox1.Location = new System.Drawing.Point(160, 53);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(118, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // reloadDash
            // 
            this.reloadDash.Location = new System.Drawing.Point(88, 27);
            this.reloadDash.Name = "reloadDash";
            this.reloadDash.Size = new System.Drawing.Size(66, 47);
            this.reloadDash.TabIndex = 3;
            this.reloadDash.Text = "Reload";
            this.reloadDash.UseVisualStyleBackColor = true;
            this.reloadDash.Click += new System.EventHandler(this.reloadDash_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 47);
            this.button2.TabIndex = 2;
            this.button2.Text = "New Report Task";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(796, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsToolStripMenuItem1,
            this.administrationsToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(970, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "mainMenu";
            // 
            // actionsToolStripMenuItem1
            // 
            this.actionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createReportTask,
            this.updateDashboard,
            this.logoutToolStripMenuItem,
            this.Exit});
            this.actionsToolStripMenuItem1.Name = "actionsToolStripMenuItem1";
            this.actionsToolStripMenuItem1.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem1.Text = "Actions";
            this.actionsToolStripMenuItem1.Click += new System.EventHandler(this.actionsToolStripMenuItem1_Click);
            // 
            // createReportTask
            // 
            this.createReportTask.Name = "createReportTask";
            this.createReportTask.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.createReportTask.Size = new System.Drawing.Size(216, 22);
            this.createReportTask.Text = "Create Report Task";
            this.createReportTask.Click += new System.EventHandler(this.createReportTask_Click);
            // 
            // updateDashboard
            // 
            this.updateDashboard.Name = "updateDashboard";
            this.updateDashboard.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.updateDashboard.Size = new System.Drawing.Size(216, 22);
            this.updateDashboard.Text = "Update Dashboard";
            this.updateDashboard.Click += new System.EventHandler(this.updateDashboard_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(216, 22);
            this.Exit.Text = "Exit";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // administrationsToolStripMenuItem
            // 
            this.administrationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddUser,
            this.AddDepartment,
            this.BrowseUsers});
            this.administrationsToolStripMenuItem.Name = "administrationsToolStripMenuItem";
            this.administrationsToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.administrationsToolStripMenuItem.Text = "Administration";
            // 
            // AddUser
            // 
            this.AddUser.Name = "AddUser";
            this.AddUser.Size = new System.Drawing.Size(162, 22);
            this.AddUser.Text = "Add User";
            this.AddUser.Click += new System.EventHandler(this.AddUser_Click);
            // 
            // AddDepartment
            // 
            this.AddDepartment.Name = "AddDepartment";
            this.AddDepartment.Size = new System.Drawing.Size(162, 22);
            this.AddDepartment.Text = "Add Department";
            this.AddDepartment.Click += new System.EventHandler(this.AddDepartment_Click);
            // 
            // BrowseUsers
            // 
            this.BrowseUsers.Name = "BrowseUsers";
            this.BrowseUsers.Size = new System.Drawing.Size(162, 22);
            this.BrowseUsers.Text = "Browse Users";
            this.BrowseUsers.Click += new System.EventHandler(this.BrowseUsers_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainer2.Panel1.Controls.Add(this.dash_reports);
            this.splitContainer2.Panel1.Controls.Add(this.statusStrip1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dash_tabs);
            this.splitContainer2.Size = new System.Drawing.Size(970, 597);
            this.splitContainer2.SplitterDistance = 322;
            this.splitContainer2.TabIndex = 0;
            // 
            // dash_reports
            // 
            this.dash_reports.Controls.Add(this.tabPage3);
            this.dash_reports.Controls.Add(this.tabPage4);
            this.dash_reports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dash_reports.Location = new System.Drawing.Point(0, 0);
            this.dash_reports.Name = "dash_reports";
            this.dash_reports.SelectedIndex = 0;
            this.dash_reports.Size = new System.Drawing.Size(322, 575);
            this.dash_reports.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.reportAssignedToMeView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(314, 549);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Assigned";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // reportAssignedToMeView
            // 
            this.reportAssignedToMeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportAssignedToMeView.FullRowSelect = true;
            this.reportAssignedToMeView.GridLines = true;
            this.reportAssignedToMeView.Location = new System.Drawing.Point(3, 3);
            this.reportAssignedToMeView.Name = "reportAssignedToMeView";
            this.reportAssignedToMeView.Size = new System.Drawing.Size(308, 543);
            this.reportAssignedToMeView.TabIndex = 1;
            this.reportAssignedToMeView.UseCompatibleStateImageBehavior = false;
            this.reportAssignedToMeView.View = System.Windows.Forms.View.List;
            this.reportAssignedToMeView.ItemActivate += new System.EventHandler(this.reportAssignedToMeView_ItemActivate);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ReportsReported);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(314, 549);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Reported";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ReportsReported
            // 
            this.ReportsReported.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportsReported.FullRowSelect = true;
            this.ReportsReported.GridLines = true;
            this.ReportsReported.Location = new System.Drawing.Point(3, 3);
            this.ReportsReported.Name = "ReportsReported";
            this.ReportsReported.Size = new System.Drawing.Size(308, 543);
            this.ReportsReported.TabIndex = 2;
            this.ReportsReported.UseCompatibleStateImageBehavior = false;
            this.ReportsReported.View = System.Windows.Forms.View.List;
            this.ReportsReported.ItemActivate += new System.EventHandler(this.ReportsReported_ItemActivate);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 575);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(322, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dash_tabs
            // 
            this.dash_tabs.Controls.Add(this.tabPage5);
            this.dash_tabs.Controls.Add(this.tabPage1);
            this.dash_tabs.Controls.Add(this.tabPage2);
            this.dash_tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dash_tabs.Location = new System.Drawing.Point(0, 0);
            this.dash_tabs.Name = "dash_tabs";
            this.dash_tabs.SelectedIndex = 0;
            this.dash_tabs.Size = new System.Drawing.Size(644, 597);
            this.dash_tabs.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.userInfo);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(636, 571);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "User info";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // userInfo
            // 
            this.userInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userInfo.Location = new System.Drawing.Point(0, 0);
            this.userInfo.MinimumSize = new System.Drawing.Size(20, 20);
            this.userInfo.Name = "userInfo";
            this.userInfo.Size = new System.Drawing.Size(636, 571);
            this.userInfo.TabIndex = 0;
            this.userInfo.TabStop = false;
            this.userInfo.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.userInfo_Navigated_1);
            this.userInfo.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.userInfo_Navigating);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dep_info);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(636, 571);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Department";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dep_info
            // 
            this.dep_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dep_info.Location = new System.Drawing.Point(3, 3);
            this.dep_info.MinimumSize = new System.Drawing.Size(20, 20);
            this.dep_info.Name = "dep_info";
            this.dep_info.Size = new System.Drawing.Size(630, 565);
            this.dep_info.TabIndex = 0;
            this.dep_info.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.dep_info_Navigating);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.statisticInfo);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(636, 571);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Statistic";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // statisticInfo
            // 
            this.statisticInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statisticInfo.Location = new System.Drawing.Point(3, 3);
            this.statisticInfo.MinimumSize = new System.Drawing.Size(20, 20);
            this.statisticInfo.Name = "statisticInfo";
            this.statisticInfo.Size = new System.Drawing.Size(630, 565);
            this.statisticInfo.TabIndex = 0;
            this.statisticInfo.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.statisticInfo_Navigating);
            // 
            // notify
            // 
            this.notify.BalloonTipText = "Creep-Enterprice is here now";
            this.notify.BalloonTipTitle = "Hello";
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Text = "Creep-Enterprice";
            this.notify.Visible = true;
            this.notify.Click += new System.EventHandler(this.notify_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 678);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Dashboard";
            this.Text = "Creep 0.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.dash_reports.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.dash_tabs.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl dash_tabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView reportAssignedToMeView;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button reloadDash;
        private System.Windows.Forms.TabControl dash_reports;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem createReportTask;
        private System.Windows.Forms.ToolStripMenuItem updateDashboard;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem administrationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddUser;
        private System.Windows.Forms.ToolStripMenuItem AddDepartment;
        private System.Windows.Forms.ToolStripMenuItem BrowseUsers;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView ReportsReported;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.WebBrowser userInfo;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.WebBrowser dep_info;
        private System.Windows.Forms.WebBrowser statisticInfo;
    }
}

