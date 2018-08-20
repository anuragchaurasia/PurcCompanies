using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrivateICO
{
    public partial class CustomerMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            Response.Cookies["SessionVal"].Value = null;
            Response.Cookies["Email"].Value = null;
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
}