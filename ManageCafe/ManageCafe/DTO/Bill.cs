using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCafe.DTO
{
	public class Bill
	{
		public Bill(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int status,int discount=0) 
		{
			this.iD = id;
			this.dateCheckIn = dateCheckIn;
			this.dateCheckOut = dateCheckOut;
			this.status = status;
			this.discount = discount;	
		}

		public Bill(DataRow row)
		{
			this.ID = (int)row["id"];
			this.dateCheckIn = (DateTime?)row["dateCheckIn"];
			var dateCheckOutTemp = row["dateCheckOut"];
			if(dateCheckOutTemp.ToString() != "")
				this.dateCheckOut = (DateTime?)dateCheckOutTemp;

			this.status = (int)row["status"];
			if (row["discount"].ToString() != "")
				this.discount = (int)row["discount"];
		}

		private int discount;

		private int iD;

		private int status;

		private DateTime? dateCheckIn;

		private DateTime? dateCheckOut;

		public int ID { get => iD; set => iD= value; }
		public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
		public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
		public int Status { get => status; set => status = value; }
		public int Discount { get => discount; set => discount = value; }
	}
}
