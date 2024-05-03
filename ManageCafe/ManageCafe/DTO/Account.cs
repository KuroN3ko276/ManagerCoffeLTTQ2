using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ManageCafe.DTO
{
	public class Account
	{
		private string userName;

		private string passWord;

		private string displayName;

		private int type;
		public Account() { }
		public Account(string username, string displayname, int type, string password) 
		{
			this.userName = username;
			this.displayName = displayname;
			this.type = type;
			this.Password = password;
		}

		public Account(DataRow row)
		{
			this.UserName = row["username"].ToString();
			this.displayName = row["displayname"].ToString();
			this.type = (int)row["type"];
			this.passWord = row["password"].ToString();

		}

		public string UserName { get => userName; set => userName = value; }
		public string Password { get => passWord; set => passWord = value; }
		public string DisplayName { get => displayName; set => displayName = value; }
		public int Type { get => type; set => type = value; }
	}
}
