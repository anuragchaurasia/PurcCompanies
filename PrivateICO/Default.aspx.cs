using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer.DataHelper;
using EntityLayer;
using DataLayer.DAL;
using System.Net;
using System.Net.Sockets;

namespace PrivateICO
{
    public partial class Default : System.Web.UI.Page
    {
        UserHelper docHelper = new UserHelper();
        UserDAL userDal = new UserDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            EntityLayer.ComplianceUserData user = new ComplianceUserData();
            if (Request.Cookies["SessionVal"] != null && Request.Cookies["Email"] != null)
            {
                user = docHelper.DirectLogin(Request.Cookies["Email"].Value, Request.Cookies["SessionVal"].Value);
                if (user != null)
                {
                    Session["UserID"] = user.UserID;
                    Session["Name"] = user.Name;
                    Session["Email"] = user.Email;
                    Session["Usertype"] = user.UserType;
                    Response.Cookies["UserID"].Value = user.UserID.ToString();
                    Response.Cookies["Name"].Value = user.Name;
                    Response.Cookies["Email"].Value = user.Email;
                    Response.Cookies["Usertype"].Value = user.UserType;
                    Response.Cookies["SessionVal"].Value = user.Password;

                    Response.Cookies["UserID"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Name"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Email"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Usertype"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["SessionVal"].Expires = DateTime.Now.AddDays(30);

                    if (user.UserType == "Sales")
                    {
                        Response.Redirect("SalesDashboard.aspx");
                    }
                    else
                    {
                        Response.Redirect("AdminDashboard.aspx");
                    }
                }
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            EntityLayer.ComplianceUserData user = new ComplianceUserData();
            user = docHelper.LoginComplianceUser(txtUsername.Text, txtPassword.Text);
            if (user != null)
            {
                Session["UserID"] = user.UserID;
                Session["Name"] = user.Name;
                Session["Email"] = user.Email;
                Session["Usertype"] = user.UserType;
                Response.Cookies["UserID"].Value = user.UserID.ToString();
                Response.Cookies["Name"].Value = user.Name;
                Response.Cookies["Email"].Value = user.Email;
                Response.Cookies["Usertype"].Value = user.UserType;
                Response.Cookies["SessionVal"].Value = user.Password;

                Response.Cookies["UserID"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Name"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Email"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Usertype"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["SessionVal"].Value = user.Password;

                if (user.UserType == "Sales")
                {
                    Response.Redirect("SalesDashboard.aspx");
                }
                else
                {
                    Response.Redirect("AdminDashboard.aspx");
                }
            }
            else
            {
                UsersEL userEL = userDal.Login(txtUsername.Text, txtPassword.Text);
                if (userEL.UserID != 0)
                {
                    Session["UserID"] = userEL.UserID;
                    Session["Name"] = userEL.Name;
                    Session["Email"] = userEL.Email;
                    Session["Usertype"] = "Customer";

                    Response.Cookies["UserID"].Value = userEL.UserID.ToString();
                    Response.Cookies["Name"].Value = userEL.Name;
                    Response.Cookies["Email"].Value = userEL.Email;
                    Response.Cookies["Usertype"].Value = "Customer";

                    Response.Cookies["UserID"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Name"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Email"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Usertype"].Expires = DateTime.Now.AddDays(30);

                    LoginAnalyticsEntity logEntity = new LoginAnalyticsEntity();
                    logEntity.IPAddress = GetLocalIPAddress();
                    logEntity.Username = userEL.Email;
                    logEntity.OS = getOS();
                    System.Web.HttpBrowserCapabilities browser = Request.Browser;
                    logEntity.Platform = browser.Platform;
                    logEntity.Browser = browser.Browser;
                    userDal.AddLoginAnalytic(logEntity);
                    Response.Redirect("DownloadDocs.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Incorrect Credentials.');</script>");
                }
            }
        }

        private string getOS()
        {
            string os = null;
            if (Request.UserAgent.IndexOf("Windows NT 5.1") > 0)
            {
                os = "Windows XP";
                return os;
            }
            else if (Request.UserAgent.IndexOf("Windows NT 6.0") > 0)
            {
                os = "Windows Vista";
                return os;
            }
            else if (Request.UserAgent.IndexOf("Windows NT 6.1") > 0)
            {
                os = "Windows 7";
                return os;
            }
            else if (Request.UserAgent.IndexOf("Intel Mac OS X") > 0)
            {
                //os = "Mac OS or older version of Windows";
                os = "Intel Mac OS X";
                return os;
            }
            else
            {
                os = "You are using older version of Windows or Mac OS";
                return os;
            }

        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        protected void btnForgetPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgetPassword.aspx");
        }

    }
}