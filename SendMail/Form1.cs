using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace SendEmail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls;
                textBox1.Text = "the_one_1989@163.com";
                textBox2.Text = "Hi";
                textBox3.Text = "Hi";
                textBox4.Text = "the_one_1989@163.com";
                textBox5.Text = "Vanora_Zhou1989";
                MailMessage mm = new MailMessage();
                mm.From = new MailAddress(textBox4.Text);
                mm.Subject = textBox2.Text;
                mm.Body = textBox3.Text;
                foreach (string s in textBox1.Text.Split(';'))
                {
                    mm.To.Add(s);
                }
                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(textBox4.Text, textBox5.Text);
                client.Host = "smtp.163.com";
                client.Port = 25;
                //client.EnableSsl = true;
                client.Send(mm);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
