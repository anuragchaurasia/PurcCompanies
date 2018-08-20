using DataLayer.DAL;
using DataLayer.DataHelper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrivateICO
{
    public partial class ViewMCSale : System.Web.UI.Page
    {
        MCSaleHelper mcSalesHelper = new MCSaleHelper();
        List<DocumentEL> serviceListData = new List<DocumentEL>();
        DocumentDAL documentDal = new DocumentDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadMCSale();
            }
        }

        public void LoadMCSale()
        {
            int MCID = Convert.ToInt32(Request.QueryString["MCID"]);
            MCSaleEntity mcSale = mcSalesHelper.GetMCSale(MCID);
            txtAddressOnCard.Text = mcSale.AddressOnCard;
            txtDOT.Text = mcSale.DotNo;
            txtMC.Text = mcSale.MCNo;
            txtNameOnCard.Text = mcSale.NameOnCard;
            txtPhysicalAddress.Text = mcSale.PhysicalAddress;
            txtRecieptEmail.Text = mcSale.Email;
            txtCardNo.Text = mcSale.CardNo;
            lblMCSaleNo.Text = mcSale.MCSaleNo;
            txtDBA.Text = mcSale.DBA;
            txtLegalName.Text = mcSale.LegalName;
            txtDOTPin.Text = mcSale.DotPin;
            foreach (MCServiceSaleEntity item in mcSale.serviceSaleData)
            {
                DocumentEL docEL = new DocumentEL();
                docEL.Description = item.ServicePrice;
                docEL.DocumentID = documentDal.GetDocumentTypeByName(item.ServiceName).DocumentTypeID;
                docEL.DocumentTypeName = item.ServiceName;
                serviceListData.Add(docEL);
            }
            lstServicesPurchased.DataSource = serviceListData;
            lstServicesPurchased.DataBind();
            Label lblTotal = lstServicesPurchased.FindControl("lblSubTotal") as Label;
            try
            {
                lblTotal.Text = "$" + serviceListData.Sum(p => Convert.ToDouble(p.Description.Replace("$", ""))).ToString();
            }
            catch
            {

            }
        }
    }
}