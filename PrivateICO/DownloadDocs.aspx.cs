using DataLayer.DAL;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrivateICO
{
    public partial class DownloadDocs : System.Web.UI.Page
    {
        DocumentDAL documentDal = new DocumentDAL();
        UserDAL userDal = new UserDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindDocuments();
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

        private void BindDocuments()
        {
            string userid = Request.Cookies["UserID"].Value;
            List<DocumentEL> lstDocs = documentDal.GetUserDocuments(userid);
            lstDocuments.DataSource = lstDocs;
            lstDocuments.DataBind();
        }

        protected void lstDocuments_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DownloadDoc")
            {
                string filename = e.CommandArgument.ToString().Replace("Uploads/", "");
                DocumentAnalyticEntity docEntity = new DocumentAnalyticEntity();
                docEntity.IPAddress = GetLocalIPAddress();
                docEntity.Username = Request.Cookies["Email"].Value;
                docEntity.OS = getOS();
                System.Web.HttpBrowserCapabilities browser = Request.Browser;
                docEntity.Platform = browser.Platform;
                docEntity.Browser = browser.Browser;
                docEntity.DocumentName = filename;
                userDal.AddDocumentAnalytic(docEntity);
                
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
                Response.TransmitFile(Server.MapPath("~/" + e.CommandArgument));
                Response.End();

                
            }
        }

        protected void lstDocuments_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

        }
    }
}