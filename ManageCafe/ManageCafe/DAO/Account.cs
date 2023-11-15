using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCafe.DAO
{
	internal class Account
	{
		private static Account instance;

		public static Account Instance
		{
			get { if (instance == null) instance = new Account(); return instance; }
			private set { instance = value; }
		}

		private Account()
		{
			
		}

		public bool Login(string username, string password)
		{
			string query = "select * from dbo.Account where Username='Chinh' and Password='1' ";
			DataTable result = DataProvider.Instance.ExecuteQuery(query);
			return result.Rows.Count > 0; ;
		}
	}
}
