namespace PiStoreManagement.Managements
{
    partial class frmBill
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblProducts = new System.Windows.Forms.Label();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.lblOrderID2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotalPrice2 = new System.Windows.Forms.Label();
            this.lblOrderDate2 = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblStaff2 = new System.Windows.Forms.Label();
            this.lblCustomer2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGridViewBills = new System.Windows.Forms.DataGridView();
            this.dataGridViewOderedProducts = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOderedProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(122, 66);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(311, 22);
            this.txtSearch.TabIndex = 87;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 65;
            this.label1.Text = "Bill Number";
            // 
            // lblStaffName
            // 
            this.lblStaffName.AutoSize = true;
            this.lblStaffName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblStaffName.Location = new System.Drawing.Point(301, 84);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(38, 16);
            this.lblStaffName.TabIndex = 66;
            this.lblStaffName.Text = "Staff";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblCustomerName.Location = new System.Drawing.Point(301, 59);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(72, 16);
            this.lblCustomerName.TabIndex = 69;
            this.lblCustomerName.Text = "Customer";
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblProducts.Location = new System.Drawing.Point(2, 117);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(68, 16);
            this.lblProducts.TabIndex = 70;
            this.lblProducts.Text = "Products";
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.139131F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnClearSearch.Location = new System.Drawing.Point(438, 61);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(75, 31);
            this.btnClearSearch.TabIndex = 90;
            this.btnClearSearch.Text = "Clear";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // lblOrderID2
            // 
            this.lblOrderID2.AutoSize = true;
            this.lblOrderID2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblOrderID2.Location = new System.Drawing.Point(124, 14);
            this.lblOrderID2.Name = "lblOrderID2";
            this.lblOrderID2.Size = new System.Drawing.Size(92, 16);
            this.lblOrderID2.TabIndex = 74;
            this.lblOrderID2.Text = "Order Number";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotalPrice2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblStaffName);
            this.groupBox1.Controls.Add(this.lblOrderDate2);
            this.groupBox1.Controls.Add(this.lblCustomerName);
            this.groupBox1.Controls.Add(this.lblTotalPrice);
            this.groupBox1.Controls.Add(this.lblProducts);
            this.groupBox1.Controls.Add(this.lblOrderDate);
            this.groupBox1.Controls.Add(this.lblOrderID2);
            this.groupBox1.Controls.Add(this.lblStaff2);
            this.groupBox1.Controls.Add(this.lblCustomer2);
            this.groupBox1.Location = new System.Drawing.Point(707, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 139);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            // 
            // lblTotalPrice2
            // 
            this.lblTotalPrice2.AutoSize = true;
            this.lblTotalPrice2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTotalPrice2.Location = new System.Drawing.Point(123, 89);
            this.lblTotalPrice2.Name = "lblTotalPrice2";
            this.lblTotalPrice2.Size = new System.Drawing.Size(72, 16);
            this.lblTotalPrice2.TabIndex = 81;
            this.lblTotalPrice2.Text = "Total Price";
            // 
            // lblOrderDate2
            // 
            this.lblOrderDate2.AutoSize = true;
            this.lblOrderDate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblOrderDate2.Location = new System.Drawing.Point(123, 59);
            this.lblOrderDate2.Name = "lblOrderDate2";
            this.lblOrderDate2.Size = new System.Drawing.Size(73, 16);
            this.lblOrderDate2.TabIndex = 80;
            this.lblOrderDate2.Text = "Order Date";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTotalPrice.Location = new System.Drawing.Point(2, 89);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(43, 16);
            this.lblTotalPrice.TabIndex = 79;
            this.lblTotalPrice.Text = "Total";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblOrderDate.Location = new System.Drawing.Point(2, 59);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(40, 16);
            this.lblOrderDate.TabIndex = 77;
            this.lblOrderDate.Text = "Date";
            // 
            // lblStaff2
            // 
            this.lblStaff2.AutoSize = true;
            this.lblStaff2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblStaff2.Location = new System.Drawing.Point(379, 84);
            this.lblStaff2.Name = "lblStaff2";
            this.lblStaff2.Size = new System.Drawing.Size(33, 16);
            this.lblStaff2.TabIndex = 76;
            this.lblStaff2.Text = "Staff";
            // 
            // lblCustomer2
            // 
            this.lblCustomer2.AutoSize = true;
            this.lblCustomer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblCustomer2.Location = new System.Drawing.Point(379, 59);
            this.lblCustomer2.Name = "lblCustomer2";
            this.lblCustomer2.Size = new System.Drawing.Size(64, 16);
            this.lblCustomer2.TabIndex = 75;
            this.lblCustomer2.Text = "Customer";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.139131F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnSearch.Location = new System.Drawing.Point(519, 61);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 31);
            this.btnSearch.TabIndex = 89;
            this.btnSearch.Text = "Search 🔍";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridViewBills
            // 
            this.dataGridViewBills.AllowUserToAddRows = false;
            this.dataGridViewBills.AllowUserToResizeRows = false;
            this.dataGridViewBills.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewBills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBills.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewBills.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBills.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBills.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewBills.EnableHeadersVisualStyles = false;
            this.dataGridViewBills.GridColor = System.Drawing.Color.Cyan;
            this.dataGridViewBills.Location = new System.Drawing.Point(7, 98);
            this.dataGridViewBills.MultiSelect = false;
            this.dataGridViewBills.Name = "dataGridViewBills";
            this.dataGridViewBills.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBills.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewBills.RowHeadersVisible = false;
            this.dataGridViewBills.RowHeadersWidth = 49;
            this.dataGridViewBills.RowTemplate.Height = 24;
            this.dataGridViewBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBills.Size = new System.Drawing.Size(611, 408);
            this.dataGridViewBills.TabIndex = 86;
            this.dataGridViewBills.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBills_CellClick);
            this.dataGridViewBills.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBills_CellEnter);
            // 
            // dataGridViewOderedProducts
            // 
            this.dataGridViewOderedProducts.AllowUserToAddRows = false;
            this.dataGridViewOderedProducts.AllowUserToDeleteRows = false;
            this.dataGridViewOderedProducts.AllowUserToResizeRows = false;
            this.dataGridViewOderedProducts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewOderedProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOderedProducts.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewOderedProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOderedProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewOderedProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewOderedProducts.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewOderedProducts.EnableHeadersVisualStyles = false;
            this.dataGridViewOderedProducts.GridColor = System.Drawing.Color.Cyan;
            this.dataGridViewOderedProducts.Location = new System.Drawing.Point(698, 173);
            this.dataGridViewOderedProducts.MultiSelect = false;
            this.dataGridViewOderedProducts.Name = "dataGridViewOderedProducts";
            this.dataGridViewOderedProducts.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOderedProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewOderedProducts.RowHeadersVisible = false;
            this.dataGridViewOderedProducts.RowHeadersWidth = 49;
            this.dataGridViewOderedProducts.RowTemplate.Height = 24;
            this.dataGridViewOderedProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOderedProducts.Size = new System.Drawing.Size(590, 333);
            this.dataGridViewOderedProducts.TabIndex = 85;
            // 
            // frmBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1303, 535);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnClearSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dataGridViewBills);
            this.Controls.Add(this.dataGridViewOderedProducts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBill";
            this.Text = "frmBill";
            this.VisibleChanged += new System.EventHandler(this.frmBill_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOderedProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStaffName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Label lblOrderID2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotalPrice2;
        private System.Windows.Forms.Label lblOrderDate2;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblStaff2;
        private System.Windows.Forms.Label lblCustomer2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridViewBills;
        private System.Windows.Forms.DataGridView dataGridViewOderedProducts;
    }
}