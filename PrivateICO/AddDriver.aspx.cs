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
    public partial class AddDriver : System.Web.UI.Page
    {
        DriverProfileHelper driverProfileHelper = new DriverProfileHelper();
        int interviewprofileid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaveDriver_Click(object sender, EventArgs e)
        {
            interviewprofileid = Convert.ToInt32(Request.QueryString["interviewprofileid"]);
            List<DriverServiceEntity> driverServices = new List<DriverServiceEntity>();
            List<ListItem> items = chkServices.Items.Cast<ListItem>().Where(n => n.Selected).ToList();
            foreach (ListItem item in items)
            {
                //if (item.Selected)
                //{
                //    DriverServiceEntity driverService = new DriverServiceEntity();
                //    driverService.Service = item.Text;
                //    driverService.ServiceDetail = "";
                //    driverService.DriverInterviewProfileID = interviewprofileid;
                //    driverServices.Add(driverService);
                //}
            }

            DriverInterviewProfileEntity driverInterviewProfile = new DriverInterviewProfileEntity();
            driverInterviewProfile.Class = txtClass.Text;
            driverInterviewProfile.Date = txtDate.Text;
           // driverInterviewProfile.DBA = txtDriverDBA.Text;
            driverInterviewProfile.DOB = txtDOB.Text;
            driverInterviewProfile.DriverName = txtDriverName.Text;
            driverInterviewProfile.EIN = txtDriverEIN.Text;
            driverInterviewProfile.Email = txtDriverEmailAddress.Text;
            driverInterviewProfile.ExpirationDate = txtExpirationDate.Text;
            driverInterviewProfile.LegalName = txtDriverLegalName.Text;
            driverInterviewProfile.LicenseNo = txtDriverLicense.Text;
           // driverInterviewProfile.MC = txtMC.Text;
            driverInterviewProfile.Notes = txtNotesCommentsObservation.Text;
            driverInterviewProfile.Phone = txtDriverPhone.Text;
            driverInterviewProfile.SSN = txtDriverSSN.Text;
            driverInterviewProfile.StatusIssued = DropDownListState.SelectedItem.Value;
            driverInterviewProfile.Supervisor = txtSupervisor.Text;
            driverInterviewProfile.USDOT = txtDriverUSDOT.Text;

            driverProfileHelper.SaveDriverServices(interviewprofileid, driverInterviewProfile, driverServices);
        }
    }
}