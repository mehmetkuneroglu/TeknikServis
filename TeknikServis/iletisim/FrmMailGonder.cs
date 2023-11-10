using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
namespace TeknikServis.iletisim
{
    public partial class FrmMailGonder : Form
    {
        public FrmMailGonder()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                string frommail = "your email";
                string password = "your email app password";
                string alici = textEdit1.Text;
                string konu = textEdit2.Text;
                string icerik = richTextBox1.Text;
                mail.From = new MailAddress(frommail);
                mail.To.Add(alici);
                mail.Subject = konu;
                mail.Body = icerik;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(frommail, password);
                smtp.EnableSsl = true;
                smtp.Send(mail);
                MessageBox.Show("Mail gönderildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Mail gönderilemedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void FrmMailGonder_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
