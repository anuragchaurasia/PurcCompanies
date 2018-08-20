using DataLayer.DataHelper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Mail;
using System.Configuration;

namespace PrivateICO
{
    public partial class RegisterSalesMan : System.Web.UI.Page
    {
        UserHelper userHelper = new UserHelper();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddUsers_Click(object sender, EventArgs e)
        {
            ComplianceUserData user = new ComplianceUserData();
            user.CreationTime = DateTime.Now.ToString();
            user.Email = txtEmail.Text;
            user.IsActive = true;
            user.Name = txtFirstName.Text;
            user.Password = txtPassword.Text;
            user.UserType = ddlUserType.SelectedItem.Text;
            user.IsContractor = ChkIsContractor.Checked;
            bool isRegistered = userHelper.RegisterSalesUser(user);
            if (isRegistered)
            {
                SendHtmlFormattedEmail("Account Created", user, txtPassword.Text);
                Response.Write("<script>alert('User Registered Successfully.');</script>");
                txtEmail.Text = "";
                txtFirstName.Text = "";
                ChkIsContractor.Checked = false;
            }
            else
            {
                Response.Write("<script>alert('Some error occured.');</script>");
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
            body = body.Replace("{{Name}}", name); //replacing the required things
            body = body.Replace("{{BodyText}}", "Congratulations ! Purcell Compliance team has made your account ready.");
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
                    System.IO.StreamWriter file = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("~/Logs/logdata.txt"));
                    file.WriteLine(ex.Message);
                    file.Dispose();
                }
            }

        }
    }
}