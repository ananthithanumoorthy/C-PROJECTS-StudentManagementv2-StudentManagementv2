using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManagementv2
{
    public partial class Backend : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Sesstion Not Exist then redirect to Welcome Page */
            if (Session["CurrentUserId"] == null)
            {
                /* Goto Welcome Page */
                Response.Redirect("/Welcome");
            }
            else
            {
                /* Set the User Name */
                lblUsername.InnerText = Session["CurrentUserName"].ToString();
                lblUsername2.InnerText = Session["CurrentUserName"].ToString();

            }
        }
    }
}