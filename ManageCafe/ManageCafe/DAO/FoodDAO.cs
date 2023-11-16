using ManageCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ManageCafe.DAO
{
	public class FoodDAO
	{
		private static FoodDAO instance;


		private FoodDAO() { }

		public static FoodDAO Instance
		{
			get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
			private set => FoodDAO.Instance = value;
		}

		public List<Food> GetListFoodByBategoryID(int id)		//Lấy danh sách món ăn từ categoryID
		{
			List<Food> list = new List<Food>();

			string query = "select * from food where idCategory = " + id;
			
			DataTable data = DataProvider.Instance.ExecuteQuery(query);

			foreach (DataRow row in data.Rows) 
			{
				Food food = new Food(row);
				list.Add(food);
			}

			return list;

		}
	}
}
