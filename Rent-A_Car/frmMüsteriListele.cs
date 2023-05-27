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
    public partial class frmMüsteriListele : Form
    {
        cArac_Kiralama arac_Kiralama = new cArac_Kiralama();
        public frmMüsteriListele()
        {
            InitializeComponent();
        }

        private void frmMüsteriListele_Load(object sender, EventArgs e)
        {
            YenileListele();

        }

        private void YenileListele()
        {
            string cümle = "select * from müşteriler";
            SqlDataAdapter adtr = new SqlDataAdapter();
            dataGridView1.DataSource = arac_Kiralama.listele(adtr, cümle);
            dataGridView1.Columns[0].HeaderText = "tc";
            dataGridView1.Columns[1].HeaderText = "adsoyad";
            dataGridView1.Columns[2].HeaderText = "telefon";
            dataGridView1.Columns[3].HeaderText = "email";
            dataGridView1.Columns[4].HeaderText = "adres";
        }

        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            string cümle = "select * from müşteriler where tc like '%" + txtTcAra.Text + "%'";
            SqlDataAdapter adtr = new SqlDataAdapter();
            dataGridView1.DataSource = arac_Kiralama.listele(adtr, cümle);
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string cümle = "update müşteri set adsoyad=@adsoyad,telefon=@telefon,adres=@adres,email=@email where tc=@tc";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("tc", txtTc.Text);
            komut2.Parameters.AddWithValue("adsoyad", txtAdSoyad.Text);
            komut2.Parameters.AddWithValue("telefon", txtTelefon.Text);
            komut2.Parameters.AddWithValue("adres", txtAdres.Text);
            komut2.Parameters.AddWithValue("email", txtEmail.Text);
            arac_Kiralama.ekle_sil_guncelle(komut2, cümle);
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            YenileListele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            txtTc.Text = satır.Cells[0].Value.ToString();
            txtAdSoyad.Text = satır.Cells[1].Value.ToString();
            txtTelefon.Text = satır.Cells[2].Value.ToString();
            txtEmail.Text = satır.Cells[3].Value.ToString();
            txtAdres.Text = satır.Cells[4].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            string cümle = "delete from müşteri where tc='" + satır.Cells["tc"].Value.ToString() + "'";
            SqlCommand komut2 = new SqlCommand();
            arac_Kiralama.ekle_sil_guncelle(komut2, cümle);
            YenileListele();
        }
    }
}
