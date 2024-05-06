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
			this.name = foodName;
			this.count = count;
			this.price = price;
			this.Totalprice = totalPrice;
		}

		public Menu(DataRow row)
		{
			this.name = row["Name"].ToString();
			this.count = (int)row["count"];
			this.price = (float)Convert.ToDouble(row["price"].ToString());
			this.Totalprice = (float)Convert.ToDouble(row["totalprice"].ToString());
		}

		private float totalPrice;

		private float price;

		private int count;

		private string name;
		public Menu() { }

		public string Name { get; set; }
		public int Count { get; set; }
		public float Price { get; set; }
		public float Totalprice { get; set; }
	}
}
