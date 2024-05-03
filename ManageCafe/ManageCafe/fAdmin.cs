using ManageCafe.Admin;
using ManageCafe.DAO;
using ManageCafe.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageCafe
{
	public partial class fAdmin : Form
	{
		private static readonly HttpClient client = new HttpClient();

		private static readonly string getAllFood = "http://192.168.0.104:3333/food/getAllFood";
		private static readonly string getAllTable = "http://192.168.0.104:3333/table/gettablelist";
		private static readonly string getAllCategory = "http://192.168.0.104:3333/category/getlistcategory";
		private static readonly string getAllBill = "http://192.168.0.104:3333/bill/getbillbydate";
		private static readonly string getAllAccount = "http://192.168.0.104:3333/account/getAllAccount";
		public fAdmin()
		{
			InitializeComponent();
			LoadDateTimePickerBill();
			LoadBillListAsync(dtpkFromDate.Value.ToString("yyyy/MM/dd"), dtpkToDate.Value.ToString("yyyy/MM/dd"));
			LoadCategoryList();
			LoadFoodList();
			FillCategoryIntoCombobox();
			LoadTableFoodList();
			LoadAccountList();
		}
		//#region methods
		//void LoadDateTimePickerBill()
		//{
		//	DateTime today = DateTime.Now;
		//	dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
		//	dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
		//}
		// async Task LoadBillListAsync(string checkIn, string checkOut)
		//{
		//	//string query = "EXEC dbo.USP_GetListBillByDate @checkIn , @checkOut";

		//	//dtgvBill.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { checkIn, checkOut });

		//	string queryString = $"bill/getbillbydate?checkIn={checkIn}&checkOut={checkOut}";
		//	HttpResponseMessage response = await client.GetAsync("http://192.168.0.104:3333/" + queryString);

		//	if (response.IsSuccessStatusCode)
		//	{
		//		string jsonResponse = await response.Content.ReadAsStringAsync();
		//		//MessageBox.Show(jsonResponse); // Hiển thị dữ liệu JSON trong một hộp thoại cảnh báo

		//		var billList = JsonConvert.DeserializeObject<List<DTO.Bill>>(jsonResponse);
		//		dtgvBill.DataSource = billList;
		//	}
		//}
		//async void LoadCategoryList()
		//{
		//	HttpResponseMessage response = await client.GetAsync(getAllCategory);

		//	if (response.IsSuccessStatusCode)
		//	{
		//		var content = await response.Content.ReadAsStringAsync();

		//		var CategoryList = JsonConvert.DeserializeObject<List<Category>>(content);
		//		dtgvCategory.DataSource = CategoryList;
		//	}
		//}
		//void FillCategoryIntoCombobox()
		//{
		//	DataTable dtCategory = DataProvider.Instance.ExecuteQuery("select * from FoodCategory");
		//	FillComBoBox(cbFoodCategory, dtCategory, "Name", "ID");
		//}
		//void LoadFoodList()
		//{
		//	HttpResponseMessage response = client.GetAsync(getAllFood).Result;

		//	if (response.IsSuccessStatusCode)
		//	{
		//		var content = response.Content.ReadAsStringAsync().Result;

		//		var foodList = JsonConvert.DeserializeObject<List<Food>>(content);
		//		dtgvFood.DataSource = foodList;
		//	}
		//}
		//void LoadTableFoodList()
		//{
		//	HttpResponseMessage response = client.GetAsync(getAllTable).Result;

		//	if (response.IsSuccessStatusCode)
		//	{
		//		var content = response.Content.ReadAsStringAsync().Result;

		//		var foodList = JsonConvert.DeserializeObject<List<Table>>(content);
		//		dtgvTable.DataSource = foodList;
		//	}
		//}
		//void LoadAccountList()
		//{
		//	HttpResponseMessage response = client.GetAsync(getAllAccount).Result;

		//	if (response.IsSuccessStatusCode)
		//	{
		//		var content = response.Content.ReadAsStringAsync().Result;

		//		var foodList = JsonConvert.DeserializeObject<List<Account>>(content);
		//		dtgvAccount.DataSource = foodList;
		//	}
		//}
		//void FillComBoBox(ComboBox cbname, DataTable data, string displayMember, string valueMember)
		//{
		//	cbname.DataSource = data;
		//	cbname.DisplayMember = displayMember;
		//	cbname.ValueMember = valueMember;
		//}
		//#endregion
		#region methods
		void LoadDateTimePickerBill()
		{
			DateTime today = DateTime.Now;
			dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
			dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
		}
		async Task LoadBillListAsync(string checkIn, string checkOut)
		{
			string queryString = $"bill/getbillbydate?checkIn={checkIn}&checkOut={checkOut}";
			HttpResponseMessage response = await client.GetAsync("http://192.168.0.104:3333/" + queryString);

			if (response.IsSuccessStatusCode)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();
				var billList = JsonConvert.DeserializeObject<List<DTO.Bill>>(jsonResponse);
				dtgvBill.DataSource = billList;
			}
		}

		async Task LoadCategoryList()
		{
			HttpResponseMessage response = await client.GetAsync(getAllCategory);

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var categoryList = JsonConvert.DeserializeObject<List<Category>>(content);
				dtgvCategory.DataSource = categoryList;
			}
		}

		void FillCategoryIntoCombobox()
		{
			DataTable dtCategory = DataProvider.Instance.ExecuteQuery("select * from FoodCategory");
			FillComBoBox(cbFoodCategory, dtCategory, "Name", "ID");
		}

		async Task LoadFoodList()
		{
			HttpResponseMessage response = await client.GetAsync(getAllFood);

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var foodList = JsonConvert.DeserializeObject<List<Food>>(content);
				dtgvFood.DataSource = foodList;
			}
		}

		async Task LoadTableFoodList()
		{
			HttpResponseMessage response = await client.GetAsync(getAllTable);

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var tableList = JsonConvert.DeserializeObject<List<Table>>(content);
				dtgvTable.DataSource = tableList;
			}
		}

		async Task LoadAccountList()
		{
			HttpResponseMessage response = await client.GetAsync(getAllAccount);

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var accountList = JsonConvert.DeserializeObject<List<Account>>(content);
				dtgvAccount.DataSource = accountList;
			}
		}

		void FillComBoBox(ComboBox cbname, DataTable data, string displayMember, string valueMember)
		{
			cbname.DataSource = data;
			cbname.DisplayMember = displayMember;
			cbname.ValueMember = valueMember;
		}
		#endregion

		#region events
		private void btnViewBill_Click(object sender, EventArgs e)
		{
			LoadBillListAsync(dtpkFromDate.Value.ToString("yyyy/MM/dd"), dtpkToDate.Value.ToString("yyyy/MM/dd"));
		}
		private void btnShowCategory_Click(object sender, EventArgs e)
		{
			LoadCategoryList();
		}
		private void dtgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			txtCategoryID.Text = dtgvCategory.CurrentRow.Cells[0].Value.ToString();
			txtCategoryName.Text = dtgvCategory.CurrentRow.Cells[1].Value.ToString();
		}
		// add category
		private void btnAddCategory_Click(object sender, EventArgs e)
		{
			try
			{
				DataTable check = DataProvider.Instance.ExecuteQuery("Select * from foodcategory Where name = N'" + txtCategoryName.Text + "'");
				if (check.Rows.Count == 0) // Chua co ma name foodcategory do
				{
					if (txtCategoryName.Text == "")
					{
						MessageBox.Show("Bạn chưa nhập tên danh mục!");
						txtCategoryName.Focus();
					}
					else
					{
						string code = "Insert into foodcategory(name) values(N'" + txtCategoryName.Text + "')";
						int result = DataProvider.Instance.ExecuteNonQuery(code);
						if (result > 0)
						{
							MessageBox.Show("Thêm category thành công");
							return;
						}
						else
						{
							MessageBox.Show("Lỗi không thể thêm category mới");
							return;
						}
					}
				}
				else
				{
					MessageBox.Show("Đã có category này!!", "Message");
					return;
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show("Không thể thêm category mới vì " + ex.Message + "");
			}
		}
		private void btnEditCategory_Click(object sender, EventArgs e)
		{
			if (txtCategoryID.Text == "" && txtCategoryName.Text == "")
			{
				MessageBox.Show("Bạn chưa nhập thay đổi!");
				return;
			}
			else
			{
				DataProvider.Instance.ExecuteQuery("Update foodcategory set Name = N'"
				+ txtCategoryName.Text + "' where id = " + int.Parse(txtCategoryID.Text) + "");
				LoadCategoryList();
			}
		}
		private void btnDeleteCategory_Click(object sender, EventArgs e)
		{
			if (txtCategoryID.Text == "" && txtCategoryName.Text == "")
			{
				MessageBox.Show("Bạn chưa chọn danh mục muốn xóa!");
				return;
			}
			else
			{
				DataTable result = DataProvider.Instance.ExecuteQuery("Select * from food Where idCategory = " + txtCategoryID.Text + "");
				if (result.Rows.Count == 0)
				{
					if (MessageBox.Show("Bạn có thực sự muốn xóa danh mục này?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						DataProvider.Instance.ExecuteQuery("Delete from foodcategory Where id = " + txtCategoryID.Text + " AND name = N'" + txtCategoryName.Text + "'");
					}
					else
					{
						return;
					}
					LoadCategoryList();
				}
				else
				{
					MessageBox.Show("Danh mục này đã có sản phẩm");
					return;
				}
			}

		}
		private void btnShowFood_Click(object sender, EventArgs e)
		{
			LoadFoodList();

		}
		private void dtgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			txtFoodID.Text = dtgvFood.CurrentRow.Cells[0].Value.ToString();
			txtFoodName.Text = dtgvFood.CurrentRow.Cells[1].Value.ToString();
			cbFoodCategory.SelectedValue = dtgvFood.CurrentRow.Cells[2].Value.ToString();
			nmFoodPrice.Text = dtgvFood.CurrentRow.Cells[3].Value.ToString();
		}
		private void btnAddFood_Click(object sender, EventArgs e)
		{
			DataTable check = DataProvider.Instance.ExecuteQuery("Select * from food Where name = N'" + txtFoodName.Text + "'");
			if (check.Rows.Count == 0) // Chua co ma name foodcategory do
			{
				if (txtFoodName.Text == "")
				{
					MessageBox.Show("Bạn chưa nhập tên thức ăn!");
					txtFoodName.Focus();
				}
				else if (cbFoodCategory.SelectedValue == null)
				{
					MessageBox.Show("Bạn chưa chọn danh mục thức ăn!");
					cbFoodCategory.Focus();
				}
				else if (nmFoodPrice.Value == 0)
				{
					MessageBox.Show("Bạn chưa chọn giá thức ăn!");
					nmFoodPrice.Focus();
				}
				else
				{
					string code = "Insert into food(name,idcategory,price) values (N'" + txtFoodName.Text + "','" + cbFoodCategory.SelectedValue + "','" + nmFoodPrice.Value + "')";
					/* DataProvider.Instance.ExecuteQuery(code);
					 LoadFoodList();*/
					int result = DataProvider.Instance.ExecuteNonQuery(code);
					if (result > 0)
					{
						MessageBox.Show("Thêm food thành công");
						return;
					}
					else
					{
						MessageBox.Show("Lỗi không thể thêm food mới");
						return;
					}

				}
			}
		}
		private void btnEditFood_Click(object sender, EventArgs e)
		{
			if (txtFoodName.Text == "" || nmFoodPrice.Value == null)
			{
				MessageBox.Show("Bạn chưa nhập thay đổi!");
				return;
			}
			else
			{
				DataProvider.Instance.ExecuteQuery("Update food set name = N'"
				+ txtFoodName.Text + "', idCategory = " + cbFoodCategory.SelectedValue + ", price = " + nmFoodPrice.Value + " where id = " + txtFoodID.Text + "");
				LoadFoodList();
			}
		}
		private void btnDeleteFood_Click(object sender, EventArgs e)
		{
			if (txtFoodID.Text == "" && txtFoodName.Text == "")
			{
				MessageBox.Show("Bạn chưa chọn món muốn xóa!");
				return;
			}
			else
			{
				DataTable result = DataProvider.Instance.ExecuteQuery("Select * from billinfo Where idfood = " + txtFoodID.Text + "");
				if (result.Rows.Count == 0)
				{
					if (MessageBox.Show("Bạn có thực sự muốn xóa món này này?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						DataProvider.Instance.ExecuteQuery("Delete from food Where id = " + txtFoodID.Text + " AND name = N'" + txtFoodName.Text + "'");
					}
					else
					{
						return;
					}
					LoadFoodList();
				}
				else
				{
					MessageBox.Show("Món này không được xoá");
					return;
				}
			}

		}
		private void btnShowTable_Click(object sender, EventArgs e)
		{
			LoadTableFoodList();
		}
		private void dtgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			txtTableID.Text = dtgvTable.CurrentRow.Cells[0].Value.ToString();
			txtTableName.Text = dtgvTable.CurrentRow.Cells[1].Value.ToString();
			cbTableStatus.Text = dtgvTable.CurrentRow.Cells[2].Value.ToString();
		}
		private void btnAddTable_Click(object sender, EventArgs e)
		{
			DataTable check = DataProvider.Instance.ExecuteQuery("Select * from tablefood where name = N'" + txtTableName.Text + "'");
			if (check.Rows.Count == 0)
			{
				if (txtTableName.Text == "")
				{
					MessageBox.Show("Bạn chưa nhập tên bàn!");
					txtTableName.Focus();
				}
				else if (cbTableStatus.Text == "")
				{
					MessageBox.Show("Bạn chưa chọn trạng thái bàn");
					cbTableStatus.Focus();
				}
				else
				{
					string query = "insert into tablefood(name,status) values(N'" + txtTableName.Text + "',N'" + cbTableStatus.Text + "')";
					int result = DataProvider.Instance.ExecuteNonQuery(query);
					if (result > 0)
					{
						MessageBox.Show("Thêm bàn thành công");
						return;
					}
					else
					{
						MessageBox.Show("Lỗi không thể thêm bàn mới");
						return;
					}
				}
			}

		}
		private void btnEditTable_Click(object sender, EventArgs e)
		{
			if (txtTableName.Text == "")
			{
				MessageBox.Show("Bạn chưa nhập thay đổi!");
				return;
			}
			else
			{
				DataProvider.Instance.ExecuteQuery("Update TableFood set name = N'"
				+ txtTableName.Text + "', status = N'" + cbTableStatus.Text + "' where id = " + txtTableID.Text + "");
				LoadTableFoodList();
			}
		}
		private void btnDeleteTable_Click(object sender, EventArgs e)
		{
			if (txtTableName.Text == "")
			{
				MessageBox.Show("Bạn chưa chọn bàn muốn xóa!");
				return;
			}
			else
			{
				DataTable result = DataProvider.Instance.ExecuteQuery("Select * from bill Where idtable = " + txtTableID.Text + "");
				if (result.Rows.Count == 0)
				{
					if (MessageBox.Show("Bạn có thực sự muốn xóa bàn này?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						DataProvider.Instance.ExecuteQuery("Delete from tablefood Where id = " + txtTableID.Text + " AND name = N'" + txtTableName.Text + "'");
					}
					else
					{
						return;
					}
					LoadTableFoodList();
				}
				else
				{
					MessageBox.Show("Bàn này không được xoá");
					return;
				}
			}
		}
		private void btnShowAccount_Click(object sender, EventArgs e)
		{
			LoadAccountList();
		}
		private void dtgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			txtUsername.Text = dtgvAccount.CurrentRow.Cells[0].Value.ToString();
			txtPassword.Text = dtgvAccount.CurrentRow.Cells[1].Value.ToString();
			txtDisplayName.Text = dtgvAccount.CurrentRow.Cells[2].Value.ToString();
			nmTypeAccount.Text = dtgvAccount.CurrentRow.Cells[3].Value.ToString();
		}
		private void btnAddAccount_Click(object sender, EventArgs e)
		{
			DataTable check = DataProvider.Instance.ExecuteQuery("Select * from Account Where username = N'" + txtUsername.Text + "' " +
				"AND displayname = N'" + txtDisplayName.Text + "'");
			if (check.Rows.Count == 0) // Chua co ma name table do
			{
				if (txtUsername.Text == "")
				{
					MessageBox.Show("Bạn chưa nhập tên tài khoản!");
					txtUsername.Focus();
				}
				else if (txtDisplayName.Text == "")
				{
					MessageBox.Show("Bạn chưa nhập tên hiển thị!");
					txtDisplayName.Focus();
				}

				else
				{
					string code = "Insert into Account(username,displayname,type) values(N'" + txtUsername.Text + "','" + txtDisplayName.Text + "','" + nmTypeAccount.Value + "')";
					//DataProvider.Instance.ExecuteQuery(code);
					int result = DataProvider.Instance.ExecuteNonQuery(code);
					if (result > 0)
					{
						MessageBox.Show("Thêm tài khoản thành công");
						return;
					}
					else
					{
						MessageBox.Show("Lỗi không thể lập tài khoản mới");
						return;
					}

				}
			}
		}
		private void btnEditAccount_Click(object sender, EventArgs e)
		{
			if (txtUsername.Text == "" || txtDisplayName.Text == "")
			{
				MessageBox.Show("Bạn chưa nhập thay đổi!");
				return;
			}
			else
			{
				DataProvider.Instance.ExecuteQuery("Update Account set username = N'"
				+ txtUsername.Text + "', displayname = N'" + txtDisplayName.Text + "', type = " + nmTypeAccount.Value + "" +
				" Where username = N'" + txtUsername.Text + "' OR displayname = '" + txtDisplayName.Text + "' OR type = " + nmTypeAccount.Value + "");
				LoadAccountList();
			}
		}
		private void btnDeleteAccout_Click(object sender, EventArgs e)
		{
			if (txtUsername.Text == "" || txtDisplayName.Text == "")
			{
				MessageBox.Show("Bạn chưa chọn tài khoản muốn xóa!");
				return;
			}
			else
			{
				if (MessageBox.Show("Bạn có thực sự muốn tài khoản này?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					DataProvider.Instance.ExecuteQuery("Delete from Account Where UserName = N'" + txtUsername.Text + "' AND DisplayName = N'" + txtDisplayName.Text + "' ");
				}
				else
				{
					return;
				}
				LoadAccountList();
			}
		}
		#endregion
	}
}
