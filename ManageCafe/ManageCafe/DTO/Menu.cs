using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCafe.DTO
{
	public class Menu
	{
		public Menu(string foodName, int count , float price, float totalPrice =0) 
		{
			this.foodName = foodName;
			this.count = count;
			this.price = price;
			this.Totalprice = totalPrice;
		}

		public Menu(DataRow row)
		{
			this.foodName = row["Name"].ToString();
			this.count = (int)row["count"];
			this.price = (float)Convert.ToDouble(row["price"].ToString());
			this.Totalprice = (float)Convert.ToDouble(row["totalprice"].ToString());
		}

		private float TotalPrice;

		private float price;

		private int count;

		private string foodName;

		public string FoodName { get => foodName; set => foodName = value; }
		public int Count { get => count; set => count = value; }
		public float Price { get => price; set => price = value; }
		public float Totalprice { get => TotalPrice; set => TotalPrice = value; }
	}
}
