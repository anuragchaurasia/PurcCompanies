using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrivateICO
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserID"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session["UserID"] = null;
            Session["Name"] = null;
            Session["Email"] = null;
            Request.Cookies["UserID"].Expires = DateTime.Now.AddDays(-1);
            Request.Cookies["Name"].Expires = DateTime.Now.AddDays(-1);
            Request.Cookies["Email"].Expires = DateTime.Now.AddDays(-1);
            Request.Cookies["Usertype"].Expires = DateTime.Now.AddDays(-1);
            Request.Cookies["SessionVal"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["SessionVal"].Value = null;
            Response.Cookies["Email"].Value = null;
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
}