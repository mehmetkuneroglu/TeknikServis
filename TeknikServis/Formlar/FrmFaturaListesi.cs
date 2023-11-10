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
    public partial class FrmFaturaListesi : Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        void Listele()
        {
            var degerler = (from x in db.TBLFATURABILGI
                            select new
                            {
                                x.ID,
                                x.SERI,
                                x.SIRANO,
                                x.TARIH,
                                x.SAAT,
                                x.VERGIDAIRE,
                                CARI = x.TBLCARI.AD + " " + x.TBLCARI.SOYAD,
                                PERSONEL = x.TBLPERSONEL.AD + " " + x.TBLPERSONEL.SOYAD
                            }).ToList();
            gridControl1.DataSource = degerler;

            lookUpEdit1.Properties.DataSource = (from x in db.TBLCARI
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD = x.AD + " " + x.SOYAD
                                                 }).ToList();
            lookUpEdit2.Properties.DataSource = (from x in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD = x.AD + " " + x.SOYAD
                                                 }).ToList();
        }
        void Temizle()
        {
            txtId.Text = null;
            txtSaat.Text = null;
            txtSeri.Text = null;
            txtSiraNo.Text = null;
            txtTarih.Text = null;
            txtVergiDairesi.Text = null;
            lookUpEdit1.Text = null;
            lookUpEdit2.Text = null;
        }
        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLFATURABILGI t = new TBLFATURABILGI();
            t.SERI = txtSeri.Text;
            t.SIRANO = txtSiraNo.Text;
            t.TARIH =DateTime.Parse( txtTarih.Text);
            t.SAAT = txtSaat.Text;
            t.VERGIDAIRE = txtVergiDairesi.Text;
            t.CARI = int.Parse(lookUpEdit1.EditValue.ToString());
            t.PERSONEL = short.Parse(lookUpEdit2.EditValue.ToString());
            db.TBLFATURABILGI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kaydedildi");
            Listele();
            Temizle();
        }
    }
}
