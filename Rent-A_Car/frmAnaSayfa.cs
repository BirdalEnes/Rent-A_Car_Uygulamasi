using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rent_A_Car
{
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMusteriEkleme_Click(object sender, EventArgs e)
        {
            frmMüsteriEkle ekle = new frmMüsteriEkle();
            ekle.ShowDialog();
        }

        private void btnMusteriListeleme_Click(object sender, EventArgs e)
        {
            frmMüsteriListele listele = new frmMüsteriListele();
            listele.ShowDialog();
        }

        private void btnAracKayıt_Click(object sender, EventArgs e)
        {
            frmAracKayıt kayıt = new frmAracKayıt();
            kayıt.ShowDialog();
        }

        private void btnSözlesme_Click(object sender, EventArgs e)
        {
            frmSözlesme sözlesme = new frmSözlesme();
            sözlesme.ShowDialog();
        }

        private void btnSatıslar_Click(object sender, EventArgs e)
        {
            frmSatis satis = new frmSatis();
            satis.ShowDialog();
        }
    }
}
