using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TeknikServis.Formlar
{
    public partial class FrmMarka : Form
    {
        public FrmMarka()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        private void FrmMarka_Load(object sender, EventArgs e)
        {
            var degerler = db.TBLURUN.OrderBy(z => z.MARKA).GroupBy(x => x.MARKA).Select(y => new
            {
                Marka = y.Key,
                Toplam = y.Count()
            });
            gridControl1.DataSource = degerler.ToList();
            labelControl19.Text = db.TBLURUN.Count().ToString();
            labelControl1.Text = (from x in db.TBLURUN
                                  select x.MARKA).Distinct().Count().ToString();
            labelControl5.Text = (from x in db.TBLURUN
                                  orderby x.SATISFIYAT descending
                                  select x.MARKA).FirstOrDefault();
            labelControl3.Text = db.maxUrunMarka().FirstOrDefault();

            //chartControl1.Series["Series 1"].Points.AddPoint("SIEMENS", 4);
            //chartControl1.Series["Series 1"].Points.AddPoint("ARÇELİK", 6);
            //chartControl1.Series["Series 1"].Points.AddPoint("BEKO", 3);
            //chartControl1.Series["Series 1"].Points.AddPoint("TOSHIBA", 2);
            //chartControl1.Series["Series 1"].Points.AddPoint("LENOVO", 1);

            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-15IJ3SF\SQLEXPRESS;Initial Catalog=DbTeknikServis;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select marka, count(*) from TBLURUN group by marka", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));

            }
            baglanti.Close();

            //chartControl2.Series["Kategoriler"].Points.AddPoint("Tv", 2);
            //chartControl2.Series["Kategoriler"].Points.AddPoint("Bilgisayar", 5);
            //chartControl2.Series["Kategoriler"].Points.AddPoint("Küçük Ev Aletleri", 8);
            //chartControl2.Series["Kategoriler"].Points.AddPoint("Beyaz Eşya", 4);
            //chartControl2.Series["Kategoriler"].Points.AddPoint("Tablet", 3);
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select TBLKATEGORI.AD, COUNT(*) FROM TBLURUN INNER JOIN TBLKATEGORI ON TBLKATEGORI.ID=TBLURUN.KATEGORI GROUP BY TBLKATEGORI.AD", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Kategoriler"].Points.AddPoint(dr2[0].ToString(), int.Parse(dr2[1].ToString()));
            }

        }
    }
}
