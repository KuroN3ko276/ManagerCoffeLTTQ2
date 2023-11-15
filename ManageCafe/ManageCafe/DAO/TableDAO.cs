using ManageCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCafe.DAO
{
	public class TableDAO
	{
		private static TableDAO instance;

		public static TableDAO Instance 
		{
			get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; } 
			private set { TableDAO.instance = value; }
		}

		public static int TableWidth = 120;

		public static int TableHeight = 120;
		private TableDAO() { }

		public List<Table> LoadTableList()
		{
			List<Table> tableList = new List<Table>();

			DataTable data =DataProvider.Instance.ExecuteQuery("exec dbo.USP_GetTableList");
			
			foreach (DataRow row in data.Rows)
			{
				Table table = new Table(row);
				tableList.Add(table);
			}

			return tableList;

		}

	}
}
