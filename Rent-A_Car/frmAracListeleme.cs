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
    public partial class frmAracListeleme : Form
    {
        cArac_Kiralama arackiralama = new cArac_Kiralama();
        public frmAracListeleme()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            txtPlaka.Text = satır.Cells["plaka"].Value.ToString();
            cmbMarka.Text = satır.Cells["maraka"].Value.ToString();
            cmbSeri.Text = satır.Cells["seri"].Value.ToString();
            txtModel.Text = satır.Cells["yil"].Value.ToString();
            txtRenk.Text = satır.Cells["renk"].Value.ToString();
            txtKm.Text = satır.Cells["km"].Value.ToString();
            cmbYakıt.Text = satır.Cells["yakit"].Value.ToString();
            txtKiraUcreti.Text = satır.Cells["kiraucreti"].Value.ToString();
            pictureBox2.ImageLocation = satır.Cells["resim"].Value.ToString();

        }

        private void frmAracListeleme_Load(object sender, EventArgs e)
        {
            YenileAraclarListesi();
            cmbAraçlar.SelectedIndex = 0;
        }

        private void YenileAraclarListesi()
        {
            string cümle = "select * from arac";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
        }

        private void btnResim_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation = openFileDialog1.FileName;

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string cümle = "update  arac set marka=@marka,seri=@seri,yil=@yil,renk=@renk,km=@km,yakit=@yakit,kiraucreti=@kiraucreti,resim=@resim,tarih=@tarih where plaka=@plaka";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@plaka", txtPlaka.Text);
            komut2.Parameters.AddWithValue("@marka", cmbMarka.Text);
            komut2.Parameters.AddWithValue("@sei", cmbSeri.Text);
            komut2.Parameters.AddWithValue("@yil", txtModel.Text);
            komut2.Parameters.AddWithValue("@renk", txtRenk.Text);
            komut2.Parameters.AddWithValue("@km", txtKm.Text);
            komut2.Parameters.AddWithValue("@yakit", cmbYakıt.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", int.Parse(txtKiraUcreti.Text));
            komut2.Parameters.AddWithValue("@resim", pictureBox2.ImageLocation);
            komut2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
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
            pictureBox2.ImageLocation = "";
            YenileAraclarListesi();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            string cümle = "delete from arac where plaka='" + satır.Cells["plaka"].Value.ToString() + "'";
            SqlCommand komut2 = new SqlCommand();
            arackiralama.ekle_sil_guncelle(komut2, cümle);
            YenileAraclarListesi();
            pictureBox2.ImageLocation = "";
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

        private void cmbAraçlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbAraçlar.SelectedIndex == 0)
                {
                    YenileAraclarListesi();
                }
                if (cmbAraçlar.SelectedIndex == 1)
                {
                    string cümle = "select * from arac where durumu='BOŞ'";
                    SqlDataAdapter adtr2 = new SqlDataAdapter();
                    dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
                }
                if (cmbAraçlar.SelectedIndex == 2)
                {
                    string cümle = "select * from arac where durumu=DOLU";
                    SqlDataAdapter adtr2 = new SqlDataAdapter();
                    dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
                }
            }
            catch
            {
                ;
            }
        }
    }
}
