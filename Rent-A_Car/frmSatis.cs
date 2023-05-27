using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rent_A_Car
{
    public partial class frmSatis : Form
    {
        public frmSatis()
        {
            InitializeComponent();
        }
        cArac_Kiralama arackirala = new cArac_Kiralama();
        private void frmSatis_Load(object sender, EventArgs e)
        {
            string sorgu = "select * from satis";
            SqlDataAdapter adtr = new SqlDataAdapter();
            dataGridView1.DataSource = arackirala.listele(adtr, sorgu);
            arackirala.satis_hesapla(label1);
        }
    }
}
