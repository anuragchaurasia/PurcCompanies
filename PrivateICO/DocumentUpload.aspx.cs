using DataLayer.DAL;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrivateICO
{
    public partial class DocumentUpload : System.Web.UI.Page
    {
        DocumentDAL documentDal = new DocumentDAL();
        UserDAL userDal = new UserDAL();
        string Userid = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Userid = Request.QueryString["id"].ToString();
            if (!this.IsPostBack)
            {
                this.BindDocumentTypes();
            }
        }

        private void BindDocumentTypes()
        {
            List<DocumentEL> lstDocs = documentDal.GetAllDocumentType();
            lstDocuments.DataSource = lstDocs;
            lstDocuments.DataBind();
        }


        private List<DocumentEL> GetUserDocs()
        {
            List<DocumentEL> lstDocs = new List<DocumentEL>();
            Userid = Request.QueryString["id"].ToString();
            lstDocs = documentDal.GetUserDocuments(Userid);
            return lstDocs;
        }

        protected void lstDocuments_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Upl")
            {
                Userid = Request.QueryString["id"].ToString();
                FileUpload fileUpl = e.Item.FindControl("flUpload") as FileUpload;
                DocumentEL docEL = new DocumentEL();
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + fileUpl.FileName;
                docEL.DocumentID = Convert.ToInt32(e.CommandArgument);
                docEL.UserID = Convert.ToInt32(Userid);
                docEL.DocumentPath = "Uploads/" + fileName;
                fileUpl.SaveAs(Server.MapPath("~/Uploads/" + fileName));
                bool isDocInserted = documentDal.AddDocument(docEL);
                UsersEL userEL = userDal.GetCustomerByID(Userid);
                if (!String.IsNullOrEmpty(userEL.PushToken) && !String.IsNullOrEmpty(userEL.DeviceType))
                {
                    //PushNotificationData pushData = new PushNotificationData();

                    //pushData.DevicePushToken = userEL.PushToken;
                    //if (userEL.DeviceType.Equals("Android"))
                    //{
                    //    pushData.DeviceType = DeviceType.Android;
                    //}
                    //else
                    //    if (userEL.DeviceType.Equals("Iphone"))
                    //    {
                    //        pushData.DeviceType = DeviceType.IPhone;
                    //    }
                    //pushData.Message = "A New document is been uploaded on your profile. Please check your document section to view.";
                    //PushHelper.SendPushMessage(pushData);
                }
                
                if (isDocInserted)
                {
                    Response.Write("<script>alert('Document uploaded successfully.');</script>");
                    this.BindDocumentTypes();
                }
                else
                {
                    Response.Write("<script>alert('Some Error Occured.');</script>");
                }

            }
        }

        protected void lstDocuments_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

        }

        protected void lstDocuments_DataBinding(object sender, EventArgs e)
        {

        }

        protected void lstDocuments_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                HiddenField hidDocID = (HiddenField)e.Item.FindControl("hidDocID");
                DocumentEL docEL = GetUserDocs().Where(x => x.DocumentID == Convert.ToInt32(hidDocID.Value)).FirstOrDefault();
                if (docEL != null)
                {
                    Label txtDocName = (Label)e.Item.FindControl("txtDocTypeName");
                    txtDocName.Visible = false;
                    LinkButton lnkDocName = (LinkButton)e.Item.FindControl("lnkDocTypeName");
                    lnkDocName.Visible = true;
                    lnkDocName.Attributes["href"] = docEL.DocumentPath;
                    lnkDocName.Attributes["target"] = "_blank";
                    lnkDocName.PostBackUrl = docEL.DocumentPath;
                }
            }
        }
    }
}