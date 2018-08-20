using DataLayer.DAL;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrivateICO
{
    public partial class DocAnalytics : System.Web.UI.Page
    {
        UserDAL userdal = new UserDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindDocuments();
            }
        }

        private void BindDocuments()
        {
            List<DocumentAnalyticEntity> lstDocs = userdal.GetDocAnalytics();
            lstCustomers.DataSource = lstDocs;
            lstCustomers.DataBind();
        }

        protected void lstCustomers_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

        }
    }
}