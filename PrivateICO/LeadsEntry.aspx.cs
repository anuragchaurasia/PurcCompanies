using CTCT;
using DataLayer.DataHelper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTCT.Components;
using CTCT.Components.Contacts;
using CTCT.Components.EmailCampaigns;
using CTCT.Exceptions;
using CTCT.Services;

namespace PrivateICO
{
    public partial class LeadsEntry : System.Web.UI.Page
    {
        LeadHelper leadHelper = new LeadHelper();
        DailyLeadsHelper dailyLeadHelper = new DailyLeadsHelper();

        private string _apiKey = "kdz3rkucvt9472mugkthbz6a";
        private string _accessToken = "dfd9591b-1cf0-48a2-b273-b678c55b6e4f";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IUserServiceContext userServiceContext = new UserServiceContext(_accessToken, _apiKey);
                IListService listServiceContext = new ListService(userServiceContext);
                if (Request.QueryString["LeadID"] != null)
                {
                    int leadID = Convert.ToInt32(Request.QueryString["LeadID"]);
                    DailyLeadEntity dailyLead = dailyLeadHelper.GetLeadRecordsByLeadID(leadID);
                    txtDoT.Text = dailyLead.DOTNumber;
                    txtBusinessName.Text = dailyLead.LegalName;
                    txtComplianceAgent.Text = Request.Cookies["Name"].Value;
                    txtBestPhone.Text = dailyLead.PhoneNo;
                }
                ContactList[] contactlist = listServiceContext.GetLists(DateTime.Now.Subtract(new TimeSpan(2000, 2000, 2000))).ToArray();
                List<ContactList> contactData = new List<ContactList>();
                foreach (ContactList item in contactlist)
                {
                    ContactList contactitem = item;
                    contactData.Add(contactitem);
                }
                drpEmailList.DataSource = contactData;
                drpEmailList.DataTextField = "Name";
                drpEmailList.DataValueField = "Id";
                drpEmailList.DataBind();
            }
        }

        private static string toString(Object obj)
        {
            return Convert.ToString(obj).Trim();
        }

        protected void btnAddLead_Click(object sender, EventArgs e)
        {
            LeadData lead = new LeadData();
            lead.BusinessName = txtBusinessName.Text;
            lead.ComplianceAgent = txtComplianceAgent.Text;
            lead.ContactName = txtContactName.Text;
            lead.DOTNo = txtDoT.Text;
            lead.Email = txtEmail.Text;
            lead.Notes = txtNotes.Text;
            lead.PhoneNoForContact = txtBestPhone.Text;
            lead.SalesPersonID = Convert.ToInt32(Request.Cookies["UserID"].Value);
            lead.ServiceDiscussed = txtServiceDiscussed.Text;
            lead.TimeLine = txtTimeLine.Text;

            bool isLeadAdded = leadHelper.AddLead(lead);

            IUserServiceContext userServiceContext = new UserServiceContext(_accessToken, _apiKey);
            ConstantContactFactory serviceFactory = new ConstantContactFactory(userServiceContext);
            //List<string> lists = new List<string>() { "1236366064" };

            List<string> lists = new List<string>();
            string[] emailid = hdnEmailID.Value.Split(',');
            foreach (string item in emailid)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    lists.Add(item);
                }
            }
            List<ContactList> contactLists = new List<ContactList>();
            foreach (string list in lists)
            {
                ContactList contactList = new ContactList()
                {
                    Id = list
                };
                contactLists.Add(contactList);
            }
            if (isLeadAdded)
            {
                int leadID = Convert.ToInt32(Request.QueryString["LeadID"]);
                DailyLeadEntity dailyLead = dailyLeadHelper.GetLeadRecordsByLeadID(leadID);
                var contactService = serviceFactory.CreateContactService();
                string physicalCity = "";
                try
                {
                    physicalCity = dailyLead.PhysicalAddress.Split(',')[1].Split(null)[1];
                }
                catch
                {

                }
                Address address = new Address();
                try
                {
                    address = new Address()
                            {

                                AddressType = "BUSINESS",
                                City = toString(physicalCity),
                                CountryCode = "US",
                                Line1 = toString(dailyLead.MailingAddress.Substring(0, 40)),
                                Line2 = toString(dailyLead.MailingAddress.Substring(0, 40)),
                                PostalCode = toString(dailyLead.ZipCode),
                                StateCode = toString("ID"),
                            };
                }
                catch
                {
                    address = new Address()
                            {

                                AddressType = "BUSINESS"
                            };
                }
                
                try
                {
                    if (dailyLead != null)
                    {
                        Contact contact = new Contact()
                        {

                            Addresses = new List<Address> { address },
                            Lists = contactLists,
                            CellPhone = dailyLead.PhoneNo,
                            CompanyName = toString(dailyLead.LegalName),
                            Confirmed = true,
                            EmailAddresses = new List<EmailAddress> { new EmailAddress(toString(txtEmail.Text)) },
                            Fax = dailyLead.PhoneNo,
                            FirstName = txtContactName.Text,
                            HomePhone = txtBestPhone.Text,
                            JobTitle = "Purcell Compliance Lead",
                            LastName = toString(""),
                            PrefixName = "Mr.",
                            WorkPhone = dailyLead.PhoneNo
                        };
                        contactService.AddContact(contact, false);
                    }
                    else
                    {
                        Contact contact = new Contact()
                        {

                            Addresses = new List<Address> { address },
                            Lists = contactLists,
                            CellPhone = txtBestPhone.Text,
                            CompanyName = toString(txtBusinessName.Text),
                            Confirmed = true,
                            EmailAddresses = new List<EmailAddress> { new EmailAddress(toString(txtEmail.Text)) },
                            Fax = txtBestPhone.Text,
                            FirstName = txtContactName.Text,
                            HomePhone = txtBestPhone.Text,
                            JobTitle = "Purcell Compliance Lead",
                            LastName = toString(""),
                            PrefixName = "Mr.",
                            WorkPhone = txtBestPhone.Text
                        };
                        contactService.AddContact(contact, false);
                    }
                    Response.Write("<script>alert('Lead added Successfully.');</script>");
                    resetControls();
                }
                catch
                {
                    //Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
                
            }
            else
            {
                Response.Write("<script>alert('Some error occured.');</script>");
            }
        }

        public void resetControls()
        {
            txtDoT.Text = "";
            txtBusinessName.Text = "";
            txtComplianceAgent.Text = "";
            txtContactName.Text = "";
            txtBestPhone.Text = "";
            txtEmail.Text = "";
            txtTimeLine.Text = "";
            txtServiceDiscussed.Text = "";
            txtNotes.Text = "";
        }
    }
}