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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        void Listele()
        {
            gridControl1.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == false).ToList();
            gridControl2.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == true).ToList();
            gridView1.Columns[0].Width = 15;
            gridView2.Columns[0].Width = 15;
            //gridView1.Columns[1].Width = 15;
            //gridView2.Columns[1].Width = 15;
            gridView1.Columns[2].Width = 300;
            gridView2.Columns[2].Width = 300;
            gridView1.Columns[3].Width = 10;
            gridView2.Columns[3].Width = 10;

        }
        void Temizle()
        {
            txtBaslik.Text = null;
            txticerik.Text = null;
            txtId.Text = null;
            checkEdit1.Checked = false;
        }
        private void FrmYoutube_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLNOTLARIM n = new TBLNOTLARIM();
            n.BASLIK = txtBaslik.Text;
            n.ICERIK = txticerik.Text;
            n.TARIH =DateTime.Parse( txtTarih.Text);
            n.DURUM = false;
            db.TBLNOTLARIM.Add(n);
            db.SaveChanges();
            MessageBox.Show("Not Kaydedildi");
            Listele();
            Temizle();

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked==true)
            {
                int id = int.Parse(txtId.Text);
                var deger = db.TBLNOTLARIM.Find(id);
                deger.DURUM = true;
                db.SaveChanges();
                MessageBox.Show("Not durumu değiştirildi");
                Listele();
                Temizle();
            }
          

        }
              

        private void gridView1_Click_1(object sender, EventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtBaslik.Text = gridView1.GetFocusedRowCellValue("BASLIK").ToString();
            txticerik.Text = gridView1.GetFocusedRowCellValue("ICERIK").ToString();
        }
    }
}
