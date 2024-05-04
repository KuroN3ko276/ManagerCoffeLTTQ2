using ManageCafe.DAO;
using ManageCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageCafe
{
    public partial class fAccountProfile : Form
    {
		private Account loginAccount;

		public Account LoginAccount
		{
			get { return loginAccount; }
			set { loginAccount = value; ChangeAccount(loginAccount); }
		}
		public fAccountProfile(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }

        void ChangeAccount(Account acc)
        {
            txbUserName.Text = LoginAccount.UserName;
            txtDisplayName.Text = LoginAccount.DisplayName;
        }
        void UpdateAccountInfo()
        {
            string displayName = txtDisplayName.Text;
            string userName = txbUserName.Text;
            string password = txtPassword.Text;
            string newpass = txtNewPassword.Text;
            string repass =txtReEnterPassword.Text;
			if(txbUserName.Text =="" || txtDisplayName.Text==""||txtNewPassword.Text==""||txtPassword.Text==""||txtReEnterPassword.Text=="")
			{
				MessageBox.Show("Bạn chưa nhập đủ thông tin");
				return;
			}
			else if(newpass.Length<8)
			{
				MessageBox.Show("Mật khẩu yếu");
				txtNewPassword.Focus();
			}
            else if(!newpass.Equals(repass)) 
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng mật khẩu mới");
				txtReEnterPassword.Focus();
            }
            else
            {
				if (AccountDAO.Instance.UpdateAccount(userName, displayName, password, newpass))
				{
					MessageBox.Show("Cập nhật thành công");
					if (updateAccount != null)
						updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUsername(userName)));
				}
				else
				{
					MessageBox.Show("Vui lòng điền đúng mật khấu");
				}
			}
        }

		private event EventHandler<AccountEvent> updateAccount;
		public event EventHandler<AccountEvent> UpdateAccount
		{
			add { updateAccount += value; }
			remove { updateAccount -= value; }
		}

		private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			UpdateAccountInfo();
		}

		public class AccountEvent : EventArgs
		{
			private Account acc;

			public Account Acc
			{
				get { return acc; }
				set { acc = value; }
			}

			public AccountEvent(Account acc)
			{
				this.Acc = acc;
			}
		}

		
	}
}
