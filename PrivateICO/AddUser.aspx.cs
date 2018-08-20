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
    public partial class AddUser : System.Web.UI.Page
    {
        UserDAL userDAL = new UserDAL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            UsersEL userEL = new UsersEL();
            userEL.Name = txtName.Text;
            userEL.Active = true;
            userEL.Address = txtAddress.Text;
            userEL.Country = ddlCountry.SelectedValue;
            userEL.State = ddlStates.SelectedValue;
            userEL.CreatedDate = DateTime.Now;
            userEL.Email = txtEmail.Text;
            userEL.PhoneNo = txtPhoneNo.Text;
            userEL.Username = txtUsername.Text;
            userEL.Zipcode = txtZipCode.Text;
            userEL.RoleID = "2";
            userDAL.RegisterUser(userEL);
        }
    }
}