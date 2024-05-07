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
	public class MenuDAO	//Hien thi danh sach hoa don
	{
		private static MenuDAO instance;
        private static readonly String APILink = "http://127.0.0.1:3333/";
        private static readonly HttpClient client = new HttpClient();

        public static MenuDAO Instance
		{
			get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
			private set { MenuDAO.instance = value; }
		}
		public MenuDAO() { }

		public List<Menu> GetListMenuByTable(int idTable) //Lay hoa don tu ID Ban
		{
			List<Menu> listMenu = new List<Menu>();
            String query = $"menu/getlistmenubytable?idTable={idTable}";
            HttpResponseMessage response = client.GetAsync(APILink + query).Result;
            if (response.IsSuccessStatusCode)
            {
                String json = response.Content.ReadAsStringAsync().Result;
                listMenu = JsonConvert.DeserializeObject<List<Menu>>(json);
            }
            //string query = "SELECT f.name, bi.count, f.price, f.price* bi.count AS totalPrice FROM dbo.BillInfo AS bi, dbo.Bill AS b, dbo.Food AS f WHERE bi.idBill = b.id AND bi.idFood = f.id AND b.status=0 AND b.idTable = " + tableID;

            //DataTable data = DataProvider.Instance.ExecuteQuery(query);

            //foreach (DataRow item in data.Rows)
            //{
            //	Menu menu = new Menu(item);
            //	listMenu.Add(menu);

            //}

			
			return listMenu;

		}
	}
}
