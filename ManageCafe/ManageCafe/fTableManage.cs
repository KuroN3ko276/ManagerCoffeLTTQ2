using ManageCafe.DAO;
using ManageCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static ManageCafe.fAccountProfile;
using Newtonsoft.Json;
using System.Net.Http;

namespace ManageCafe
{
	public partial class fTableManage : Form
	{
		private Account loginAccount;
        
        

        public Account LoginAccount
		{

			get { return loginAccount; }
			set { loginAccount = value; changeAcccount(loginAccount.Type); }
		}

		public fTableManage(Account acc)
		{
			InitializeComponent();

			this.LoginAccount = acc;

			LoadTable();
			LoadCategory();
			LoadComboboxTable(cbSwitchTable);
		}
     

        #region Methods
        void changeAcccount(int type)
		{
			adminToolStripMenuItem.Enabled = type == 1;
			thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
		}


		void LoadTable()
		{

			flpTable.Controls.Clear();
			List<Table> tableList = TableDAO.Instance.LoadTableList();
			foreach (Table table in tableList)
			{
				Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
				btn.Text = table.Name + Environment.NewLine + table.Status;
				btn.Click += Btn_TableClick;
				btn.Tag = table;

				switch (table.Status)
				{
					case "Trống":
						btn.BackColor = Color.LightGreen;
						break;
					default:
						btn.BackColor = Color.LightPink;
						break;
				}

				flpTable.Controls.Add(btn);
			}
		}

		void showBill(int id)
		{
			lsvBill.Items.Clear();
			List<ManageCafe.DTO.Menu> listMenu = MenuDAO.Instance.GetListMenuByTable(id);
			float totalPrice = 0;
			foreach (ManageCafe.DTO.Menu item in listMenu)
			{
				ListViewItem lsvItem = new ListViewItem(item.Name.ToString());
				lsvItem.SubItems.Add(item.Count.ToString());
				lsvItem.SubItems.Add(item.Price.ToString());
				lsvItem.SubItems.Add(item.Totalprice.ToString());
				totalPrice += item.Totalprice;
				lsvBill.Items.Add(lsvItem);
			}
			CultureInfo cultureInfo = new CultureInfo("vi-VN");
			txbTotalPrice.Text = totalPrice.ToString("c", cultureInfo);

		}

		void LoadCategory() //Load loại đồ ăn
		{
			List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
			cbCategory.DataSource = listCategory;
			cbCategory.DisplayMember = "Name";
		}

		void LoadFoodListByCategoryID(int id) //Load đồ ăn theo loại 
		{
			List<Food> listFood = FoodDAO.Instance.GetListFoodByCategoryID(id);
			cbFood.DataSource = listFood;
			cbFood.DisplayMember = "Name";
		}

		void LoadComboboxTable(ComboBox cb)
		{
			cb.DataSource = TableDAO.Instance.LoadTableList();
			cb.DisplayMember = "Name";
		}

		void ExportFileExcel()
		{
			Table table = lsvBill.Tag as Table;
			int idBill = BillDAO.Instance.GetBillIDByTableID(table.ID);
			int discount = (int)nmDiscount.Value;

			double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0].Replace(".", ""));
			double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;

			SaveFileDialog file = new SaveFileDialog();
			Excel.Application exApp = new Excel.Application();
			Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
			Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
			Excel.Range tenTruong = (Excel.Range)exSheet.Cells[1, 1]; //Đưa con trỏ vào ô A1
																	  //Đưa dữ liệu vào file Excel

