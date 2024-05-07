using ManageCafe.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ManageCafe.DAO
{
	public class BillInfoDAO
	{
		private static BillInfoDAO instance;

		public static BillInfoDAO Instance 
		{
			get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
			private set { BillInfoDAO.instance = value; }
		}

		public BillInfoDAO() { }

		//public List<BillInfo> GetListBillInfo(int id)
		//{
		//	List<BillInfo> listBillInfo = new List<BillInfo>();

		//	DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BillInfo WHERE idBill = " + id);

		//	foreach(DataRow item in data.Rows)
		//	{
		//		BillInfo info = new BillInfo(item);
		//		listBillInfo.Add(info);
		//	}

		//	return listBillInfo;
		//}

		public void InsertBillInfo(int idBill,int idFood, int count)
		{
			HttpClient client = new HttpClient();
			//DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBillInfo @idBill , @idFood , @count ", new object[] {idBill,idFood,count });
			var newBill = new
			{
				idBill = idBill,
				idFood = idFood,
				foodCount = count
			};

			// Chuyển đối tượng food thành chuỗi JSON
			string jsonFood = JsonConvert.SerializeObject(newBill);

			// Tạo đường dẫn API và HttpClient
			string apiUrl = "http://127.0.0.1:3333/billInfo/insert";

			// Tạo nội dung yêu cầu POST với dữ liệu JSON
			var content = new StringContent(jsonFood, Encoding.UTF8, "application/json");

			// Gửi yêu cầu POST đến API
			HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;

			// Đọc nội dung phản hồi từ máy chủ Python
			string responseContent = response.Content.ReadAsStringAsync().Result;
		}
	}
}
