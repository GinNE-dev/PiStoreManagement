namespace PiStoreManagement.Managements
{
    partial class frmOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.lblProducts = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewOderedProducts = new System.Windows.Forms.DataGridView();
            this.lblOrderID2 = new System.Windows.Forms.Label();
            this.lblCustomer2 = new System.Windows.Forms.Label();
            this.lblStaff2 = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblOrderDate2 = new System.Windows.Forms.Label();
            this.lblTotalPrice2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOderedProducts)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.AllowUserToAddRows = false;
            this.dataGridViewOrders.AllowUserToResizeRows = false;
            this.dataGridViewOrders.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOrders.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewOrders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewOrders.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewOrders.EnableHeadersVisualStyles = false;
            this.dataGridViewOrders.GridColor = System.Drawing.Color.Cyan;
            this.dataGridViewOrders.Location = new System.Drawing.Point(20, 117);
            this.dataGridViewOrders.MultiSelect = false;
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.ReadOnly = true;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOrders.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewOrders.RowHeadersVisible = false;
            this.dataGridViewOrders.RowHeadersWidth = 49;
            this.dataGridViewOrders.RowTemplate.Height = 24;
            this.dataGridViewOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrders.Size = new System.Drawing.Size(611, 408);
            this.dataGridViewOrders.TabIndex = 71;
            this.dataGridViewOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrders_CellClick);
            this.dataGridViewOrders.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrders_CellEnter);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 65;
            this.label1.Text = "Order Number";
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
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOderedProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewOderedProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewOderedProducts.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewOderedProducts.EnableHeadersVisualStyles = false;
            this.dataGridViewOderedProducts.GridColor = System.Drawing.Color.Cyan;
            this.dataGridViewOderedProducts.Location = new System.Drawing.Point(711, 192);
            this.dataGridViewOderedProducts.MultiSelect = false;
            this.dataGridViewOderedProducts.Name = "dataGridViewOderedProducts";
            this.dataGridViewOderedProducts.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOderedProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridViewOderedProducts.RowHeadersVisible = false;
            this.dataGridViewOderedProducts.RowHeadersWidth = 49;
            this.dataGridViewOderedProducts.RowTemplate.Height = 24;
            this.dataGridViewOderedProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOderedProducts.Size = new System.Drawing.Size(590, 333);
            this.dataGridViewOderedProducts.TabIndex = 63;
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
            this.groupBox1.Location = new System.Drawing.Point(720, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 139);
            this.groupBox1.TabIndex = 83;
            this.groupBox1.TabStop = false;
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.139131F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnClearSearch.Location = new System.Drawing.Point(451, 53);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(75, 31);
            this.btnClearSearch.TabIndex = 84;
            this.btnClearSearch.Text = "Clear";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.139131F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnSearch.Location = new System.Drawing.Point(532, 53);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 31);
            this.btnSearch.TabIndex = 83;
            this.btnSearch.Text = "Search 🔍";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(135, 58);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(311, 22);
            this.txtSearch.TabIndex = 82;
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1321, 580);
            this.Controls.Add(this.btnClearSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dataGridViewOrders);
            this.Controls.Add(this.dataGridViewOderedProducts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOrder";
            this.Text = "frmOrder";
            this.VisibleChanged += new System.EventHandler(this.frmOrder_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOderedProducts)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblStaffName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewOderedProducts;
        private System.Windows.Forms.Label lblOrderID2;
        private System.Windows.Forms.Label lblCustomer2;
        private System.Windows.Forms.Label lblStaff2;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblOrderDate2;
        private System.Windows.Forms.Label lblTotalPrice2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}