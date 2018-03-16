using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace ITSourceManagement
{
    public class EmailService
    {
        public void SendMail(string toAddr,string title,string content,string cc="")
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("2870677789@qq.com","YF",System.Text.Encoding.UTF8);
                string[] tos = toAddr.Split(new string[]{";",","},StringSplitOptions.RemoveEmptyEntries);
                foreach(var to in tos)
                {
                    mail.To.Add(new MailAddress(to));
                }
                string[] ccs = cc.Split(new string[] { ";","," }, StringSplitOptions.RemoveEmptyEntries);
                foreach(var xcc in ccs)
                {
                    mail.CC.Add(new MailAddress(xcc));
                }
                mail.Subject = title;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.Body = content;
                mail.IsBodyHtml = true;

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.qq.com";
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("email","psw");

                client.Send(mail);
            }
            catch
            {

            }
        }
    }
}