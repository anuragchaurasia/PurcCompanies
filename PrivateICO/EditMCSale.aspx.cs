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
    public partial class EditMCSale : System.Web.UI.Page
    {
        MCSaleHelper mcSalesHelper = new MCSaleHelper();
        List<DocumentEL> serviceListData = new List<DocumentEL>();
        DocumentDAL documentDal = new DocumentDAL();
        SettingHelper settingsHelper = new SettingHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadMCSale();
                LoadServices();
                BindPurchasedItems();
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

        public void LoadMCSale()
        {
            int MCID = Convert.ToInt32(Request.QueryString["MCID"]);
            MCSaleEntity mcSale = mcSalesHelper.GetTempMCSale(MCID);
            Session["MCSaleNo"] = mcSale.MCSaleNo;
            txtAddressOnCard.Text = mcSale.AddressOnCard;
            txtDOT.Text = mcSale.DotNo;
            txtMC.Text = mcSale.MCNo;
            txtPhoneNo.Text = mcSale.PhoneNo;
            txtCardNo.Text = mcSale.CardNo;
            hidCardNo.Value = mcSale.CardNo;
            txtNameOnCard.Text = mcSale.NameOnCard;
            txtPhysicalAddress.Text = mcSale.PhysicalAddress;
            txtRecieptEmail.Text = mcSale.Email;
            lblMCSaleNo.Text = mcSale.MCSaleNo;
            txtExpirationDate.Text = mcSale.ExpirationDate;
            txtCVC.Text = mcSale.CVC;
            txtDBA.Text = mcSale.DBA;
            txtDOTPin.Text = mcSale.DotPin;
            txtLegalName.Text = mcSale.LegalName;
            ulcardtype.Attributes["class"] = mcSale.CardType;

            foreach (MCServiceSaleEntity item in mcSale.serviceSaleData)
            {
                DocumentEL docEL = new DocumentEL();
                docEL.Description = item.ServicePrice;
                docEL.DocumentID = documentDal.GetDocumentTypeByName(item.ServiceName).DocumentTypeID;
                docEL.DocumentTypeName = item.ServiceName;
                serviceListData.Add(docEL);
            }
            Session["services"] = serviceListData;
        }

        public void BindPurchasedItems()
        {
            if (Session["services"] != null)
            {
                lstServicesPurchased.DataSource = (List<DocumentEL>)Session["services"];
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

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            int MCID = Convert.ToInt32(Request.QueryString["MCID"]);
            MCSaleEntity mcData = new MCSaleEntity();
            mcData.AddressOnCard = txtAddressOnCard.Text;
            mcData.DotNo = txtDOT.Text;

            mcData.CardNo = hidCardNo.Value;
            mcData.Email = txtRecieptEmail.Text;
            mcData.MCNo = txtMC.Text;
            mcData.NameOnCard = txtNameOnCard.Text;
            mcData.PhysicalAddress = txtPhysicalAddress.Text;
            mcData.MCID = MCID;
            mcData.ExpirationDate = txtExpirationDate.Text;
            mcData.CVC = txtCVC.Text;
            mcData.CardType = ulcardtype.Attributes["class"];
            mcData.MCSaleNo = Session["MCSaleNo"].ToString();
            mcData.PhoneNo = txtPhoneNo.Text;
            mcData.LegalName = txtLegalName.Text;
            mcData.DotPin = txtDOTPin.Text;
            mcData.DBA = txtDBA.Text;
            if (Session["services"] != null)
            {
                serviceListData = (List<DocumentEL>)Session["services"];
                List<MCServiceSaleEntity> saleListEL = new List<MCServiceSaleEntity>();
                foreach (DocumentEL item in serviceListData)
                {
                    MCServiceSaleEntity saleEL = new MCServiceSaleEntity();
                    saleEL.MCSaleID = Convert.ToInt32(Request.QueryString["MCID"]);
                    saleEL.ServiceID = documentDal.GetDocumentTypeByName(item.DocumentTypeName).DocumentTypeID;
                    saleListEL.Add(saleEL);
                }
                mcData.serviceSaleData = saleListEL;
            }
            mcSalesHelper.EditTempMCSales(mcData);
            Response.Write("<script>alert('Details Edited Successfully.');</script>");
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

        protected void btnSubmit_Click(object sender, EventArgs e)
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
                mcData.CardNo = hidCardNo.Value;
                mcData.NameOnCard = txtNameOnCard.Text;
                mcData.PhysicalAddress = txtPhysicalAddress.Text;
                mcData.serviceSaleData = saleServiceEntity;
                mcData.saleType = SaleType.Submitted;
                mcData.SalesPersonID = Convert.ToInt32(Request.Cookies["UserID"].Value);
                mcData.MCID = Convert.ToInt32(Request.QueryString["MCID"]);
                mcData.ExpirationDate = txtExpirationDate.Text;
                mcData.CVC = txtCVC.Text;
                mcData.PhoneNo = txtPhoneNo.Text;
                mcData.CardType = ulcardtype.Attributes["class"];
                mcData.MCSaleNo = Session["MCSaleNo"].ToString();
                mcData.LegalName = txtLegalName.Text;
                mcData.DBA = txtDBA.Text;
                mcData.DotPin = txtDOTPin.Text;
                mcSalesHelper.AddMCSales(mcData);
                EmailHelper emailHelper = new EmailHelper();
                emailHelper.SendPlainEmail("New MC Sale Order", "A new sales order is been closed by " + Request.Cookies["Name"].Value + " (" + Request.Cookies["Email"].Value + "). Please login into admin panel to view orders.", "");
                Response.Write("<script>alert('Details Submitted Successfully.You cant edit them back.');</script>");
                Response.Redirect("ListSubmittedMCProfiles.aspx");
            }
            catch
            {

            }
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