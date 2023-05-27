using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Rent_A_Car
{
    internal class cArac_Kiralama
    {
        SqlConnection baglanti = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Rent-A_Car;Integrated Security=True");
        DataTable tablo;
        public void ekle_sil_guncelle(SqlCommand komut, string sorgu)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = sorgu;
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public DataTable listele(SqlDataAdapter adtr2, string sorgu)
        {
            tablo = new DataTable();

            adtr2 = new SqlDataAdapter(sorgu, baglanti);
            adtr2.Fill(tablo);
            baglanti.Close();

            return tablo;
        }
        public void Bos_Araclar(ComboBox combo, string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                combo.Items.Add(read["plaka"].ToString());
            }
            baglanti.Close();
        }
        public void TC_ARA(TextBox tcara, TextBox tc, TextBox adsoyad, TextBox telefon, string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                tc.Text = read["tc"].ToString();
                adsoyad.Text = read["adsoyad"].ToString();
                telefon.Text = read["telefon"].ToString();
            }
            baglanti.Close();
        }
        public void CombodanGetir(ComboBox araclar, TextBox marka, TextBox seri, TextBox yil, TextBox renk, string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                marka.Text = read["marka"].ToString();
                seri.Text = read["seri"].ToString();
                renk.Text = read["renk"].ToString();
                yil.Text = read["yil"].ToString();
            }
            baglanti.Close();
        }
        public void Ucret_Hesapla(ComboBox cmbkirasekli, TextBox ucret, string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (cmbkirasekli.SelectedIndex == 0) ucret.Text = (int.Parse(read[""].ToString()) * 1).ToString();
                if (cmbkirasekli.SelectedIndex == 1) ucret.Text = (int.Parse(read[""].ToString()) * 0.80).ToString();
                if (cmbkirasekli.SelectedIndex == 2) ucret.Text = (int.Parse(read[""].ToString()) * 0.70).ToString();


            }
            baglanti.Close();
        }
        public void satis_hesapla(Label lbl, string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(tutar) from satis", baglanti);
            lbl.Text = "Toplam Tutar" + komut.ExecuteScalar() + "TL";
            baglanti.Close();
        }
    }
}
