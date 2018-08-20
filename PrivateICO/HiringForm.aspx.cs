using DataLayer.DataHelper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Mail;
using System.Configuration;

namespace PrivateICO
{
    public partial class HiringForm : System.Web.UI.Page
    {
        CandidateHelper candidateHelper = new CandidateHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtTodayDate.Text = DateTime.Now.ToShortDateString();
        }

        protected void btnAddHiring_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(flResume.FileName))
            {
                string resume = DateTime.Now.Ticks.ToString() + flResume.FileName;
                flResume.SaveAs(Server.MapPath("~/Resumes/" + resume));
                CandidateEntity candidatedb = new CandidateEntity();
                candidatedb.Address = txtCollegeAddress1.Text;
                candidatedb.Apartment = txtApartmentUnitNo.Text;
                candidatedb.FirstName = txtFirstName.Text;
                if (radioAuthorizedForWork.SelectedItem != null)
                {
                    candidatedb.AuthorizedForWork = Convert.ToBoolean(radioAuthorizedForWork.SelectedItem.Value == "1" ? true : false);
                }
                else
                {
                    candidatedb.AuthorizedForWork = false;
                }
                candidatedb.LastName = txtLastName.Text;
                if (radioContactToCompany1.SelectedItem != null)
                {
                    candidatedb.CanContactSV1 = Convert.ToBoolean(radioContactToCompany1.SelectedItem.Value == "1" ? true : false);
                }
                else
                {
                    candidatedb.CanContactSV1 = false;
                }
                if (radioContactToCompany2.SelectedItem != null)
                {
                    candidatedb.CanContactSV2 = Convert.ToBoolean(radioContactToCompany2.SelectedItem.Value == "1" ? true : false);
                }
                else
                {
                    candidatedb.CanContactSV2 = false;
                }
                if (radioContactToCompany3.SelectedItem != null)
                {
                    candidatedb.CanContactSV3 = Convert.ToBoolean(radioContactToCompany3.SelectedItem.Value == "1" ? true : false);
                }
                else
                {
                    candidatedb.CanContactSV3 = false;
                }
                candidatedb.City = txtCity.Text;
                candidatedb.College = txtCollege1.Text;
                candidatedb.CompanyAddress1 = txtCompanyAddress1.Text;
                candidatedb.CompanyAddress2 = txtCompanyAddress2.Text;
                candidatedb.CompanyAddress3 = txtCompanyAddress3.Text;
                candidatedb.CompanyFrom1 = txtCompanyFrom1.Text;
                candidatedb.CompanyFrom2 = txtCompanyFrom2.Text;
                candidatedb.CompanyFrom3 = txtCompanyFrom3.Text;
                candidatedb.CompanyName1 = txtCompanyName1.Text;
                candidatedb.CompanyName2 = txtCompanyName2.Text;
                candidatedb.CompanyName3 = txtCompanyName3.Text;
                candidatedb.CompanyPhone1 = txtCompanyPhone1.Text;
                candidatedb.CompanyPhone2 = txtCompanyPhone2.Text;
                candidatedb.CompanyPhone3 = txtCompanyPhone3.Text;
                candidatedb.CompanySupervisor1 = txtCompanySupervisor1.Text;
                candidatedb.CompanySupervisor2 = txtCompanySupervisor2.Text;
                candidatedb.CompanySupervisor3 = txtSupervisor3.Text;
                candidatedb.CompanyTo1 = txtCompanyTo1.Text;
                candidatedb.CompanyTo2 = txtCompanyTo2.Text;
                candidatedb.CompanyTo3 = txtCompanyTo3.Text;
                if (radioFelony.SelectedItem != null)
                {
                    candidatedb.Convicted = Convert.ToBoolean(radioFelony.SelectedItem.Value == "1" ? true : false);
                }
                else
                {
                    candidatedb.Convicted = false;
                }
                candidatedb.Date = DateTime.Now.ToShortDateString();
                candidatedb.DateAvailable = txtDateAvailable.Text;
                candidatedb.Deegre1 = txtDeegre.Text;
                candidatedb.Deegre2 = txtDeegre2.Text;
                candidatedb.DeegreAddress = txtDeegreAddress.Text;
                candidatedb.DesiredIncome = txtDesiredIncome.Text;
                if (radioGraduated1.SelectedItem != null)
                {
                    candidatedb.DidYouGraduated1 = Convert.ToBoolean(radioGraduated1.SelectedItem.Value == "1" ? true : false);
                }
                else
                {
                    candidatedb.DidYouGraduated1 = false;
                }
                if (radioGraduated2.SelectedItem != null)
                {
                    candidatedb.DidYouGraduated2 = Convert.ToBoolean(radioGraduated2.SelectedItem.Value == "1" ? true : false);
                }
                else
                {
                    candidatedb.DidYouGraduated2 = false;
                }
                if (radioGraduated3.SelectedItem != null)
                {
                    candidatedb.DidYouGraduated3 = Convert.ToBoolean(radioGraduated3.SelectedItem.Value == "1" ? true : false);
                }
                else
                {
                    candidatedb.DidYouGraduated3 = false;
                }
                candidatedb.Diploma = txtDiploma1.Text;
                candidatedb.Email = txtEmail.Text;
                candidatedb.EndingSalary1 = txtEndingSalary.Text;
                candidatedb.EndingSalary2 = txtEndingSalary2.Text;
                candidatedb.EndingSalary3 = txtEndingSalary3.Text;
                candidatedb.Explanation = txtExplainFelony.Text;
                candidatedb.FirstName = txtFirstName.Text;
                candidatedb.HighSchool = txtHighSchool.Text;
                candidatedb.IfYesExplain = txtExplainFelony.Text;
                candidatedb.IfYesWhen = txtWorkedForCompany.Text;
                candidatedb.JobTitle1 = txtJobTitle.Text;
                candidatedb.JobTitle2 = txtJobTitle2.Text;
                candidatedb.JobTitle3 = txtJobTitle3.Text;
                candidatedb.LastName = txtLastName.Text;
                candidatedb.MiddleName = txtMiddleName.Text;
                candidatedb.MilitaryBranch = txtBranch.Text;
                candidatedb.MilitaryFrom = txtMilitaryFrom.Text;
                candidatedb.MilitaryTo = txtMilitaryTo.Text;
                candidatedb.Other = txtOther.Text;
                candidatedb.Phone = txtPhone.Text;
                candidatedb.PositionAppliedFor = ddlPositions.SelectedItem.Text;
                candidatedb.RankAtDischarge = txtRankAtDischarge.Text;
                candidatedb.ReasonForLeaving1 = txtReasonForLeaving1.Text;
                candidatedb.ReasonForLeaving2 = txtReasonForLeaving2.Text;
                candidatedb.ReasonForLeaving3 = txtReasonForLeaving3.Text;
                candidatedb.RefAddress1 = txtReferenceAddress.Text;
                candidatedb.RefAddress2 = txtReferenceAddress2.Text;
                candidatedb.RefAddress3 = txtReferenceAddress3.Text;
                candidatedb.RefCompany1 = txtReferenceCompanyName.Text;
                candidatedb.RefCompany2 = txtReferenceCompanyName2.Text;
                candidatedb.RefCompany3 = txtReferenceCompanyName3.Text;
                candidatedb.RefFullName1 = txtFullReferenceName.Text;
                candidatedb.RefFullName2 = txtFullReferenceName2.Text;
                candidatedb.RefFullName3 = txtFullReferenceName3.Text;
                candidatedb.RefPhone1 = txtReferencePhoneNo.Text;
                candidatedb.RefPhone2 = txtReferencePhoneNo2.Text;
                candidatedb.RefPhone3 = txtReferencePhoneNo3.Text;
                candidatedb.RefRelationShip1 = txtRelationship.Text;
                candidatedb.RefRelationShip2 = txtRelationship2.Text;
                candidatedb.RefRelationShip3 = txtRelationship3.Text;
                candidatedb.Responsibilities1 = txtResponsibility.Text;
                candidatedb.Responsibilities2 = txtResponsibility2.Text;
                candidatedb.Responsibilities3 = txtResponsibilities3.Text;
                candidatedb.ResumeDetails = resume;
                candidatedb.SchoolAddress = txtHighSchoolAddress.Text;
                candidatedb.SchoolFrom1 = txtFrom1.Text;
                candidatedb.SchoolFrom2 = txtFrom2.Text;
                candidatedb.SchoolFrom3 = txtFrom3.Text;
                candidatedb.SchoolTo1 = txtTo1.Text;
                candidatedb.SchoolTo2 = txtTo2.Text;
                candidatedb.SchoolTo3 = txtTo3.Text;
                candidatedb.SignatureName = txtSignatureName.Text;
                candidatedb.SocialSecurityNo = txtSSN.Text;
                candidatedb.StartingSalary1 = txtStartingSalary.Text;
                candidatedb.StartingSalary2 = txtStartingSalary2.Text;
                candidatedb.StartingSalary3 = txtStartingSalary3.Text;
                candidatedb.State = txtState.Text;
                candidatedb.StreetAddress = txtStreetAddress.Text;
                candidatedb.TypeOFDischarge = txtTypeOfDischarge.Text;
                if (radioUSCitizen.SelectedItem != null)
                {
                    candidatedb.UsCitiZen = Convert.ToBoolean(radioUSCitizen.SelectedItem.Value == "1" ? true : false);
                }
                else
                {
                    candidatedb.UsCitiZen = false;
                }
                if (radioWorkedForThisCompany.SelectedItem != null)
                {
                    candidatedb.WorkedHere = Convert.ToBoolean(radioWorkedForThisCompany.SelectedItem.Value == "1" ? true : false);
                }
                else
                {
                    candidatedb.WorkedHere = false;
                }
                candidatedb.ZipCode = txtZipCode.Text;
                bool isAdded = candidateHelper.AddHiring(candidatedb);
                if (isAdded)
                {
                    SendHtmlFormattedEmail("New application submitted", candidatedb, "");
                    Response.Write("<script>alert('Your request submit successfull.Admin team will contact you shortly.');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Some error occured.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please upload your resume.');</script>");
            }
        }


        private string createEmailBody(string email, string name, string password)
        {
            string body = string.Empty;
            //using streamreader for reading my htmltemplate   
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Templates/NewApplicant.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{{Name}}", name); //replacing the required things
            body = body.Replace("{{BodyText}}", "Please check admin panel for new applicant.");
            body = body.Replace("{{Email}}", email);
            body = body.Replace("{{Password}}", password);
            return body;
        }

        public void SendHtmlFormattedEmail(string subject, CandidateEntity user, string password)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                try
                {
                    mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                    mailMessage.Subject = subject;
                    mailMessage.Body = createEmailBody(user.Email, "Adam", password);
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(new MailAddress("adam@purcelltransportation.com"));
                    mailMessage.CC.Add(new MailAddress("jemaica@purcelltransportation.com"));
                    mailMessage.CC.Add(new MailAddress("sylviapurcell777@outlook.com"));
                    mailMessage.Bcc.Add(new MailAddress("anurag.dealstodo@gmail.com"));
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = ConfigurationManager.AppSettings["Host"];
                    smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"]; //reading from web.config  
                    NetworkCred.Password = ConfigurationManager.AppSettings["Password"]; //reading from web.config  
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]); //reading from web.config  
                    smtp.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("~/Logs/logdata.txt"));
                    file.WriteLine(ex.Message);
                    file.Dispose();
                }
            }

        }
    }
}