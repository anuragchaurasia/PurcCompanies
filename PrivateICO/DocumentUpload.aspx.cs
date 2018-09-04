using DataLayer.DAL;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.IO;
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
        
        string Userid = null, UsDot=null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Userid = Request.QueryString["id"].ToString();
             UsDot = Request.QueryString["UsDot"].ToString();
            if (!this.IsPostBack)
            {
                //if (!string.IsNullOrEmpty (Userid ))
                //{
                //    this.BindDocumentTypesById(Userid);
                //}
                //else
                //{
                //    this.BindDocumentTypes();

                //}
                this.BindDocumentTypes();
            }
        }

        private void BindDocumentTypes()
        {
            List<DocumentEL> lstDocs = documentDal.GetAllDocumentType();
            lstDocuments.DataSource = lstDocs;
            lstDocuments.DataBind();
        }
        private void BindDocumentTypesById(string UserId)
        {
            DocumentEL lstDocs = documentDal.GetDocumentTypeByID(UserId);
            List<DocumentEL> lstDocsLst = new List<DocumentEL>();
            lstDocsLst.Add(lstDocs);
            lstDocuments.DataSource = lstDocsLst;
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
            Random rand = new Random();
            if (e.CommandName == "Upl")
            {
                Userid = Request.QueryString["id"].ToString();
                FileUpload fileUpl = e.Item.FindControl("flUpload") as FileUpload;
                Label lblDocTypeName = e.Item.FindControl("txtDocTypeName") as Label;
                DocumentEL docEL = new DocumentEL();
              //  string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + fileUpl.FileName;
                string fileName = fileUpl.FileName;
                string ext = Path.GetExtension(fileName);
                fileName = lblDocTypeName.Text +"_"+GenerateRandomNo ()+ ext;
                docEL.DocumentID = Convert.ToInt32(e.CommandArgument);
                docEL.UserID = Convert.ToInt32(Userid);
               // docEL.DocumentPath = "Uploads/" + fileName;
              string saleId = documentDal.GetOrderByUSDOT(UsDot);
                string NewDirectory = "~/Uploads/" + saleId+ "/";
                if (!Directory.Exists(NewDirectory))
                {
                    //If No any such directory then creates the new one
                    Directory.CreateDirectory(Server.MapPath(NewDirectory));
                    
                }
               

                fileUpl.SaveAs(Server.MapPath(NewDirectory + fileName));
                string filepath = NewDirectory + fileName;
                docEL.DocumentPath = filepath;
                // fileUpl.SaveAs(Server.MapPath("~/Uploads/" + fileName));
                bool isDocInserted = documentDal.AddDocument(docEL);
                UsersEL userEL = userDal.GetCustomerByID(Userid);

                // New changes with DocumetnUpload table

                //DocumentUploadEL _docRec = new DocumentUploadEL();
                //_docRec.UserId = Convert.ToInt32( Userid);
                //_docRec.doc_id= Convert.ToInt32(e.CommandArgument);
                //_docRec.doctypename = lblDocTypeName.Text.ToString(); ;
                //_docRec.filepath = filepath;
                //bool isDocUploadInserted = documentDal.AddDocumentUpload(_docRec);
                //AddDocumentUpload
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

        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
    }
}