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
	public class CategoryDAO
	{
		private static CategoryDAO instance;
        private static readonly string getAllCategory = "http://127.0.0.1:3333/category/getlistcategory";
        private static readonly HttpClient client = new HttpClient();

        private CategoryDAO() { }

		public static CategoryDAO Instance
		{
			get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
			private set => CategoryDAO.Instance = value;
		}

		public List<Category> GetListCategory()
		{
			List<Category> list = new List<Category>();
            HttpResponseMessage response =  client.GetAsync(getAllCategory).Result;

            if (response.IsSuccessStatusCode)
            {
                var content =  response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<Category>>(content);
               
            }

            //string query = "SELECT * FROM dbo.FoodCategory";

            //DataTable data = DataProvider.Instance.ExecuteQuery(query);

            //foreach (DataRow item in data.Rows)
            //{
            //	Category category = new Category(item);
            //	list.Add(category);
            //}

            return list;
		}
	}
}
