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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        void Listele()
        {
            gridControl1.DataSource = (from p in db.TBLPERSONEL
                                       select new
                                       {
                                           p.ID,
                                           p.AD,
                                           p.SOYAD,
                                           DEPARTMAN = p.TBLDEPARTMAN.AD,
                                           p.MAIL,
                                           p.TELEFON
                                       }).ToList();
            string ad1, soyad1,ad2,soyad2,ad3,soyad3,ad4,soyad4;
            // 1.Personel
            ad1 = db.TBLPERSONEL.First(x => x.ID == 1).AD;
            soyad1 = db.TBLPERSONEL.First(x => x.ID == 1).SOYAD;
            labelControl3.Text = ad1 + " " + soyad1;
            labelControl5.Text = db.TBLPERSONEL.First(x => x.ID == 1).TBLDEPARTMAN.AD;
            labelControl8.Text = db.TBLPERSONEL.First(x => x.ID == 1).MAIL;
            // 2.Personel
            ad2 = db.TBLPERSONEL.First(x => x.ID == 2).AD;
            soyad2 = db.TBLPERSONEL.First(x => x.ID == 2).SOYAD;
            labelControl13.Text = ad2 + " " + soyad2;
            labelControl11.Text = db.TBLPERSONEL.First(x => x.ID == 2).TBLDEPARTMAN.AD;
            labelControl9.Text = db.TBLPERSONEL.First(x => x.ID == 2).MAIL;
            // 3.Personel
            ad3 = db.TBLPERSONEL.First(x => x.ID == 3).AD;
            soyad3 = db.TBLPERSONEL.First(x => x.ID == 3).SOYAD;
            labelControl26.Text = ad3 + " " + soyad3;
            labelControl24.Text = db.TBLPERSONEL.First(x => x.ID == 3).TBLDEPARTMAN.AD;
            labelControl22.Text = db.TBLPERSONEL.First(x => x.ID == 3).MAIL;
            // 4.Personel
            ad4 = db.TBLPERSONEL.First(x => x.ID == 4).AD;
            soyad4 = db.TBLPERSONEL.First(x => x.ID == 4).SOYAD;
            labelControl32.Text = ad4 + " " + soyad4;
            labelControl30.Text = db.TBLPERSONEL.First(x => x.ID == 4).TBLDEPARTMAN.AD;
            labelControl28.Text = db.TBLPERSONEL.First(x => x.ID == 4).MAIL;

            //lookUpEdit1.Properties.DataSource = (from x in db.TBLDEPARTMAN
            //                                     select new
            //                                     {
            //                                         x.AD,
            //                                         x.ID
            //                                     });
            lookUpEdit1.Properties.DataSource = (from x in db.TBLDEPARTMAN
                                     select new
                                     {
                                         x.AD
                                     }).ToList();
        }
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

        }
    }
}
