using ManageCafe.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ManageCafe.DAO
{
	internal class AccountDAO
	{
		private static AccountDAO instance;
		private static readonly String APILink = "http://127.0.0.1:3333/";
		private static readonly HttpClient client = new HttpClient();

		public static AccountDAO Instance
		{
			get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
			private set { AccountDAO.instance = value; }
		}

		private AccountDAO() { }

		public bool Login(string username, string password)
		{
			Account account = new Account();
			var newAccount = new
			{
				UserName = username,
				PassWord = password
			};

			string jsonLogin = JsonConvert.SerializeObject(newAccount);

			string apiUrl = "http://127.0.0.1:3333/account/login";
			HttpClient client = new HttpClient();
			var content = new StringContent(jsonLogin, Encoding.UTF8, "application/json");
			HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;
			if (response.IsSuccessStatusCode)
			{
				string responseContent = response.Content.ReadAsStringAsync().Result;
				account = JsonConvert.DeserializeObject<Account>(responseContent);
			}
			return account.UserName != null;
		}
		public Account GetAccountByUsername(string username)
		{
			Account account = new Account();
			var newAccount = new
			{
				UserName = username,
			};

			string jsonLogin = JsonConvert.SerializeObject(newAccount);

			string apiUrl = "http://127.0.0.1:3333/account/getaccountbyusername";
			HttpClient client = new HttpClient();
			var content = new StringContent(jsonLogin, Encoding.UTF8, "application/json");
			HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;
			if (response.IsSuccessStatusCode)
			{
				string responseContent = response.Content.ReadAsStringAsync().Result;
				account = JsonConvert.DeserializeObject<Account>(responseContent);
				return account;
			}
			return null;
		}

		public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
		{
			Account account = new Account();
			var newAccount = new
			{
				UserName = userName,
				DisplayName = displayName,
				PassWord = pass,
				NewPassword = newPass
			};

			string jsonLogin = JsonConvert.SerializeObject(newAccount);

			string apiUrl = "http://127.0.0.1:3333/account/updateaccount";
			HttpClient client = new HttpClient();
			var content = new StringContent(jsonLogin, Encoding.UTF8, "application/json");
			HttpResponseMessage response = client.PutAsync(apiUrl, content).Result;
			if (response.IsSuccessStatusCode)
			{
				string responseContent = response.Content.ReadAsStringAsync().Result;
				account = JsonConvert.DeserializeObject<Account>(responseContent);
			}
			return response.IsSuccessStatusCode;
		
		}
	}
}
