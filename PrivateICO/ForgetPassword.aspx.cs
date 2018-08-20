using DataLayer.DataHelper;
using DataLayer.Helper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrivateICO
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        UserHelper userHelper = new UserHelper();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            bool isAvailable=false;
            try
            {
                isAvailable = userHelper.IsEmailAvailable(txtUsername.Text);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            if (!userHelper.IsEmailAvailable(txtUsername.Text))
            {
                Response.Write("<script>alert('Email doesn't exist into our database.');</script>");
            }
            else
            {
                try
                {
                    ComplianceUserData user = userHelper.GetComplianceUserEmail(txtUsername.Text);
                    Random rand = new Random();
                    int randomPass = rand.Next(100000, 999999);
                    user.Password = randomPass.ToString();
                    userHelper.EditSalesUserPassword(user);
                    SendHtmlFormattedEmail("Password Recovery", user, randomPass.ToString());
                    Response.Write("<script>alert('Password recovery email sent successfully.');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('"+ex.Message+"');</script>");
                }
            }
        }

        private string createEmailBody(string email, string name, string password)
        {
            string body = string.Empty;
            //using streamreader for reading my htmltemplate   
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Templates/NewAccount.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{{Name}}", name);
            body = body.Replace("{{BodyText}}", "Your password has been reset.");
            body = body.Replace("{{Email}}", email);
            body = body.Replace("{{Password}}", password);
            return body;
        }

        public void SendHtmlFormattedEmail(string subject, ComplianceUserData user, string password)
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
                    //mailMessage.CC.Add(new MailAddress("alexxanderpurcell@outlook.com"));
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
                    Response.Write("<script>alert('"+ex.Message+"');</script>");
                    System.IO.StreamWriter file = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("~/Logs/logdata.txt"));
                    file.WriteLine(ex.Message);
                    file.Dispose();
                }
            }

        }

    }
}