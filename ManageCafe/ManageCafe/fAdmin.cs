using ManageCafe.Admin;
using ManageCafe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageCafe
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
            LoadDateTimePickerBill();
			LoadAccountList();
            LoadBillList(dtpkFromDate.Value, dtpkToDate.Value);
            LoadCategoryList();
            LoadFoodList();
            FillCategoryIntoCombobox();
			LoadTableFoodList();

		}
		#region methods
		void LoadAccountList()
        {
			//string query = "EXEC dbo.USP_GetAccountByUserName @userName";
			string query = "select UserName,Displayname,Type from Account ";
            dtgvAccount.DataSource =DataProvider.Instance.ExecuteQuery(query);

        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }
        void LoadBillList(DateTime checkIn, DateTime checkOut)
        {
            string query = "EXEC dbo.USP_GetListBillByDate @checkIn , @checkOut";

            dtgvBill.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] {checkIn,checkOut});
		}
		void LoadCategoryList()
        {
            string query = "Select * from foodcategory";
            dtgvCategory.DataSource = DataProvider.Instance.ExecuteQuery(query);
            txtCategoryID.Text = "";
            txtCategoryName.Text = "";
		}
		#endregion

		#region events
		private void btnViewBill_Click(object sender, EventArgs e)
		{
            LoadBillList(dtpkFromDate.Value,dtpkToDate.Value);
		}

		private void btnShowCategory_Click(object sender, EventArgs e)
		{
            LoadCategoryList();
		}

		private void btnAddCategory_Click(object sender, EventArgs e)
		{
            try
            {
                DataTable check = DataProvider.Instance.ExecuteQuery("Select * from foodcategory Where name = N'" + txtCategoryName.Text + "'");
                if(check.Rows.Count == 0) // Chua co ma name foodcategory do
                {
					if (txtCategoryName.Text == "")
					{
						MessageBox.Show("Bạn chưa nhập tên danh mục!");
						txtCategoryName.Focus();
                    }
                    else
                    {
						string code = "Insert into foodcategory(name) values(N'"+ txtCategoryName.Text + "')";
                        int result = DataProvider.Instance.ExecuteNonQuery(code);
                        if(result > 0)
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
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thêm category mới vì "+ex.Message+"");
            }
		}

		private void btnEditCategory_Click(object sender, EventArgs e)
		{
            DataProvider.Instance.ExecuteQuery("Update foodcategory set Name = N'" 
                + txtCategoryName.Text + "' where id = " + int.Parse(txtCategoryID.Text) + "");
			LoadCategoryList();
		}


		private void dtgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			txtCategoryID.Text = dtgvCategory.CurrentRow.Cells[0].Value.ToString();
			txtCategoryName.Text = dtgvCategory.CurrentRow.Cells[1].Value.ToString();
		}

		private void btnDeleteCategory_Click(object sender, EventArgs e)
		{
            int result = DataProvider.Instance.ExecuteNonQuery("Select * from food Where idCategory = "+int.Parse(txtCategoryID.Text)+"");
            if(result > 0)
            {
                MessageBox.Show("Danh mục này đã có sản phẩm");
                return;          
			}
			else
			{
                if(MessageBox.Show("Bạn có thực sự muốn xóa danh mục này?","Message",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
				    DataProvider.Instance.ExecuteQuery("Delete foodcategory Where id = " + int.Parse(txtCategoryID.Text) + " AND Name = N'" + txtCategoryName.Text + "'");
                }
                else
                {
                    return;
                }
			}
			LoadCategoryList() ;
		}
		#endregion
		// nong hoangminh

		void LoadFoodList()
		{
			string query = "Select * from Food";
			dtgvFood.DataSource = DataProvider.Instance.ExecuteQuery(query);
            cbFoodCategory.Items.Clear();
            txtFoodID.Text = "";
            txtFoodName.Text = "";
            nmFoodPrice.Value = 0;
		}
		private void btnShowFood_Click(object sender, EventArgs e)
		{
            LoadFoodList();
			
		}
        
        void FillComBoBox(ComboBox cbname,DataTable data,string displayMember,string valueMember)
        {
            cbname.DataSource = data;
            cbname.DisplayMember=displayMember;
            cbname.ValueMember=valueMember;
        }
        void FillCategoryIntoCombobox()
        {
            DataTable dtCategory = DataProvider.Instance.ExecuteQuery("select * from FoodCategory");
            FillComBoBox(cbFoodCategory,dtCategory,"Name","ID");
        }

		private void dtgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
		{
            txtFoodID.Text = dtgvFood.CurrentRow.Cells[0].Value.ToString();
            txtFoodName.Text= dtgvFood.CurrentRow.Cells[1].Value.ToString();
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
				else if (cbFoodCategory.SelectedValue==null) 
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
					string code = "Insert into food(name,idcategory,price) values(N'" + txtFoodName.Text + "','"+cbFoodCategory.SelectedValue+"','"+nmFoodPrice.Value+"')";
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

		private void btnDeleteFood_Click(object sender, EventArgs e)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("Select * from billinfo Where idfood = " + txtFoodID.Text+ "");
			if (result > 0)
			{
				MessageBox.Show("Món này không được xoá");
				return;
			}
			else
			{
				if (MessageBox.Show("Bạn có thực sự muốn xóa món này này?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					DataProvider.Instance.ExecuteQuery("Delete food Where id = " + int.Parse(txtFoodID.Text) + " AND Name = N'" + txtFoodName.Text + "'");
				}
				else
				{
					return;
				}
			}
			LoadFoodList();
		}

		private void btnEditFood_Click(object sender, EventArgs e)
		{
			DataProvider.Instance.ExecuteQuery("Update food set name = N'"
				+ txtFoodName.Text + "', idCategory = "+int.Parse(cbFoodCategory.Text)+", price = "+nmFoodPrice.Value+" where id = "+int.Parse(txtFoodID.Text)+"");
			LoadFoodList();
		}


		void LoadTableFoodList() { 
			string query = "Select * from TableFood";
			dtgvTable.DataSource = DataProvider.Instance.ExecuteQuery(query);
			txtTableID.Text = "";
			txtTableName.Text = "";
			//cbTableStatus.Items.Clear();
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
			DataTable check = DataProvider.Instance.ExecuteQuery("Select * from tablefood Where name = N'" + txtTableName.Text + "'");
			if (check.Rows.Count == 0) // Chua co ma name table do
			{
				if (txtTableName.Text == "")
				{
					MessageBox.Show("Bạn chưa nhập tên bàn!");
					txtTableName.Focus();
				}
				else if (cbTableStatus.Text == "")
				{
					MessageBox.Show("Bạn chưa chọn trạng thái bàn!");
					cbTableStatus.Focus();
				}
				else
				{
					string code = "Insert into tablefood(name,status) values(N'" + txtTableName.Text + "','" + cbTableStatus.Text + "')";
					/* DataProvider.Instance.ExecuteQuery(code);
					 LoadFoodList();*/
					int result = DataProvider.Instance.ExecuteNonQuery(code);
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

		private void btnDeleteTable_Click(object sender, EventArgs e)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("Select * from bill Where idtable = " + txtTableID.Text + "");
			if (result > 0)
			{
				MessageBox.Show("Bàn này không được xoá");
				return;
			}
			else
			{
				if (MessageBox.Show("Bạn có thực sự muốn xóa bàn này?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					DataProvider.Instance.ExecuteQuery("Delete tablefood Where id = " + int.Parse(txtTableID.Text) + " AND Name = N'" + txtTableName.Text + "'");
				}
				else
				{
					return;
				}
			}
			LoadTableFoodList();
		}

		private void btnEditTable_Click(object sender, EventArgs e)
		{
			DataProvider.Instance.ExecuteQuery("Update TableFood set name = N'"
				+ txtTableName.Text + "', status=" + cbTableStatus.Text+ " where id = " + int.Parse(txtTableID.Text) + "");
			LoadTableFoodList();
		}

		private void btnShowAccount_Click(object sender, EventArgs e)
		{
			LoadAccountList();
		}

		private void dtgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			txtUsername.Text = dtgvAccount.CurrentRow.Cells[0].Value.ToString();
			txtDisplayName.Text = dtgvAccount.CurrentRow.Cells[1].Value.ToString();
			nmTypeAccount.Text = dtgvAccount.CurrentRow.Cells[2].Value.ToString();
		}

		private void btnAddAccount_Click(object sender, EventArgs e)
		{
			DataTable check = DataProvider.Instance.ExecuteQuery("Select * from Account Where username = N'" + txtUsername.Text + "'");
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
					string code = "Insert into Account(userame,displayname,type) values(N'" + txtUsername.Text + "','" + txtDisplayName.Text + "','"+nmTypeAccount.Value+"')";
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

		private void btnDeleteAccout_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Bạn có thực sự muốn xóa bàn này?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				DataProvider.Instance.ExecuteQuery("Delete Account Where UserName = N'" + txtUsername.Text + "' AND DisplayName = N'" + txtDisplayName.Text + "' ");
			}
			else
			{
				return;
			}
			LoadAccountList();
		}

		private void btnResetPassword_Click(object sender, EventArgs e)
		{
			string query = "Update account set password=N'1'";
			DataProvider.Instance.ExecuteQuery(query);
		}
	}
}
