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
    public partial class FrmCariEkle : Form
    {
        public FrmCariEkle()
        {
            InitializeComponent();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLCARI t = new TBLCARI();
            t.AD = txtAd.Text;
            t.SOYAD = txtSoyad.Text;
            t.TELEFON = txtTelefon.Text;
            t.MAİL = txtEmail.Text;
            //t.IL = txtil.Text;
           // t.ILCE = txtilçe.Text;
            t.BANKA = txtBanka.Text;
            t.VERGIDAIRESI = txtVergiDairesi.Text;
            t.VERGINO = txtVergiNo.Text;
            t.STATU = txtStatu.Text;
            t.ADRES = txtAdres.Text;
            db.TBLCARI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Cari Eklendi");
        }

        private void FrmCariEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
