using DataLayer.DAL;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrivateICO
{
    public partial class Documents : System.Web.UI.Page
    {
        DocumentDAL documentDal = new DocumentDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindDocuments();
            }
        }

        private void BindDocuments()
        {
            List<DocumentEL> lstDocs = documentDal.GetAllDocumentType();
            lstDocuments.DataSource = lstDocs.OrderBy(x => x.DocumentID).ToList();
            lstDocuments.DataBind();
        }

        [WebMethod]
        public void TransferFile()
        {

            HttpContext postedContext = HttpContext.Current;
            HttpFileCollection Request = postedContext.Request.Files;
            foreach (HttpPostedFile item in Request)
            {
                string filename = item.FileName;

                byte[] fileBytes = new byte[item.ContentLength];
                item.InputStream.Read(fileBytes, 0, item.ContentLength);
                //TransferFile(filename, fileBytes);

                //objFileTransfer.TransferFile(filename, fileBytes);
                //retJSON = js.Serialize(new { Result = objFileTransfer.TransferFile(filename, fileBytes) });
                //Context.Response.Write(retJSON);
                // fileBytes now contains the content of the file
                // filename contains the name of the file
            }
        }

        protected void lstDocuments_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Modify")
            {
                Session["EditID"] = e.CommandArgument;
                DocumentEL doc = documentDal.GetDocumentTypeByID(e.CommandArgument.ToString());
                txtDescription.Text = doc.Description;
                txtDocName.Text = doc.DocumentTypeName;
                this.BindDocuments();
            }
            else
                if (e.CommandName == "Del")
                {
                    documentDal.DeleteDocumentType(e.CommandArgument.ToString());
                    this.BindDocuments();
                }
        }

        protected void lstDocuments_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lstDocuments.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindDocuments();
        }

        protected void btnSaveDocument_Click(object sender, EventArgs e)
        {
            if (Session["EditID"] == null)
            {
                DocumentEL docEL = new DocumentEL();
                docEL.Description = txtDescription.Text;
                docEL.DocumentTypeName = txtDocName.Text;
                documentDal.AddDocumentType(docEL);
                this.BindDocuments();
            }
            else
            {
                DocumentEL docEL = new DocumentEL();
                docEL.Description = txtDescription.Text;
                docEL.DocumentTypeName = txtDocName.Text;
                docEL.DocumentTypeID = Convert.ToInt32(Session["EditID"]);
                documentDal.EditDocumentType(docEL);
                Session["EditID"] = null;
                this.BindDocuments();
            }
        }
    }
}