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
<<<<<<< Updated upstream
            LoadDateTimePickerBill();
			LoadAccountList();
            LoadBillList(dtpkFromDate.Value, dtpkToDate.Value);
            LoadCategoryList();
        }
		#region methods
		void LoadAccountList()
        {
            string query = "EXEC dbo.USP_GetAccountByUserName @userName";

            dtgvAccount.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] {"staff"}); // Singleton

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
=======
        }

>>>>>>> Stashed changes

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
	}
}
