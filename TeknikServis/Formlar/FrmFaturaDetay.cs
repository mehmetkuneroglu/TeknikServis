using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmFaturaDetay : Form
    {
        public FrmFaturaDetay()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        void Listele()
        {
            gridControl1.DataSource = (from x in db.TBLFATURADETAY
                                       select new
                                       {
                                           x.FATURADETAYID,
                                           x.URUN,
                                           x.ADET,
                                           x.FIYAT,
                                           x.TUTAR,
                                           x.FATURAID
                                       }).ToList();
        }
        void Temizle()
        {
            txtAdet.Text = null;
            txtDetayId.Text = null;
            txtFaturaId.Text = null;
            txtFiyat.Text = null;
            txtTutar.Text = null;
            txtUrun.Text = null;
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLFATURADETAY t = new TBLFATURADETAY();
            t.URUN = txtUrun.Text;
            t.ADET =short.Parse(txtAdet.Text);
            t.FIYAT = decimal.Parse(txtFiyat.Text);
            t.TUTAR = decimal.Parse(txtTutar.Text);
            t.FATURAID = int.Parse(txtFaturaId.Text);
            db.TBLFATURADETAY.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kaydedildi");
            Listele();
            Temizle();
        }

        private void FrmFaturaDetay_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }
    }
}
