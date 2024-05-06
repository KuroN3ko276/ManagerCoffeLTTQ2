using ManageCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ManageCafe.DAO
{
	public class FoodDAO
	{
		private static FoodDAO instance;
        private static readonly HttpClient client = new HttpClient();
		private static readonly String APILink = "http://127.0.0.1:3333/";

        private FoodDAO() { }

		public static FoodDAO Instance
		{
			get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
			private set => FoodDAO.Instance = value;
		}

		public List<Food> GetListFoodByCategoryID(int id)		//Lấy danh sách món ăn từ categoryID
		{
			List<Food> list = new List<Food>();
			String query = $"food/getlistfoodbycategory?idCategory={id}";
			HttpResponseMessage response = client.GetAsync(APILink + query).Result;
			if(response.IsSuccessStatusCode)
			{
				String json = response.Content.ReadAsStringAsync().Result;
				list = JsonConvert.DeserializeObject<List<Food>>(json);
			}
			//string query = "select * from food where idCategory = " + id;
			
			//DataTable data = DataProvider.Instance.ExecuteQuery(query);

			//foreach (DataRow row in data.Rows) 
			//{
			//	Food food = new Food(row);
			//	list.Add(food);
			//}

			return list;

		}
	}
}
