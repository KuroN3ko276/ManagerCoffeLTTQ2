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

namespace ManageCafe.Admin
{
    public partial class fFood : Form
    {
        public fFood()
        {
            InitializeComponent();
        }
        public List<fFood> GetListFood()
        {
            List<fFood> list = new List<fFood> ();
            string query = "select * from fFood";
            DataTable data= DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow dr in data.Rows) 
            {
               fFood food= new fFood();
                list.Add(food);
            }
            return list;
        }
		private void btnAddFood_Click(object sender, EventArgs e)
		{

		}
         void LoadListFood()
        {
            dtgvFood.DataSource = GetListFood();
        }
		private void btnShowFood_Click(object sender, EventArgs e)
		{
            LoadListFood();
		}
	}
}
