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
            this.reportContentView = new System.Windows.Forms.TableLayoutPanel();
            this.report_save = new System.Windows.Forms.Button();
            this.report_finish = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // reportContentView
            // 
            this.reportContentView.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.reportContentView.ColumnCount = 1;
            this.reportContentView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.reportContentView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.reportContentView.Location = new System.Drawing.Point(3, 145);
            this.reportContentView.Name = "reportContentView";
            this.reportContentView.RowCount = 1;
            this.reportContentView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.reportContentView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.reportContentView.Size = new System.Drawing.Size(592, 517);
            this.reportContentView.TabIndex = 2;
            // 
            // report_save
            // 
            this.report_save.Location = new System.Drawing.Point(694, 639);
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
            this.report_finish.Location = new System.Drawing.Point(704, 616);
            this.report_finish.Name = "report_finish";
            this.report_finish.Size = new System.Drawing.Size(83, 17);
            this.report_finish.TabIndex = 4;
            this.report_finish.Text = "Finish report";
            this.report_finish.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(601, 639);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Done";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(601, 145);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(196, 465);
            this.webBrowser1.TabIndex = 12;
            // 
            // webBrowser2
            // 
            this.webBrowser2.Location = new System.Drawing.Point(3, 12);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(794, 127);
            this.webBrowser2.TabIndex = 13;
            // 
            // FillReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(798, 674);
            this.Controls.Add(this.webBrowser2);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.report_finish);
            this.Controls.Add(this.report_save);
            this.Controls.Add(this.reportContentView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FillReport";
            this.Text = "FillReport";
            this.Load += new System.EventHandler(this.FillReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel reportContentView;
        private System.Windows.Forms.Button report_save;
        private System.Windows.Forms.CheckBox report_finish;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.WebBrowser webBrowser2;
    }
}