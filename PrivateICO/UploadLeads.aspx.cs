using DataLayer.DataHelper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrivateICO
{
    public partial class UploadLeads : System.Web.UI.Page
    {
        UserHelper userHelper = new UserHelper();
        LeadDocumentHelper leadDocHelper = new LeadDocumentHelper();
        DailyLeadsHelper dailyLeadsHelper = new DailyLeadsHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindSalesUsers();
            }
        }

        protected void lstUsers_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lstUsers.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindSalesUsers();
        }

        public void BindSalesUsers()
        {
            List<ComplianceUserData> lstUserData = userHelper.GetAllComplianceUsers().Where(x => x.UserType == "Sales").ToList();
            lstUsers.DataSource = lstUserData;
            lstUsers.DataBind();
        }

        protected DateTime GetCurrentTime()
        {
            DateTime serverTime = DateTime.Now;
            DateTime _localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(serverTime, TimeZoneInfo.Local.Id, "Mountain Standard Time");
            return _localTime;
        }

        protected void lstUsers_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Upl")
            {
                FileUpload fileUpl = e.Item.FindControl("flUpload") as FileUpload;
                LeadDocEntity leadEntity = new LeadDocEntity();
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + fileUpl.FileName;
                leadEntity.DocumentName = fileUpl.FileName;
                leadEntity.DocumentPath = "Uploads/" + fileName;
                leadEntity.UploadedFor = Convert.ToInt32(e.CommandArgument);
                leadEntity.UploadDate = GetCurrentTime().ToShortDateString();
                leadEntity.UploadedBy = Request.Cookies["Name"].Value;
                //int leadDocID = leadDocHelper.CheckDoc(leadEntity);
                int leadDocID = 0;
                if (leadDocID == 0)
                {
                    ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                    fileUpl.SaveAs(Server.MapPath("~/Uploads/" + fileName));
                    int isuploaded = leadDocHelper.AddLeadDoc(leadEntity);
                    if (isuploaded > 0)
                    {
                        var excelName = Server.MapPath("~/Uploads/" + fileName);
                        var connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelName + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";";

                        var adapter = new OleDbDataAdapter("SELECT * FROM [Leads$]", connectionString);
                        var ds = new DataSet();

                        try
                        {
                            adapter.Fill(ds, "ExcelFileData");
                        }
                        catch (Exception ex)
                        {
                            Response.Write("<script>alert('" + ex.Message + "');</script>");
                        }

                        DataTable data = ds.Tables["ExcelFileData"];
                        List<DataRow> list = data.AsEnumerable().ToList();
                        List<DailyLeadEntity> listLeadsData = new List<DailyLeadEntity>();
                        foreach (DataRow item in list)
                        {
                            DailyLeadEntity saleData = new DailyLeadEntity();
                            saleData.AuthForHire = item["AuthForHire"].ToString();
                            saleData.DateFiled = item["DateFiled"].ToString();
                            saleData.DOTNumber = item["DOTNumber"].ToString();
                            saleData.Drivers = item["Drivers"].ToString();
                            saleData.Interstate = item["Interstate"].ToString();
                            saleData.LeadDocID = isuploaded;
                            saleData.LegalName = item["LegalName"].ToString();
                            saleData.MailingAddress = item["MailingAddress"].ToString();
                            saleData.OperatingStatus = item["OperatingStatus"].ToString();
                            saleData.PhoneNo = item["PhoneNo"].ToString();
                            saleData.PhysicalAddress = item["PhysicalAddress"].ToString();
                            saleData.PowerUnits = item["PowerUnits"].ToString();
                            saleData.Status = "New Leads";
                            saleData.TimeZone = item["TimeZone"].ToString();
                            saleData.ZipCode = item["ZipCode"].ToString();
                            listLeadsData.Add(saleData);
                        }
                        dailyLeadsHelper.AddBulkLeads(listLeadsData);
                        // = list.Select(new DailyLeadEntity() { AuthForHire = list["AuthForHire"] }).ToList();
                        Response.Write("<script>alert('Lead uploaded Successfully.');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Some error occured.');</script>");
                    }
                }
                else
                {
                    leadEntity.LeadDocID = leadDocID;
                    fileUpl.SaveAs(Server.MapPath("~/Uploads/" + fileName));
                    leadDocHelper.UpdateLeadDoc(leadEntity);
                    Response.Write("<script>alert('Lead updated Successfully.');</script>");
                }
            }
        }
    }
}