using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCafe.DTO
{
	public class BillInfo
	{
		public BillInfo(int id, int billID,int foodID, int count )
		{
			this.iD = id;
			this.billID = billID;
			this.foodID = foodID;
			this.count = count;
		}

		public BillInfo(DataRow row) 
		{
			this.ID = (int)row["id"];
			this.billID = (int)row["idBill"];
			this.foodID = (int)row["idFood"];
			this.count = (int)row["count"];
		}
		private int count;

		private int foodID;

		private int billID;

		private int iD;

		public int ID { get => iD; set => iD = value; }
		public int BillID { get => billID; set => billID = value; }
		public int FoodID { get => foodID; set => foodID = value; }
		public int Count { get => count; set => count = value; }
	}
}
