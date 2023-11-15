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
            LoadAccountList();
        }

        void LoadAccountList()
        {
            string query = "EXEC dbo.USP_GetAccountByUserName @userName";

            

            dtgvAccount.DataSource =DataProvider.Instance.ExecuteQuery(query, new object[] {"staff"});

        }

        //void loadfoodcategory()
        //{
        //    string query = "select * from dbo.foodcategory";

        //    dataprovider provider = new dataprovider();

        //    dtgvcategory.datasource = provider.executequery(query);

        //}



    }
}
