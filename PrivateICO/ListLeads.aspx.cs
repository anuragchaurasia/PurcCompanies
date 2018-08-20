using DataLayer.DataHelper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PrivateICO
{
    public partial class ListLeads : System.Web.UI.Page
    {
        DailyLeadsHelper leadHelper = new DailyLeadsHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindLeads();
            }
        }


        private void BindLeads()
        {
            if (ddlSortByTime.SelectedItem.Text == "Newest First" && ddlSortByOperatingStatus.SelectedItem.Text == "Please Select" && ddlSortByClosedStatus.SelectedItem.Text == "Please Select" && ddlTimeZone.SelectedItem.Text == "Please Select")
            {
                List<DailyLeadEntity> lstLeadsData = leadHelper.GetLeadRecordsByUserIDDesc(Convert.ToInt32(Request.Cookies["UserID"].Value));
                lstOfLeads.DataSource = lstLeadsData;
                lstOfLeads.DataBind();
                UpdateLeadStats(lstLeadsData);
            }
            else
                if (ddlSortByTime.SelectedItem.Text == "Oldest First" && ddlSortByOperatingStatus.SelectedItem.Text == "Please Select" && ddlSortByClosedStatus.SelectedItem.Text == "Please Select" && ddlTimeZone.SelectedItem.Text == "Please Select")
                {
                    List<DailyLeadEntity> lstLeadsData = leadHelper.GetLeadRecordsByUserID(Convert.ToInt32(Request.Cookies["UserID"].Value)).OrderByDescending(x => DateTime.Parse(x.SavedOn)).ToList();
                    lstLeadsData.Sort((x, y) => (DateTime.Parse(y.SavedOn)).CompareTo(DateTime.Parse(x.SavedOn)));
                    lstOfLeads.DataSource = lstLeadsData;
                    lstOfLeads.DataBind();
                    UpdateLeadStats(lstLeadsData);
                }
                else
                    if (ddlSortByTime.SelectedItem.Text == "Oldest First" && (ddlSortByOperatingStatus.SelectedItem.Text != "Please Select" && ddlSortByClosedStatus.SelectedItem.Text != "Please Select" && ddlTimeZone.SelectedItem.Text != "Please Select"))
                    {
                        List<DailyLeadEntity> lstOperatingStatusData = leadHelper.GetLeadRecordsByUserID(Convert.ToInt32(Request.Cookies["UserID"].Value)).Where(x => x.OperatingStatus.ToUpper() == ddlSortByOperatingStatus.SelectedItem.Text.ToUpper() && x.Status.ToUpper() == ddlSortByClosedStatus.SelectedItem.Text.ToUpper() && x.TimeZone.ToUpper() == ddlTimeZone.SelectedItem.Text.ToUpper()).ToList();
                        List<DailyLeadEntity> lstLeadsData = new List<DailyLeadEntity>();
                        lstLeadsData.AddRange(lstOperatingStatusData);
                        lstOfLeads.DataSource = lstLeadsData;
                        lstOfLeads.DataBind();
                        UpdateLeadStats(lstLeadsData);
                    }
                    else
                        if (ddlSortByTime.SelectedItem.Text == "Oldest First" && (ddlSortByOperatingStatus.SelectedItem.Text == "Please Select" && ddlSortByClosedStatus.SelectedItem.Text != "Please Select" && ddlTimeZone.SelectedItem.Text != "Please Select"))
                        {
                            List<DailyLeadEntity> lstOperatingStatusData = leadHelper.GetLeadRecordsByUserID(Convert.ToInt32(Request.Cookies["UserID"].Value)).Where(x => x.Status.ToUpper() == ddlSortByClosedStatus.SelectedItem.Text.ToUpper() && x.TimeZone.ToUpper() == ddlTimeZone.SelectedItem.Text.ToUpper()).ToList();
                            List<DailyLeadEntity> lstLeadsData = new List<DailyLeadEntity>();
                            lstLeadsData.AddRange(lstOperatingStatusData);
                            lstOfLeads.DataSource = lstLeadsData;
                            lstOfLeads.DataBind();
                            UpdateLeadStats(lstLeadsData);
                        }
                        else
                            if (ddlSortByTime.SelectedItem.Text == "Oldest First" && (ddlSortByOperatingStatus.SelectedItem.Text == "Please Select" && ddlSortByClosedStatus.SelectedItem.Text == "Please Select" && ddlTimeZone.SelectedItem.Text != "Please Select"))
                            {
                                List<DailyLeadEntity> lstOperatingStatusData = leadHelper.GetLeadRecordsByUserID(Convert.ToInt32(Request.Cookies["UserID"].Value)).Where(x => x.TimeZone.ToUpper() == ddlTimeZone.SelectedItem.Text.ToUpper()).ToList();
                                List<DailyLeadEntity> lstLeadsData = new List<DailyLeadEntity>();
                                lstLeadsData.AddRange(lstOperatingStatusData);
                                lstOfLeads.DataSource = lstLeadsData;
                                lstOfLeads.DataBind();
                                UpdateLeadStats(lstLeadsData);
                            }
                            else
                                if (ddlSortByTime.SelectedItem.Text == "Oldest First" && (ddlSortByOperatingStatus.SelectedItem.Text != "Please Select" && ddlSortByClosedStatus.SelectedItem.Text == "Please Select" && ddlTimeZone.SelectedItem.Text != "Please Select"))
                                {
                                    List<DailyLeadEntity> lstOperatingStatusData = leadHelper.GetLeadRecordsByUserID(Convert.ToInt32(Request.Cookies["UserID"].Value)).Where(x => x.OperatingStatus.ToUpper() == ddlSortByOperatingStatus.SelectedItem.Text.ToUpper() && x.TimeZone.ToUpper() == ddlTimeZone.SelectedItem.Text.ToUpper()).ToList();
                                    List<DailyLeadEntity> lstLeadsData = new List<DailyLeadEntity>();
                                    lstLeadsData.AddRange(lstOperatingStatusData);
                                    lstOfLeads.DataSource = lstLeadsData;
                                    lstOfLeads.DataBind();
                                    UpdateLeadStats(lstLeadsData);
                                }
                                else
                                    if (ddlSortByTime.SelectedItem.Text == "Oldest First" && (ddlSortByOperatingStatus.SelectedItem.Text != "Please Select" && ddlSortByClosedStatus.SelectedItem.Text == "Please Select" && ddlTimeZone.SelectedItem.Text == "Please Select"))
                                    {
                                        List<DailyLeadEntity> lstOperatingStatusData = leadHelper.GetLeadRecordsByUserID(Convert.ToInt32(Request.Cookies["UserID"].Value)).Where(x => x.OperatingStatus.ToUpper() == ddlSortByOperatingStatus.SelectedItem.Text.ToUpper()).ToList();
                                        List<DailyLeadEntity> lstLeadsData = new List<DailyLeadEntity>();
                                        lstLeadsData.AddRange(lstOperatingStatusData);
                                        lstOfLeads.DataSource = lstLeadsData;
                                        lstOfLeads.DataBind();
                                        UpdateLeadStats(lstLeadsData);
                                    }
                                    else
                                        if (ddlSortByTime.SelectedItem.Text == "Oldest First" && (ddlSortByOperatingStatus.SelectedItem.Text == "Please Select" && ddlSortByClosedStatus.SelectedItem.Text != "Please Select" && ddlTimeZone.SelectedItem.Text == "Please Select"))
                                        {
                                            List<DailyLeadEntity> lstOperatingStatusData = leadHelper.GetLeadRecordsByUserID(Convert.ToInt32(Request.Cookies["UserID"].Value)).Where(x => x.OperatingStatus.ToUpper() == ddlSortByOperatingStatus.SelectedItem.Text.ToUpper()).ToList();
                                            List<DailyLeadEntity> lstLeadsData = new List<DailyLeadEntity>();
                                            lstLeadsData.AddRange(lstOperatingStatusData);
                                            lstOfLeads.DataSource = lstLeadsData;
                                            lstOfLeads.DataBind();
                                            UpdateLeadStats(lstLeadsData);
                                        }

                                        else
                                            if (ddlSortByTime.SelectedItem.Text == "Oldest First" && (ddlSortByOperatingStatus.SelectedItem.Text != "Please Select" && ddlSortByClosedStatus.SelectedItem.Text != "Please Select" && ddlTimeZone.SelectedItem.Text == "Please Select"))
                                            {
                                                List<DailyLeadEntity> lstOperatingStatusData = leadHelper.GetLeadRecordsByUserID(Convert.ToInt32(Request.Cookies["UserID"].Value)).Where(x => x.Status.ToUpper() == ddlSortByClosedStatus.SelectedItem.Text.ToUpper()).ToList();
                                                List<DailyLeadEntity> lstLeadsData = new List<DailyLeadEntity>();
                                                lstLeadsData.AddRange(lstOperatingStatusData);
                                                lstOfLeads.DataSource = lstLeadsData;
                                                lstOfLeads.DataBind();
                                                UpdateLeadStats(lstLeadsData);
                                            }

                                            else
                                                if (ddlSortByTime.SelectedItem.Text == "Newest First" && (ddlSortByOperatingStatus.SelectedItem.Text != "Please Select" && ddlSortByClosedStatus.SelectedItem.Text != "Please Select" && ddlTimeZone.SelectedItem.Text != "Please Select"))
                                                {
                                                    List<DailyLeadEntity> lstOperatingStatusData = leadHelper.GetLeadRecordsByUserIDDesc(Convert.ToInt32(Request.Cookies["UserID"].Value)).Where(x => x.OperatingStatus.ToUpper() == ddlSortByOperatingStatus.SelectedItem.Text.ToUpper() && x.Status.ToUpper() == ddlSortByClosedStatus.SelectedItem.Text.ToUpper() && x.TimeZone.ToUpper() == ddlTimeZone.SelectedItem.Text.ToUpper()).ToList();
                                                    List<DailyLeadEntity> lstLeadsData = new List<DailyLeadEntity>();
                                                    lstLeadsData.AddRange(lstOperatingStatusData);
                                                    lstOfLeads.DataSource = lstLeadsData;
                                                    lstOfLeads.DataBind();
                                                    UpdateLeadStats(lstLeadsData);
                                                }
                                                else
                                                    if (ddlSortByTime.SelectedItem.Text == "Newest First" && (ddlSortByOperatingStatus.SelectedItem.Text == "Please Select" && ddlSortByClosedStatus.SelectedItem.Text != "Please Select" && ddlTimeZone.SelectedItem.Text != "Please Select"))
                                                    {
                                                        List<DailyLeadEntity> lstOperatingStatusData = leadHelper.GetLeadRecordsByUserIDDesc(Convert.ToInt32(Request.Cookies["UserID"].Value)).Where(x => x.Status.ToUpper() == ddlSortByClosedStatus.SelectedItem.Text.ToUpper() && x.TimeZone.ToUpper() == ddlTimeZone.SelectedItem.Text.ToUpper()).ToList();
                                                        List<DailyLeadEntity> lstLeadsData = new List<DailyLeadEntity>();
                                                        lstLeadsData.AddRange(lstOperatingStatusData);
                                                        lstOfLeads.DataSource = lstLeadsData;
                                                        lstOfLeads.DataBind();
                                                        UpdateLeadStats(lstLeadsData);
                                                    }
                                                    else
                                                        if (ddlSortByTime.SelectedItem.Text == "Newest First" && (ddlSortByOperatingStatus.SelectedItem.Text == "Please Select" && ddlSortByClosedStatus.SelectedItem.Text == "Please Select" && ddlTimeZone.SelectedItem.Text != "Please Select"))
                                                        {
                                                            List<DailyLeadEntity> lstOperatingStatusData = leadHelper.GetLeadRecordsByUserIDDesc(Convert.ToInt32(Request.Cookies["UserID"].Value)).Where(x => x.TimeZone.ToUpper() == ddlTimeZone.SelectedItem.Text.ToUpper()).ToList();
                                                            List<DailyLeadEntity> lstLeadsData = new List<DailyLeadEntity>();
                                                            lstLeadsData.AddRange(lstOperatingStatusData);
                                                            lstOfLeads.DataSource = lstLeadsData;
                                                            lstOfLeads.DataBind();
                                                            UpdateLeadStats(lstLeadsData);
                                                        }
                                                        else
                                                            if (ddlSortByTime.SelectedItem.Text == "Newest First" && (ddlSortByOperatingStatus.SelectedItem.Text != "Please Select" && ddlSortByClosedStatus.SelectedItem.Text == "Please Select" && ddlTimeZone.SelectedItem.Text != "Please Select"))
                                                            {
                                                                List<DailyLeadEntity> lstOperatingStatusData = leadHelper.GetLeadRecordsByUserIDDesc(Convert.ToInt32(Request.Cookies["UserID"].Value)).Where(x => x.OperatingStatus.ToUpper() == ddlSortByOperatingStatus.SelectedItem.Text.ToUpper() && x.TimeZone.ToUpper() == ddlTimeZone.SelectedItem.Text.ToUpper()).ToList();
                                                                List<DailyLeadEntity> lstLeadsData = new List<DailyLeadEntity>();
                                                                lstLeadsData.AddRange(lstOperatingStatusData);
                                                                lstOfLeads.DataSource = lstLeadsData;
                                                                lstOfLeads.DataBind();
                                                                UpdateLeadStats(lstLeadsData);
                                                            }
                                                            else
                                                                if (ddlSortByTime.SelectedItem.Text == "Newest First" && (ddlSortByOperatingStatus.SelectedItem.Text != "Please Select" && ddlSortByClosedStatus.SelectedItem.Text == "Please Select" && ddlTimeZone.SelectedItem.Text == "Please Select"))
                                                                {
                                                                    List<DailyLeadEntity> lstOperatingStatusData = leadHelper.GetLeadRecordsByUserIDDesc(Convert.ToInt32(Request.Cookies["UserID"].Value)).Where(x => x.OperatingStatus.ToUpper() == ddlSortByOperatingStatus.SelectedItem.Text.ToUpper()).ToList();
                                                                    List<DailyLeadEntity> lstLeadsData = new List<DailyLeadEntity>();
                                                                    lstLeadsData.AddRange(lstOperatingStatusData);
                                                                    lstOfLeads.DataSource = lstLeadsData;
                                                                    lstOfLeads.DataBind();
                                                                    UpdateLeadStats(lstLeadsData);
                                                                }
                                                                else
                                                                    if (ddlSortByTime.SelectedItem.Text == "Newest First" && (ddlSortByOperatingStatus.SelectedItem.Text == "Please Select" && ddlSortByClosedStatus.SelectedItem.Text != "Please Select" && ddlTimeZone.SelectedItem.Text == "Please Select"))
                                                                    {
                                                                        List<DailyLeadEntity> lstOperatingStatusData = leadHelper.GetLeadRecordsByUserIDDesc(Convert.ToInt32(Request.Cookies["UserID"].Value)).Where(x => x.Status.ToUpper() == ddlSortByClosedStatus.SelectedItem.Text.ToUpper()).ToList();
                                                                        List<DailyLeadEntity> lstLeadsData = new List<DailyLeadEntity>();
                                                                        lstLeadsData.AddRange(lstOperatingStatusData);
                                                                        lstOfLeads.DataSource = lstLeadsData;
                                                                        lstOfLeads.DataBind();
                                                                        UpdateLeadStats(lstLeadsData);
                                                                    }

                                                                    else
                                                                        if (ddlSortByTime.SelectedItem.Text == "Newest First" && (ddlSortByOperatingStatus.SelectedItem.Text != "Please Select" && ddlSortByClosedStatus.SelectedItem.Text != "Please Select" && ddlTimeZone.SelectedItem.Text == "Please Select"))
                                                                        {
                                                                            List<DailyLeadEntity> lstOperatingStatusData = leadHelper.GetLeadRecordsByUserIDDesc(Convert.ToInt32(Request.Cookies["UserID"].Value)).Where(x => x.Status.ToUpper() == ddlSortByClosedStatus.SelectedItem.Text.ToUpper() && x.OperatingStatus.ToUpper() == ddlSortByOperatingStatus.SelectedItem.Text.ToUpper()).ToList();
                                                                            List<DailyLeadEntity> lstLeadsData = new List<DailyLeadEntity>();
                                                                            lstLeadsData.AddRange(lstOperatingStatusData);
                                                                            lstOfLeads.DataSource = lstLeadsData;
                                                                            lstOfLeads.DataBind();
                                                                            UpdateLeadStats(lstLeadsData);
                                                                        }
        }

        public void UpdateLeadStats(List<DailyLeadEntity> lstLeadsData)
        {
            try
            {
                Label lblNewLeads = lstOfLeads.FindControl("lblNewLeads") as Label;
                lblNewLeads.Text = lstLeadsData.Where(x => x.Status == "New Leads").Count().ToString();

                Label lblNotaSale = lstOfLeads.FindControl("lblNotASale") as Label;
                lblNotaSale.Text = lstLeadsData.Where(x => x.Status == "Closed").Count().ToString();

                Label lblaSale = lstOfLeads.FindControl("lblSaleLeads") as Label;
                lblaSale.Text = lstLeadsData.Where(x => x.Status == "Follow up").Count().ToString();

                Label lblTotalLeads = lstOfLeads.FindControl("lblTotalLeads") as Label;
                lblTotalLeads.Text = lstLeadsData.Count().ToString();
                if (drpDOTNo.SelectedItem.Text.Contains("Asc"))
                {
                    if (String.IsNullOrEmpty(txtDate.Text))
                    {
                        lstOfLeads.DataSource = lstLeadsData.OrderBy(x => Convert.ToInt32(x.DOTNumber)).ToList();
                        lstOfLeads.DataBind();
                    }
                    else
                    {
                        lstOfLeads.DataSource = lstLeadsData.Where(p => Convert.ToDateTime(p.SavedOn).Date == Convert.ToDateTime(txtDate.Text).Date).OrderBy(x => Convert.ToInt32(x.DOTNumber)).ToList();
                        lstOfLeads.DataBind();
                    }
                }
                else
                    if (drpDOTNo.SelectedItem.Text.Contains("Desc"))
                    {
                        if (String.IsNullOrEmpty(txtDate.Text))
                        {
                            lstOfLeads.DataSource = lstLeadsData.OrderByDescending(x => Convert.ToInt32(x.DOTNumber)).ToList();
                            lstOfLeads.DataBind();
                        }
                        else
                        {
                            lstOfLeads.DataSource = lstLeadsData.Where(p => Convert.ToDateTime(p.SavedOn).Date == Convert.ToDateTime(txtDate.Text).Date).OrderByDescending(x => Convert.ToInt32(x.DOTNumber)).ToList();
                            lstOfLeads.DataBind();
                        }
                    }
                    else
                        if (!String.IsNullOrEmpty(txtDate.Text))
                        {
                            lstOfLeads.DataSource = lstLeadsData.Where(p => Convert.ToDateTime(p.SavedOn).Date == Convert.ToDateTime(txtDate.Text).Date).OrderBy(x => Convert.ToInt32(x.DOTNumber)).ToList();
                            lstOfLeads.DataBind();
                        }
            }
            catch
            {

            }
        }

        protected void lstOfLeads_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lstOfLeads.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindLeads();
        }

        protected void lstOfLeads_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                // you would use your actual data item type here, not "object"
                HiddenField hidStatus = (HiddenField)e.Item.FindControl("HiddenStatus");
                HiddenField hidID = (HiddenField)e.Item.FindControl("HiddenID");
                DropDownList drpStatus = (DropDownList)e.Item.FindControl("drpStatusList");
                drpStatus.Items.FindByText(hidStatus.Value).Selected = true;
                drpStatus.CssClass = hidID.Value;
                HtmlTableRow htmlRow = (HtmlTableRow)e.Item.FindControl("row");
                if (hidStatus.Value.Contains("Follow up"))
                {
                    htmlRow.Attributes.Add("style", "background-color: #BBDAFF;");
                }
                else
                    if (hidStatus.Value.Contains("Left Voicemail"))
                    {
                        htmlRow.Attributes.Add("style", "background-color: #EFCDF8;");
                    }
                    else
                        if (hidStatus.Value.Contains("Closed"))
                        {
                            htmlRow.Attributes.Add("style", "background-color: #A4F0B7;");
                        }
                        else
                            if (hidStatus.Value.Contains("No Answer"))
                            {
                                htmlRow.Attributes.Add("style", "background-color: #FFFF99;");
                            }
                            else
                                if (hidStatus.Value.Contains("Do Not Call"))
                                {
                                    htmlRow.Attributes.Add("style", "background-color: #FFA8A8;");
                                }
                //object o = (object)dataItem.DataItem;
            }
        }

        protected void drpStatusList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList drpStatus = (DropDownList)sender;
            leadHelper.UpdateLeadStatus(Convert.ToInt32(drpStatus.CssClass), drpStatus.SelectedItem.Text);
            if (drpStatus.SelectedItem.Text == "Follow up")
            {
                Response.Redirect("LeadsEntry.aspx?LeadID=" + Convert.ToInt32(drpStatus.CssClass));
            }
            this.BindLeads();


            //else
            //    if (drpStatus.SelectedItem.Text == "Closed")
            //    {
            //        leadHelper.UpdateLeadStatus(Convert.ToInt32(drpStatus.CssClass), drpStatus.SelectedItem.Text);
            //        this.BindLeads();
            //    }
        }

        [WebMethod(EnableSession = true)]
        public static string UpdateStatus(string leadid, string status,string id)
        {
            string dropid = "";
            DailyLeadsHelper statisLeadHelper = new DailyLeadsHelper();
            bool isUpdated = statisLeadHelper.UpdateLeadStatus(Convert.ToInt32(leadid), status);
            if (isUpdated)
            {
                dropid = id;
            }
            return dropid;
        }

        protected void delLead_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstOfLeads.Items.Count; i++)
            {
                ListViewDataItem items = lstOfLeads.Items[i];
                CheckBox chkBox = (CheckBox)lstOfLeads.Items[i].FindControl("chkDelete");

                if (chkBox.Checked == true)
                {
                    HiddenField hdnLeadID = (HiddenField)lstOfLeads.Items[i].FindControl("HiddenID");
                    leadHelper.DeleteLead(Convert.ToInt32(hdnLeadID.Value));
                }

            }
            this.BindLeads();
        }

        protected void btnSort_Click(object sender, EventArgs e)
        {
            this.BindLeads();
            //List<DailyLeadEntity> lstLeadsData = leadHelper.GetLeadRecordsByUserID(Convert.ToInt32(Request.Cookies["UserID"].Value)).Where(x => x.OperatingStatus == ddlSortByOperatingStatus.SelectedItem.Text || x.Status == ddlSortByClosedStatus.SelectedItem.Value).ToList();
            //lstOfLeads.DataSource = lstLeadsData;
            //lstOfLeads.DataBind();
        }

        protected void btnSearchByDOTNo_Click(object sender, EventArgs e)
        {
            DailyLeadEntity LeadsData = leadHelper.GetLeadRecordsByDOTNo(txtDOTNo.Text);
            List<DailyLeadEntity> lstLeadsData = new List<DailyLeadEntity>();
            lstLeadsData.Add(LeadsData);
            lstOfLeads.DataSource = lstLeadsData;
            lstOfLeads.DataBind();

            UpdateLeadStats(lstLeadsData);
        }
    }



}