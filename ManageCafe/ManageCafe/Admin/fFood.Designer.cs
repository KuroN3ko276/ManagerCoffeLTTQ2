namespace ManageCafe.Admin
{
    partial class fFood
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
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel10 = new System.Windows.Forms.Panel();
			this.nmFoodPrice = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.panel9 = new System.Windows.Forms.Panel();
			this.cbFoodCategory = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.txtFoodName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.txtFoodID = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.btnShowFood = new System.Windows.Forms.Button();
			this.btnEditFood = new System.Windows.Forms.Button();
			this.btnDeleteFood = new System.Windows.Forms.Button();
			this.btnAddFood = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dtgvFood = new System.Windows.Forms.DataGridView();
			this.panel5.SuspendLayout();
			this.panel10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmFoodPrice)).BeginInit();
			this.panel9.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtgvFood)).BeginInit();
			this.SuspendLayout();
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.panel10);
			this.panel5.Controls.Add(this.panel9);
			this.panel5.Controls.Add(this.panel8);
			this.panel5.Controls.Add(this.panel7);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel5.Location = new System.Drawing.Point(466, 65);
			this.panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(434, 469);
			this.panel5.TabIndex = 5;
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.nmFoodPrice);
			this.panel10.Controls.Add(this.label4);
			this.panel10.Location = new System.Drawing.Point(3, 245);
			this.panel10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(432, 69);
			this.panel10.TabIndex = 5;
			// 
			// nmFoodPrice
			// 
			this.nmFoodPrice.Location = new System.Drawing.Point(107, 23);
			this.nmFoodPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.nmFoodPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.nmFoodPrice.Name = "nmFoodPrice";
			this.nmFoodPrice.Size = new System.Drawing.Size(271, 23);
			this.nmFoodPrice.TabIndex = 1;
			this.nmFoodPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(3, 21);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 19);
			this.label4.TabIndex = 0;
			this.label4.Text = "Giá:";
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.cbFoodCategory);
			this.panel9.Controls.Add(this.label3);
			this.panel9.Location = new System.Drawing.Point(3, 169);
			this.panel9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(428, 69);
			this.panel9.TabIndex = 4;
			// 
			// cbFoodCategory
			// 
			this.cbFoodCategory.FormattingEnabled = true;
			this.cbFoodCategory.Location = new System.Drawing.Point(110, 17);
			this.cbFoodCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cbFoodCategory.Name = "cbFoodCategory";
			this.cbFoodCategory.Size = new System.Drawing.Size(271, 24);
			this.cbFoodCategory.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(3, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(81, 19);
			this.label3.TabIndex = 0;
			this.label3.Text = "Danh mục:";
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.txtFoodName);
			this.panel8.Controls.Add(this.label1);
			this.panel8.Location = new System.Drawing.Point(3, 93);
			this.panel8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(428, 69);
			this.panel8.TabIndex = 3;
			// 
			// txtFoodName
			// 
			this.txtFoodName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtFoodName.Location = new System.Drawing.Point(110, 13);
			this.txtFoodName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtFoodName.Name = "txtFoodName";
			this.txtFoodName.Size = new System.Drawing.Size(271, 26);
			this.txtFoodName.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tên món:";
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.txtFoodID);
			this.panel7.Controls.Add(this.label2);
			this.panel7.Location = new System.Drawing.Point(3, 17);
			this.panel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(428, 69);
			this.panel7.TabIndex = 2;
			// 
			// txtFoodID
			// 
			this.txtFoodID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtFoodID.Location = new System.Drawing.Point(110, 13);
			this.txtFoodID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtFoodID.Name = "txtFoodID";
			this.txtFoodID.ReadOnly = true;
			this.txtFoodID.Size = new System.Drawing.Size(271, 26);
			this.txtFoodID.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(3, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 19);
			this.label2.TabIndex = 0;
			this.label2.Text = "ID:";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.btnShowFood);
			this.panel4.Controls.Add(this.btnEditFood);
			this.panel4.Controls.Add(this.btnDeleteFood);
			this.panel4.Controls.Add(this.btnAddFood);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(900, 65);
			this.panel4.TabIndex = 4;
			// 
			// btnShowFood
			// 
			this.btnShowFood.Location = new System.Drawing.Point(336, 4);
			this.btnShowFood.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnShowFood.Name = "btnShowFood";
			this.btnShowFood.Size = new System.Drawing.Size(102, 57);
			this.btnShowFood.TabIndex = 3;
			this.btnShowFood.Text = "Xem";
			this.btnShowFood.UseVisualStyleBackColor = true;
			this.btnShowFood.Click += new System.EventHandler(this.btnShowFood_Click);
			// 
			// btnEditFood
			// 
			this.btnEditFood.Location = new System.Drawing.Point(228, 4);
			this.btnEditFood.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnEditFood.Name = "btnEditFood";
			this.btnEditFood.Size = new System.Drawing.Size(102, 57);
			this.btnEditFood.TabIndex = 2;
			this.btnEditFood.Text = "Sửa";
			this.btnEditFood.UseVisualStyleBackColor = true;
			// 
			// btnDeleteFood
			// 
			this.btnDeleteFood.Location = new System.Drawing.Point(120, 4);
			this.btnDeleteFood.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnDeleteFood.Name = "btnDeleteFood";
			this.btnDeleteFood.Size = new System.Drawing.Size(102, 57);
			this.btnDeleteFood.TabIndex = 1;
			this.btnDeleteFood.Text = "Xoá";
			this.btnDeleteFood.UseVisualStyleBackColor = true;
			// 
			// btnAddFood
			// 
			this.btnAddFood.Location = new System.Drawing.Point(12, 4);
			this.btnAddFood.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnAddFood.Name = "btnAddFood";
			this.btnAddFood.Size = new System.Drawing.Size(102, 57);
			this.btnAddFood.TabIndex = 0;
			this.btnAddFood.Text = "Thêm";
			this.btnAddFood.UseVisualStyleBackColor = true;
			this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dtgvFood);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 65);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(466, 469);
			this.panel1.TabIndex = 6;
			// 
			// dtgvFood
			// 
			this.dtgvFood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgvFood.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dtgvFood.Location = new System.Drawing.Point(0, 0);
			this.dtgvFood.Name = "dtgvFood";
			this.dtgvFood.RowHeadersWidth = 51;
			this.dtgvFood.RowTemplate.Height = 24;
			this.dtgvFood.Size = new System.Drawing.Size(466, 469);
			this.dtgvFood.TabIndex = 0;
			// 
			// fFood
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(900, 534);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel4);
			this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "fFood";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "fFood";
			this.panel5.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmFoodPrice)).EndInit();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dtgvFood)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.NumericUpDown nmFoodPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.ComboBox cbFoodCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtFoodName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtFoodID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnShowFood;
        private System.Windows.Forms.Button btnEditFood;
        private System.Windows.Forms.Button btnDeleteFood;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgvFood;
    }
}