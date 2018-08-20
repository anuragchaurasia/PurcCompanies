using DataLayer;
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
    public partial class ChangePassword : System.Web.UI.Page
    {
        UserHelper userHelper = new UserHelper();
        int userid;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            userid = Convert.ToInt32(Request.Cookies["UserID"].Value);
            if (userHelper.IsPasswordAssociated(EncryptionHelper.Encrypt(txtOldPassword.Text), userid))
            {
                ComplianceUserData complianceUser = new ComplianceUserData();
                complianceUser.UserID = userid;
                complianceUser.Password = txtNewPassword.Text;
                if (userHelper.EditSalesUserPassword(complianceUser))
                {
                    Response.Write("<script>alert('Password changed successfully.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Password not associated with your account.');</script>");
            }
        }
    }
}