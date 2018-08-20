using DataLayer.Common;
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
    public partial class MCDriverProfile : System.Web.UI.Page
    {
        DocumentDAL documentDal = new DocumentDAL();
        List<DocumentEL> serviceListData = new List<DocumentEL>();
        MCSaleHelper mcSalesHelper = new MCSaleHelper();
        SettingHelper settingsHelper = new SettingHelper();
        Random rand = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadServices();
                if (Session["services"] != null)
                {
                    BindPurchasedItems();
                }
            }
            if (!String.IsNullOrEmpty(hdnCardType.Value))
            {
                ulcardtype.Attributes["class"] = hdnCardType.Value;
            }
        }

        public void LoadServices()
        {
            drpServices.Items.Clear();
            List<DocumentEL> lstDocs = documentDal.GetAllDocumentType();
            foreach (DocumentEL item in lstDocs)
            {
                ListItem serviceData = new ListItem(item.DocumentTypeName, item.Description);
                serviceData.Attributes.Add("serviceid", item.DocumentID.ToString());
                drpServices.Items.Add(serviceData);
            }

        }


        protected void btnAddService_Click(object sender, EventArgs e)
        {

            bool isServiceExist = false;
            if (Session["services"] != null)
            {
                serviceListData = (List<DocumentEL>)Session["services"];
                isServiceExist = serviceListData.Any(x => x.Description == drpServices.SelectedItem.Value && x.DocumentTypeName == drpServices.SelectedItem.Text);
            }

            if (!isServiceExist)
            {
                DocumentEL service = new DocumentEL();
                service.Description = drpServices.SelectedItem.Value;
                service.DocumentTypeName = drpServices.SelectedItem.Text;
                service.DocumentID = documentDal.GetDocumentTypeByName(drpServices.SelectedItem.Text).DocumentTypeID;
                if (Session["services"] == null)
                {
                    serviceListData.Add(service);
                }
                else
                {
                    serviceListData = (List<DocumentEL>)Session["services"];
                    serviceListData.Add(service);
                }
                Session["services"] = serviceListData;

            }

            BindPurchasedItems();
        }

        public void BindPurchasedItems()
        {
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

        protected void btnSaveDriver_Click(object sender, EventArgs e)
        {
            try
            {
                serviceListData = (List<DocumentEL>)Session["services"];
                List<MCServiceSaleEntity> saleServiceEntity = new List<MCServiceSaleEntity>();
                if (serviceListData != null)
                {
                    foreach (DocumentEL item in serviceListData)
                    {
                        MCServiceSaleEntity mcsale = new MCServiceSaleEntity();
                        mcsale.ServiceID = item.DocumentID;
                        saleServiceEntity.Add(mcsale);

                    }
                }
                
                MCSaleEntity mcData = new MCSaleEntity();
                mcData.AddressOnCard = txtAddressOnCard.Text;
                mcData.DotNo = txtDOT.Text;
                mcData.Email = txtRecieptEmail.Text;
                mcData.MCNo = txtMC.Text;
                mcData.PhoneNo = txtPhoneNo.Text;
                mcData.NameOnCard = txtNameOnCard.Text;
                mcData.PhysicalAddress = txtPhysicalAddress.Text;
                mcData.serviceSaleData = saleServiceEntity;
                mcData.saleType = SaleType.Saved;
                mcData.CardNo = txtCardNo.Text;
                mcData.SalesPersonID = Convert.ToInt32(Request.Cookies["UserID"].Value);
                mcData.ExpirationDate = txtExpirationDate.Text;
                mcData.CVC = txtCVC.Text;
                mcData.MCSaleNo = hidSaleNo.Value;
                mcData.CardType = ulcardtype.Attributes["class"];
                mcData.PhoneNo = txtPhoneNo.Text;
                mcData.LegalName = txtLegalName.Text;
                mcData.DBA = txtDBA.Text;
                mcData.DotPin = txtDOTPin.Text;
                mcSalesHelper.AddMCSales(mcData);
                Session["services"] = null;
                Response.Redirect("ListSavedMCProfiles.aspx");
            }
            catch
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            serviceListData = (List<DocumentEL>)Session["services"];
            List<MCServiceSaleEntity> saleServiceEntity = new List<MCServiceSaleEntity>();
            if (serviceListData != null)
            {
                foreach (DocumentEL item in serviceListData)
                {
                    MCServiceSaleEntity mcsale = new MCServiceSaleEntity();
                    mcsale.ServiceID = item.DocumentID;
                    saleServiceEntity.Add(mcsale);
                }
            }

            MCSaleEntity mcData = new MCSaleEntity();
            mcData.AddressOnCard = txtAddressOnCard.Text;
            mcData.DotNo = txtDOT.Text;
            mcData.Email = txtRecieptEmail.Text;
            mcData.MCNo = txtMC.Text;
            mcData.NameOnCard = txtNameOnCard.Text;
            mcData.PhysicalAddress = txtPhysicalAddress.Text;
            mcData.serviceSaleData = saleServiceEntity;
            mcData.saleType = SaleType.Submitted;
            mcData.SalesPersonID = Convert.ToInt32(Request.Cookies["UserID"].Value);
            mcData.CardNo = txtCardNo.Text;
            mcData.ExpirationDate = txtExpirationDate.Text;
            mcData.CVC = txtCVC.Text;
            mcData.MCSaleNo = hidSaleNo.Value;
            mcData.CardType = ulcardtype.Attributes["class"];
            mcData.PhoneNo = txtPhoneNo.Text;
            mcSalesHelper.AddMCSales(mcData);
            Session["services"] = null;
            EmailHelper emailHelper = new EmailHelper();
            emailHelper.SendPlainEmail("New MC Sale Order", "A new sales order is been closed by " + Request.Cookies["Name"].Value + " (" + Request.Cookies["Email"].Value + "). Please login into admin panel to view orders.", "");
            Response.Redirect("ListSubmittedMCProfiles.aspx");
            Response.Write("<script>alert('Details Submitted Successfully.You cant edit them back.');</script>");
            ResetAll();
        }

        public void ResetAll()
        {
            txtDOT.Text = "";
            txtMC.Text = "";
            txtNameOnCard.Text = "";
            txtRecieptEmail.Text = "";
            txtAddressOnCard.Text = "";
            txtPhysicalAddress.Text = "";
            chkSameAddress.Checked = false;
        }

        protected void lstServicesPurchased_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DelService")
            {
                if (Session["services"] != null)
                {
                    serviceListData = (List<DocumentEL>)Session["services"];
                    DocumentEL docEL = serviceListData.Where(x => x.DocumentID == Convert.ToInt32(e.CommandArgument)).FirstOrDefault();
                    serviceListData.Remove(docEL);
                    BindPurchasedItems();
                }
            }
        }

    }
}