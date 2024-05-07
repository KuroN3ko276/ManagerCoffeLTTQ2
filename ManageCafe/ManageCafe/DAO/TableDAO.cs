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
	public class TableDAO
	{   
		private static TableDAO instance;

		public static TableDAO Instance 
		{
			get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; } 
			private set { TableDAO.instance = value; }
		}

		public static int TableWidth = 120;

		public static int TableHeight = 120;
        private static readonly HttpClient client = new HttpClient();
        private static readonly string getAllTable = "http://127.0.0.1:3333/table/gettablelist";
        private TableDAO() { }
        

        public List<Table> LoadTableList()
		{      
            HttpResponseMessage response =  client.GetAsync(getAllTable).Result;
            List<Table> Tablelist = new List<Table>();
               if (response.IsSuccessStatusCode)
                {
                    var content =  response.Content.ReadAsStringAsync().Result;
                    Tablelist = JsonConvert.DeserializeObject<List<Table>>(content);
                    
                }
            //List<Table> tableList = new List<Table>();

            //DataTable data =DataProvider.Instance.ExecuteQuery("exec dbo.USP_GetTableList");

            //foreach (DataRow row in data.Rows)
            //{
            //	Table table = new Table(row);
            //	tableList.Add(table);
            //}

            return Tablelist;

        }

		public void SwitchTable(int id1, int id2)
		{
			//DataProvider.Instance.ExecuteQuery("exec USP_SwitchTabel @idTable1 , @idTable2", new object[] { id1, id2 });
			HttpClient client = new HttpClient();
			//DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBillInfo @idBill , @idFood , @count ", new object[] {idBill,idFood,count });
			var switchTable = new
			{
				idTable1 = id1,
				idTable2 = id2
			};

			// Chuyển đối tượng food thành chuỗi JSON
			string jsonFood = JsonConvert.SerializeObject(switchTable);

			// Tạo đường dẫn API và HttpClient
			string apiUrl = "http://127.0.0.1:3333/table/switchtable";

			// Tạo nội dung yêu cầu POST với dữ liệu JSON
			var content = new StringContent(jsonFood, Encoding.UTF8, "application/json");

			// Gửi yêu cầu POST đến API
			HttpResponseMessage response = client.PutAsync(apiUrl, content).Result;

			// Đọc nội dung phản hồi từ máy chủ Python
			string responseContent = response.Content.ReadAsStringAsync().Result;
		}

	}
}