			string query = "select Food.id as idfood,Food.name,count,Food.price,(count * price) as totalPrice,TableFood.id as idtable from bill join BillInfo on bill.id=BillInfo.idBill join TableFood on TableFood.id=Bill.idTable join food on Food.id=BillInfo.idFood where tablefood.id=" + table.ID + " and Bill.status = 0";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			tenTruong.Range["A1:D1"].MergeCells = true;
			tenTruong.Range["A1"].Value = "CẬU CHÍNH COFFEE";
			tenTruong.Range["A2"].Value = "Địa chỉ: Cầu Giấy - Hà Nội";
			tenTruong.Range["A3"].Value = "Điện thoại: 088888888";
			tenTruong.Range["c5:f5"].MergeCells = true;
			tenTruong.Range["C5:F5"].Font.Size = 18;
			tenTruong.Range["C5:F5"].Font.Color = System.Drawing.Color.Red;
			tenTruong.Range["C5"].Value = "HÓA ĐƠN BÁN";
			tenTruong.Range["A7"].Value = "Mã HĐ: " + idBill;
			tenTruong.Range["A8"].Value = "Tên bàn: " + table.Name;
			tenTruong.Range["B10"].Value = "Mã Hàng ";
			tenTruong.Range["C10"].Value = "Tên hàng ";
			tenTruong.Range["D10"].Value = "Số lượng ";
			tenTruong.Range["E10"].Value = "Đơn giá bán ";
			tenTruong.Range["F10"].Value = "Thành tiền ";
			int hang = 10;
			for (int i = 0; i < data.Rows.Count; i++)
			{
				hang++;
				tenTruong.Range["A" + hang.ToString()].Value = (i + 1).ToString();
				tenTruong.Range["B" + hang.ToString()].Value = data.Rows[i]["idfood"];
				tenTruong.Range["C" + hang.ToString()].Value = data.Rows[i]["name"];
				tenTruong.Range["D" + hang.ToString()].Value = data.Rows[i]["count"];
				tenTruong.Range["E" + hang.ToString()].Value = data.Rows[i]["price"];
				tenTruong.Range["F" + hang.ToString()].Value = data.Rows[i]["totalprice"];

			}
			tenTruong.Range["D" + (hang + 1).ToString()].Value = "Giảm giá: " + discount;
			tenTruong.Range["C" + (hang + 2).ToString()].Value = "Tổng tiền: " + finalTotalPrice;

			exSheet.Name = "HoaDonBan";
			exBook.Activate();
			if (file.ShowDialog() == DialogResult.OK)
				exBook.SaveAs(file.FileName.ToString());
			exApp.Quit();

		}
		#endregion

		#region Events

		private void Btn_TableClick(object sender, EventArgs e)
		{
			int tableID = ((sender as Button).Tag as Table).ID;
			lsvBill.Tag = (sender as Button).Tag;
			showBill(tableID);
		}

		private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
		{
			fAccountProfile f = new fAccountProfile(LoginAccount);
			f.UpdateAccount += F_UpdateAccount;
			f.ShowDialog();
		}

		private void F_UpdateAccount(object sender, AccountEvent e)
		{
			thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";
		}

		private void adminToolStripMenuItem_Click(object sender, EventArgs e)
		{
			fAdmin f = new fAdmin();
			f.ShowDialog();
		}

		private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Admin.fDoanhThu f = new Admin.fDoanhThu();
			f.ShowDialog();
		}

		private void thứcĂnToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Admin.fFood f = new Admin.fFood();
			f.ShowDialog();
		}

		private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Admin.fDanhMuc f = new Admin.fDanhMuc();
			f.ShowDialog();
		}

		private void bànĂnToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Admin.fBanAn f = new Admin.fBanAn();
			f.ShowDialog();
		}

		private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Admin.fTaiKhoan f = new Admin.fTaiKhoan();
			f.ShowDialog();
		}

		private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			int id = 0;

			ComboBox cb = sender as ComboBox;

			if (cb.SelectedIndex == null) return;

			Category selected = cb.SelectedItem as Category;
			id = selected.ID;
			LoadFoodListByCategoryID(id);
		}

		private void btnAddFood_Click(object sender, EventArgs e)
		{
			Table table = lsvBill.Tag as Table;

			int idBill = BillDAO.Instance.GetBillIDByTableID(table.ID);
			int foodID = (cbFood.SelectedItem as Food).ID;
			int count = (int)nmFoodCount.Value;

			if (idBill == -1)
			{
				BillDAO.Instance.InsertBill(table.ID);
				BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
			}
			else
			{
				BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
			}
			showBill(table.ID);
			LoadTable();
		}
		private void btnCheckOut_Click(object sender, EventArgs e)
		{
			Table table = lsvBill.Tag as Table;
			int idBill = BillDAO.Instance.GetBillIDByTableID(table.ID);
			int discount = (int)nmDiscount.Value;

			double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0].Replace(".", ""));
			double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;

			if (idBill != -1)
			{
				if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn {0}", table.Name), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					ExportFileExcel();
					BillDAO.Instance.CheckOut(idBill, discount, (float)finalTotalPrice);
					showBill(table.ID);
					LoadTable();

				}
			}

		}
		private void btnSwitchTable_Click(object sender, EventArgs e)
		{

			int id1 = (lsvBill.Tag as Table).ID;

			int id2 = (cbSwitchTable.SelectedItem as Table).ID;
			if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển bàn {0} qua bàn {1}", (lsvBill.Tag as Table).Name, (cbSwitchTable.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
			{
				TableDAO.Instance.SwitchTable(id1, id2);

				LoadTable();
			}
		}
		#endregion

	}
}
