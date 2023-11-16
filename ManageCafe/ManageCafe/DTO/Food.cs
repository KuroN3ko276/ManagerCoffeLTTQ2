using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCafe.DTO
{
	public class Food
	{

		private int iD;

		private string name;

		private float price;

		private int idCategory;

		public Food(int iD, string name, float price, int idCategory)
		{
			ID = iD;
			Name = name;
			Price = price;
			IdCategory = idCategory;
			ID = iD;
			Name = name;
			Price = price;
			IdCategory = idCategory;
		}

		public Food(DataRow row) 
		{
			ID = (int)row["ID"];
			Name = row["Name"].ToString();
			idCategory = (int)row["idCategory"];
			Price = (float)Convert.ToDouble(row["price"].ToString());
		}

		public int ID { get => iD; set => iD = value; }
		public string Name { get => name; set => name = value; }
		public float Price { get => price; set => price = value; }
		public int IdCategory { get => idCategory; set => idCategory = value; }
	}
}
