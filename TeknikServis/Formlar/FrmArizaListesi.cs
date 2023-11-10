using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmArizaListesi : Form
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }

        private void labelControl14_Click(object sender, EventArgs e)
        {

        }
        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        void Listele()
        {
            gridControl1.DataSource = (from x in db.TBLURUNKABUL
                                      select new
                                      {
                                          x.ISLEMID,                                          
                                          CARI = x.TBLCARI.AD + " " + x.TBLCARI.SOYAD,
                                          PERSINEL = x.TBLPERSONEL.AD + " " + x.TBLPERSONEL.SOYAD,
                                          x.GELISTARIHI,
                                          x.CIKISTARIHI,
                                          x.URUNSERINO,
                                          x.DURUMDETAY
                                      }).ToList();
            gridView1.Columns[0].Width = 25;
            gridView1.Columns[1].Width = 50;
            gridView1.Columns[1].Caption = "CARİ ADI";
            gridView1.Columns[3].Caption = "GELİŞ TARİHİ";
            gridView1.Columns[4].Caption = "ÇIKIŞ TARİHİ";
            gridView1.Columns[5].Caption = "SERİ NO";
            gridView1.Columns[6].Caption = "DURUM DETAYI";

            labelControl1.Text = db.TBLURUNKABUL.Count(x=>x.DURUM==true).ToString();
            labelControl3.Text = db.TBLURUNKABUL.Count(x=>x.DURUM==false).ToString();
            labelControl11.Text = db.TBLURUN.Count().ToString();
            labelControl5.Text = db.TBLURUNKABUL.Count(x => x.DURUMDETAY =="Parça bekleniyor").ToString();
            labelControl9.Text = db.TBLURUNKABUL.Count(x => x.DURUMDETAY =="Mesaj bekleniyor").ToString();
            labelControl13.Text = db.TBLURUNKABUL.Count(x => x.DURUMDETAY =="İptal edildi").ToString();


            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-15IJ3SF\SQLEXPRESS;Initial Catalog=DbTeknikServis;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select durumdetay,COUNT(*) from TBLURUNkabul group by durumdetay", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));

            }
            baglanti.Close();

        }
        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
