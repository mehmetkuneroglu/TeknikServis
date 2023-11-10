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
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        public void Listele()
        {
            
            //gridControl1.DataSource = db.TBLDEPARTMAN.ToList();
            gridControl1.DataSource = (from d in db.TBLDEPARTMAN
                                       select new
                                       {
                                           d.ID,
                                           d.AD
                                           
                                       }
                                       ).ToList();
            labelControl13.Text = db.TBLDEPARTMAN.Count().ToString();
            labelControl15.Text = db.TBLPERSONEL.Count().ToString();

        }
        void Temizle()
        {
            txtAd.Text = null;
            txtId.Text = null;
            richTextBox1.Text = null;

        }
        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void labelControl18_Click(object sender, EventArgs e)
        {

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAd.Text.Length<=50 && txtAd.Text!="" )
            {
            TBLDEPARTMAN d = new TBLDEPARTMAN();
            d.AD = txtAd.Text;
           // d.ACIKLAMA = richTextBox1.Text;
            db.TBLDEPARTMAN.Add(d);
            db.SaveChanges();
            MessageBox.Show("Kaydedildi");
            }
            else
            {
                MessageBox.Show("Verileri kontrol edip yeniden deneyin", "Hata");
            }
            Listele();
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
           // richTextBox1.Text = gridView1.GetFocusedRowCellValue("ACIKLAMA").ToString();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            byte id = byte.Parse(txtId.Text);
            var deger = db.TBLDEPARTMAN.Find(id);
            db.TBLDEPARTMAN.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("kayıt silindi");
            Listele();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            byte id = byte.Parse(txtId.Text);
            var deger = db.TBLDEPARTMAN.Find(id);
            deger.AD = txtAd.Text;
            db.SaveChanges();
            MessageBox.Show("Güncellendi");
            Listele();
            Temizle();
        }
    }
}
