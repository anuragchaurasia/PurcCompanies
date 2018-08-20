using DataLayer.DataHelper;
using DataLayer.Helper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrivateICO
{
    public partial class ProfileManagement : System.Web.UI.Page
    {
        UserHelper userHelper = new UserHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindSalesPErsonDetails();
            }
        }

        public void BindSalesPErsonDetails()
        {
            int salesUserID = Convert.ToInt32(Request.Cookies["UserID"].Value);
            ComplianceUserData user = userHelper.GetComplianceUserByID(salesUserID);
            txtEmail.Text = user.Email;
            txtFirstName.Text = user.Name;
            ChkIsContractor.Checked = (bool)user.IsContractor;
            chkIsActive.Checked = (bool)user.IsActive;
            ddlUserType.Items.FindByText(user.UserType).Selected = true;
        }

        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            int salesUserID = Convert.ToInt32(Request.Cookies["UserID"].Value);
            ComplianceUserData user = new ComplianceUserData();
            user.CreationTime = DateTime.Now.ToString();
            user.Email = txtEmail.Text;
            user.IsActive = chkIsActive.Checked;
            user.Name = txtFirstName.Text;
            user.IsContractor = ChkIsContractor.Checked;
            user.UserID = salesUserID;
            user.UserType = ddlUserType.SelectedItem.Text;
            bool isEdited = userHelper.EditSalesUser(user);
            if (isEdited)
            {
                Response.Write("<script>alert('User Edited Successfully.');</script>");
            }
            else
            {
                Response.Write("<script>alert('Some error occured.');</script>");
            }
        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }
       
    }
}