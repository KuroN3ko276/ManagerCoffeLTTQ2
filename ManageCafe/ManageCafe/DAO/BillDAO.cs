﻿using ManageCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCafe.DAO
{
	public class BillDAO
	{
		private static BillDAO instance;

		public static BillDAO Instance 
		{	
			get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
			private set { BillDAO.instance = value; } 
		}

		private BillDAO() { }

		public int GetBillIDByTableID(int id)
		{
			DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE idTable = " + id + " AND status = 0");
			if(data.Rows.Count > 0) 
			{
				Bill bill = new Bill(data.Rows[0]);
				return bill.ID;
			}
			return -1;
		}
	}
}
