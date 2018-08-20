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
    public partial class EditSalesPersonProfile : System.Web.UI.Page
    {
        UserHelper userHelper = new UserHelper();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BindSalesPErsonDetails()
        {
            ComplianceUserData user = userHelper.GetComplianceUserByID(Convert.ToInt32(Request.Cookies["UserID"].Value));
            txtEmail.Text = user.Email;
            txtFirstName.Text = user.Name;
            ChkIsContractor.Checked = (bool)user.IsContractor;
        }

        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            int salesUserID = Convert.ToInt32(Request.QueryString["UserID"].ToString());
            ComplianceUserData user = new ComplianceUserData();
            user.CreationTime = DateTime.Now.ToString();
            user.Email = txtEmail.Text;
            user.IsActive = true;
            user.Name = txtFirstName.Text;
            user.UserID = salesUserID;
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                user.Password = txtPassword.Text;
            }
            else
            {
                user.Password = null;
            }
            user.IsContractor = ChkIsContractor.Checked;
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
    }
}