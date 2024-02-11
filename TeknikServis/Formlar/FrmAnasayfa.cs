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
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        void Listele()
        {
            gridControl1.DataSource = (from x in db.TBLURUN
                                       select new
                                       {
                                           x.AD,
                                           x.MARKA,
                                           x.STOK
                                       }).Where(x => x.STOK <= 30).ToList();

            gridControl2.DataSource = (from x in db.TBLCARI
                                       select new
                                       {
                                           x.AD,
                                           x.SOYAD,
                                           x.IL,
                                           x.TELEFON
                                       }).ToList();
            gridControl3.DataSource = db.urunKategori().ToList();
            gridControl4.DataSource = (from x in db.TBLNOTLARIM.Where(y => y.TARIH == DateTime.Today)
                                       select new
                                       {
                                           x.BASLIK,
                                           x.ICERIK
                                       }).ToList();
            gridView4.Columns[0].Width = 30;
            int sayac = db.TBLILETISIM.Count();
            int i = 1;
            while (sayac > 0)
            {
                string adsoyad = db.TBLILETISIM.First(x => x.ID == sayac).ADSOYAD;
                string konu = db.TBLILETISIM.First(x => x.ID == sayac).KONU;
                string mesaj = db.TBLILETISIM.First(x => x.ID == sayac).MESAJ;
                string tarih = Convert.ToString(db.TBLILETISIM.First(x => x.ID == sayac).TARIH);

                Label lbl1 = new Label();
                lbl1.Width = 150;
                lbl1.ForeColor = Color.DarkRed;
                lbl1.Name = "label" + i;
                lbl1.Text = "Gönderen: " + adsoyad;
                lbl1.Location = new Point(10, 10);

                Label lbl2 = new Label();
                lbl2.Width = 200;
                lbl2.ForeColor = Color.Purple;
                lbl2.Name = "label" + i;
                lbl2.Text = "Konu: " + konu;
                lbl2.Location = new Point(160, 10);


                //Label lbl3 = new Label();
                //lbl3.Width = 340;
                //lbl3.Height = 60;
                //lbl3.ForeColor = Color.Black;
                //lbl3.Name = "label" + i;
                //lbl3.Text = "Mesaj: "+mesaj;
                //lbl3.Location = new Point(10, 30);

                TextBox t = new TextBox();
                t.Name = "txt" + i;
                t.Width = 415;
                t.Height = 50;
                t.ForeColor = Color.Black;
                t.Multiline = true;
                t.Text = "Mesaj: " + mesaj;
                t.BackColor = Color.Yellow;
                if (i % 2 == 0)
                {
                    t.BackColor = Color.GreenYellow;
                }
                t.BorderStyle = BorderStyle.None;
                t.Location = new Point(10, 30);
                t.ScrollBars = ScrollBars.Vertical;


                Label lbl4 = new Label();
                lbl4.Width = 415;
                lbl4.ForeColor = Color.Gray;
                lbl4.Name = "label" + i;
                lbl4.Text = "Tarih: " + tarih + "                                                                " + sayac + ". mesaj";
                lbl4.Location = new Point(10, 85);

                Panel p = new Panel();
                p.Name = "panel" + i;
                p.Width = 423;
                p.Height = 100;
                p.BackColor = Color.Yellow;
                if (i % 2 == 0)
                {
                    p.BackColor = Color.GreenYellow;
                }
                p.Controls.Add(lbl1);
                p.Controls.Add(lbl2);
                // p.Controls.Add(lbl3);
                p.Controls.Add(t);
                p.Controls.Add(lbl4);

                flowLayoutPanel1.Controls.Add(p);
                i++;
                sayac--;
            }
        }
        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
