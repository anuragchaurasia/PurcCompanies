using DataLayer.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer.Helper;
using System.IO;
using System.Net.Mail;
using System.Configuration;

namespace PrivateICO
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        UserHelper userHelper = new UserHelper();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddUser_Click(object sender, EventArgs e)
        {
            
        }

        private string createEmailBody(string email, string name, string password)
        {
            string body = string.Empty;
            //using streamreader for reading my htmltemplate   
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Templates/NewAccount.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{{Name}}", name); //replacing the required things
            body = body.Replace("{{BodyText}}", "Congratulations ! QTM admin team has made your account ready.");
            body = body.Replace("{{Email}}", email);
            body = body.Replace("{{Password}}", password);
            return body;
        }

        //public void SendHtmlFormattedEmail(string subject, EntityLayer.User user, string password)
        //{
        //    using (MailMessage mailMessage = new MailMessage())
        //    {
        //        try
        //        {
        //            mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
        //            mailMessage.Subject = subject;
        //            mailMessage.Body = createEmailBody(user.EmailAddress, user.FirstName + " " + user.LastName, password);
        //            mailMessage.IsBodyHtml = true;
        //            mailMessage.To.Add(new MailAddress(user.EmailAddress));
        //            //mailMessage.CC.Add(new MailAddress("alexxanderpurcell@outlook.com"));
        //            mailMessage.Bcc.Add(new MailAddress("anurag.dealstodo@gmail.com"));
        //            SmtpClient smtp = new SmtpClient();
        //            smtp.Host = ConfigurationManager.AppSettings["Host"];
        //            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
        //            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
        //            NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"]; //reading from web.config  
        //            NetworkCred.Password = ConfigurationManager.AppSettings["Password"]; //reading from web.config  
        //            smtp.UseDefaultCredentials = true;
        //            smtp.Credentials = NetworkCred;
        //            smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]); //reading from web.config  
        //            smtp.Send(mailMessage);
        //        }
        //        catch (Exception ex)
        //        {
        //            System.IO.StreamWriter file = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("~/Logs/logdata.txt"));
        //            file.WriteLine(ex.Message);
        //            file.Dispose();
        //        }
        //    }

        //}
    }
}