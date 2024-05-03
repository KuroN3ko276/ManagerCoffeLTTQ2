using Newtonsoft.Json;
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

		private int id;

		private string name;

		private float price;

		private int idCategory;

		public Food() { }

		public Food(int id, string name, float price, int idCategory)
		{
			this.id = id;
			this.name = name;
			this.price = price;
			this.idCategory = idCategory;
		}

		public Food(DataRow row) 
		{
			ID = (int)row["ID"];
			Name = row["Name"].ToString();
			idCategory = (int)row["idCategory"];
			Price = (float)Convert.ToDouble(row["price"].ToString());
		}
		[JsonProperty("ID")]
		public int ID { get => id; set => id = value; }
		[JsonProperty("Name")]

		public string Name { get => name; set => name = value; }
		[JsonProperty("price")]

		public float Price { get => price; set => price = value; }
		[JsonProperty("idCategory")]

		public int IdCategory { get => idCategory; set => idCategory = value; }
	}
}
