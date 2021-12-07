using Studentski_online_servis.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System;

namespace Studentski_online_servis.IB190057.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MailController
    {
        [HttpPost("{From}, {To}, {Subject},{Message}")]
        public void SendMail(string From, string To,string Subject, string Message)
        {
            MailMessage message= new MailMessage(From, To);
            message.Subject = Subject;
            message.Body = Message;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.mail.yahoo.com", 465); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("mail", "sifra");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
