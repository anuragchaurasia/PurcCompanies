using DataLayer.DAL;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrivateICO
{
    public partial class EditUsers : System.Web.UI.Page
    {
        UserDAL userdal = new UserDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string userid = Request.QueryString["id"];
                UsersEL user = userdal.GetCustomerByID(userid);
                txtAddress.Text = user.Address;
                txtEmail.Text = user.Email;
                txtName.Text = user.Name;
                txtPassword.Text = txtConfirmPassword.Text = user.Password;
                txtPhoneNo.Text = user.PhoneNo;
                txtUsername.Text = user.Username;
                txtZipCode.Text = user.Zipcode;
            }
        }

        protected void btnEditCustomer_Click(object sender, EventArgs e)
        {
            string userid = Request.QueryString["id"];
            UsersEL userEL = new UsersEL();
            userEL.Name = txtName.Text;
            userEL.Active = true;
            userEL.Address = txtAddress.Text;
            userEL.Country = ddlCountry.SelectedValue;
            userEL.State = ddlStates.SelectedValue;
            userEL.Email = txtEmail.Text;
            userEL.PhoneNo = txtPhoneNo.Text;
            userEL.Username = txtUsername.Text;
            userEL.Zipcode = txtZipCode.Text;
            userEL.UserID = Convert.ToInt32(userid);
            userdal.EditUser(userEL);
        }
    }
}