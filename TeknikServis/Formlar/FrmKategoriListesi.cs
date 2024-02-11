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
    public partial class FrmKategoriListesi : Form
    {
        public FrmKategoriListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void Listele()
        {
            var degerler = from k in db.TBLKATEGORI
                           select new
                           {
                               k.ID,
                               k.AD
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        void Temizle()
        {
            txtKategoriAd.Text = null;
            txtId.Text = null;
        }
        private void FrmKategoriListesi_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLKATEGORI t = new TBLKATEGORI();
            t.AD = txtKategoriAd.Text;
            db.TBLKATEGORI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori kaydedildi");
            Listele();
            Temizle();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtKategoriAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            int id = int.Parse(txtId.Text);
            var deger = db.TBLKATEGORI.Find(id);
            db.TBLKATEGORI.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Kategori silindi");

            Listele();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deger = db.TBLKATEGORI.Find(id);
            deger.AD = txtKategoriAd.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori güncellendi");

            Listele();
            Temizle();
        }
    }
}
