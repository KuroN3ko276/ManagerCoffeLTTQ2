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

		private string password;

		private string displayName;

		private int type;

		public Account(string username, string displayname, int type,string password = null) 
		{
			this.userName = username;
			this.displayName = displayname;
			this.type = type;
			this.password = password;
		}

		public Account(DataRow row)
		{
			this.userName = row["username"].ToString();
			this.displayName = row["displayname"].ToString();
			this.type = (int)row["type"];
			this.password = row["password"].ToString();

		}

		public string UserName { get => userName; set => userName = value; }
		public string Password { get => password; set => password = value; }
		public string DisplayName { get => displayName; set => displayName = value; }
		public int Type { get => type; set => type = value; }
	}
}
