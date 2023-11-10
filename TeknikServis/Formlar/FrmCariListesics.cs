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
    public partial class FrmCariListesics : Form
    {
        public FrmCariListesics()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        void Listele()
        {

            //gridControl1.DataSource = db.TBLCARI.ToList();
            var degerler = from c in db.TBLCARI
                           select new
                           {
                               c.ID,
                               c.AD,
                               c.SOYAD,
                               c.TELEFON,
                               c.MAİL,
                               İL = c.TBLILLER.ILADI,
                               İLÇE = c.TBLILCELER.ILCE,
                               c.BANKA,
                               c.VERGIDAIRESI,
                               c.VERGINO,
                               c.STATU,
                               c.ADRES

                           };
            gridControl1.DataSource = degerler.ToList();
            lookUpEdit1.Properties.DataSource = (from x in db.TBLILLER
                                                 select new
                                                 {
                                                     x.id,
                                                     x.ILADI
                                                 }).ToList();

            labelControl19.Text = db.TBLCARI.Select(x => x.IL).Distinct().Count().ToString();
            labelControl17.Text = db.TBLCARI.Select(x => x.ILCE).Distinct().Count().ToString();
            txtAd.Focus();


        }
        void Temizle()
        {
            txtAd.Text = "";
            txtAdres.Text = "";
            txtBanka.Text = "";
            txtEmail.Text = "";
            txtId.Text = "";
            txtSoyad.Text = "";
            txtStatu.Text = "";
            txtTelefon.Text = "";
            txtVerDairesi.Text = "";
            txtVerNo.Text = "";
            lookUpEdit1.Text = null;
            lookUpEdit2.Text = null;
            lookUpEdit1.Properties.NullText = "";
            txtAd.Focus();
        }
        private void FrmCariListesics_Load(object sender, EventArgs e)
        {
            Listele();            
            groupControl1.Focus();
            Temizle();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
            btnKaydet.Enabled = true;
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAd.Text != "" && txtSoyad.Text != "")
            {

                TBLCARI t = new TBLCARI();
                t.AD = txtAd.Text;
                t.SOYAD = txtSoyad.Text;
                t.TELEFON = txtTelefon.Text;
                t.MAİL = txtEmail.Text;
                t.IL = byte.Parse(lookUpEdit1.EditValue.ToString());
                t.ILCE = Convert.ToInt16(lookUpEdit2.EditValue.ToString());
                t.BANKA = txtBanka.Text;
                t.VERGIDAIRESI = txtVerDairesi.Text;
                t.VERGINO = txtVerNo.Text;
                t.STATU = txtStatu.Text;
                t.ADRES = txtAdres.Text;
                db.TBLCARI.Add(t);
                db.SaveChanges();
                MessageBox.Show("Cari Eklendi");
                Listele();
                Temizle();
            }else
            {
                MessageBox.Show("Ad ve Soyad boş geçilemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        int secilen;
        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            secilen = int.Parse(lookUpEdit1.EditValue.ToString());
            lookUpEdit2.Properties.DataSource = (from x in db.TBLILCELER
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.ILID,
                                                     x.ILCE
                                                 }).Where(x => x.ILID == secilen).ToList();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deger = db.TBLCARI.Find(id);
            deger.AD = txtAd.Text;
            deger.SOYAD = txtSoyad.Text;
            deger.IL = byte.Parse(lookUpEdit1.EditValue.ToString());
            deger.ILCE = short.Parse(lookUpEdit2.EditValue.ToString());
            deger.TELEFON = txtTelefon.Text;
            deger.MAİL = txtEmail.Text;
            deger.ADRES = txtAdres.Text;
            deger.STATU = txtStatu.Text;
            deger.BANKA = txtBanka.Text;
            deger.VERGIDAIRESI = txtVerDairesi.Text;
            deger.VERGINO = txtVerNo.Text;
          
            
            db.SaveChanges();
            MessageBox.Show("Cari güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            btnKaydet.Enabled = true;
            Temizle();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            txtSoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("İL").ToString();
            lookUpEdit2.Text = gridView1.GetFocusedRowCellValue("İLÇE").ToString();
            txtAdres.Text = gridView1.GetFocusedRowCellValue("ADRES").ToString();
            txtBanka.Text= gridView1.GetFocusedRowCellValue("BANKA").ToString();
            txtEmail.Text= gridView1.GetFocusedRowCellValue("MAİL").ToString();
            txtStatu.Text= gridView1.GetFocusedRowCellValue("STATU").ToString();
            txtTelefon.Text= gridView1.GetFocusedRowCellValue("TELEFON").ToString();
            txtVerDairesi.Text= gridView1.GetFocusedRowCellValue("VERGIDAIRESI").ToString();
            txtVerNo.Text= gridView1.GetFocusedRowCellValue("VERGINO").ToString();
            btnKaydet.Enabled = false;
        }
    }
}
