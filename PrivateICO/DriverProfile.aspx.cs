using DataLayer.Common;
using DataLayer.DAL;
using DataLayer.DataHelper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrivateICO
{
    public partial class DriverProfile : System.Web.UI.Page
    {
        DriverProfileHelper driverProfileHelper = new DriverProfileHelper();
        List<DriverInterviewProfileEntity> driverList = new List<DriverInterviewProfileEntity>();
        DailyLeadsHelper dailyLeadHelper = new DailyLeadsHelper();
        UserHelper userHelper = new UserHelper();
        DocumentDAL documentDal = new DocumentDAL();
        List<DocumentEL> serviceListData = new List<DocumentEL>();
        List<DriverVehicleEntity> driverVehicleEntity = new List<DriverVehicleEntity>();
        List<DocumentEL> completeDocumentList = new List<DocumentEL>();
        Random rand = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ClearSessions();
                if (Request.QueryString["LeadID"] != null)
                {
                    int leadID = Convert.ToInt32(Request.QueryString["LeadID"]);
                    DailyLeadEntity dailyLead = dailyLeadHelper.GetLeadRecordsByLeadID(leadID);
                    txtUSDOT.Text = dailyLead.DOTNumber;
                    txtLegalName.Text = dailyLead.LegalName;
                    txtMailingAddress.Text = dailyLead.MailingAddress;
                    
                    txtDriverLegalName.Text = dailyLead.LegalName;
                    txtDriverUSDOT.Text = dailyLead.DOTNumber;
                }
                txtDateTime.Text = DateTime.Now.ToString();
                txtDate.Text = DateTime.Now.ToShortDateString();
                LoadComplianceSupervisors();
                LoadServices();
                lblPCSaleNo.Text = "PC" + txtUSDOT.Text + rand.Next(10, 99).ToString();
                lblPCSalePersonName.Text = userHelper.GetComplianceUserByID(Convert.ToInt32(Request.Cookies["UserID"].Value)).Name;

            }
            //LoadTempDrivers();
        }

        public void LoadServices()
        {
            drpServices.Items.Clear();
            List<DocumentEL> lstDocs = documentDal.GetAllDocumentType();
            foreach (DocumentEL item in lstDocs)
            {
                ListItem serviceData = new ListItem(item.DocumentTypeName, item.DocumentID.ToString());
                
                serviceData.Attributes.Add("serviceid", item.DocumentID.ToString());
                drpServices.Items.Add(serviceData);
            }
        }

        public void LoadTempDrivers()
        {
            if (Session["driverlist"] != null)
            {
                driverList = (List<DriverInterviewProfileEntity>)Session["driverlist"];
                lstDrivers.DataSource = driverList;
                lstDrivers.DataBind();
            }
        }

        public void LoadComplianceSupervisors()
        {
            drpComplianceSupervisor.DataSource = userHelper.GetAllComplianceUsers();
            drpComplianceSupervisor.DataValueField = "UserID";
            drpComplianceSupervisor.DataTextField = "Name";
            drpComplianceSupervisor.DataBind();

        }

        public void BindPurchasedItems()
        {
            completeDocumentList = (List<DocumentEL>)Session["completeservices"];
            lstServicesPurchased.DataSource = (List<DocumentEL>)completeDocumentList;
            lstServicesPurchased.DataBind();
            Label lblTotal = lstServicesPurchased.FindControl("lblSubTotal") as Label;
            try
            {
                lblTotal.Text = "$" + completeDocumentList.Sum(p => Convert.ToDouble(p.Description.Replace("$", ""))).ToString();
            }
            catch
            {

            }
        }

        public void ResetBoxes()
        {
            txtNotesCommentsObservation.Text = "";
            txtClass.Text = "";
            txtDate.Text = DateTime.Now.ToShortDateString();
            txtDOB.Text = "";
            txtDriverName.Text = "";
            txtDriverEIN.Text = "";
            txtDriverVIN.Text = "";
            txtDriverEmailAddress.Text = "";
            txtExpirationDate.Text = "";
            txtDriverLegalName.Text = "";
            txtDriverLicense.Text = "";
            txtNotesCommentsObservation.Text = "";
            txtDriverPhone.Text = "";
            txtDriverSSN.Text = "";
            DropDownListState.SelectedIndex = 1;
            txtSupervisor.Text = "";
            txtDriverUSDOT.Text = "";
            txtYear.Text = "";
            txtMake.Text = "";
            txtModel.Text = "";
            txtGVW.Text = "";
            chkAgriculturalFarmSupplies.Checked = false;
            chkBeverages.Checked = false;
            chkBuildingMaterials.Checked = false;
            chkChemicals.Checked = false;
            chkCoalCoke.Checked = false;
            chkCommoditiesDryBulk.Checked = false;
            chkConstruction.Checked = false;
            chkDriveTowaway.Checked = false;
            chkFreshProduce.Checked = false;
            chkGarbageRefuse.Checked = false;
            chkGeneralFreight.Checked = false;
            chkGrainFeedHay.Checked = false;
            chkHouseholdGoods.Checked = false;
            chkIntermodalCont.Checked = false;
            chkLiquidsGases.Checked = false;
            chkLivestock.Checked = false;
            chkLogsPolesBeamsLumber.Checked = false;
            chkMachineryLargeObjects.Checked = false;
            chkMeat.Checked = false;
            chkMetalsheetscoilsrolls.Checked = false;
            chkMobileHomes.Checked = false;
            chkMotorVehicles.Checked = false;
            chkOilfieldEquipment.Checked = false;
            chkPaperProducts.Checked = false;
            chkPassengers.Checked = false;
            chkRefrigeratedFood.Checked = false;
            chkUSMail.Checked = false;
            chkUtilities.Checked = false;
            chkWaterWell.Checked = false;
            hidSSNNo.Value = "";
            lstServicesPurchased.DataSource = null;
            lstServicesPurchased.DataBind();
        }

        protected void btnSaveDriverProfileInterview_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtGVW.Text) || !String.IsNullOrEmpty(txtMake.Text) || !String.IsNullOrEmpty(txtYear.Text) || !String.IsNullOrEmpty(txtModel.Text))
            {
                Response.Write("<script>alert('There is an unsaved driver profile, please save that before saving the sale.');</script>");
                return;
            }

            #region ProfileCard
            ProfileCardEntity profileCard = new ProfileCardEntity();
            profileCard.CardType = hdnCardType.Value;
            profileCard.CorDC = hidCardNo.Value;
            profileCard.CVC = txtCVC.Text;
            profileCard.Expiration = txtExpiration.Text;
            
            profileCard.IsSubmitted = false;
            #endregion

            #region OrderForm
            OrderFormEntity orderForm = new OrderFormEntity();
            orderForm.USDot = txtUSDOT.Text;
            orderForm.CA = txtCA.Text;
            orderForm.NameOnCard = txtNameOnCard.Text;
            orderForm.Name = txtName.Text;
            orderForm.DBA = txtDBA.Text;
            orderForm.LegalName = txtLegalName.Text;
            orderForm.DOTPinNo = txtUSDOTPin.Text;
            orderForm.PhysicalAddress = txtMailingAddress.Text;
            orderForm.Email = txtEmailAddress.Text;
            orderForm.DateTime = txtDateTime.Text;
            orderForm.DriverPhone = txtAdditionalPhoneNo.Text;
            orderForm.BillingAddress = txtBillingAddress.Text;
            orderForm.ComplianceSupervisor = drpComplianceSupervisor.SelectedItem.Value.ToString();
            orderForm.CompanyType = chkCompanyType.SelectedItem.Text;
            orderForm.ComplianceUserID = Convert.ToInt32(Request.Cookies["UserID"].Value);
            orderForm.DOTPinNo = txtUSDOTPin.Text;
            orderForm.SaleID = lblPCSaleNo.Text;
            orderForm.IsSubmitted = false;
            #endregion

            #region DriverVehicleCargo
            List<DriverVehicleCargoEntity> vehicleCargos = new List<DriverVehicleCargoEntity>();

            if (chkGeneralFreight.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkGeneralFreight.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkHouseholdGoods.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkHouseholdGoods.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkMetalsheetscoilsrolls.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkMetalsheetscoilsrolls.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkMotorVehicles.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkMotorVehicles.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkDriveTowaway.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkDriveTowaway.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkLogsPolesBeamsLumber.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkLogsPolesBeamsLumber.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkBuildingMaterials.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkBuildingMaterials.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkMobileHomes.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkMobileHomes.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkMachineryLargeObjects.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkMachineryLargeObjects.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkFreshProduce.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkFreshProduce.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkLiquidsGases.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkLiquidsGases.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkIntermodalCont.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkIntermodalCont.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkPassengers.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkPassengers.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkOilfieldEquipment.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkOilfieldEquipment.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkLivestock.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkLivestock.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkGrainFeedHay.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkGrainFeedHay.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkCoalCoke.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkCoalCoke.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkMeat.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkMeat.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkGarbageRefuse.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkGarbageRefuse.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkUSMail.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkUSMail.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkChemicals.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkChemicals.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkCommoditiesDryBulk.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkCommoditiesDryBulk.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkRefrigeratedFood.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkRefrigeratedFood.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkBeverages.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkBeverages.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkPaperProducts.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkPaperProducts.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkUtilities.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkUtilities.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkAgriculturalFarmSupplies.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkAgriculturalFarmSupplies.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkConstruction.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkConstruction.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkWaterWell.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkWaterWell.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            #endregion

            #region DriverInterviewProfile
            List<DriverInterviewProfileEntity> driverInterviewProfiles = new List<DriverInterviewProfileEntity>();
            DriverInterviewProfileEntity driverInterviewProfile = new DriverInterviewProfileEntity();
            driverInterviewProfiles = (List<DriverInterviewProfileEntity>)Session["driverlist"];

            #endregion
            serviceListData = (List<DocumentEL>)Session["completeservices"];
            List<DriverServiceEntity> saleServiceEntity = new List<DriverServiceEntity>();
            if (serviceListData != null)
            {
                foreach (DocumentEL item in serviceListData)
                {
                    DriverServiceEntity mcsale = new DriverServiceEntity();
                    mcsale.ServiceID = item.DocumentID;
                    saleServiceEntity.Add(mcsale);
                }
            }
            int driverInterviewProfileID = driverProfileHelper.AddDriverProfile(profileCard, orderForm, driverInterviewProfiles, saleServiceEntity);
            ClearSessions();
            Response.Write("<script>alert('Details saved successfully.');</script>");
            Response.Redirect("ListTempUSDotSale.aspx");
        }

        protected void lnkAddDrivers_Click(object sender, EventArgs e)
        {
            #region DriverServices
            serviceListData = (List<DocumentEL>)Session["completeservices"];
            List<DriverServiceEntity> saleServiceEntity = new List<DriverServiceEntity>();
            if (serviceListData != null)
            {
                foreach (DocumentEL item in serviceListData)
                {
                    DriverServiceEntity mcsale = new DriverServiceEntity();
                    mcsale.ServiceID = item.DocumentID;
                    saleServiceEntity.Add(mcsale);
                }
            }


            #endregion

            #region DriverVehicleCargo
            List<DriverVehicleCargoEntity> vehicleCargos = new List<DriverVehicleCargoEntity>();

            if (chkGeneralFreight.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkGeneralFreight.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkHouseholdGoods.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkHouseholdGoods.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkMetalsheetscoilsrolls.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkMetalsheetscoilsrolls.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkMotorVehicles.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkMotorVehicles.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkDriveTowaway.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkDriveTowaway.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkLogsPolesBeamsLumber.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkLogsPolesBeamsLumber.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkBuildingMaterials.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkBuildingMaterials.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkMobileHomes.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkMobileHomes.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkMachineryLargeObjects.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkMachineryLargeObjects.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkFreshProduce.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkFreshProduce.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkLiquidsGases.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkLiquidsGases.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkIntermodalCont.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkIntermodalCont.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkPassengers.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkPassengers.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkOilfieldEquipment.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkOilfieldEquipment.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkLivestock.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkLivestock.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkGrainFeedHay.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkGrainFeedHay.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkCoalCoke.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkCoalCoke.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkMeat.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkMeat.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkGarbageRefuse.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkGarbageRefuse.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkUSMail.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkUSMail.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkChemicals.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkChemicals.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkCommoditiesDryBulk.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkCommoditiesDryBulk.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkRefrigeratedFood.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkRefrigeratedFood.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkBeverages.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkBeverages.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkPaperProducts.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkPaperProducts.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkUtilities.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkUtilities.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkAgriculturalFarmSupplies.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkAgriculturalFarmSupplies.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkConstruction.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkConstruction.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkWaterWell.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkWaterWell.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            #endregion

            #region DriverVehicle

            DriverVehicleEntity driverVehicle = new DriverVehicleEntity();
            if (Session["vehicles"] == null)
            {

                driverVehicle.GVW = txtGVW.Text;
                driverVehicle.Make = txtMake.Text;
                driverVehicle.Year = txtYear.Text;
                driverVehicle.Model = txtModel.Text;
                driverVehicleEntity.Add(driverVehicle);
                Session["vehicles"] = driverVehicleEntity;
            }
            else
            {
                driverVehicleEntity = (List<DriverVehicleEntity>)Session["vehicles"];
                driverVehicle.GVW = txtGVW.Text;
                driverVehicle.Make = txtMake.Text;
                driverVehicle.Year = txtYear.Text;
                driverVehicle.Model = txtModel.Text;
                driverVehicleEntity.Add(driverVehicle);
                Session["vehicles"] = driverVehicleEntity;
            }
            #endregion

            List<DriverInterviewProfileEntity> driverInterviewProfiles = new List<DriverInterviewProfileEntity>();
            DriverInterviewProfileEntity driverInterviewProfile = new DriverInterviewProfileEntity();
            if (Session["driverlist"] == null)
            {

                driverInterviewProfile.Class = txtClass.Text;
                driverInterviewProfile.Date = txtDate.Text;
                driverInterviewProfile.DOB = txtDOB.Text;
                driverInterviewProfile.DriverName = txtDriverName.Text;
                driverInterviewProfile.EIN = txtDriverEIN.Text;
                driverInterviewProfile.VIN = txtDriverVIN.Text;
                driverInterviewProfile.Email = txtDriverEmailAddress.Text;
                driverInterviewProfile.ExpirationDate = txtExpirationDate.Text;
                driverInterviewProfile.LegalName = txtDriverLegalName.Text;
                driverInterviewProfile.LicenseNo = txtDriverLicense.Text;
                driverInterviewProfile.Notes = txtNotesCommentsObservation.Text;
                driverInterviewProfile.Phone = txtDriverPhone.Text;
                driverInterviewProfile.SSN = hidSSNNo.Value;
                driverInterviewProfile.StatusIssued = DropDownListState.SelectedItem.Value;
                driverInterviewProfile.Supervisor = txtSupervisor.Text;
                driverInterviewProfile.USDOT = txtDriverUSDOT.Text;
                driverInterviewProfile.CDLNonCDL = drpCDL.SelectedItem.Text;
                driverInterviewProfile.DriverVehicle = driverVehicle;
                driverInterviewProfile.DriverServices = saleServiceEntity;
                driverInterviewProfile.DriverCargos = vehicleCargos;
                driverInterviewProfile.IsSubmitted = false;
                driverInterviewProfiles.Add(driverInterviewProfile);
                driverList.Add(driverInterviewProfile);
                Session["driverlist"] = driverList;
            }
            else
            {
                driverInterviewProfile.Class = txtClass.Text;
                driverInterviewProfile.Date = txtDate.Text;
                driverInterviewProfile.DOB = txtDOB.Text;
                driverInterviewProfile.DriverName = txtDriverName.Text;
                driverInterviewProfile.EIN = txtDriverEIN.Text;
                driverInterviewProfile.VIN = txtDriverVIN.Text;
                driverInterviewProfile.Email = txtDriverEmailAddress.Text;
                driverInterviewProfile.ExpirationDate = txtExpirationDate.Text;
                driverInterviewProfile.LegalName = txtDriverLegalName.Text;
                driverInterviewProfile.LicenseNo = txtDriverLicense.Text;
                driverInterviewProfile.Notes = txtNotesCommentsObservation.Text;
                driverInterviewProfile.Phone = txtDriverPhone.Text;
                driverInterviewProfile.SSN = hidSSNNo.Value;
                driverInterviewProfile.StatusIssued = DropDownListState.SelectedItem.Value;
                driverInterviewProfile.Supervisor = txtSupervisor.Text;
                driverInterviewProfile.USDOT = txtDriverUSDOT.Text;
                driverInterviewProfile.CDLNonCDL = drpCDL.SelectedItem.Text;
                driverInterviewProfile.DriverVehicle = driverVehicle;
                driverInterviewProfile.DriverServices = saleServiceEntity;
                driverInterviewProfile.DriverCargos = vehicleCargos;
                driverList.Add(driverInterviewProfile);
                driverInterviewProfile.IsSubmitted = false;
                driverInterviewProfiles = (List<DriverInterviewProfileEntity>)Session["driverlist"];
                driverInterviewProfiles.Add(driverInterviewProfile);
                Session["driverlist"] = driverInterviewProfiles;
            }

            ResetBoxes();
            Session["services"] = null;
            LoadTempDrivers();
            BindPurchasedItems();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "autoscroll()", true);
        }

        protected void lstServicesPurchased_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DelService")
            {
                if (Session["services"] != null)
                {
                    serviceListData = (List<DocumentEL>)Session["services"];
                    DocumentEL docEL = serviceListData.Where(x => x.DocumentID == Convert.ToInt32(e.CommandArgument)).FirstOrDefault();
                    serviceListData.Remove(docEL);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "servicescroll()", true);
                }

                if (Session["completeservices"] != null)
                {
                    completeDocumentList = (List<DocumentEL>)Session["completeservices"];
                    DocumentEL docEL = completeDocumentList.Where(x => x.DocumentID == Convert.ToInt32(e.CommandArgument)).FirstOrDefault();
                    completeDocumentList.Remove(docEL);
                    Session["completeservices"] = completeDocumentList;

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "servicescroll()", true);
                }
                BindPurchasedItems();
            }
        }

        protected void btnAddService_Click(object sender, EventArgs e)
        {
            bool isServiceExist = false;
            if (Session["services"] != null)
            {
                serviceListData = (List<DocumentEL>)Session["services"];
                isServiceExist = serviceListData.Any(x => x.Description == drpServices.SelectedItem.Value && x.DocumentTypeName == drpServices.SelectedItem.Text);

                if (!isServiceExist)
                {
                    DocumentEL docDAL = documentDal.GetDocumentTypeByName(drpServices.SelectedItem.Text);
                    DocumentEL service = new DocumentEL();
                    service.Description = docDAL.Description;
                    service.DocumentTypeName = drpServices.SelectedItem.Text;
                    service.DocumentID = docDAL.DocumentTypeID;
                    serviceListData = (List<DocumentEL>)Session["services"];
                    serviceListData.Add(service);
                    Session["services"] = serviceListData;

                }
            }
            else
            {
                DocumentEL docDAL = documentDal.GetDocumentTypeByName(drpServices.SelectedItem.Text);
                DocumentEL service = new DocumentEL();
                service.Description = docDAL.Description;
                service.DocumentTypeName = drpServices.SelectedItem.Text;
                service.DocumentID = docDAL.DocumentTypeID;
                serviceListData.Add(service);
                Session["services"] = serviceListData;
            }

            if (Session["completeservices"] == null)
            {
                DocumentEL docDAL = documentDal.GetDocumentTypeByName(drpServices.SelectedItem.Text);
                DocumentEL service = new DocumentEL();
                service.Description = docDAL.Description;
                service.DocumentTypeName = drpServices.SelectedItem.Text;
                service.DocumentID = docDAL.DocumentTypeID;
                completeDocumentList.Add(service);
                Session["completeservices"] = completeDocumentList;

            }
            else
            {
                if (!isServiceExist)
                {
                    DocumentEL docDAL = documentDal.GetDocumentTypeByName(drpServices.SelectedItem.Text);
                    completeDocumentList = (List<DocumentEL>)Session["completeservices"];
                    DocumentEL service = new DocumentEL();
                    service.Description = docDAL.Description;
                    service.DocumentTypeName = drpServices.SelectedItem.Text;
                    service.DocumentID = docDAL.DocumentTypeID;
                    completeDocumentList.Add(service);
                    Session["completeservices"] = completeDocumentList;
                }
            }

            BindPurchasedItems();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "servicescroll()", true);
        }

        protected void btnSubmitDetails_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtGVW.Text) || !String.IsNullOrEmpty(txtMake.Text) || !String.IsNullOrEmpty(txtYear.Text) || !String.IsNullOrEmpty(txtModel.Text))
            {
                Response.Write("<script>alert('There is an unsaved driver profile, please save that before saving the sale.');</script>");
                return;
            }

            #region ProfileCard
            ProfileCardEntity profileCard = new ProfileCardEntity();
            profileCard.CardType = hdnCardType.Value;
            profileCard.CorDC = hidCardNo.Value;
            profileCard.CVC = txtCVC.Text;
            profileCard.Expiration = txtExpiration.Text;
            profileCard.IsSubmitted = true;
            #endregion

            #region OrderForm
            OrderFormEntity orderForm = new OrderFormEntity();
            orderForm.USDot = txtUSDOT.Text;
            orderForm.CA = txtCA.Text;
            orderForm.NameOnCard = txtNameOnCard.Text;
            orderForm.Name = txtName.Text;
            orderForm.DBA = txtDBA.Text;
            orderForm.DOTPinNo = txtUSDOTPin.Text;
            orderForm.LegalName = txtLegalName.Text;
            orderForm.PhysicalAddress = txtMailingAddress.Text;
            orderForm.Email = txtEmailAddress.Text;
            orderForm.DateTime = txtDateTime.Text;
            orderForm.DriverPhone = txtAdditionalPhoneNo.Text;
            orderForm.BillingAddress = txtBillingAddress.Text;
            orderForm.ComplianceSupervisor = drpComplianceSupervisor.SelectedItem.Value.ToString();
            orderForm.CompanyType = chkCompanyType.SelectedItem.Text;
            orderForm.SaleID = lblPCSaleNo.Text;
            orderForm.IsSubmitted = true;
            #endregion

            #region DriverVehicleCargo
            List<DriverVehicleCargoEntity> vehicleCargos = new List<DriverVehicleCargoEntity>();

            if (chkGeneralFreight.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkGeneralFreight.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkHouseholdGoods.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkHouseholdGoods.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkMetalsheetscoilsrolls.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkMetalsheetscoilsrolls.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkMotorVehicles.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkMotorVehicles.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkDriveTowaway.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkDriveTowaway.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkLogsPolesBeamsLumber.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkLogsPolesBeamsLumber.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkBuildingMaterials.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkBuildingMaterials.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkMobileHomes.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkMobileHomes.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkMachineryLargeObjects.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkMachineryLargeObjects.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkFreshProduce.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkFreshProduce.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkLiquidsGases.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkLiquidsGases.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkIntermodalCont.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkIntermodalCont.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkPassengers.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkPassengers.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkOilfieldEquipment.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkOilfieldEquipment.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkLivestock.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkLivestock.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkGrainFeedHay.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkGrainFeedHay.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkCoalCoke.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkCoalCoke.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkMeat.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkMeat.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkGarbageRefuse.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkGarbageRefuse.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkUSMail.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkUSMail.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkChemicals.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkChemicals.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkCommoditiesDryBulk.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkCommoditiesDryBulk.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkRefrigeratedFood.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkRefrigeratedFood.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkBeverages.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkBeverages.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkPaperProducts.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkPaperProducts.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkUtilities.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkUtilities.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkAgriculturalFarmSupplies.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkAgriculturalFarmSupplies.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkConstruction.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkConstruction.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            if (chkWaterWell.Checked)
            {
                DriverVehicleCargoEntity vehicleCargo = new DriverVehicleCargoEntity();
                vehicleCargo.CargoCarriedName = chkWaterWell.Text;
                vehicleCargos.Add(vehicleCargo);
            }
            #endregion

            #region DriverInterviewProfile
            List<DriverInterviewProfileEntity> driverInterviewProfiles = new List<DriverInterviewProfileEntity>();
            DriverInterviewProfileEntity driverInterviewProfile = new DriverInterviewProfileEntity();
            driverInterviewProfiles = (List<DriverInterviewProfileEntity>)Session["driverlist"];

            #endregion

            serviceListData = (List<DocumentEL>)Session["completeservices"];
            List<DriverServiceEntity> saleServiceEntity = new List<DriverServiceEntity>();
            if (serviceListData != null)
            {
                foreach (DocumentEL item in serviceListData)
                {
                    DriverServiceEntity mcsale = new DriverServiceEntity();
                    mcsale.ServiceID = item.DocumentID;
                    saleServiceEntity.Add(mcsale);
                }
            }

            int driverInterviewProfileID = driverProfileHelper.AddDriverProfile(profileCard, orderForm, driverInterviewProfiles, saleServiceEntity);
            UserDAL userDAL = new UserDAL();
            UsersEL userEL = new UsersEL();
            userEL.Name = txtName.Text;
            userEL.Active = true;
            userEL.Address = txtMailingAddress.Text;
            userEL.Country = "US";
            userEL.State = DropDownListState.SelectedItem.Text;
            userEL.CreatedDate = DateTime.Now;
            userEL.Email = txtEmailAddress.Text;
            userEL.PhoneNo = txtAdditionalPhoneNo.Text;
            userEL.Username = txtUSDOT.Text;
            userEL.Zipcode = "";
            userEL.RoleID = "2";
            userDAL.RegisterUser(userEL);

            ClearSessions();
            EmailHelper emailHelper = new EmailHelper();
            emailHelper.SendPlainEmail("New Sales Order", "A new sales order is been closed by " + Request.Cookies["Name"].Value + " (" + Request.Cookies["Email"].Value + "). Please login into admin panel to view orders.", "");
            Response.Write("<script>alert('Details submitted successfully.');</script>");
            Response.Redirect("ListSubmittedUSDotSale.aspx");

        }

        public void ClearSessions()
        {
            Session["driverlist"] = null;
            Session["services"] = null;
            Session["completeservices"] = null;
            Session["vehicles"] = null;
        }

        [WebMethod(EnableSession = true)]
        public static string GetUSDOTDetails(string usdotno)
        {
            string dropid = "";
            DriverProfileHelper driverProfile = new DriverProfileHelper();

            DailyLeadsHelper leadHelper = new DailyLeadsHelper();
            DailyLeadEntity LeadsData = leadHelper.GetLeadRecordsByDOTNo(usdotno);
            var json = new JavaScriptSerializer().Serialize(LeadsData);
            return json;
        }
    }
}