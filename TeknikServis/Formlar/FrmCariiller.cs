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
    public partial class FrmCariiller : Form
    {
        public FrmCariiller()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-15IJ3SF\\SQLEXPRESS;Initial Catalog=DbTeknikServis;Integrated Security=True");
        private void FrmCariiller_Load(object sender, EventArgs e)
        {
            //chartControl1.Series["Series 1"].Points.AddPoint("Ankara",2);
            //chartControl1.Series["Series 1"].Points.AddPoint("İzmir",4);
            //chartControl1.Series["Series 1"].Points.AddPoint("Bursa",8);
            //chartControl1.Series["Series 1"].Points.AddPoint("Aydın",6);
            //chartControl1.Series["Series 1"].Points.AddPoint("Muğla",3);
            //chartControl1.Series["Series 1"].Points.AddPoint("Isparta",1);

            gridControl1.DataSource = db.TBLCARI.
                GroupBy(y => y.TBLILLER.ILADI).OrderByDescending(x=>x.Count()).
                Select(z => new
                {
                    İL = z.Key,
                    TOPLAM = z.Count()
                }).ToList();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT TBLILLER.ILADI,COUNT(*) FROM TBLCARI INNER JOIN TBLILLER ON TBLILLER.id=TBLCARI.IL  GROUP BY TBLILLER.ILADI ORDER BY COUNT(*) DESC", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString( dr[0].ToString()), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
        }
    }
}
