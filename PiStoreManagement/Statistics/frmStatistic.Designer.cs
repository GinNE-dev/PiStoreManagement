namespace PiStoreManagement.Statistics
{
    partial class frmStatistic
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
            this.plotViewMain = new OxyPlot.WindowsForms.PlotView();
            this.comboBoxPeriod = new System.Windows.Forms.ComboBox();
            this.dateTimePickerRange = new System.Windows.Forms.DateTimePicker();
            this.btnGeneareDataTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // plotViewMain
            // 
            this.plotViewMain.Location = new System.Drawing.Point(108, 105);
            this.plotViewMain.Name = "plotViewMain";
            this.plotViewMain.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotViewMain.Size = new System.Drawing.Size(1066, 405);
            this.plotViewMain.TabIndex = 0;
            this.plotViewMain.Text = "plotView1";
            this.plotViewMain.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotViewMain.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotViewMain.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // comboBoxPeriod
            // 
            this.comboBoxPeriod.FormattingEnabled = true;
            this.comboBoxPeriod.Items.AddRange(new object[] {
            "Week",
            "Month",
            "Year"});
            this.comboBoxPeriod.Location = new System.Drawing.Point(59, 47);
            this.comboBoxPeriod.Name = "comboBoxPeriod";
            this.comboBoxPeriod.Size = new System.Drawing.Size(121, 24);
            this.comboBoxPeriod.TabIndex = 2;
            this.comboBoxPeriod.Text = "Week";
            this.comboBoxPeriod.SelectedIndexChanged += new System.EventHandler(this.comboBoxPeriod_SelectedIndexChanged);
            // 
            // dateTimePickerRange
            // 
            this.dateTimePickerRange.Location = new System.Drawing.Point(204, 47);
            this.dateTimePickerRange.Name = "dateTimePickerRange";
            this.dateTimePickerRange.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerRange.TabIndex = 3;
            this.dateTimePickerRange.ValueChanged += new System.EventHandler(this.dateTimePickerRange_ValueChanged);
            // 
            // btnGeneareDataTest
            // 
            this.btnGeneareDataTest.Location = new System.Drawing.Point(1027, 533);
            this.btnGeneareDataTest.Name = "btnGeneareDataTest";
            this.btnGeneareDataTest.Size = new System.Drawing.Size(269, 23);
            this.btnGeneareDataTest.TabIndex = 4;
            this.btnGeneareDataTest.Text = "Generate Bills, Orders To test";
            this.btnGeneareDataTest.UseVisualStyleBackColor = true;
            this.btnGeneareDataTest.Click += new System.EventHandler(this.btnGeneareDataTest_Click);
            // 
            // frmStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1321, 580);
            this.Controls.Add(this.btnGeneareDataTest);
            this.Controls.Add(this.dateTimePickerRange);
            this.Controls.Add(this.comboBoxPeriod);
            this.Controls.Add(this.plotViewMain);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStatistic";
            this.Text = "frmStatistic";
            this.Load += new System.EventHandler(this.frmStatistic_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private OxyPlot.WindowsForms.PlotView plotViewMain;
        private System.Windows.Forms.ComboBox comboBoxPeriod;
        private System.Windows.Forms.DateTimePicker dateTimePickerRange;
        private System.Windows.Forms.Button btnGeneareDataTest;
    }
}