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
    public partial class FrmUrunSatis : Form
    {
        public FrmUrunSatis()
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
            TBLURUNHAREKET h = new TBLURUNHAREKET();
            h.URUN = int.Parse(lookUpEdit1.EditValue.ToString());
            h.MUSTERI = int.Parse(lookUpEdit2.EditValue.ToString());
            h.PERSONEL = short.Parse(lookUpEdit3.EditValue.ToString());
            h.TARIH = Convert.ToDateTime(txtTarih.Text);
            h.ADET = short.Parse(txtAdet.Text);
            h.FIYAT = decimal.Parse(txtSatisFiyati.Text);
            h.URUNSERINO = txtSeriNo.Text;
            db.TBLURUNHAREKET.Add(h);
            db.SaveChanges();
            MessageBox.Show("Ürün Satış Yapıldı");

        }

        private void FrmUrunSatis_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in db.TBLURUN
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.MARKA,
                                                    x.AD
                                                 }).ToList();
            lookUpEdit2.Properties.DataSource = (from x in db.TBLCARI
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList();
            lookUpEdit3.Properties.DataSource = (from x in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            int id = int.Parse(lookUpEdit1.EditValue.ToString());
            txtSatisFiyati.Text = (from x in db.TBLURUN
                                   where x.ID == id
                                   select x.SATISFIYAT

                                   ).First().ToString();
        }
    }
}
