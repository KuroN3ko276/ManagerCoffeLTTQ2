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

namespace ManageCafe
{
    public partial class fTableManage : Form
    {
        public fTableManage()
        {
            InitializeComponent();
			LoadTable();
			LoadCategory();
			LoadComboboxTable(cbSwitchTable);
		}

		#region Methods
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

				switch(table.Status)
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
			foreach(ManageCafe.DTO.Menu item in listMenu)
			{
				ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
				lsvItem.SubItems.Add(item.Count.ToString());
				lsvItem.SubItems.Add(item.Price.ToString());
				lsvItem.SubItems.Add(item.Totalprice.ToString());
				totalPrice += item.Totalprice;
				lsvBill.Items.Add(lsvItem);
			}
			CultureInfo cultureInfo = new CultureInfo("vi-VN");
			txbTotalPrice.Text = totalPrice.ToString("c",cultureInfo);

		}

		void LoadCategory()	//Load loại đồ ăn
		{
			List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
			cbCategory.DataSource = listCategory;
			cbCategory.DisplayMember = "Name";
		}

		void LoadFoodListByCategoryID(int id) //Load đồ ăn theo loại 
		{
			List<Food> listFood = FoodDAO.Instance.GetListFoodByBategoryID(id);
			cbFood.DataSource = listFood;
			cbFood.DisplayMember = "Name";
		}

		void LoadComboboxTable(ComboBox cb)
		{
			cb.DataSource = TableDAO.Instance.LoadTableList();
			cb.DisplayMember = "Name";
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
			fAccountProfile f = new fAccountProfile();
			f.ShowDialog();
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
				BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(),foodID,count);
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
				if(MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn {0}\nTổng tiền - (Tổng tiền / 100) x Giảm giá\n=> {1} - ({1} / 100) x {2} = {3}", table.Name, totalPrice, discount, finalTotalPrice),"Thông báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
				{

					BillDAO.Instance.CheckOut(idBill,discount);
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
