using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;


namespace DataLayer.Common
{
    public class EmailHelper
    {
        private string createEmailBody(string email, string name, string password)
        {
            string body = string.Empty;
            //using streamreader for reading my htmltemplate   
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/Templates/NewAccount.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{{Name}}", name); //replacing the required things  
            body = body.Replace("{{Email}}", email);
            body = body.Replace("{{Password}}", password);
            body = body.Replace("{{BodyText}}", "");
            return body;
        }

        private string createEmailBody(string name, string description, string customername, string customeremail, string imagepath)
        {
            string body = string.Empty;
            //using streamreader for reading my htmltemplate   
            if (!String.IsNullOrEmpty(imagepath))
            {
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/Templates/DocView.html")))
                {
                    body = reader.ReadToEnd();
                }
            }
            else
            {
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/Templates/ChangeRequest.html")))
                {
                    body = reader.ReadToEnd();
                }
            }

            body = body.Replace("{{name}}", name); //replacing the required things  
            body = body.Replace("{{description}}", description);
            body = body.Replace("{{name}}", customername);
            body = body.Replace("{{custEmail}}", customeremail);
            if (!String.IsNullOrEmpty(imagepath))
            {
                body = body.Replace("{{imgPath}}", imagepath);
            }
            return body;
        }

        public void SendHtmlFormattedEmail(string subject, User user, string password)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                try
                {
                    mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                    mailMessage.Subject = subject;
                    mailMessage.Body = createEmailBody(user.Email, user.Name, password);
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(new MailAddress(user.Email));
                    mailMessage.CC.Add(new MailAddress("alexxanderpurcell@outlook.com"));
                    mailMessage.Bcc.Add(new MailAddress("anurag.dealstodo@gmail.com"));
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
                catch (Exception ex)
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("~/Logs/logdata.txt"));
                    file.WriteLine(ex.Message);
                    file.Dispose();
                }
            }

        }

        public void SendHtmlEmailWithImage(string subject, string name, User user, string imagePath, string description)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                try
                {
                    mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                    mailMessage.Subject = subject;
                    //AlternateView avHtml = AlternateView.CreateAlternateViewFromString(createEmailBody(name, description, user.Name, user.Email), null, MediaTypeNames.Text.Html);
                    //LinkedResource pic1 = new LinkedResource(imagePath, MediaTypeNames.Image.Jpeg);
                    //pic1.ContentId = "Pic1";
                    //avHtml.LinkedResources.Add(pic1);
                    //mailMessage.AlternateViews.Add(avHtml);
                    mailMessage.Body = createEmailBody(name, description, user.Name, user.Email, imagePath);
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(new MailAddress(user.Email));
                    mailMessage.CC.Add(new MailAddress("alexxanderpurcell@outlook.com"));
                    mailMessage.Bcc.Add(new MailAddress("anurag.dealstodo@gmail.com"));
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
                catch (Exception ex)
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("~/Logs/logdata.txt"));
                    file.WriteLine(ex.Message);
                    file.Dispose();
                }
            }

        }

        public void SendPlainEmail(string subject, string body, string password)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                try
                {
                    mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(new MailAddress("sylviapurcell777@outlook.com"));
                    mailMessage.CC.Add(new MailAddress("alexxanderpurcell@outlook.com"));
                    mailMessage.Bcc.Add(new MailAddress("anurag.dealstodo@gmail.com"));
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
                catch (Exception ex)
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("~/Logs/logdata.txt"));
                    file.WriteLine(ex.Message);
                    file.Dispose();
                }
            }

        }

        public void SendAdminEmails(string emails, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                try
                {
                    mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;
                    String[] emailList = emails.Split(',');
                    foreach (string item in emailList)
                    {
                        mailMessage.To.Add(new MailAddress(item));
                    }
                    //mailMessage.CC.Add(new MailAddress("alexxanderpurcell@outlook.com"));
                    //mailMessage.Bcc.Add(new MailAddress("anurag.dealstodo@gmail.com"));
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
                catch (Exception ex)
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("~/Logs/logdata.txt"));
                    file.WriteLine(ex.Message);
                    file.Dispose();
                }
            }

        }
    }
}