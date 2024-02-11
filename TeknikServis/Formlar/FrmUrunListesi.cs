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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }
        void Listele()
        {
            //var degerler = db.TBLURUN.ToList();
            var degerler = from u in db.TBLURUN
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.MARKA,
                               KATEGORI = u.TBLKATEGORI.AD,
                               u.STOK,
                               u.ALISFIYAT,
                               u.SATISFIYAT

                           };
            gridControl1.DataSource = degerler.ToList();
        }
        void Temizle()
        {
            txtId.Text = "";
            txtUrunAd.Text = "";
            txtMarka.Text = "";
            txtAlisFiyati.Text = "";
            txtSatisFiyati.Text = "";
            txtStok.Text = "";
            lookUpEdit1.Text= "Bir değer seçiniz";

        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            Listele();
            lookUpEdit1.Properties.DataSource =(from x in db.TBLKATEGORI
                                                select new
                                                {
                                                    x.ID,
                                                    x.AD
                                                }).ToList();
            

            Temizle();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.AD = txtUrunAd.Text;
            t.MARKA = txtMarka.Text;
            t.ALISFIYAT = decimal.Parse(txtAlisFiyati.Text);
            t.SATISFIYAT = decimal.Parse(txtSatisFiyati.Text);
            t.STOK = short.Parse(txtStok.Text);
            t.DURUM = false;
            t.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();



        }

        
        private void btnListele_Click_1(object sender, EventArgs e)
        {
            Listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtUrunAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            txtMarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
            txtAlisFiyati.Text = gridView1.GetFocusedRowCellValue("ALISFIYAT").ToString();
            txtSatisFiyati.Text = gridView1.GetFocusedRowCellValue("SATISFIYAT").ToString();
            txtStok.Text = gridView1.GetFocusedRowCellValue("STOK").ToString();
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("KATEGORI").ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deger = db.TBLURUN.Find(id);
            db.TBLURUN.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Ürün silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deger = db.TBLURUN.Find(id);
            deger.AD = txtUrunAd.Text;
            deger.MARKA = txtMarka.Text;
            deger.ALISFIYAT = decimal.Parse(txtAlisFiyati.Text);
            deger.SATISFIYAT = decimal.Parse(txtSatisFiyati.Text);
            deger.STOK = short.Parse(txtStok.Text);
            deger.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }
    }
}
