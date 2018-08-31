using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RingCentral;


namespace PrivateICO
{
    public partial class RingCentralStats : System.Web.UI.Page
    {
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
                    lblTotalCalls.Text = callLog.records.Count().ToString();
                    lblInBoundCalls.Text = callLog.records.Where(x => x.direction == "Inbound").Count().ToString();
                    lblTotalTime.Text = GetFormattedTime(callLog.records.Sum(x => x.duration).Value.ToString());
                    lblVoiceMails.Text = callLog.records.Where(x => x.result == "Voicemail").Count().ToString();
                    lblCallAverage.Text = GetFormattedTime((Convert.ToDouble(callLog.records.Sum(x => x.duration).Value.ToString()) / Convert.ToDouble(lblTotalCalls.Text)).ToString());
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