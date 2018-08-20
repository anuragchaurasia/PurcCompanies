using DataLayer.Common;
using DataLayer.DAL;
using DataLayer.DataHelper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PrivateICO
{
    public partial class EditTempDOTSale : System.Web.UI.Page
    {

        DriverProfileHelper driverProfileHelper = new DriverProfileHelper();
        List<DriverInterviewProfileEntity> driverList = new List<DriverInterviewProfileEntity>();
        DailyLeadsHelper dailyLeadHelper = new DailyLeadsHelper();
        UserHelper userHelper = new UserHelper();
        DocumentDAL documentDal = new DocumentDAL();
        List<DocumentEL> serviceListData = new List<DocumentEL>();
        List<DriverVehicleEntity> driverVehicleEntity = new List<DriverVehicleEntity>();
        List<DocumentEL> completeDocumentList = new List<DocumentEL>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearSessions();
                LoadComplianceSupervisors();
                LoadServices();
                LoadDriverProfile();
            }
        }

        public void LoadDriverProfile()
        {
            int orderid = Convert.ToInt32(Request.QueryString["USDotSaleID"]);
            DriverSaleEntity usdotDriver = driverProfileHelper.GetSalesByOrderID(false, orderid);

            txtCardNo.Text = usdotDriver.profileCard.CorDC;
            hidCardNo.Value = usdotDriver.profileCard.CorDC;

            ulcardtype.Attributes["class"] = usdotDriver.profileCard.CardType;


            txtExpiration.Text = usdotDriver.profileCard.Expiration;
            txtCVC.Text = usdotDriver.profileCard.CVC;

            OrderFormEntity order = usdotDriver.orderForm;
            txtUSDOT.Text = order.USDot;
            txtCA.Text = order.CA;
            txtNameOnCard.Text = order.NameOnCard;
            txtUSDOTPin.Text = order.DOTPinNo;
            txtName.Text = order.Name;
            txtDBA.Text = order.DBA;
            txtLegalName.Text = order.LegalName;
            chkCompanyType.ClearSelection();
            chkCompanyType.Items.FindByText(order.CompanyType).Selected = true;
            txtMailingAddress.Text = order.PhysicalAddress;
            txtBillingAddress.Text = order.BillingAddress;
            txtEmailAddress.Text = order.Email;
            txtDateTime.Text = DateTime.Now.ToString();
            txtAdditionalPhoneNo.Text = order.DriverPhone;
            drpComplianceSupervisor.ClearSelection();
            drpComplianceSupervisor.Items.FindByValue(order.ComplianceSupervisor).Selected = true;
            lblPCSaleNo.Text = order.SaleID;
            lblPCSalePersonName.Text = order.ComplianceUserID == null ? "N/A" : userHelper.GetComplianceUserByID(Convert.ToInt32(order.ComplianceUserID)).Name;
            int DriverProfileID = 0;
            if (usdotDriver.driverInterviewProfiles.Count > 0)
            {
                DriverProfileID = usdotDriver.driverInterviewProfiles.FirstOrDefault().DriverInterviewID;
                DriverVehicleEntity driverVehicle = usdotDriver.driverInterviewProfiles.FirstOrDefault().DriverVehicle;
                List<DriverVehicleCargoEntity> driverVehicleCargoData = usdotDriver.driverInterviewProfiles.FirstOrDefault().DriverCargos.Where(x => x.DriverVehicleID == DriverProfileID).ToList();

                List<DriverInterviewProfileEntity> driverInterviewProfiles = usdotDriver.driverInterviewProfiles.Where(x => x.OrderFormID == order.OrderFormID).ToList();
                DriverInterviewProfileEntity driverInterviewProfile = usdotDriver.driverInterviewProfiles.FirstOrDefault();

                lstDrivers.DataSource = driverInterviewProfiles;
                lstDrivers.DataBind();
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
                    DropDownListState.ClearSelection();
                    DropDownListState.Items.FindByValue(driverInterviewProfile.StatusIssued).Selected = true;
                    txtClass.Text = driverInterviewProfile.Class;
                    txtDOB.Text = driverInterviewProfile.DOB;
                    //drpCDL.ClearSelection();
                    //drpCDL.Items.FindByText(driverInterviewProfile.CDLNonCDL).Selected = true;
                    txtDriverSSN.Text = driverInterviewProfile.SSN;
                    hidSSNNo.Value = driverInterviewProfile.SSN;
                    txtDriverEIN.Text = driverInterviewProfile.EIN;
                    txtNotesCommentsObservation.Text = driverInterviewProfile.Notes;
                    hidCurrentDriverInterviewID.Value = driverInterviewProfile.DriverInterviewID.ToString();
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
            }

            
            serviceListData = new List<DocumentEL>();

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
            

            Session["driverlist"] = driverProfileHelper.GetSalesByOrderID(false, orderid).driverInterviewProfiles;
            BindPurchasedItems();
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

        protected void btnEditDriverProfileInterview_Click(object sender, EventArgs e)
        {
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
            orderForm.DOTPinNo = txtUSDOTPin.Text;
            orderForm.LegalName = txtLegalName.Text;
            orderForm.PhysicalAddress = txtMailingAddress.Text;
            orderForm.Email = txtEmailAddress.Text;
            orderForm.DateTime = txtDateTime.Text;
            orderForm.DriverPhone = txtAdditionalPhoneNo.Text;
            orderForm.BillingAddress = txtBillingAddress.Text;
            orderForm.ComplianceSupervisor = drpComplianceSupervisor.SelectedItem.Value.ToString();
            orderForm.CompanyType = chkCompanyType.SelectedItem.Text;
            orderForm.DOTPinNo = txtUSDOT.Text;
            orderForm.SaleID = lblPCSaleNo.Text;
            orderForm.IsSubmitted = false;
            #endregion

            #region DriverInterviewProfile
            List<DriverInterviewProfileEntity> driverInterviewProfiles = new List<DriverInterviewProfileEntity>();

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
            int orderid = Convert.ToInt32(Request.QueryString["USDotSaleID"]);
            driverProfileHelper.EditDriverProfile(orderid, profileCard, orderForm, driverInterviewProfiles, false, saleServiceEntity);
            Response.Write("<script>alert('Details updated successfully.');</script>");
            ResetBoxes();
            LoadDriverProfile();
        }

        public void ResetBoxes()
        {
            txtNotesCommentsObservation.Text = "";
            txtClass.Text = "";
            txtDate.Text = "";
            txtDOB.Text = "";
            txtDriverName.Text = "";
            txtDriverEIN.Text = "";
            txtDriverEmailAddress.Text = "";
            txtExpirationDate.Text = "";
            txtDriverLegalName.Text = "";
            txtDriverLicense.Text = "";
            txtNotesCommentsObservation.Text = "";
            txtDriverPhone.Text = "";
            txtDriverSSN.Text = "";
            hidSSNNo.Value = "";
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
        }

        public void LoadServices()
        {
            drpServices.ClearSelection();
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
            drpComplianceSupervisor.ClearSelection();
            drpComplianceSupervisor.DataSource = userHelper.GetAllComplianceUsers();
            drpComplianceSupervisor.DataValueField = "UserID";
            drpComplianceSupervisor.DataTextField = "Name";
            drpComplianceSupervisor.DataBind();

        }

        protected void lstDrivers_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            ResetBoxes();
            if (e.CommandName == "EditDriver")
            {
                DriverInterviewProfileEntity driverInterviewProfile = driverProfileHelper.GetDriverDataByInterviewProfileID(true, Convert.ToInt32(e.CommandArgument));

                DriverVehicleEntity driverVehicle = driverInterviewProfile.DriverVehicle;
                //List<DriverVehicleCargoEntity> driverVehicleCargo = driverInterviewProfile.DriverCargos;

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
                    //DropDownListState.Items.FindByValue(driverInterviewProfile.StatusIssued).Selected=true;
                    txtClass.Text = driverInterviewProfile.Class;
                    txtDOB.Text = driverInterviewProfile.DOB;
                    drpCDL.ClearSelection();
                    //drpCDL.Items.FindByText(driverInterviewProfile.CDLNonCDL).Selected = true;
                    hidSSNNo.Value = driverInterviewProfile.SSN;
                    txtDriverSSN.Text = driverInterviewProfile.SSN;
                    txtDriverEIN.Text = driverInterviewProfile.EIN;
                    txtNotesCommentsObservation.Text = driverInterviewProfile.Notes;
                }

                //if (driverInterviewProfile.DriverServices != null)
                //{
                //    foreach (DriverServiceEntity item in driverInterviewProfile.DriverServices)
                //    {
                //        DocumentEL docEL = new DocumentEL();
                //        docEL.Description = item.ServicePrice;
                //        docEL.DocumentID = documentDal.GetDocumentTypeByName(item.ServiceName).DocumentTypeID;
                //        docEL.DocumentTypeName = item.ServiceName;
                //        serviceListData.Add(docEL);
                //    }
                //}

                //lstServicesPurchased.DataSource = serviceListData;
                //lstServicesPurchased.DataBind();
                BindPurchasedItems();

                if (driverVehicle != null)
                {
                    txtYear.Text = driverVehicle.Year.ToString();
                    txtMake.Text = driverVehicle.Make;
                    txtModel.Text = driverVehicle.Model;
                    txtGVW.Text = driverVehicle.GVW;
                    foreach (DriverVehicleCargoEntity driverVehicleCargo in driverInterviewProfile.DriverCargos)
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

                List<DocumentEL> docList = new List<DocumentEL>();
                foreach (DriverServiceEntity item in driverInterviewProfile.DriverServices)
                {
                    DocumentEL service = new DocumentEL();
                    service.Description = item.ServicePrice;
                    service.DocumentTypeName = item.ServiceName;
                    service.DocumentID = item.ServiceID;
                    docList.Add(service);
                }



                Session["services"] = docList;
                BindPurchasedItems();
                hidCurrentDriverInterviewID.Value = e.CommandArgument.ToString();
                foreach (ListViewItem item in lstDrivers.Items)
                {
                    var ctrlData = (HtmlTableRow)item.FindControl("tempSaleArea");
                    ctrlData.Attributes["style"] = "background-color:White; color:Black; padding:0px;";
                }
                var ctrl = (HtmlTableRow)e.Item.FindControl("tempSaleArea");
                ctrl.Attributes["style"] = "background-color:#008d4c; color:White; padding:0px;";
            }
            else
                if (e.CommandName == "DeleteDriver")
            {
                List<DriverInterviewProfileEntity> driverInterviewProfiles = (List<DriverInterviewProfileEntity>)Session["driverlist"];
                DriverInterviewProfileEntity driverEntity = driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(e.CommandArgument)).FirstOrDefault();
                driverInterviewProfiles.Remove(driverEntity);
                LoadTempDrivers();
            }
        }

        protected void btnAddService_Click(object sender, EventArgs e)
        {
            bool isServiceExist = false;
            if (Session["services"] != null)
            {
                serviceListData = (List<DocumentEL>)Session["services"];
                //isServiceExist = serviceListData.Any(x => x.Description == drpServices.SelectedItem.Value && x.DocumentTypeName == drpServices.SelectedItem.Text);
            }

            if (!isServiceExist)
            {
                DocumentEL docDAL = documentDal.GetDocumentTypeByName(drpServices.SelectedItem.Text);
                DocumentEL service = new DocumentEL();
                service.Description = docDAL.Description;
                service.DocumentTypeName = drpServices.SelectedItem.Text;
                service.DocumentID = docDAL.DocumentTypeID;
                if (Session["services"] == null)
                {
                    serviceListData.Add(service);
                }
                else
                {
                    serviceListData = (List<DocumentEL>)Session["services"];
                    serviceListData.Add(service);
                }
                Session["services"] = serviceListData;

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
                List<DriverInterviewProfileEntity> driverInterviewProfiles = (List<DriverInterviewProfileEntity>)Session["driverlist"];
                driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().DriverServices = saleServiceEntity;
            }

            //if (Session["completeservices"] == null)
            //{
            //    DocumentEL docDAL = documentDal.GetDocumentTypeByName(drpServices.SelectedItem.Text);
            //    DocumentEL service = new DocumentEL();
            //    service.Description = docDAL.Description;
            //    service.DocumentTypeName = drpServices.SelectedItem.Text;
            //    service.DocumentID = docDAL.DocumentTypeID;
            //    completeDocumentList.Add(service);
            //    Session["completeservices"] = completeDocumentList;

            //}
            //else
            //{
            //    if (!isServiceExist)
            //    {
            //        DocumentEL docDAL = documentDal.GetDocumentTypeByName(drpServices.SelectedItem.Text);
            //        completeDocumentList = (List<DocumentEL>)Session["completeservices"];
            //        DocumentEL service = new DocumentEL();
            //        service.Description = docDAL.Description;
            //        service.DocumentTypeName = drpServices.SelectedItem.Text;
            //        service.DocumentID = docDAL.DocumentTypeID;
            //        completeDocumentList.Add(service);
            //        Session["completeservices"] = completeDocumentList;
            //    }
            //}

            BindPurchasedItems();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "servicescroll()", true);
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
                    Session["services"] = serviceListData;
                    #region DriverServices
                    serviceListData = (List<DocumentEL>)Session["services"];
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
                    List<DriverInterviewProfileEntity> driverInterviewProfiles = (List<DriverInterviewProfileEntity>)Session["driverlist"];
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().DriverServices = saleServiceEntity;
                    #endregion
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

        protected void lnkAddDrivers_Click(object sender, EventArgs e)
        {
            #region DriverServices
            serviceListData = (List<DocumentEL>)Session["services"];
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
                Session["driverlist"] = driverList;
                driverInterviewProfiles = (List<DriverInterviewProfileEntity>)Session["driverlist"];
                driverInterviewProfiles.Add(driverInterviewProfile);
                Session["driverlist"] = driverInterviewProfiles;
            }

            txtClass.Text = "";
            txtDate.Text = "";
            txtDOB.Text = "";
            txtDriverName.Text = "";
            txtDriverEIN.Text = "";
            txtDriverEmailAddress.Text = "";
            txtExpirationDate.Text = "";
            txtDriverLegalName.Text = "";
            txtDriverLicense.Text = "";
            txtNotesCommentsObservation.Text = "";
            txtDriverPhone.Text = "";
            txtDriverSSN.Text = "";
            hidSSNNo.Value = "";
            DropDownListState.SelectedIndex = 1;
            txtSupervisor.Text = "";
            txtDriverUSDOT.Text = "";

            LoadTempDrivers();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "autoscroll()", true);
        }

        protected void btnSubmitDetails_Click(object sender, EventArgs e)
        {
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
            orderForm.IsSubmitted = true;
            #endregion

            #region DriverInterviewProfile
            List<DriverInterviewProfileEntity> driverInterviewProfiles = new List<DriverInterviewProfileEntity>();

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
            int orderid = Convert.ToInt32(Request.QueryString["USDotSaleID"]);
            driverProfileHelper.EditDriverProfile(orderid, profileCard, orderForm, driverInterviewProfiles, false, saleServiceEntity);

            Session["driverlist"] = null;
            EmailHelper emailHelper = new EmailHelper();
            emailHelper.SendPlainEmail("New Sales Order", "A new sales order is been closed by " + Request.Cookies["Name"].Value + " (" + Request.Cookies["Email"].Value + "). Please login into admin panel to view orders.", "");
            Response.Write("<script>alert('Details submitted successfully.');</script>");
            Response.Redirect("ListSubmittedUSDotSale.aspx");
        }

        protected void btnUpdateDriver_Click(object sender, EventArgs e)
        {
            try
            {
                List<DriverInterviewProfileEntity> driverInterviewProfiles = (List<DriverInterviewProfileEntity>)Session["driverlist"];

                if (driverInterviewProfiles.Count > 0)
                {

                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().DriverVehicle.GVW = txtGVW.Text;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().DriverVehicle.Year = txtYear.Text;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().DriverVehicle.Make = txtMake.Text;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().DriverVehicle.Model = txtModel.Text;

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

                    #region DriverServices
                    serviceListData = (List<DocumentEL>)Session["services"];
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


                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().Class = txtClass.Text;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().Date = txtDate.Text;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().DOB = txtDOB.Text;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().DriverName = txtDriverName.Text;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().EIN = txtDriverEIN.Text;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().Email = txtDriverEmailAddress.Text;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().ExpirationDate = txtExpirationDate.Text;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().LegalName = txtDriverLegalName.Text;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().LicenseNo = txtDriverLicense.Text;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().Notes = txtNotesCommentsObservation.Text;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().Phone = txtDriverPhone.Text;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().SSN = hidSSNNo.Value;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().StatusIssued = DropDownListState.SelectedItem.Value;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().Supervisor = txtSupervisor.Text;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().USDOT = txtDriverUSDOT.Text;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().CDLNonCDL = drpCDL.SelectedItem.Text;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().DriverServices = saleServiceEntity;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().DriverCargos = vehicleCargos;
                    driverInterviewProfiles.Where(x => x.DriverInterviewID == Convert.ToInt32(hidCurrentDriverInterviewID.Value)).First().IsSubmitted = false;
                }
            }
            catch 
            {
                
            }

        }

        public void ClearSessions()
        {
            Session["driverlist"] = null;
            Session["services"] = null;
            Session["completeservices"] = null;
            Session["vehicles"] = null;
        }

    }
}