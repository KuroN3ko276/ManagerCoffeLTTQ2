using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ManageCafe.DTO
{

	public class Bill
	{
		public Bill() { }
		public Bill(int id, string dateCheckIn, string dateCheckOut, int totalPrice, int discount = 0)
		{
			this.id = id;
			this.dateCheckIn = DateTime.Parse(dateCheckIn);
			if (dateCheckOut != null)
				this.dateCheckOut = DateTime.Parse(dateCheckOut);
			this.totalPrice = totalPrice;
			this.discount = discount;
		}
		public Bill(int id, string dateCheckIn, int totalPrice, int discount = 0)
		{
			this.id = id;
			this.dateCheckIn = DateTime.Parse(dateCheckIn);
			this.totalPrice = totalPrice;
			this.discount = discount;
		}

		public Bill(DataRow row)
		{
			this.ID = (int)row["ID"];
			this.DateCheckIn = (DateTime)row["DateCheckIn"];

			if (row["DateCheckOut"].ToString() != "")
				this.DateCheckOut = (DateTime)row["DateCheckOut"];

			if (row["TotalPrice"].ToString() != "")
				this.ToTalPrice = (float)Convert.ToDouble(row["TotalPrice"]);
			if (row["discount"].ToString() != "")
				this.discount = (int)row["Discount"];
		}

		private int discount;

		private int id;

		private float totalPrice;

		private DateTime dateCheckIn;

		private DateTime dateCheckOut;

		public int ID { get; set; }
		public DateTime DateCheckIn { get; set; }

		public DateTime DateCheckOut { get; set; }
		public int Discount { get; set; }
		public float ToTalPrice { get; set; }
	}
}
