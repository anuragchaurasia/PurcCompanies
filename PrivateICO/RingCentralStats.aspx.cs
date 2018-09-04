using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RingCentral;
using DataLayer.DataHelper;
using EntityLayer;


namespace PrivateICO
{
    public partial class RingCentralStats : System.Web.UI.Page
    {
        DailyLeadsHelper leadHelper = new DailyLeadsHelper();
        protected async void Page_Load(object sender, EventArgs e)
        {
            RestClient rc = new RestClient("9ggNhhKMQzydWCI7iRU_qQ", "43bUqIQ7QWiYMI9tUZvRBw8oDl2ziYQrK5_f0i0O9hdw", true);
            string extensionNo = Request.QueryString["ExtensionNo"].ToString();

            if (String.IsNullOrEmpty(extensionNo))
            {
                Response.Write("<script>alert('Please update extension no for this sales person.');</script>");
                return;
            }
            try
            {
                if (!Page.IsPostBack)
                {
                    await rc.Authorize("+12086390799", "101", "Welcome2018");
                }
                var extension = rc.Restapi().Account("~").Extension("~");
                if (!String.IsNullOrEmpty(extensionNo))
                {
                    ExtensionCallLogResponse callLog = await rc.Restapi().Account("~").CallLog().List(new { extensionNumber = extensionNo, view = "Detailed" });
                    try
                    {
                        lblTotalCalls.Text = callLog.records.Count().ToString();
                    }
                    catch
                    {
                        lblTotalCalls.Text = "0";
                    }
                    try
                    {
                        lblInBoundCalls.Text = callLog.records.Where(x => x.direction == "Inbound").Count().ToString();
                    }
                    catch
                    {
                        lblInBoundCalls.Text = "0";
                    }
                    try
                    {
                        lblTotalTime.Text = GetFormattedTime(callLog.records.Sum(x => x.duration).Value.ToString());
                    }
                    catch
                    {
                        lblTotalTime.Text = "0";
                    }
                    try
                    {
                        lblVoiceMails.Text = callLog.records.Where(x => x.result == "Voicemail").Count().ToString();
                    }
                    catch
                    {
                        lblVoiceMails.Text = "0";
                    }
                    try
                    {
                        lblCallAverage.Text = GetFormattedTime((Convert.ToDouble(callLog.records.Sum(x => x.duration).Value.ToString()) / Convert.ToDouble(lblTotalCalls.Text)).ToString());
                    }
                    catch
                    {
                        lblCallAverage.Text = "0";
                    }
                    try
                    {
                        List<DailyLeadEntity> lstLeads = leadHelper.GetAllLeads();
                        if (lstLeads != null)
                        {
                            lblClosedSales.Text = lstLeads.Where(x => x.Status == "Closed").Count().ToString();
                            lblDoNotCall.Text = lstLeads.Where(x => x.Status == "Do Not Call").Count().ToString();
                            lblFollowUps.Text = lstLeads.Where(x => x.Status == "Follow up").Count().ToString();
                            lblClosingStatement.Text = lstLeads.Where(x => x.Status == "Closing Statement").Count().ToString();
                        }
                    }
                    catch
                    {

                    }

                    
                    try
                    {
                        var contactsCount = await rc.Restapi().Account("~").Extension("~").AddressBook().Contact().List();
                        lblTotalContacts.Text = contactsCount.records.Count().ToString();
                    }
                    catch
                    {
                        lblTotalContacts.Text = "0";
                    }

                    

                    try
                    {
                        RestClient rc1 = new RestClient("540zdnTnTL64KBoAT73s1Q", "2XUkif7WSaWqg23JjDknCwcenZ3T6kQye_Rezocxz1QA", true);
                        var contactStatus = await rc1.Restapi().Account("~").Extension(extensionNo).Presence().List();
                        lblUserStatus.Text = contactStatus.records.Select(x => x.presenceStatus).First().ToString();
                    }
                    catch
                    {
                        lblUserStatus.Text = "N/A";
                    }


                }
            }
            catch
            {

            }

        }

        public string GetFormattedTime(string seconds)
        {
            TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(seconds));
            string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                t.Hours,
                t.Minutes,
                t.Seconds,
                t.Milliseconds);
            return answer;
        }
    }
}