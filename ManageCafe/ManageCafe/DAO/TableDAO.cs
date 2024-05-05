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
			DataProvider.Instance.ExecuteQuery("exec USP_SwitchTabel @idTable1 , @idTable2", new object[] { id1, id2 });
		}

	}
}
