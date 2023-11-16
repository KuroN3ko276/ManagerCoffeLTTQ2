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

namespace ManageCafe
{
    public partial class fTableManage : Form
    {
        public fTableManage()
        {
            InitializeComponent();
			LoadTable();
		}

		#region Methods
		void LoadTable() 
		{
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
		#endregion

		#region Events

		private void Btn_TableClick(object sender, EventArgs e)
		{
			int tableID = ((sender as Button).Tag as Table).ID;
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


		#endregion

	}
}
