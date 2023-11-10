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
    public partial class FrmYeniDepartman : Form
    {
        public FrmYeniDepartman()
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
            if (txtAd.Text.Length <= 50 && txtAd.Text != "")
            {
                TBLDEPARTMAN d = new TBLDEPARTMAN();
                d.AD = txtAd.Text;                
                db.TBLDEPARTMAN.Add(d);
                db.SaveChanges();
                MessageBox.Show("Kaydedildi");
            }
            else
            {
                MessageBox.Show("Departman İsmi 50 karakterden fazla olmaz ve boş kayıt girilemez.", "Hata!");
            }
           
        }

        private void FrmYeniDepartman_Load(object sender, EventArgs e)
        {

        }
    }
}
