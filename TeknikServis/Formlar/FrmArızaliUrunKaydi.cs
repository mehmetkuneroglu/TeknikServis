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
    public partial class FrmArızaliUrunKaydi : Form
    {
        public FrmArızaliUrunKaydi()
        {
            InitializeComponent();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUNKABUL t = new TBLURUNKABUL();
            t.CARI = int.Parse(txtUrunID.Text);
            t.GELISTARIHI =DateTime.Parse( txtTarih.Text);
            t.PERSONEL = short.Parse(txtPersonel.Text);
            t.URUNSERINO = txtSeriNo.Text;
            db.TBLURUNKABUL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kaydedildi");
            


        }

        private void txtTarih_Click(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
        }

        private void FrmArızaliUrunKaydi_Load(object sender, EventArgs e)
        {

        }
    }
}
