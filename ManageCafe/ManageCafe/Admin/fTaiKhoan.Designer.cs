namespace ManageCafe.Admin
{
    partial class fTaiKhoan
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
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.btnDeleteAccout = new System.Windows.Forms.Button();
            this.btnEditAccount = new System.Windows.Forms.Button();
            this.btnShowAccount = new System.Windows.Forms.Button();
            this.panel25 = new System.Windows.Forms.Panel();
            this.panel24 = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel23 = new System.Windows.Forms.Panel();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.cbAccountType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgvAccount = new System.Windows.Forms.DataGridView();
            this.panel25.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(12, 3);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(91, 56);
            this.btnAddAccount.TabIndex = 0;
            this.btnAddAccount.Text = "Thêm";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAccout
            // 
            this.btnDeleteAccout.Location = new System.Drawing.Point(109, 3);
            this.btnDeleteAccout.Name = "btnDeleteAccout";
            this.btnDeleteAccout.Size = new System.Drawing.Size(91, 56);
            this.btnDeleteAccout.TabIndex = 1;
            this.btnDeleteAccout.Text = "Xoá";
            this.btnDeleteAccout.UseVisualStyleBackColor = true;
            // 
            // btnEditAccount
            // 
            this.btnEditAccount.Location = new System.Drawing.Point(206, 3);
            this.btnEditAccount.Name = "btnEditAccount";
            this.btnEditAccount.Size = new System.Drawing.Size(91, 56);
            this.btnEditAccount.TabIndex = 2;
            this.btnEditAccount.Text = "Sửa";
            this.btnEditAccount.UseVisualStyleBackColor = true;
            // 
            // btnShowAccount
            // 
            this.btnShowAccount.Location = new System.Drawing.Point(303, 3);
            this.btnShowAccount.Name = "btnShowAccount";
            this.btnShowAccount.Size = new System.Drawing.Size(91, 56);
            this.btnShowAccount.TabIndex = 3;
            this.btnShowAccount.Text = "Xem";
            this.btnShowAccount.UseVisualStyleBackColor = true;
            // 
            // panel25
            // 
            this.panel25.Controls.Add(this.btnShowAccount);
            this.panel25.Controls.Add(this.btnEditAccount);
            this.panel25.Controls.Add(this.btnDeleteAccout);
            this.panel25.Controls.Add(this.btnAddAccount);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel25.Location = new System.Drawing.Point(0, 0);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(847, 62);
            this.panel25.TabIndex = 7;
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.txtUsername);
            this.panel24.Controls.Add(this.label13);
            this.panel24.Location = new System.Drawing.Point(12, 6);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(380, 58);
            this.panel24.TabIndex = 2;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(141, 11);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(236, 30);
            this.txtUsername.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(132, 23);
            this.label13.TabIndex = 0;
            this.label13.Text = "Tên tài khoản:";
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.txtDisplayName);
            this.panel23.Controls.Add(this.label12);
            this.panel23.Location = new System.Drawing.Point(12, 70);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(380, 58);
            this.panel23.TabIndex = 3;
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisplayName.Location = new System.Drawing.Point(141, 11);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(236, 30);
            this.txtDisplayName.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 23);
            this.label12.TabIndex = 0;
            this.label12.Text = "Tên hiển thị:";
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.cbAccountType);
            this.panel22.Controls.Add(this.label11);
            this.panel22.Location = new System.Drawing.Point(12, 134);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(380, 58);
            this.panel22.TabIndex = 4;
            // 
            // cbAccountType
            // 
            this.cbAccountType.FormattingEnabled = true;
            this.cbAccountType.Location = new System.Drawing.Point(141, 14);
            this.cbAccountType.Name = "cbAccountType";
            this.cbAccountType.Size = new System.Drawing.Size(236, 27);
            this.cbAccountType.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 23);
            this.label11.TabIndex = 0;
            this.label11.Text = "Loại tài khoản:";
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(301, 214);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(91, 56);
            this.btnResetPassword.TabIndex = 5;
            this.btnResetPassword.Text = "Đặt lại mật khẩu";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnResetPassword);
            this.panel1.Controls.Add(this.panel24);
            this.panel1.Controls.Add(this.panel22);
            this.panel1.Controls.Add(this.panel23);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(443, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(404, 472);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgvAccount);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(443, 472);
            this.panel2.TabIndex = 10;
            // 
            // dtgvAccount
            // 
            this.dtgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvAccount.Location = new System.Drawing.Point(0, 0);
            this.dtgvAccount.Name = "dtgvAccount";
            this.dtgvAccount.RowHeadersWidth = 51;
            this.dtgvAccount.RowTemplate.Height = 24;
            this.dtgvAccount.Size = new System.Drawing.Size(443, 472);
            this.dtgvAccount.TabIndex = 0;
            // 
            // fTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 534);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel25);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "fTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fTaiKhoan";
            this.panel25.ResumeLayout(false);
            this.panel24.ResumeLayout(false);
            this.panel24.PerformLayout();
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Button btnDeleteAccout;
        private System.Windows.Forms.Button btnEditAccount;
        private System.Windows.Forms.Button btnShowAccount;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.ComboBox cbAccountType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgvAccount;
    }
}