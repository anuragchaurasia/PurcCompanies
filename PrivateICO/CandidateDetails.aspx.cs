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
    public partial class CandidateDetails : System.Web.UI.Page
    {
        CandidateHelper candidateHelper = new CandidateHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    this.BindCandidateDetails();
                }
                catch
                {

                }
            }
        }

        public void BindCandidateDetails()
        {
            int candidateID = Convert.ToInt32(Request.QueryString["candidateid"]);
            CandidateEntity candidate = candidateHelper.GetCandidateByID(candidateID);
            txtApartmentUnitNo.Text = candidate.Apartment;
            txtStreetAddress.Text = candidate.Address;
            txtFirstName.Text = candidate.FirstName;
            lblAuthorizedForWork.Text = candidate.AuthorizedForWork == true ? "Yes" : "No";
            txtLastName.Text = candidate.LastName;
            lblContactSV1.Text = candidate.CanContactSV1 == true ? "Yes" : "No";
            lblContactSV2.Text = candidate.CanContactSV2 == true ? "Yes" : "No";
            lblContactSV3.Text = candidate.CanContactSV3 == true ? "Yes" : "No";
            txtCity.Text = candidate.City;
            txtCollege1.Text = candidate.College;
            txtCompanyAddress1.Text = candidate.CompanyAddress1;
            txtCompanyAddress2.Text = candidate.CompanyAddress2;
            txtCompanyAddress3.Text = candidate.CompanyAddress3;
            txtCompanyFrom1.Text = candidate.CompanyFrom1;
            txtCompanyFrom2.Text = candidate.CompanyFrom2;
            txtCompanyFrom3.Text = candidate.CompanyFrom3;
            txtCompanyName1.Text = candidate.CompanyName1;
            txtCompanyName2.Text = candidate.CompanyName2;
            txtCompanyName3.Text = candidate.CompanyName3;
            txtCompanyPhone1.Text = candidate.CompanyPhone1;
            txtCompanyPhone2.Text = candidate.CompanyPhone2;
            txtCompanyPhone3.Text = candidate.CompanyPhone3;
            txtCompanySupervisor1.Text = candidate.CompanySupervisor1;
            txtCompanySupervisor2.Text = candidate.CompanySupervisor2;
            txtSupervisor3.Text = candidate.CompanySupervisor3;
            txtCompanyTo1.Text = candidate.CompanyTo1;
            txtCompanyTo2.Text = candidate.CompanyTo2;
            txtCompanyTo3.Text = candidate.CompanyTo3;
            lblHaveConvictedForFelony.Text = candidate.Convicted == true ? "Yes" : "No";
            txtDateAvailable.Text = candidate.DateAvailable;
            txtDeegre.Text = candidate.Deegre1;
            txtDeegre2.Text = candidate.Deegre2;
            txtDeegreAddress.Text = candidate.DeegreAddress;
            txtDesiredIncome.Text = candidate.DesiredIncome;
            lblGraduated1.Text = candidate.DidYouGraduated1 == true ? "Yes" : "No";
            lblGraduated2.Text = candidate.DidYouGraduated2 == true ? "Yes" : "No";
            lblGraduated3.Text = candidate.DidYouGraduated3 == true ? "Yes" : "No";
            txtDiploma1.Text = candidate.Diploma;
            txtEmail.Text = candidate.Email;
            txtEndingSalary.Text = candidate.EndingSalary1;
            txtEndingSalary2.Text = candidate.EndingSalary2;
            txtEndingSalary3.Text = candidate.EndingSalary3;
            txtMilitaryExplain.Text = candidate.Explanation;
            txtHighSchool.Text = candidate.HighSchool;
            txtExplainFelony.Text = candidate.IfYesExplain;
            txtWorkedForCompany.Text = candidate.IfYesWhen;
            txtJobTitle.Text = candidate.JobTitle1;
            txtJobTitle2.Text = candidate.JobTitle2;
            txtJobTitle3.Text = candidate.JobTitle3;
            txtMiddleName.Text = candidate.MiddleName;
            txtBranch.Text = candidate.MilitaryBranch;
            txtMilitaryFrom.Text = candidate.MilitaryFrom;
            txtMilitaryTo.Text = candidate.MilitaryTo;
            txtOther.Text = candidate.Other;
            txtPhone.Text = candidate.Phone;
            txtPositionAppliedFor.Text = candidate.PositionAppliedFor;
            txtRankAtDischarge.Text = candidate.RankAtDischarge;
            txtReasonForLeaving1.Text = candidate.ReasonForLeaving1;
            txtReasonForLeaving2.Text = candidate.ReasonForLeaving2;
            txtReasonForLeaving3.Text = candidate.ReasonForLeaving3;
            txtReferenceAddress.Text = candidate.RefAddress1;
            txtReferenceAddress2.Text = candidate.RefAddress2;
            txtReferenceAddress3.Text = candidate.RefAddress3;
            txtReferenceCompanyName.Text = candidate.RefCompany1;
            txtReferenceCompanyName2.Text = candidate.RefCompany2;
            txtReferenceCompanyName3.Text = candidate.RefCompany3;
            txtFullReferenceName.Text = candidate.RefFullName1;
            txtFullReferenceName2.Text = candidate.RefFullName2;
            txtFullReferenceName3.Text = candidate.RefFullName3;
            txtReferencePhoneNo.Text = candidate.RefPhone1;
            txtReferencePhoneNo2.Text = candidate.RefPhone2;
            txtReferencePhoneNo3.Text = candidate.RefPhone3;
            txtRelationship.Text = candidate.RefRelationShip1;
            txtRelationship2.Text = candidate.RefRelationShip2;
            txtRelationship3.Text = candidate.RefRelationShip3;
            txtResponsibility.Text = candidate.Responsibilities1;
            txtResponsibility2.Text = candidate.Responsibilities2;
            txtResponsibilities3.Text = candidate.Responsibilities3;
            lblDownloadResume.Text = candidate.ResumeDetails;
            txtHighSchoolAddress.Text = candidate.SchoolAddress;
            txtFrom1.Text = candidate.SchoolFrom1;
            txtFrom2.Text = candidate.SchoolFrom2;
            txtFrom3.Text = candidate.SchoolFrom3;
            txtTo1.Text = candidate.SchoolTo1;
            txtTo2.Text = candidate.SchoolTo2;
            txtTo3.Text = candidate.SchoolTo3;
            txtSSN.Text = candidate.SocialSecurityNo;
            txtStartingSalary.Text = candidate.StartingSalary1;
            txtStartingSalary2.Text = candidate.StartingSalary2;
            txtStartingSalary3.Text = candidate.StartingSalary3;
            txtState.Text = candidate.State;
            txtStreetAddress.Text = candidate.StreetAddress;
            txtTypeOfDischarge.Text = candidate.TypeOFDischarge;
            lblCitizenUS.Text = candidate.UsCitiZen == true ? "Yes" : "No";
            lblHaveYourWorked.Text = candidate.WorkedHere == true ? "Yes" : "No";
            txtZipCode.Text = candidate.ZipCode;
        }

        protected void lblDownloadResume_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/Resumes/" + lblDownloadResume.Text);
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                Response.Write("This file does not exist.");
            }
        }
    }
}