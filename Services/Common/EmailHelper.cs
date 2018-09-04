using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;


namespace PurcellComplianceServices.Common
{
    public class EmailHelper
    {
        private string createEmailBody(string userName)
        {
            string body = string.Empty;
            //using streamreader for reading my htmltemplate   
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/Templates/ForgetPass.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{{UserName}}", userName); //replacing the required things  
            return body;
        }

        private void SendHtmlFormattedEmail(string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(""));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"]; //reading from web.config  
                NetworkCred.Password = ConfigurationManager.AppSettings["Password"]; //reading from web.config  
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]); //reading from web.config  
                smtp.Send(mailMessage);
            }

        }  
    }
}