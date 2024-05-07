//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ManageCafe.DAO
//{
//	public class DataProvider
//	{

//		private static DataProvider instance;

//		private string connectionStr = "Data Source=KURON3KO\\HAIDANG;Initial Catalog=QLCoffeLTTQ;Integrated Security=True";

//		public static DataProvider Instance 
//		{
//			get { if (instance == null) instance = new DataProvider(); return instance; }
//			private set { DataProvider.instance = value; }
//		}

//		private DataProvider()
//		{

//		}

//		public DataTable ExecuteQuery(string query, object[] parameter =null) //Doc DL
//		{
//			DataTable data = new DataTable();
//			using (SqlConnection connection = new SqlConnection(connectionStr))
//			{
//				connection.Open();

//				SqlCommand command = new SqlCommand(query, connection);

//				if(parameter != null )
//				{
//					string[] listPara = query.Split(' ');
//					int i = 0;
//					foreach(string item in listPara)
//					{
//						if(item.Contains('@'))
//						{
//							command.Parameters.AddWithValue(item, parameter[i]);
//							i++;
//						}
//					}
//				}

//				SqlDataAdapter adapter = new SqlDataAdapter(command);

//				adapter.Fill(data);

//				connection.Close();


//			}
//			return data;
//		}

//		public int ExecuteNonQuery(string query, object[] parameter = null)// Thong bao co bao nhieu thay doi trong database
//		{
//			int data = 0;
//			using (SqlConnection connection = new SqlConnection(connectionStr))
//			{
//				connection.Open();

//				SqlCommand command = new SqlCommand(query, connection);

//				if (parameter != null)
//				{
//					string[] listPara = query.Split(' ');
//					int i = 0;
//					foreach (string item in listPara)
//					{
//						if (item.Contains('@'))
//						{
//							command.Parameters.AddWithValue(item, parameter[i]);
//							i++;
//						}
//					}
//				}

//				data = command.ExecuteNonQuery();

//				connection.Close();


//			}
//			return data;
//		}

//		public object ExecuteScalar(string query, object[] parameter = null)//TRa ve 1 row
//		{
//			object data = 0;
//			using (SqlConnection connection = new SqlConnection(connectionStr))
//			{
//				connection.Open();

//				SqlCommand command = new SqlCommand(query, connection);

//				if (parameter != null)
//				{
//					string[] listPara = query.Split(' ');
//					int i = 0;
//					foreach (string item in listPara)
//					{
//						if (item.Contains('@'))
//						{
//							command.Parameters.AddWithValue(item, parameter[i]);
//							i++;
//						}
//					}
//				}

//				data = command.ExecuteScalar();

//				connection.Close();


//			}
//			return data;
//		}
//	}
//}
