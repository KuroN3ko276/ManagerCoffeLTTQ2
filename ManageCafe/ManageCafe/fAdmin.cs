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

		private static readonly string getAllFood = "http://127.0.0.1:3333/food/getAllFood";
		private static readonly string getAllTable = "http://127.0.0.1:3333/table/gettablelist";
		private static readonly string getAllCategory = "http://127.0.0.1:3333/category/getlistcategory";
		//private static readonly string getAllBill = "http://127.0.0.1:3333/bill/getbillbydate";
		private static readonly string getAllAccount = "http://127.0.0.1:3333/account/getAllAccount";
		public fAdmin()
		{
			InitializeComponent();
			LoadDateTimePickerBill();
			LoadBillListAsync(dtpkFromDate.Value.ToString("yyyy/MM/dd"), dtpkToDate.Value.ToString("yyyy/MM/dd"));
			LoadCategoryList();
			LoadFoodList();
			//FillCategoryIntoCombobox();
			LoadTableFoodList();
			LoadAccountList();
		}

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
			HttpResponseMessage response = await client.GetAsync("http://127.0.0.1:3333/" + queryString);

			if (response.IsSuccessStatusCode)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();
				var billList = JsonConvert.DeserializeObject<List<Object>>(jsonResponse);
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
				cbFoodCategory.DataSource = categoryList;
				cbFoodCategory.DisplayMember = "Name";
				cbFoodCategory.ValueMember = "ID";
			}
		}

		//void FillCategoryIntoCombobox()
		//{
		//	//DataTable dtCategory = DataProvider.Instance.ExecuteQuery("select * from FoodCategory");
		//	//FillComBoBox(cbFoodCategory, dtCategory, "Name", "ID");
		//	HttpResponseMessage response = client.GetAsync(getAllCategory).Result;

		//	if (response.IsSuccessStatusCode)
		//	{
		//		var content = response.Content.ReadAsStringAsync().Result;
		//		List<Category> dtCategory = JsonConvert.DeserializeObject<List<Category>>(content);
		//		cbFoodCategory.DataSource = dtCategory;
		//		cbFoodCategory.DisplayMember = "Name";
		//		cbFoodCategory.ValueMember = "ID";
		//	}
		//}

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

		void LoadAccountList()
		{
			HttpResponseMessage response = client.GetAsync(getAllAccount).Result;

			if (response.IsSuccessStatusCode)
			{
				var content = response.Content.ReadAsStringAsync().Result;
				var accountList = JsonConvert.DeserializeObject<List<Account>>(content);
				dtgvAccount.DataSource = accountList;
			}
		}

		//void FillComBoBox(ComboBox cbname, DataTable data, string displayMember, string valueMember)
		//{
		//	cbname.DataSource = data;
		//	cbname.DisplayMember = displayMember;
		//	cbname.ValueMember = valueMember;
		//}
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
		private async void btnAddCategory_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
				{
					MessageBox.Show("Bạn chưa nhập tên danh mục!");
					txtCategoryName.Focus();
					return;
				}

				// Tạo đối tượng category từ tên danh mục
				var newCategory = new { name = txtCategoryName.Text };

				// Chuyển đối tượng category thành chuỗi JSON
				string jsonCategory = JsonConvert.SerializeObject(newCategory);

				// Tạo đường dẫn API và HttpClient
				string apiUrl = "http://127.0.0.1:3333/category/insertCategory";
				HttpClient client = new HttpClient();

				// Tạo nội dung yêu cầu POST với dữ liệu JSON
				var content = new StringContent(jsonCategory, Encoding.UTF8, "application/json");

				// Gửi yêu cầu POST đến API
				HttpResponseMessage response = await client.PostAsync(apiUrl, content);

				// Đọc nội dung phản hồi từ máy chủ Python
				string responseContent = await response.Content.ReadAsStringAsync();

				// Xác định xem yêu cầu đã thành công hay không
				if (response.IsSuccessStatusCode)
				{
					// Kiểm tra nội dung phản hồi từ máy chủ
					dynamic responseData = JsonConvert.DeserializeObject(responseContent);
					string message = responseData.mess;
					if (message == "Thành công")
					{
						MessageBox.Show("Thêm category thành công");
						LoadCategoryList();
						//FillCategoryIntoCombobox();
					}
					else if (message == "Đã có category này")
					{
						MessageBox.Show("Đã có category này!");
					}
					else
					{
						MessageBox.Show("Lỗi không thể thêm category mới");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Không thể thêm category mới vì " + ex.Message);
			}
		}
		// edit category
		private async void btnEditCategory_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtCategoryID.Text) || string.IsNullOrWhiteSpace(txtCategoryName.Text))
			{
				MessageBox.Show("Bạn chưa nhập thông tin cần thay đổi!");
				return;
			}
			else
			{
				try
				{
					// Tạo đối tượng category từ thông tin cần chỉnh sửa
					var category = new
					{
						id = int.Parse(txtCategoryID.Text),
						name = txtCategoryName.Text
					};

					// Chuyển đối tượng category thành chuỗi JSON
					string jsonCategory = JsonConvert.SerializeObject(category);

					// Tạo đường dẫn API và HttpClient
					string apiUrl = "http://127.0.0.1:3333/category/edit";
					HttpClient client = new HttpClient();

					// Tạo nội dung yêu cầu PUT với dữ liệu JSON
					var content = new StringContent(jsonCategory, Encoding.UTF8, "application/json");

					// Gửi yêu cầu PUT đến API
					HttpResponseMessage response = await client.PutAsync(apiUrl, content);

					// Đọc nội dung phản hồi từ máy chủ Python
					string responseContent = await response.Content.ReadAsStringAsync();

					// Xác định xem yêu cầu đã thành công hay không
					if (response.IsSuccessStatusCode)
					{
						dynamic responseData = JsonConvert.DeserializeObject(responseContent);
						string message = responseData.mess;
						if (message == "Thành công")
						{
							MessageBox.Show("Sửa danh mục thành công");
							LoadCategoryList(); // Load lại danh sách danh mục sau khi chỉnh sửa thành công
							//FillCategoryIntoCombobox();
						}
						else if (message == "Đã có danh mục này")
						{
							MessageBox.Show("Đã có danh mục này!");
						}
					}
					else
					{
						MessageBox.Show("Lỗi không thể chỉnh sửa danh mục: " + responseContent);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Không thể chỉnh sửa danh mục vì " + ex.Message);
				}
			}
		}
		// delete category
		private async void btnDeleteCategory_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtCategoryID.Text) || string.IsNullOrWhiteSpace(txtCategoryName.Text))
			{
				MessageBox.Show("Bạn chưa chọn danh mục muốn xóa!");
				return;
			}
			else
			{
				try
				{
					// Gửi yêu cầu DELETE đến API
					
					if (MessageBox.Show("Bạn có thực sự muốn xóa danh mục này?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						string apiUrl = "http://127.0.0.1:3333/category/delete?id=" + txtCategoryID.Text + "&name=" + txtCategoryName.Text;
						HttpResponseMessage response = await client.DeleteAsync(apiUrl);
						// Đọc nội dung phản hồi từ máy chủ Python
						string responseContent = await response.Content.ReadAsStringAsync();

						// Xác định xem yêu cầu đã thành công hay không
						if (response.IsSuccessStatusCode)
						{
							dynamic responseData = JsonConvert.DeserializeObject(responseContent);
							string message = responseData.mess;
							if (message == "Thành công")
							{
								MessageBox.Show("Xoá danh mục thành công");
								LoadCategoryList(); // Load lại danh sách danh mục sau khi chỉnh sửa thành công
								//FillCategoryIntoCombobox();
							}
							else if (message == "Danh mục này đã có món")
							{
								MessageBox.Show("Danh mục này không được xoá");
							}
						}
						else
						{
							MessageBox.Show("Lỗi không thể xóa danh mục: " + responseContent);
						}
					}	
					
				}
				catch (Exception ex)
				{
					MessageBox.Show("Không thể xóa danh mục vì " + ex.Message);
				}
			}
			//if (txtCategoryID.Text == "" && txtCategoryName.Text == "")
			//{
			//	MessageBox.Show("Bạn chưa chọn danh mục muốn xóa!");
			//	return;
			//}
			//else
			//{
			//	DataTable result = DataProvider.Instance.ExecuteQuery("Select * from food Where idCategory = " + txtCategoryID.Text + "");
			//	if (result.Rows.Count == 0)
			//	{
			//		if (MessageBox.Show("Bạn có thực sự muốn xóa danh mục này?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			//		{
			//			DataProvider.Instance.ExecuteQuery("Delete from foodcategory Where id = " + txtCategoryID.Text + " AND name = N'" + txtCategoryName.Text + "'");
			//		}
			//		else
			//		{
			//			return;
			//		}
			//		LoadCategoryList();
			//	}
			//	else
			//	{
			//		MessageBox.Show("Danh mục này đã có sản phẩm");
			//		return;
			//	}
			//}

		}
		private void btnShowFood_Click(object sender, EventArgs e)
		{
			LoadFoodList();
			LoadCategoryList();

		}
		private void dtgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			txtFoodID.Text = dtgvFood.CurrentRow.Cells[0].Value.ToString();
			txtFoodName.Text = dtgvFood.CurrentRow.Cells[1].Value.ToString();
			nmFoodPrice.Text = dtgvFood.CurrentRow.Cells[2].Value.ToString();
			cbFoodCategory.SelectedValue = dtgvFood.CurrentRow.Cells[3].Value.ToString();

		}
		private async void btnAddFood_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(txtFoodName.Text))
				{
					MessageBox.Show("Bạn chưa nhập tên thức ăn!");
					txtFoodName.Focus();
					return;
				}
				else if (cbFoodCategory.SelectedValue == null)
				{
					MessageBox.Show("Bạn chưa chọn danh mục thức ăn!");
					cbFoodCategory.Focus();
					return;
				}
				else if (nmFoodPrice.Value == 0)
				{
					MessageBox.Show("Bạn chưa chọn giá thức ăn!");
					nmFoodPrice.Focus();
					return;
				}

				// Tạo đối tượng food từ thông tin món ăn
				var newFood = new
				{
					name = txtFoodName.Text,
					idCategory = cbFoodCategory.SelectedValue,
					price = nmFoodPrice.Value
				};

				// Chuyển đối tượng food thành chuỗi JSON
				string jsonFood = JsonConvert.SerializeObject(newFood);

				// Tạo đường dẫn API và HttpClient
				string apiUrl = "http://127.0.0.1:3333/food/insert";

				// Tạo nội dung yêu cầu POST với dữ liệu JSON
				var content = new StringContent(jsonFood, Encoding.UTF8, "application/json");

				// Gửi yêu cầu POST đến API
				HttpResponseMessage response = await client.PostAsync(apiUrl, content);

				// Đọc nội dung phản hồi từ máy chủ Python
				string responseContent = await response.Content.ReadAsStringAsync();

				// Xác định xem yêu cầu đã thành công hay không
				if (response.IsSuccessStatusCode)
				{
					dynamic responseData = JsonConvert.DeserializeObject(responseContent);
					string message = responseData.mess;
					if (message == "Thành công")
					{
						MessageBox.Show("Thêm Food thành công");
						LoadFoodList();
					}
					else if (message == "Tên thức ăn đã tồn tại!")
					{
						MessageBox.Show("Đã có Food này!");
					}
					else
					{
						MessageBox.Show("Lỗi không thể thêm Food mới");
					}
				}
				else
				{
					MessageBox.Show("Lỗi không thể thêm món ăn mới: " + responseContent);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Không thể thêm món ăn mới vì " + ex.Message);
			}
			//DataTable check = DataProvider.Instance.ExecuteQuery("Select * from food Where name = N'" + txtFoodName.Text + "'");
			//if (check.Rows.Count == 0) // Chua co ma name foodcategory do
			//{
			//	if (txtFoodName.Text == "")
			//	{
			//		MessageBox.Show("Bạn chưa nhập tên thức ăn!");
			//		txtFoodName.Focus();
			//	}
			//	else if (cbFoodCategory.SelectedValue == null)
			//	{
			//		MessageBox.Show("Bạn chưa chọn danh mục thức ăn!");
			//		cbFoodCategory.Focus();
			//	}
			//	else if (nmFoodPrice.Value == 0)
			//	{
			//		MessageBox.Show("Bạn chưa chọn giá thức ăn!");
			//		nmFoodPrice.Focus();
			//	}
			//	else
			//	{
			//		string code = "Insert into food(name,idcategory,price) values (N'" + txtFoodName.Text + "','" + cbFoodCategory.SelectedValue + "','" + nmFoodPrice.Value + "')";
			//		/* DataProvider.Instance.ExecuteQuery(code);
			//		 LoadFoodList();*/
			//		int result = DataProvider.Instance.ExecuteNonQuery(code);
			//		if (result > 0)
			//		{
			//			MessageBox.Show("Thêm food thành công");
			//			return;
			//		}
			//		else
			//		{
			//			MessageBox.Show("Lỗi không thể thêm food mới");
			//			return;
			//		}

			//	}
			//}
		}
		private async void btnEditFood_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtFoodName.Text) || string.IsNullOrWhiteSpace(nmFoodPrice.Value.ToString()) || string.IsNullOrWhiteSpace(cbFoodCategory.Text) || string.IsNullOrWhiteSpace(txtFoodID.Text))
			{
				MessageBox.Show("Bạn chưa nhập thông tin cần thay đổi!");
				return;
			}
			else
			{
				try
				{
					// Tạo đối tượng category từ thông tin cần chỉnh sửa
					var newFood = new
					{
						name = txtFoodName.Text,
						idCategory = cbFoodCategory.SelectedValue,
						price = nmFoodPrice.Value,
						id = txtFoodID.Text
					};

					// Chuyển đối tượng category thành chuỗi JSON
					string jsonCategory = JsonConvert.SerializeObject(newFood);

					// Tạo đường dẫn API và HttpClient
					string apiUrl = "http://127.0.0.1:3333/food/edit";
					HttpClient client = new HttpClient();

					// Tạo nội dung yêu cầu PUT với dữ liệu JSON
					var content = new StringContent(jsonCategory, Encoding.UTF8, "application/json");

					// Gửi yêu cầu PUT đến API
					HttpResponseMessage response = await client.PutAsync(apiUrl, content);

					// Đọc nội dung phản hồi từ máy chủ Python
					string responseContent = await response.Content.ReadAsStringAsync();

					// Xác định xem yêu cầu đã thành công hay không
					if (response.IsSuccessStatusCode)
					{
						dynamic responseData = JsonConvert.DeserializeObject(responseContent);
						string message = responseData.mess;
						if (message == "Thành công")
						{
							MessageBox.Show("Sửa món thành công");
							LoadFoodList(); // Load lại danh sách danh mục sau khi chỉnh sửa thành công
						}
						else if (message == "Đã có món này")
						{
							MessageBox.Show("Đã có món này");
						}
					}
					else
					{
						MessageBox.Show("Lỗi không thể chỉnh sửa Food: " + responseContent);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Không thể chỉnh sửa Food vì " + ex.Message);
				}
			}
			//if (txtFoodName.Text == "" || nmFoodPrice.Value == null)
			//{
			//	MessageBox.Show("Bạn chưa nhập thay đổi!");
			//	return;
			//}
			//else
			//{
			//	DataProvider.Instance.ExecuteQuery("Update food set name = N'"
			//	+ txtFoodName.Text + "', idCategory = " + cbFoodCategory.SelectedValue + ", price = " + nmFoodPrice.Value + " where id = " + txtFoodID.Text + "");
			//	LoadFoodList();
			//}
		}
		private async void btnDeleteFood_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtFoodID.Text) || string.IsNullOrWhiteSpace(txtFoodName.Text))
			{
				MessageBox.Show("Bạn chưa chọn món muốn xóa!");
				return;
			}
			else
			{
				try
				{
					if (MessageBox.Show("Bạn có thực sự muốn xóa món này?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						string apiUrl = "http://127.0.0.1:3333/food/delete?id=" + txtFoodID.Text + "&name=" + txtFoodName.Text;
						HttpResponseMessage response = await client.DeleteAsync(apiUrl);
						// Đọc nội dung phản hồi từ máy chủ Python
						string responseContent = await response.Content.ReadAsStringAsync();

						// Xác định xem yêu cầu đã thành công hay không
						if (response.IsSuccessStatusCode)
						{
							dynamic responseData = JsonConvert.DeserializeObject(responseContent);
							string message = responseData.mess;
							if (message == "Thành công")
							{
								MessageBox.Show("Xoá món này thành công");
								LoadFoodList(); // Load lại danh sách danh mục sau khi chỉnh sửa thành công
							}
							else if (message == "Món này không được xoá vì đã lên bill")
							{
								MessageBox.Show("Món này không được xoá vì đã lên bill");
							}

						}
						else
						{
							MessageBox.Show("Lỗi không thể xóa món ăn");
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Không thể xóa món ăn vì " + ex.Message);
				}
			}

			//if (txtFoodID.Text == "" && txtFoodName.Text == "")
			//{
			//	MessageBox.Show("Bạn chưa chọn món muốn xóa!");
			//	return;
			//}
			//else
			//{
			//	DataTable result = DataProvider.Instance.ExecuteQuery("Select * from billinfo Where idfood = " + txtFoodID.Text + "");
			//	if (result.Rows.Count == 0)
			//	{
			//		if (MessageBox.Show("Bạn có thực sự muốn xóa món này này?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			//		{
			//			DataProvider.Instance.ExecuteQuery("Delete from food Where id = " + txtFoodID.Text + " AND name = N'" + txtFoodName.Text + "'");
			//		}
			//		else
			//		{
			//			return;
			//		}
			//		LoadFoodList();
			//	}
			//	else
			//	{
			//		MessageBox.Show("Món này không được xoá");
			//		return;
			//	}
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
		private async void btnAddTable_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(txtTableName.Text))
				{
					MessageBox.Show("Bạn chưa nhập tên bàn!");
					txtTableName.Focus();
					return;
				}
				else if (string.IsNullOrWhiteSpace(cbTableStatus.Text))
				{
					MessageBox.Show("Bạn chưa chọn trạng thái bàn!");
					cbTableStatus.Focus();
					return;
				}
				var newTable = new
				{
					name = txtTableName.Text,
					status = cbTableStatus.Text
				};

				string jsonTable = JsonConvert.SerializeObject(newTable);
				string apiUrl = "http://127.0.0.1:3333/table/insert";
				var content = new StringContent(jsonTable, Encoding.UTF8, "application/json");
				HttpResponseMessage response = await client.PostAsync(apiUrl, content);
				string responseContent = await response.Content.ReadAsStringAsync();
				if (response.IsSuccessStatusCode)
				{
					dynamic responseData = JsonConvert.DeserializeObject(responseContent);
					string message = responseData.mess;
					if (message == "Thành công")
					{
						MessageBox.Show("Thêm bàn thành công");
					}
					else if (message == "Đã có bàn này")
					{
						MessageBox.Show("Đã có bàn này!");
					}
					else
					{
						MessageBox.Show("Lỗi không thể thêm bàn mới");
					}
					LoadTableFoodList();
				}
				else
				{
					MessageBox.Show("Lỗi không thể thêm bàn mới: " + responseContent);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Không thể thêm bàn vì " + ex.Message);
			}

			//DataTable check = DataProvider.Instance.ExecuteQuery("Select * from tablefood where name = N'" + txtTableName.Text + "'");
			//if (check.Rows.Count == 0)
			//{
			//	if (txtTableName.Text == "")
			//	{
			//		MessageBox.Show("Bạn chưa nhập tên bàn!");
			//		txtTableName.Focus();
			//	}
			//	else if (cbTableStatus.Text == "")
			//	{
			//		MessageBox.Show("Bạn chưa chọn trạng thái bàn");
			//		cbTableStatus.Focus();
			//	}
			//	else
			//	{
			//		string query = "insert into tablefood(name,status) values(N'" + txtTableName.Text + "',N'" + cbTableStatus.Text + "')";
			//		int result = DataProvider.Instance.ExecuteNonQuery(query);
			//		if (result > 0)
			//		{
			//			MessageBox.Show("Thêm bàn thành công");
			//			return;
			//		}
			//		else
			//		{
			//			MessageBox.Show("Lỗi không thể thêm bàn mới");
			//			return;
			//		}
			//	}
			//}

		}
		private async void btnEditTable_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtTableName.Text) || string.IsNullOrWhiteSpace(txtTableID.Text.ToString()) || string.IsNullOrWhiteSpace(cbTableStatus.Text))
			{
				MessageBox.Show("Bạn chưa nhập thông tin cần thay đổi!");
				return;
			}
			else
			{
				try
				{
					var newTable = new
					{
						name = txtTableName.Text,
						status = cbTableStatus.Text,
						id = txtTableID.Text
					};

					string jsonTable = JsonConvert.SerializeObject(newTable);
					string apiUrl = "http://127.0.0.1:3333/table/edit";
					var content = new StringContent(jsonTable, Encoding.UTF8, "application/json");
					HttpResponseMessage response = await client.PutAsync(apiUrl, content);
					string responseContent = await response.Content.ReadAsStringAsync();

					if (response.IsSuccessStatusCode)
					{
						dynamic responseData = JsonConvert.DeserializeObject(responseContent);
						string message = responseData.mess;
						if (message == "Thành công")
						{
							MessageBox.Show("Sửa bàn thành công");
							LoadTableFoodList(); 
						}
						else if (message == "Đã có bàn này")
						{
							MessageBox.Show("Đã có bàn này");
						}
					}
					else
					{
						MessageBox.Show("Lỗi không thể chỉnh sửa bàn: " + responseContent);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Không thể chỉnh sửa bàn vì " + ex.Message);
				}
			}
				//if (txtTableName.Text == "")
				//{
				//	MessageBox.Show("Bạn chưa nhập thay đổi!");
				//	return;
				//}
				//else
				//{
				//	DataProvider.Instance.ExecuteQuery("Update TableFood set name = N'"
				//	+ txtTableName.Text + "', status = N'" + cbTableStatus.Text + "' where id = " + txtTableID.Text + "");
				//	LoadTableFoodList();
				//}
			}
		private async void btnDeleteTable_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtTableName.Text) || string.IsNullOrWhiteSpace(txtTableID.Text))
			{
				MessageBox.Show("Bạn chưa chọn bàn muốn xóa!");
				return;
			}
			else
			{
				try
				{
					if (MessageBox.Show("Bạn có thực sự muốn xóa bàn này?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						string apiUrl = "http://127.0.0.1:3333/table/delete?id=" + txtTableID.Text + "&name=" + txtTableName.Text;
						HttpResponseMessage response = await client.DeleteAsync(apiUrl);
						string responseContent = await response.Content.ReadAsStringAsync();
						if (response.IsSuccessStatusCode)
						{
							dynamic responseData = JsonConvert.DeserializeObject(responseContent);
							string message = responseData.mess;
							if (message == "Thành công")
							{
								MessageBox.Show("Xoá bàn thành công");
								LoadTableFoodList(); 
							}
							else if (message == "Bàn này đã có bill")
							{
								MessageBox.Show("Bàn này không được xoá");
							}

						}
						else
						{
							MessageBox.Show("Lỗi không thể xóa bàn ");
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Không thể xóa món ăn vì " + ex.Message);
				}
			}
			//if (txtTableName.Text == "")
			//{
			//	MessageBox.Show("Bạn chưa chọn bàn muốn xóa!");
			//	return;
			//}
			//else
			//{
			//	DataTable result = DataProvider.Instance.ExecuteQuery("Select * from bill Where idtable = " + txtTableID.Text + "");
			//	if (result.Rows.Count == 0)
			//	{
			//		if (MessageBox.Show("Bạn có thực sự muốn xóa bàn này?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			//		{
			//			DataProvider.Instance.ExecuteQuery("Delete from tablefood Where id = " + txtTableID.Text + " AND name = N'" + txtTableName.Text + "'");
			//		}
			//		else
			//		{
			//			return;
			//		}
			//		LoadTableFoodList();
			//	}
			//	else
			//	{
			//		MessageBox.Show("Bàn này không được xoá");
			//		return;
			//	}
			//}
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
		private async void btnAddAccount_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(txtUsername.Text))
				{
					MessageBox.Show("Bạn chưa nhập tên tài khoản!");
					txtUsername.Focus();
					return;
				}
				else if (string.IsNullOrWhiteSpace(txtDisplayName.Text))
				{
					MessageBox.Show("Bạn chưa nhập tên hiển thị!");
					txtDisplayName.Focus();
					return;
				}
				else if (string.IsNullOrWhiteSpace(txtPassword.Text))
				{
					MessageBox.Show("Bạn chưa nhập mật khẩu!");
					txtPassword.Focus();
					return;
				}
				var newAccount = new
				{
					UserName = txtUsername.Text,
					DisplayName = txtDisplayName.Text,
					PassWord = txtPassword.Text,
					type = nmTypeAccount.Text
				};

				string jsonTable = JsonConvert.SerializeObject(newAccount);
				string apiUrl = "http://127.0.0.1:3333/account/insert";
				var content = new StringContent(jsonTable, Encoding.UTF8, "application/json");
				HttpResponseMessage response = await client.PostAsync(apiUrl, content);
				string responseContent = await response.Content.ReadAsStringAsync();
				if (response.IsSuccessStatusCode)
				{
					dynamic responseData = JsonConvert.DeserializeObject(responseContent);
					string message = responseData.mess;
					if (message == "Thành công")
					{
						MessageBox.Show("Thêm tài khoản thành công");
						LoadAccountList();
					}
					else if (message == "Đã có tài khoản này")
					{
						MessageBox.Show("Đã có tài khoản này!");
					}
					else
					{
						MessageBox.Show("Lỗi không thể thêm tài khoản mới");
					}
				}
				else
				{
					MessageBox.Show("Lỗi không thể thêm tài khoản mới: " + responseContent);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Không thể thêm tài khoản vì " + ex.Message);
			}
			//DataTable check = DataProvider.Instance.ExecuteQuery("Select * from Account Where username = N'" + txtUsername.Text + "' " +
			//	"AND displayname = N'" + txtDisplayName.Text + "'");
			//if (check.Rows.Count == 0) // Chua co ma name table do
			//{
			//	if (txtUsername.Text == "")
			//	{
			//		MessageBox.Show("Bạn chưa nhập tên tài khoản!");
			//		txtUsername.Focus();
			//	}
			//	else if (txtDisplayName.Text == "")
			//	{
			//		MessageBox.Show("Bạn chưa nhập tên hiển thị!");
			//		txtDisplayName.Focus();
			//	}

			//	else
			//	{
			//		string code = "Insert into Account(username,displayname,type) values(N'" + txtUsername.Text + "','" + txtDisplayName.Text + "','" + nmTypeAccount.Value + "')";
			//		//DataProvider.Instance.ExecuteQuery(code);
			//		int result = DataProvider.Instance.ExecuteNonQuery(code);
			//		if (result > 0)
			//		{
			//			MessageBox.Show("Thêm tài khoản thành công");
			//			return;
			//		}
			//		else
			//		{
			//			MessageBox.Show("Lỗi không thể lập tài khoản mới");
			//			return;
			//		}

			//	}
			//}
		}
		private async void btnEditAccount_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtDisplayName.Text.ToString()) || string.IsNullOrWhiteSpace(txtPassword.Text))
			{
				MessageBox.Show("Bạn chưa nhập thông tin cần thay đổi!");
				return;
			}
			else
			{
				try
				{
					var newAccount = new
					{
						UserName = txtUsername.Text,
						DisplayName = txtDisplayName.Text,
						PassWord = txtPassword.Text,
						type = nmTypeAccount.Text
					};

					string jsonTable = JsonConvert.SerializeObject(newAccount);
					string apiUrl = "http://127.0.0.1:3333/account/edit";
					var content = new StringContent(jsonTable, Encoding.UTF8, "application/json");
					HttpResponseMessage response = await client.PutAsync(apiUrl, content);
					string responseContent = await response.Content.ReadAsStringAsync();

					if (response.IsSuccessStatusCode)
					{
						
						MessageBox.Show("Sửa tài khoản thành công");
						LoadAccountList();
						
					}
					else
					{
						MessageBox.Show("Lỗi không thể chỉnh sửa tài khoản: " + responseContent);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Không thể chỉnh sửa tài khoản vì " + ex.Message);
				}
			}
			//if (txtUsername.Text == "" || txtDisplayName.Text == "")
			//{
			//	MessageBox.Show("Bạn chưa nhập thay đổi!");
			//	return;
			//}
			//else
			//{
			//	DataProvider.Instance.ExecuteQuery("Update Account set username = N'"
			//	+ txtUsername.Text + "', displayname = N'" + txtDisplayName.Text + "', type = " + nmTypeAccount.Value + "" +
			//	" Where username = N'" + txtUsername.Text + "' OR displayname = '" + txtDisplayName.Text + "' OR type = " + nmTypeAccount.Value + "");
			//	LoadAccountList();
			//}
		}
		private async void btnDeleteAccout_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtUsername.Text))
			{
				MessageBox.Show("Bạn chưa chọn tài khoản muốn xóa!");
				return;
			}
			else
			{
				try
				{
					if (MessageBox.Show("Bạn có thực sự muốn xóa tài khoản này?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						string apiUrl = "http://127.0.0.1:3333/account/delete?UserName=" + txtUsername.Text;
						HttpResponseMessage response = await client.DeleteAsync(apiUrl);
						string responseContent = await response.Content.ReadAsStringAsync();
						if (response.IsSuccessStatusCode)
						{
							MessageBox.Show("Xoá tài khoản thành công");
							LoadAccountList();
						}
						else
						{
							MessageBox.Show("Lỗi không thể xóa tài khoản ");
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Không thể xóa tài khoản vì " + ex.Message);
				}
			}
			//if (txtUsername.Text == "" || txtDisplayName.Text == "")
			//{
			//	MessageBox.Show("Bạn chưa chọn tài khoản muốn xóa!");
			//	return;
			//}
			//else
			//{
			//	if (MessageBox.Show("Bạn có thực sự muốn tài khoản này?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			//	{
			//		DataProvider.Instance.ExecuteQuery("Delete from Account Where UserName = N'" + txtUsername.Text + "' AND DisplayName = N'" + txtDisplayName.Text + "' ");
			//	}
			//	else
			//	{
			//		return;
			//	}
			//	LoadAccountList();
			//}
		}
		#endregion

		
	}
}
