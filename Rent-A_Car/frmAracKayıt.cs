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
    public partial class frmAracKayıt : Form
    {
        cArac_Kiralama arackiralama = new cArac_Kiralama();
        public frmAracKayıt()
        {
            InitializeComponent();
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void cmbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbSeri.Items.Clear();
                if (cmbMarka.SelectedItem.ToString() == "Opel")
                {
                    cmbSeri.Items.Add("Astra");
                    cmbSeri.Items.Add("Vectra");
                    cmbSeri.Items.Add("Corsa");
                }
                else if (cmbMarka.SelectedIndex == 1)
                {
                    cmbSeri.Items.Add("Megane");
                    cmbSeri.Items.Add("clio");
                }
                else if (cmbMarka.SelectedIndex == 2)
                {
                    cmbSeri.Items.Add("Egea");
                    cmbSeri.Items.Add("Cross");
                    cmbSeri.Items.Add("Linea");
                }
                else if (cmbMarka.SelectedIndex == 3)
                {
                    cmbSeri.Items.Add("Fiesta");
                    cmbSeri.Items.Add("Focus");
                    cmbSeri.Items.Add("Tourneo");
                }
            }
            catch
            {

                ;
            }
        }

        private void btnKayıt_Click(object sender, EventArgs e)
        {
            string cümle = "insert into arac(plaka,marka,sei,yil,renk,km,yakit,kiraucreti,resim,tarih,durumu) values(@plaka,@marka,@sei,@yil,@renk,@km,@yakit,@kiraucreti,@resim,@tarih,@durumu)";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@plaka", txtPlaka.Text);
            komut2.Parameters.AddWithValue("@marka", cmbMarka.Text);
            komut2.Parameters.AddWithValue("@sei", cmbSeri.Text);
            komut2.Parameters.AddWithValue("@yil", txtModel.Text);
            komut2.Parameters.AddWithValue("@renk", txtRenk.Text);
            komut2.Parameters.AddWithValue("@km", txtKm.Text);
            komut2.Parameters.AddWithValue("@yakit", cmbYakıt.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", int.Parse(txtKiraUcreti.Text));
            komut2.Parameters.AddWithValue("@resim", pictureBox1.ImageLocation);
            komut2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            komut2.Parameters.AddWithValue("@durumu", "BOŞ");
            arackiralama.ekle_sil_guncelle(komut2, cümle);
            cmbSeri.Items.Clear();
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            pictureBox1.ImageLocation = "";
        }

        private void frmAracKayıt_Load(object sender, EventArgs e)
        {
           
        }
    }
}
