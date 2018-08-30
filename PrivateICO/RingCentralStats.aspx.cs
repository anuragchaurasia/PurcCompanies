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
            RestClient rc = new RestClient("qsS0ls3TQ8S0kqkTnxe0Ww", "Ba1F7bHMSBSiDqqJR_Efyw3oEOKQEVREGKdbZe5FGmUQ", false);
            //rc.Authorize("0HwD5fBJSNWR67MX8BzkTQ~p-ghYa4ZS_iC_HGF_c6b3A", "http://localhost:8187/RingCentralStats.aspx");
            //rc.AutoRefreshToken = false;
            //rc.AuthorizeUri("http://localhost:8187/RingCentralStats.aspx", "test");
            await rc.Authorize("+13128589233", "101", "Galaxys6101");
            //rc.Authorize("U0pDMTFQMDFQQVMwMHxBQURHbThQTDdkODNROTBCY2N0VGdqQjcxTnZtcFpyVkJLWVhNNUREU1VKQ09aTkFwOGY4c2pSeWs0THZad3lXbmk5NF9QWWRPMEVYNENYQjd4dmJsWHJoOWtIR1h2cmFDVl9qWXpxcUVzWjRORy1jR3JLUnpqTFBxQlQ4V01rNlZteldCMFVtMDVFYV9sdTJtV0RtQlRiR041NXVaajRWakJjMG5rU2ozWk9MMDlDZWJQNGJ4eUpBM3lfak9hRkZ6MVF8WE9xNUdRfFZQcUZOclhJQzVTZmFVSHhyZnZVZFF8QUE", "http://localhost:8187/RingCentralStats.aspx");
            var extension = rc.Restapi().Account("245372004").Extension("245372004");
            var callLogs = await extension.CallLog().List(new { direction = "Inbound" });
            
            //rc.AutoRefreshToken = false;
        }
    }
}