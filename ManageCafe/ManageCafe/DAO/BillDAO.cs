using ManageCafe.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ManageCafe.DAO
{
	public class BillDAO
	{
		private static BillDAO instance;

		public static BillDAO Instance 
		{	
			get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
			private set { BillDAO.instance = value; } 
		}

		private BillDAO() { }

		public int GetBillIDByTableID(int id)
		{
			Bill bill = new Bill();
			var newBill = new
			{
				idTable = id
			};

			string jsonLogin = JsonConvert.SerializeObject(newBill);

			string apiUrl = "http://127.0.0.1:3333/bill/getnumbillbytableid";
			HttpClient client = new HttpClient();
			var content = new StringContent(jsonLogin, Encoding.UTF8, "application/json");
			HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;
			if (response.IsSuccessStatusCode)
			{
				string responseContent = response.Content.ReadAsStringAsync().Result;
				if (responseContent == "[]\n")
				{
					return -1;
				}
				else
				{
					bill = JsonConvert.DeserializeObject<Bill>(responseContent);
				}
			}
			return bill.ID;
			//DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE idTable = " + id + " AND status = 0");
			//if(data.Rows.Count > 0) 
			//{
			//	Bill bill = new Bill(data.Rows[0]);
			//	return bill.ID;
			//}
			//return -1;
		}

		public void InsertBill(int idTable)		//thêm bill theo idTable
		{
			Bill bill = new Bill();
			var newTable = new
			{
				idTable = idTable
			};

			string jsonLogin = JsonConvert.SerializeObject(newTable);

			string apiUrl = "http://127.0.0.1:3333/bill/insert";
			HttpClient client = new HttpClient();
			var content = new StringContent(jsonLogin, Encoding.UTF8, "application/json");
			HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;
			if (response.IsSuccessStatusCode)
			{
				string responseContent = response.Content.ReadAsStringAsync().Result;
			}
		}

		public int GetMaxIDBill()
		{
			try
			{
				string query = "http://127.0.0.1:3333/bill/getmaxbillid";
				HttpClient client = new HttpClient();
				HttpResponseMessage response = client.GetAsync(query).Result;

				if (response.IsSuccessStatusCode)
				{
					var content = response.Content.ReadAsStringAsync().Result;
					var maxBillID = JsonConvert.DeserializeObject<int>(content);
					return maxBillID;
				}
				return 1;
			}
			catch
			{
				return 1;
			}
			
		}

		public void CheckOut(int id, int discount, float totalPrice)
		{
			//string query = "Update dbo.Bill Set status = 1,DateCheckOut = GETDATE(), discount = "+discount+",totalPrice ="+totalPrice+" where id =  "+id;
			//DataProvider.Instance.ExecuteNonQuery(query);
			var checkOut = new
			{
				discount = discount, 
				totalPrice = totalPrice, 
				id = id
			};
			string jsonLogin = JsonConvert.SerializeObject(checkOut);
			string apiUrl = "http://127.0.0.1:3333/bill/checkout";
			HttpClient client = new HttpClient();
			var content = new StringContent(jsonLogin, Encoding.UTF8, "application/json");
			HttpResponseMessage response = client.PutAsync(apiUrl, content).Result;
			//if (response.IsSuccessStatusCode)
			//{
			//	string responseContent = response.Content.ReadAsStringAsync().Result;
			//}
		}

		
	}
}
