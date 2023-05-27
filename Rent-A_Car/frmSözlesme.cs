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
    public partial class frmSözlesme : Form
    {
        public frmSözlesme()
        {
            InitializeComponent();
        }
        cArac_Kiralama arac = new cArac_Kiralama();
        private void frmSözlesme_Load(object sender, EventArgs e)
        {
            Bos_Araclar();
            Yenile();
        }

        private void Bos_Araclar()
        {
            string sorgu2 = "select * from where durumu='BOŞ'";
            arac.Bos_Araclar(cmbAraclar, sorgu2);
        }

        private void Yenile()
        {
            string sorgu3 = "select * from sözlesme";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = arac.listele(adtr2, sorgu3);
        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {


        }

        private void cmbAraclar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorgu2 = "select * from arac where plaka like '" + cmbAraclar.SelectedItem + "'";
            arac.CombodanGetir(cmbAraclar, txtMarka, txtSeri, txtYil, txtRenk, sorgu2);
        }

        private void cmbKiraSekli_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorgu2 = "select * from arac where plaka like '" + cmbAraclar.SelectedItem + "'";
            arac.Ucret_Hesapla(cmbKiraSekli, txtKiraUcreti, sorgu2);
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            TimeSpan gun = DateTime.Parse(dateDonusTarihi.Text) - DateTime.Parse(dateCikisTarihi.Text);
            int gun2 = gun.Days;
            txtGun.Text = gun2.ToString();
            txtTutar.Text = (gun2 * int.Parse(txtKiraUcreti.Text)).ToString();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            dateCikisTarihi.Text = DateTime.Now.ToShortDateString();
            dateDonusTarihi.Text = DateTime.Now.ToShortDateString();
            cmbKiraSekli.Text = "";
            txtKiraUcreti.Text = "";
            txtGun.Text = "";
            txtTutar.Text = "";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string sorgu2 = "insert into sözlesme(tc,adsoyad,telefon,ehliyetno,e_tarih,e_yer,plaka,marka,seri,yil,renk,kirasekli,kiraucreti,gun,tutar,ctarih,dtarih) values(@tc,@adsoyad,@telefon,@ehliyetno,@e_tarih,@e_yer,@plaka,@marka,@seri,@yil,@renk,@kirasekli,@kiraucreti,@gun,@tutar,@ctarih,@dtarih)";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@tc", txtTc.Text);
            komut2.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut2.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut2.Parameters.AddWithValue("@ehliyetno", txtEhliyetno.Text);
            komut2.Parameters.AddWithValue("@e_tarih", txtEhliyetTarihi.Text);
            komut2.Parameters.AddWithValue("@e_yer", txtEVerildiğiYer.Text);
            komut2.Parameters.AddWithValue("@plaka", cmbAraclar.Text);
            komut2.Parameters.AddWithValue("@marka", txtMarka.Text);
            komut2.Parameters.AddWithValue("@seri", txtSeri.Text);
            komut2.Parameters.AddWithValue("@yil", txtYil.Text);
            komut2.Parameters.AddWithValue("@renk", txtRenk.Text);
            komut2.Parameters.AddWithValue("@kirasekli", cmbKiraSekli.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", txtKiraUcreti.Text);
            komut2.Parameters.AddWithValue("@gun", int.Parse(txtGun.Text));
            komut2.Parameters.AddWithValue("@tutar", int.Parse(txtTutar.Text));
            komut2.Parameters.AddWithValue("@ctarih", dateCikisTarihi.Text);
            komut2.Parameters.AddWithValue("@dtarih", dateDonusTarihi.Text);
            arac.ekle_sil_guncelle(komut2, sorgu2);

            string sorgu3 = "update arac set durumu='DOLU' where plaka='" + cmbAraclar.Text + "'";
            SqlCommand komut3 = new SqlCommand();
            arac.ekle_sil_guncelle(komut3, sorgu3);
            cmbAraclar.Items.Clear();
            Bos_Araclar();
            Yenile();
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            cmbAraclar.Text = "";
            Temizle();
            MessageBox.Show("Sözleşme Eklendi");
        }

        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            if (txtTcAra.Text == "")
            {
                foreach (Control item in groupBox1.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
            string sorgu2 = "select * from müşteri where tc like '" + txtTcAra.Text + "'";
            arac.TC_ARA(txtTcAra, txtAdSoyad, txtTc, txtTelefon, sorgu2);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string sorgu2 = "update sözlesme set tc=@tc,adsoyad=@adsoyad,telefon=@telefon,ehliyeno=@ehliyetno,e_tarih=@e_tarih,e_yer=@e_yer,marka=@marka,seri=@seri,yil=@yil,renk=@renk,kirasekli=@kirasekli,kiraucreti=@kiraucreti,gun=@gun,tutar=@tutar,ctarih=@ctarih,dtarih=@dtarih  where plaka=@plaka";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@tc", txtTc.Text);
            komut2.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut2.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut2.Parameters.AddWithValue("@ehliyetno", txtEhliyetno.Text);
            komut2.Parameters.AddWithValue("@e_tarih", txtEhliyetTarihi.Text);
            komut2.Parameters.AddWithValue("@e_yer", txtEVerildiğiYer.Text);
            komut2.Parameters.AddWithValue("@plaka", cmbAraclar.Text);
            komut2.Parameters.AddWithValue("@marka", txtMarka.Text);
            komut2.Parameters.AddWithValue("@seri", txtSeri.Text);
            komut2.Parameters.AddWithValue("@yil", txtYil.Text);
            komut2.Parameters.AddWithValue("@renk", txtRenk.Text);
            komut2.Parameters.AddWithValue("@kirasekli", cmbKiraSekli.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", txtKiraUcreti.Text);
            komut2.Parameters.AddWithValue("@gun", int.Parse(txtGun.Text));
            komut2.Parameters.AddWithValue("@tutar", int.Parse(txtTutar.Text));
            komut2.Parameters.AddWithValue("@ctarih", dateCikisTarihi.Text);
            komut2.Parameters.AddWithValue("@dtarih", dateDonusTarihi.Text);
            arac.ekle_sil_guncelle(komut2, sorgu2);

            cmbAraclar.Items.Clear();
            Bos_Araclar();
            Yenile();
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            cmbAraclar.Text = "";
            Temizle();
            MessageBox.Show("Sözleşme Güncellendi");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            txtTc.Text = satır.Cells[0].Value.ToString();
            txtAdSoyad.Text = satır.Cells[1].Value.ToString();
            txtTelefon.Text = satır.Cells[2].Value.ToString();
            txtEhliyetno.Text = satır.Cells[3].Value.ToString();
            txtEhliyetTarihi.Text = satır.Cells[4].Value.ToString();
            txtEVerildiğiYer.Text = satır.Cells[5].Value.ToString();
            cmbAraclar.Text = satır.Cells[6].Value.ToString();
            txtMarka.Text = satır.Cells[7].Value.ToString();
            txtSeri.Text = satır.Cells[8].Value.ToString();
            txtYil.Text = satır.Cells[9].Value.ToString();
            txtRenk.Text = satır.Cells[10].Value.ToString();
            cmbKiraSekli.Text = satır.Cells[11].Value.ToString();
            txtKiraUcreti.Text = satır.Cells[12].Value.ToString();
            txtGun.Text = satır.Cells[13].Value.ToString();
            txtTutar.Text = satır.Cells[14].Value.ToString();
            dateCikisTarihi.Text = satır.Cells[15].Value.ToString();
            dateDonusTarihi.Text = satır.Cells[16].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            //Gün farkı hesaplama
            DateTime bugün = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime dönüs = DateTime.Parse(satır.Cells["dtarih"].Value.ToString());
            int ucret = int.Parse(satır.Cells["kiraucreti"].Value.ToString());
            TimeSpan gunfarkı = bugün - dönüs;
            int _gunfarkı = gunfarkı.Days;
            int ucretfarkı;
            //Ücret farkı hesaplama
            ucretfarkı = _gunfarkı * ucret;
            txtEkstra.Text = ucretfarkı.ToString();
            //Toplam tutar hesaplama
        }

        private void btnAracTeslim_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtEkstra.Text) >= 0 || int.Parse(txtEkstra.Text) < 0)
            {
                DataGridViewRow satır = dataGridView1.CurrentRow;
                DateTime bugün = DateTime.Parse(DateTime.Now.ToShortDateString());
                int tutar = int.Parse(satır.Cells["tutar"].Value.ToString());
                int ucret = int.Parse(satır.Cells["kiraucreti"].Value.ToString());
                DateTime cikis = DateTime.Parse(satır.Cells["ctarih"].Value.ToString());
                TimeSpan gun = bugün - cikis;
                int _gun = gun.Days;
                int toplamtutar = _gun * ucret; ;

                string sorgu1 = "delete from sözlesme where plaka='" + satır.Cells["plaka"].Value.ToString() + "'";
                SqlCommand komut = new SqlCommand();
                arac.ekle_sil_guncelle(komut, sorgu1);

                string sorgu2 = "update arac set durumu='BOŞ' where plaka ='" + satır.Cells["plaka"].Value.ToString() + "'";
                SqlCommand komut3 = new SqlCommand();
                arac.ekle_sil_guncelle(komut3, sorgu2);

                string sorgu3 = "insert into satis(tc,adsoyad,telefon,plaka,marka,seri,yil,renk,gun,fiyat,tutar,tarih1,tarih2) values(@tc,@adsoyad,@telefon,@plaka,@marka,@seri,@yil,@renk,@gun,@fiyat,@tutar,@tarih1,@tarih2)";
                SqlCommand komut2 = new SqlCommand();
                komut2.Parameters.AddWithValue("@tc", satır.Cells["tc"].Value.ToString());
                komut2.Parameters.AddWithValue("@adsoyad", satır.Cells["adsoyad"].Value.ToString());
                komut2.Parameters.AddWithValue("@telefon", satır.Cells["telefon"].Value.ToString());
                komut2.Parameters.AddWithValue("@plaka", satır.Cells["plaka"].Value.ToString());
                komut2.Parameters.AddWithValue("@marka", satır.Cells["marka"].Value.ToString());
                komut2.Parameters.AddWithValue("@seri", satır.Cells["seri"].Value.ToString());
                komut2.Parameters.AddWithValue("@yil", satır.Cells["yil"].Value.ToString());
                komut2.Parameters.AddWithValue("@renk", satır.Cells["renk"].Value.ToString());
                komut2.Parameters.AddWithValue("@gun", _gun);
                komut2.Parameters.AddWithValue("@fiyat", ucret);
                komut2.Parameters.AddWithValue("@tutar", toplamtutar);
                komut2.Parameters.AddWithValue("@tarih1", satır.Cells["ctarih"].Value.ToString());
                komut2.Parameters.AddWithValue("@tarih2", DateTime.Now.ToShortDateString());
                arac.ekle_sil_guncelle(komut2, sorgu3);

                MessageBox.Show("Araç Teslim Edildi");
                cmbAraclar.Items.Clear();
                Bos_Araclar();
                Yenile();
                foreach (Control item in groupBox1.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
                cmbAraclar.Text = "";
                Temizle();

                txtEkstra.Text = "";
            }
            else 
            {
                MessageBox.Show("Lütfen Seçim Yapınız", "Uyarı");
            }
        }
    }
}
