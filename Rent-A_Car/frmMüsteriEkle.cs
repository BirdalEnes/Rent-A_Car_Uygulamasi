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
    public partial class frmMüsteriEkle : Form
    {
        cArac_Kiralama arac_kiralama = new cArac_Kiralama();
        public frmMüsteriEkle()
        {
            InitializeComponent();
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string cümle = "insert into müşteri(tc,adsoyad,telefon,adres,email) values(@tc,@adsoyad,@telefon,@adres,@email)";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("tc", txtTc.Text);
            komut2.Parameters.AddWithValue("adsoyad", txtAdSoyad.Text);
            komut2.Parameters.AddWithValue("telefon", txtTelefon.Text);
            komut2.Parameters.AddWithValue("adres", txtAdres.Text);
            komut2.Parameters.AddWithValue("email", txtEmail.Text);
            arac_kiralama.ekle_sil_guncelle(komut2, cümle);
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = ""; 
                }
            }
        }

        private void frmMüsteriEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
