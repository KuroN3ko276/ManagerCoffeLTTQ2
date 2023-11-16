namespace ManageCafe
{
    partial class fTableManage
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.doanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.thứcĂnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bànĂnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.panel2 = new System.Windows.Forms.Panel();
			this.lsvBill = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel3 = new System.Windows.Forms.Panel();
			this.txbTotalPrice = new System.Windows.Forms.TextBox();
			this.cbSwitchTable = new System.Windows.Forms.ComboBox();
			this.btnSwitchTable = new System.Windows.Forms.Button();
			this.nmDiscount = new System.Windows.Forms.NumericUpDown();
			this.btnDiscount = new System.Windows.Forms.Button();
			this.btnCheckOut = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.nmFoodCount = new System.Windows.Forms.NumericUpDown();
			this.btnAddFood = new System.Windows.Forms.Button();
			this.cbFood = new System.Windows.Forms.ComboBox();
			this.cbCategory = new System.Windows.Forms.ComboBox();
			this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.menuStrip1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).BeginInit();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(952, 30);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// adminToolStripMenuItem
			// 
			this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doanhThuToolStripMenuItem,
            this.thứcĂnToolStripMenuItem,
            this.danhMụcToolStripMenuItem,
            this.bànĂnToolStripMenuItem,
            this.tàiKhoảnToolStripMenuItem});
			this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
			this.adminToolStripMenuItem.Size = new System.Drawing.Size(67, 26);
			this.adminToolStripMenuItem.Text = "Admin";
			this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
			// 
			// doanhThuToolStripMenuItem
			// 
			this.doanhThuToolStripMenuItem.Name = "doanhThuToolStripMenuItem";
			this.doanhThuToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
			this.doanhThuToolStripMenuItem.Text = "Doanh thu";
			this.doanhThuToolStripMenuItem.Click += new System.EventHandler(this.doanhThuToolStripMenuItem_Click);
			// 
			// thứcĂnToolStripMenuItem
			// 
			this.thứcĂnToolStripMenuItem.Name = "thứcĂnToolStripMenuItem";
			this.thứcĂnToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
			this.thứcĂnToolStripMenuItem.Text = "Thức ăn";
			this.thứcĂnToolStripMenuItem.Click += new System.EventHandler(this.thứcĂnToolStripMenuItem_Click);
			// 
			// danhMụcToolStripMenuItem
			// 
			this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
			this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
			this.danhMụcToolStripMenuItem.Text = "Danh mục";
			this.danhMụcToolStripMenuItem.Click += new System.EventHandler(this.danhMụcToolStripMenuItem_Click);
			// 
			// bànĂnToolStripMenuItem
			// 
			this.bànĂnToolStripMenuItem.Name = "bànĂnToolStripMenuItem";
			this.bànĂnToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
			this.bànĂnToolStripMenuItem.Text = "Bàn ăn";
			this.bànĂnToolStripMenuItem.Click += new System.EventHandler(this.bànĂnToolStripMenuItem_Click);
			// 
			// tàiKhoảnToolStripMenuItem
			// 
			this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
			this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
			this.tàiKhoảnToolStripMenuItem.Text = "Tài khoản";
			this.tàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.tàiKhoảnToolStripMenuItem_Click);
			// 
			// thôngTinTàiKhoảnToolStripMenuItem
			// 
			this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
			this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
			this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
			this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
			// 
			// thôngTinCáNhânToolStripMenuItem
			// 
			this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
			this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
			this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
			this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
			// 
			// đăngXuấtToolStripMenuItem
			// 
			this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
			this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
			this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
			this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lsvBill);
			this.panel2.Location = new System.Drawing.Point(452, 124);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(486, 350);
			this.panel2.TabIndex = 3;
			// 
			// lsvBill
			// 
			this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.lsvBill.GridLines = true;
			this.lsvBill.HideSelection = false;
			this.lsvBill.Location = new System.Drawing.Point(3, 6);
			this.lsvBill.Name = "lsvBill";
			this.lsvBill.Size = new System.Drawing.Size(480, 425);
			this.lsvBill.TabIndex = 0;
			this.lsvBill.UseCompatibleStateImageBehavior = false;
			this.lsvBill.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Tên món";
			this.columnHeader1.Width = 126;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Số lượng";
			this.columnHeader2.Width = 76;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Đơn giá";
			this.columnHeader3.Width = 127;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Thành tiền";
			this.columnHeader4.Width = 259;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.txbTotalPrice);
			this.panel3.Controls.Add(this.cbSwitchTable);
			this.panel3.Controls.Add(this.btnSwitchTable);
			this.panel3.Controls.Add(this.nmDiscount);
			this.panel3.Controls.Add(this.btnDiscount);
			this.panel3.Controls.Add(this.btnCheckOut);
			this.panel3.Location = new System.Drawing.Point(452, 480);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(485, 80);
			this.panel3.TabIndex = 4;
			// 
			// txbTotalPrice
			// 
			this.txbTotalPrice.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txbTotalPrice.ForeColor = System.Drawing.Color.Black;
			this.txbTotalPrice.Location = new System.Drawing.Point(257, 29);
			this.txbTotalPrice.Name = "txbTotalPrice";
			this.txbTotalPrice.ReadOnly = true;
			this.txbTotalPrice.Size = new System.Drawing.Size(124, 28);
			this.txbTotalPrice.TabIndex = 7;
			this.txbTotalPrice.Text = "0";
			this.txbTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cbSwitchTable
			// 
			this.cbSwitchTable.FormattingEnabled = true;
			this.cbSwitchTable.Location = new System.Drawing.Point(3, 49);
			this.cbSwitchTable.Name = "cbSwitchTable";
			this.cbSwitchTable.Size = new System.Drawing.Size(125, 27);
			this.cbSwitchTable.TabIndex = 2;
			// 
			// btnSwitchTable
			// 
			this.btnSwitchTable.Location = new System.Drawing.Point(3, 3);
			this.btnSwitchTable.Name = "btnSwitchTable";
			this.btnSwitchTable.Size = new System.Drawing.Size(125, 40);
			this.btnSwitchTable.TabIndex = 6;
			this.btnSwitchTable.Text = "Chuyển bàn";
			this.btnSwitchTable.UseVisualStyleBackColor = true;
			// 
			// nmDiscount
			// 
			this.nmDiscount.Location = new System.Drawing.Point(134, 51);
			this.nmDiscount.Name = "nmDiscount";
			this.nmDiscount.Size = new System.Drawing.Size(117, 27);
			this.nmDiscount.TabIndex = 5;
			this.nmDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btnDiscount
			// 
			this.btnDiscount.Location = new System.Drawing.Point(134, 4);
			this.btnDiscount.Name = "btnDiscount";
			this.btnDiscount.Size = new System.Drawing.Size(117, 40);
			this.btnDiscount.TabIndex = 4;
			this.btnDiscount.Text = "Giảm giá";
			this.btnDiscount.UseVisualStyleBackColor = true;
			// 
			// btnCheckOut
			// 
			this.btnCheckOut.Location = new System.Drawing.Point(386, 3);
			this.btnCheckOut.Name = "btnCheckOut";
			this.btnCheckOut.Size = new System.Drawing.Size(96, 77);
			this.btnCheckOut.TabIndex = 3;
			this.btnCheckOut.Text = "Thanh toán";
			this.btnCheckOut.UseVisualStyleBackColor = true;
			this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.nmFoodCount);
			this.panel4.Controls.Add(this.btnAddFood);
			this.panel4.Controls.Add(this.cbFood);
			this.panel4.Controls.Add(this.cbCategory);
			this.panel4.Location = new System.Drawing.Point(452, 42);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(482, 82);
			this.panel4.TabIndex = 5;
			// 
			// nmFoodCount
			// 
			this.nmFoodCount.Location = new System.Drawing.Point(392, 30);
			this.nmFoodCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.nmFoodCount.Name = "nmFoodCount";
			this.nmFoodCount.Size = new System.Drawing.Size(54, 27);
			this.nmFoodCount.TabIndex = 3;
			this.nmFoodCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.nmFoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// btnAddFood
			// 
			this.btnAddFood.Location = new System.Drawing.Point(273, 3);
			this.btnAddFood.Name = "btnAddFood";
			this.btnAddFood.Size = new System.Drawing.Size(96, 76);
			this.btnAddFood.TabIndex = 2;
			this.btnAddFood.Text = "Thêm món";
			this.btnAddFood.UseVisualStyleBackColor = true;
			this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
			// 
			// cbFood
			// 
			this.cbFood.FormattingEnabled = true;
			this.cbFood.Location = new System.Drawing.Point(3, 49);
			this.cbFood.Name = "cbFood";
			this.cbFood.Size = new System.Drawing.Size(232, 27);
			this.cbFood.TabIndex = 1;
			// 
			// cbCategory
			// 
			this.cbCategory.FormattingEnabled = true;
			this.cbCategory.Location = new System.Drawing.Point(3, 3);
			this.cbCategory.Name = "cbCategory";
			this.cbCategory.Size = new System.Drawing.Size(232, 27);
			this.cbCategory.TabIndex = 0;
			this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
			// 
			// flpTable
			// 
			this.flpTable.AutoScroll = true;
			this.flpTable.Location = new System.Drawing.Point(12, 45);
			this.flpTable.Name = "flpTable";
			this.flpTable.Size = new System.Drawing.Size(434, 515);
			this.flpTable.TabIndex = 6;
			// 
			// fTableManage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(952, 572);
			this.Controls.Add(this.flpTable);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "fTableManage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Phần mềm quản lý quán cafe";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).EndInit();
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.NumericUpDown nmFoodCount;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.NumericUpDown nmDiscount;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnSwitchTable;
        private System.Windows.Forms.ComboBox cbSwitchTable;
        private System.Windows.Forms.ToolStripMenuItem doanhThuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thứcĂnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bànĂnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.TextBox txbTotalPrice;
	}
}