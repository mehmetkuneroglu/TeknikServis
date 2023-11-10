using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Formlar.FrmKategoriListesi fr1;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr1==null|| fr1.IsAccessible)
            {
                fr1 = new Formlar.FrmKategoriListesi();
                fr1.MdiParent = this;
                fr1.Show();
            }
            
        }
        Formlar.FrmUrunListesi fr2;
        private void BtnUrunListesiFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2==null|| fr2.IsDisposed)
            {
                fr2 = new Formlar.FrmUrunListesi();
                fr2.MdiParent = this;
                fr2.Show();
            }
            
        }
        Formlar.FrmAnasayfa fr;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (fr==null || fr.IsDisposed)
            {
                fr = new Formlar.FrmAnasayfa();
                fr.MdiParent = this;
                fr.Show();
            }
           
        }
        Formlar.FrmYeniUrun fr3;
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3==null || fr3.IsDisposed)
            {
                fr3 = new Formlar.FrmYeniUrun();
                fr3.Show();
            }
            
        }
        Formlar.FrmYeniKategori fr4;
        private void btnYeniKategori_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4==null || fr.IsDisposed)
            {
                fr4 = new Formlar.FrmYeniKategori();
                fr4.ShowDialog();
            }
            
        }
        Formlar.FrmUrunIstatistikleri fr5;
        private void btnUrunIstatistikleri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5==null || fr5.IsDisposed)
            {
                fr5 = new Formlar.FrmUrunIstatistikleri();
                fr5.MdiParent = this;
                fr5.Show();
            }
           
        }
        Formlar.FrmMarka fr6;
        private void btnMarkaIstatıstıkler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6==null || fr6.IsDisposed)
            {
                fr6 = new Formlar.FrmMarka();
                fr6.MdiParent = this;
                fr6.Show();
            }
           
        }
        Formlar.FrmCariListesics fr7;
        private void btnCariListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7==null || fr7.IsDisposed)
            {
                fr7 = new Formlar.FrmCariListesics();
                fr7.MdiParent = this;
                fr7.Show();
            }
            
        }
        Formlar.FrmCariiller fr8;
        private void btnCariiller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8==null || fr8.IsDisposed)
            {
                fr8 = new Formlar.FrmCariiller();
                fr8.MdiParent = this;
                fr8.Show();
            }
            
        }
        Formlar.FrmCariEkle fr9;
        private void btnCariEkle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9==null || fr9.IsDisposed)
            {
                fr9 = new Formlar.FrmCariEkle();
                fr9.Show();
            }
            
        }
        Formlar.FrmDepartman fr10;
        private void btnDepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr10==null || fr10.IsDisposed)
            {
                fr10 = new Formlar.FrmDepartman();
                fr10.MdiParent = this;
                fr10.Show();
            }
            
        }
        Formlar.FrmYeniDepartman fr11;
        private void btnYeniDepartman_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11==null || fr11.IsDisposed)
            {
                fr11 = new Formlar.FrmYeniDepartman();
                fr11.Show();
            }
            
        }
        Formlar.FrmPersonel fr12;
        private void btnPersonelListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12==null || fr12.IsDisposed)
            {
                fr12 = new Formlar.FrmPersonel();
                fr12.MdiParent = this;
                fr12.Show();
            }
            
        }

        private void btnHesapMakinesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }
        Formlar.FrmKurlar fr13;
        private void btnKurlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr13==null || fr13.IsDisposed)
            {
                fr13 = new Formlar.FrmKurlar();
                fr13.MdiParent = this;
                fr13.Show();
            }
            
        }

        private void btnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword");

        }

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel");

        }

        private void btnYouTube_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }
        Formlar.FrmNotlar fr14;
        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr14==null || fr14.IsDisposed)
            {
                fr14 = new Formlar.FrmNotlar();
                fr14.MdiParent = this;
                fr14.Show();
            }
            
        }
        Formlar.FrmArizaListesi fr15;
        private void btnArizaliUrunListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr15==null || fr15.IsDisposed)
            {
                fr15 = new Formlar.FrmArizaListesi();
                fr15.MdiParent = this;
                fr15.Show();
            }
            
        }
        Formlar.FrmUrunSatis fr16;
        private void btnYeniUrunSatis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr16==null || fr16.IsDisposed)
            {
                fr16 = new Formlar.FrmUrunSatis();
                fr16.Show();
            }
            
        }
        Formlar.FrmSatislar fr17;
        private void btnSatisListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr17==null || fr17.IsDisposed)
            {
                fr17 = new Formlar.FrmSatislar();
                fr17.MdiParent = this;
                fr17.Show();
            }
            
        }
        Formlar.FrmArızaliUrunKaydi fr28;
        private void btnYeniArizaliUrunKaydi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr28==null || fr28.IsDisposed)
            {
                fr28 = new Formlar.FrmArızaliUrunKaydi();
                fr28.Show();
            }
            
        }
        Formlar.FrmUrunTakip fr27;
        private void btnUrunTakip_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr27==null || fr27.IsDisposed)
            {
                fr27 = new Formlar.FrmUrunTakip();
                fr27.Show();
            }
           
        }
        Formlar.FrmArizaliUrunDetayListesi fr18;
        private void btnArizaliUrunDetayi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr18==null || fr18.IsDisposed)
            {
                fr18 = new Formlar.FrmArizaliUrunDetayListesi();
                fr18.MdiParent = this;
                fr18.Show();
            }
            
        }
        Formlar.FrmQrCode fr26;
        private void btnQRkod_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr26==null || fr26.IsDisposed)
            {
                fr26 = new Formlar.FrmQrCode();
                fr26.Show();
            }
            
        }
        Formlar.FrmFaturaListesi fr19;
        private void btnFaturaListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr19==null || fr19.IsDisposed)
            {
                fr19 = new Formlar.FrmFaturaListesi();
                fr19.MdiParent = this;
                fr19.Show();
            }
            
        }
        Formlar.FrmFaturaDetay fr20;
        private void btnFaturaDetay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr20==null || fr20.IsDisposed)
            {
                fr20 = new Formlar.FrmFaturaDetay();
                fr20.MdiParent = this;
                fr20.Show();
            }
            
        }
        Formlar.FrmFaturaKalemleri fr21;
        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr21==null || fr21.IsDisposed)
            {
                fr21 = new Formlar.FrmFaturaKalemleri();
                fr21.MdiParent = this;
                fr21.Show();
            }
           
        }
        Formlar.FrmGauge fr22;
        private void btnHakkimizda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr22==null || fr22.IsDisposed)
            {
                fr22 = new Formlar.FrmGauge();
                fr22.MdiParent = this;
                fr22.Show();
            }
            
        }
        Formlar.FrmHarita fr23;
        private void btnHaritalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr23==null || fr23.IsDisposed)
            {
                fr23 = new Formlar.FrmHarita();
                fr23.MdiParent = this;
                fr23.Show();
            }
           
        }
        Formlar.FrmRaporlar fr25;
        private void btnRaporSihirbazı_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr25==null || fr25.IsDisposed)
            {
                fr25 = new Formlar.FrmRaporlar();
                fr25.Show();
            }
            
        }

        private void btnAnasayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmAnasayfa();
                fr.MdiParent = this;
                fr.Show();
            }
        }
        Formlar.FrmHakkimizda fr24;
        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr24==null || fr24.IsDisposed)
            {
                fr24 = new Formlar.FrmHakkimizda();
                fr24.MdiParent = this;
                fr24.Show();
            }
           
        }

        private void barButtonItem36_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            iletisim.FrmMailGonder fr = new iletisim.FrmMailGonder();
            fr.Show();
        }
    }
}
