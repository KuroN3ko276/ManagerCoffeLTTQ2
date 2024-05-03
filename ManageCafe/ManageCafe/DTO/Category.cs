using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCafe.DAO
{
	
	public class Category
	{
		private string name;
		private int id;
		public Category() { }
		public Category(int id, string _name) 
		{
			this.id = id;
			this.name = _name;
		}	

		public Category(DataRow row) 
		{
			this.id = (int)row["ID"];
			this.name = row["Name"].ToString();
		}

		public int ID { get => id; set => id = value; }
		public string Name { get => name; set => name = value; }
	}
}
