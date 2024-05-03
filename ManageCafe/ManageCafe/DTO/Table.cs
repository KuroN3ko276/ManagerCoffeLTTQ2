using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCafe.DTO
{
	public class Table
	{
		private string status;

		private int id;

		private string name;

		public Table() { }

		public Table(int id, string name, string status) 
		{
			this.id = id;
			this.name = name;
			this.status = status;
		}

		public Table(DataRow row)
		{
			this.id = (int)row["ID"];
			this.name = row["Name"].ToString();
			this.status = row["status"].ToString();
		}

		public int ID { get => id; set => id = value; }
		public string Name { get => name; set => name = value; }
		public string Status { get => status; set => status = value; }
	}
}
