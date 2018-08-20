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
    public partial class Dashboard : System.Web.UI.Page
    {
        //QuestionnaireHelper questionnaireHelper = new QuestionnaireHelper();
        TransactionHelper transHelper = new TransactionHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            }
        }

        private void BindQuestionnaire()
        {
            //List<QuestionnaireData> lstQuestionnaireData = questionnaireHelper.GetAllQuestionnaire().Take(5).ToList();
            //lstQuestionnaire.DataSource = lstQuestionnaireData;
            //lstQuestionnaire.DataBind();
        }

        protected void lstQuestionnaire_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                Response.Redirect("QuestionAsnwer.aspx?QuestionnaireID=" + e.CommandArgument);
            }
        }
    }
}