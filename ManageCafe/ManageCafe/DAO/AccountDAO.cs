using ManageCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCafe.DAO
{
	internal class AccountDAO
	{
		private static AccountDAO instance;

		public static AccountDAO Instance
		{
			get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
			private set { AccountDAO.instance = value; }
		}

		private AccountDAO() { }

		public bool Login(string username, string password)
		{
			string query = "USP_Login @username , @password ";
			DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[]{ username,password});
			return result.Rows.Count > 0; ;
		}

		public Account GetAccountByUsername(string username)
		{
			DataTable data = DataProvider.Instance.ExecuteQuery("select * from Account where username = '"+username+"'");
			foreach(DataRow row in data.Rows)
			{
				return new Account(row);
			}
			return null;
		}

		public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[] { userName, displayName, pass, newPass });

			return result > 0;
		}
	}
}
