namespace Creep
{
    partial class FillReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FillReport));
            this.reportTitleView = new System.Windows.Forms.Label();
            this.reportDescView = new System.Windows.Forms.Label();
            this.reportContentView = new System.Windows.Forms.TableLayoutPanel();
            this.report_save = new System.Windows.Forms.Button();
            this.report_finish = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reporterName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.due_date = new System.Windows.Forms.Label();
            this.report_assignee = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportTitleView
            // 
            this.reportTitleView.AutoSize = true;
            this.reportTitleView.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reportTitleView.Location = new System.Drawing.Point(258, 20);
            this.reportTitleView.Name = "reportTitleView";
            this.reportTitleView.Size = new System.Drawing.Size(105, 23);
            this.reportTitleView.TabIndex = 0;
            this.reportTitleView.Text = "Report title";
            // 
            // reportDescView
            // 
            this.reportDescView.AutoSize = true;
            this.reportDescView.Location = new System.Drawing.Point(68, 57);
            this.reportDescView.Name = "reportDescView";
            this.reportDescView.Size = new System.Drawing.Size(539, 39);
            this.reportDescView.TabIndex = 1;
            this.reportDescView.Text = "Visual Basic\r\nPrivate Sub Button1_Click(ByVal sender As System.Object, ByVal e As" +
    " System.EventArgs) Handles Button1.Click\r\n   Dim MyText As New TextBox()\r\n";
            // 
            // reportContentView
            // 
            this.reportContentView.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.reportContentView.ColumnCount = 1;
            this.reportContentView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.reportContentView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.reportContentView.Location = new System.Drawing.Point(58, 116);
            this.reportContentView.Name = "reportContentView";
            this.reportContentView.RowCount = 1;
            this.reportContentView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.reportContentView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.reportContentView.Size = new System.Drawing.Size(536, 488);
            this.reportContentView.TabIndex = 2;
            // 
            // report_save
            // 
            this.report_save.Location = new System.Drawing.Point(693, 583);
            this.report_save.Name = "report_save";
            this.report_save.Size = new System.Drawing.Size(103, 23);
            this.report_save.TabIndex = 3;
            this.report_save.Text = "Save";
            this.report_save.UseVisualStyleBackColor = true;
            this.report_save.Click += new System.EventHandler(this.report_save_Click);
            // 
            // report_finish
            // 
            this.report_finish.AutoSize = true;
            this.report_finish.Location = new System.Drawing.Point(703, 560);
            this.report_finish.Name = "report_finish";
            this.report_finish.Size = new System.Drawing.Size(83, 17);
            this.report_finish.TabIndex = 4;
            this.report_finish.Text = "Finish report";
            this.report_finish.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(623, 376);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Reporter:";
            // 
            // reporterName
            // 
            this.reporterName.AutoSize = true;
            this.reporterName.Location = new System.Drawing.Point(632, 389);
            this.reporterName.Name = "reporterName";
            this.reporterName.Size = new System.Drawing.Size(0, 13);
            this.reporterName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(623, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Due date";
            // 
            // due_date
            // 
            this.due_date.AutoSize = true;
            this.due_date.Location = new System.Drawing.Point(680, 363);
            this.due_date.Name = "due_date";
            this.due_date.Size = new System.Drawing.Size(61, 13);
            this.due_date.TabIndex = 8;
            this.due_date.Text = "2012-12-01";
            // 
            // report_assignee
            // 
            this.report_assignee.AutoSize = true;
            this.report_assignee.Location = new System.Drawing.Point(632, 424);
            this.report_assignee.Name = "report_assignee";
            this.report_assignee.Size = new System.Drawing.Size(0, 13);
            this.report_assignee.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(623, 411);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Asignee";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(600, 583);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Done";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FillReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(798, 618);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.report_assignee);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.due_date);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reporterName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.report_finish);
            this.Controls.Add(this.report_save);
            this.Controls.Add(this.reportContentView);
            this.Controls.Add(this.reportDescView);
            this.Controls.Add(this.reportTitleView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FillReport";
            this.Text = "FillReport";
            this.Load += new System.EventHandler(this.FillReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label reportTitleView;
        private System.Windows.Forms.Label reportDescView;
        private System.Windows.Forms.TableLayoutPanel reportContentView;
        private System.Windows.Forms.Button report_save;
        private System.Windows.Forms.CheckBox report_finish;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label reporterName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label due_date;
        private System.Windows.Forms.Label report_assignee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}