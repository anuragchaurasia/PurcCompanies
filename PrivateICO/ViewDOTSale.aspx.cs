using DataLayer.DAL;
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
    public partial class ViewDOTSale : System.Web.UI.Page
    {
        DriverProfileHelper driverProfileHelper = new DriverProfileHelper();
        List<DriverInterviewProfileEntity> driverList = new List<DriverInterviewProfileEntity>();
        DailyLeadsHelper dailyLeadHelper = new DailyLeadsHelper();
        UserHelper userHelper = new UserHelper();
        DocumentDAL documentDal = new DocumentDAL();
        List<DocumentEL> serviceListData = new List<DocumentEL>();
        List<DriverVehicleEntity> driverVehicleEntity = new List<DriverVehicleEntity>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadComplianceSupervisors();
                LoadDriverProfile();
            }
        }

        public void LoadComplianceSupervisors()
        {
            drpComplianceSupervisor.DataSource = userHelper.GetAllComplianceUsers();
            drpComplianceSupervisor.DataValueField = "UserID";
            drpComplianceSupervisor.DataTextField = "Name";
            drpComplianceSupervisor.DataBind();

        }


        public void LoadDriverProfile()
        {
            int orderid = Convert.ToInt32(Request.QueryString["USDotSaleID"]);
            DriverSaleEntity usdotDriver = driverProfileHelper.GetSalesByOrderID(true, orderid);

            txtCardNo.Text = usdotDriver.profileCard.CorDC;
            hidCardNo.Value = usdotDriver.profileCard.CorDC;

            ulcardtype.Attributes["class"] = usdotDriver.profileCard.CardType;


            txtExpiration.Text = usdotDriver.profileCard.Expiration;
            txtCVC.Text = usdotDriver.profileCard.CVC;

            OrderFormEntity order = usdotDriver.orderForm;
            txtUSDOT.Text = order.USDot;
            txtCA.Text = order.CA;
            txtNameOnCard.Text = order.NameOnCard;
            txtName.Text = order.Name;
            txtDBA.Text = order.DBA;
            txtLegalName.Text = order.LegalName;
            chkCompanyType.Items.FindByText(order.CompanyType).Selected = true;
            txtMailingAddress.Text = order.PhysicalAddress;
            txtBillingAddress.Text = order.BillingAddress;
            txtEmailAddress.Text = order.Email;
            txtDateTime.Text = DateTime.Now.ToString();
            txtAdditionalPhoneNo.Text = order.DriverPhone;
            drpComplianceSupervisor.Items.FindByValue(order.ComplianceSupervisor).Selected = true;

            int DriverProfileID = usdotDriver.driverInterviewProfiles.FirstOrDefault().DriverInterviewID;
            DriverVehicleEntity driverVehicle = usdotDriver.driverInterviewProfiles.FirstOrDefault().DriverVehicle;
            List<DriverVehicleCargoEntity> driverVehicleCargoData = usdotDriver.driverInterviewProfiles.FirstOrDefault().DriverCargos.Where(x => x.DriverVehicleID == DriverProfileID).ToList();

            List<DriverInterviewProfileEntity> driverInterviewProfiles = usdotDriver.driverInterviewProfiles.Where(x => x.OrderFormID == order.OrderFormID).ToList();
            DriverInterviewProfileEntity driverInterviewProfile = usdotDriver.driverInterviewProfiles.FirstOrDefault();

            lstDrivers.DataSource = driverInterviewProfiles;
            lstDrivers.DataBind();

            foreach (DriverServiceEntity item in usdotDriver.driverServices)
            {
                DocumentEL docEL = new DocumentEL();
                docEL.Description = item.ServicePrice;
                docEL.DocumentID = documentDal.GetDocumentTypeByName(item.ServiceName).DocumentTypeID;
                docEL.DocumentTypeName = item.ServiceName;
                serviceListData.Add(docEL);
            }

            //lstServicesPurchased.DataSource = serviceListData;
            //lstServicesPurchased.DataBind();
            Session["services"] = serviceListData;
            Session["completeservices"] = serviceListData;
            if (driverInterviewProfile != null)
            {
                txtDate.Text = DateTime.Now.ToShortDateString();
                txtDriverLegalName.Text = driverInterviewProfile.LegalName;
                txtDriverUSDOT.Text = driverInterviewProfile.USDOT;
                txtDriverPhone.Text = driverInterviewProfile.Phone;
                txtDriverEmailAddress.Text = driverInterviewProfile.Email;
                txtDriverName.Text = driverInterviewProfile.DriverName;
                txtSupervisor.Text = driverInterviewProfile.Supervisor;
                txtDriverLicense.Text = driverInterviewProfile.LicenseNo;
                txtExpirationDate.Text = driverInterviewProfile.ExpirationDate;
                DropDownListState.Items.FindByValue(driverInterviewProfile.StatusIssued).Selected = true;
                txtClass.Text = driverInterviewProfile.Class;
                txtDOB.Text = driverInterviewProfile.DOB;
                drpCDL.Items.FindByText(driverInterviewProfile.CDLNonCDL).Selected = true;
                txtDriverSSN.Text = driverInterviewProfile.SSN;
                hidSSNNo.Value = driverInterviewProfile.SSN;
                txtDriverEIN.Text = driverInterviewProfile.EIN;
                txtNotesCommentsObservation.Text = driverInterviewProfile.Notes;
            }

            if (driverVehicle != null)
            {
                txtYear.Text = driverVehicle.Year.ToString();
                txtMake.Text = driverVehicle.Make;
                txtModel.Text = driverVehicle.Model;
                txtGVW.Text = driverVehicle.GVW;
                foreach (DriverVehicleCargoEntity driverVehicleCargo in driverVehicleCargoData)
                {
                    if (driverVehicleCargo != null)
                    {
                        if (driverVehicleCargo.CargoCarriedName == chkAgriculturalFarmSupplies.Text)
                        {
                            chkAgriculturalFarmSupplies.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkBeverages.Text)
                        {
                            chkBeverages.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkBuildingMaterials.Text)
                        {
                            chkBuildingMaterials.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkChemicals.Text)
                        {
                            chkChemicals.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkCoalCoke.Text)
                        {
                            chkCoalCoke.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkCommoditiesDryBulk.Text)
                        {
                            chkCommoditiesDryBulk.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkConstruction.Text)
                        {
                            chkConstruction.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkDriveTowaway.Text)
                        {
                            chkDriveTowaway.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkFreshProduce.Text)
                        {
                            chkFreshProduce.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkGarbageRefuse.Text)
                        {
                            chkGarbageRefuse.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkGeneralFreight.Text)
                        {
                            chkGeneralFreight.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkGrainFeedHay.Text)
                        {
                            chkGrainFeedHay.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkHouseholdGoods.Text)
                        {
                            chkHouseholdGoods.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkIntermodalCont.Text)
                        {
                            chkIntermodalCont.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkLiquidsGases.Text)
                        {
                            chkLiquidsGases.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkLivestock.Text)
                        {
                            chkLivestock.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkLogsPolesBeamsLumber.Text)
                        {
                            chkLogsPolesBeamsLumber.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkMachineryLargeObjects.Text)
                        {
                            chkMachineryLargeObjects.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkMeat.Text)
                        {
                            chkMeat.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkMetalsheetscoilsrolls.Text)
                        {
                            chkMetalsheetscoilsrolls.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkMobileHomes.Text)
                        {
                            chkMobileHomes.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkMotorVehicles.Text)
                        {
                            chkMotorVehicles.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkOilfieldEquipment.Text)
                        {
                            chkOilfieldEquipment.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkPaperProducts.Text)
                        {
                            chkPaperProducts.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkPassengers.Text)
                        {
                            chkPassengers.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkRefrigeratedFood.Text)
                        {
                            chkRefrigeratedFood.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkUSMail.Text)
                        {
                            chkUSMail.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkUtilities.Text)
                        {
                            chkUtilities.Checked = true;
                        }
                        if (driverVehicleCargo.CargoCarriedName == chkWaterWell.Text)
                        {
                            chkWaterWell.Checked = true;
                        }
                    }
                }

            }

            Session["driverlist"] = driverProfileHelper.GetSalesByOrderID(false, orderid).driverInterviewProfiles;

            BindPurchasedItems();
        }

        public void BindPurchasedItems()
        {
            serviceListData = (List<DocumentEL>)Session["completeservices"];
            lstServicesPurchased.DataSource = (List<DocumentEL>)serviceListData;
            lstServicesPurchased.DataBind();
            Label lblTotal = lstServicesPurchased.FindControl("lblSubTotal") as Label;
            try
            {
                lblTotal.Text = "$" + serviceListData.Sum(p => Convert.ToDouble(p.Description.Replace("$", ""))).ToString();
            }
            catch
            {

            }
        }
    }
}