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
    public partial class AdminSetting : System.Web.UI.Page
    {
        SettingHelper settingHelper = new SettingHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindSettings();
            }
        }

        public void BindSettings()
        {
            SettingEntity setting = settingHelper.GetSettings();
            txtMonthlyTarget.Text = setting.MaxTarget;
            txtEmails.Text = setting.AdminEmails;
            txtProcEmail.Text = setting.ProcessedEmails;
            txtVoidedEmail.Text = setting.VoidedEmails;
            txtRefundEmail.Text = setting.RefundEmails;
        }

        protected void btnUpdateSetting_Click(object sender, EventArgs e)
        {
            SettingEntity setting = new SettingEntity();
            setting.MaxTarget = txtMonthlyTarget.Text;
            setting.AdminEmails = txtEmails.Text;
            setting.ProcessedEmails = txtProcEmail.Text;
            setting.VoidedEmails = txtVoidedEmail.Text;
            setting.RefundEmails = txtRefundEmail.Text;
            bool isEdited = settingHelper.AddTarget(setting);
            if (isEdited)
            {
                Response.Write("<script>alert('Setting updated Successfully.');</script>");
                this.BindSettings();
            }
            else
            {
                Response.Write("<script>alert('Some error occured.');</script>");
            }
        }
    }
}