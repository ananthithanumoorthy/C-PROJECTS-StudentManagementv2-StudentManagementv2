using System;
using StudentManagementv2.App_Start.DataConnection;
using StudentManagementv2.App_Start.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace StudentManagementv2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Clear the Current Userid */
            Session["CurrentUserId"] = null;
            Session["CurrentUserName"] = null;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            /* Declearation */
            String[] Params, Values;
            DataTable dtValidation = new DataTable();
            App_Start.Interface.IDataSource IDataSource = Injection.DeFaultConnection();

            try
            {
                if (IsValidData())
                {
                    /* ==== */
                    /* Login Authentication */
                    #region"Login Authentication"
                    Params = new string[4];
                    Values = new string[4];

                    Params[0] = DataBase.SP_UsersAccount.UserName.ToString();
                    Values[0] = txtUserName.Text.Trim();

                    Params[1] = DataBase.SP_UsersAccount.Password.ToString();
                    Values[1] = txtPassword.Text.Trim();

                    Params[2] = DataBase.SP_UsersAccount.Usertype.ToString();
                    Values[2] = "Student";

                    Params[3] = DataBase.SP_UsersAccount.Entrytype.ToString();
                    Values[3] = "Authentication";

                    /* Get the Matched Student Details */
                    var ObjValidationResponse = IDataSource.GetData(DataBase.Tables.SP_UsersAccount.ToString(), Params, Values);
                    if (ObjValidationResponse.Status == "Success") dtValidation = ObjValidationResponse.Result;
                    if (dtValidation.Rows.Count > 0)
                    {
                        /* Get the Current UserId Details */
                        Session["CurrentUserId"] = dtValidation.Rows[0][DataBase.SP_UsersAccount.UserId.ToString()].ToString();

                        Session["CurrentUserName"] = dtValidation.Rows[0][DataBase.SP_UsersAccount.FirstName.ToString()].ToString();

                        /* Goto Home Page */
                        Response.Redirect("/Home"); 
                        
                    }
                    else
                    {
                        lblErrorMessage.InnerText = "The username or password is incorrect";
                        lblErrorMessage.Visible = true;
                    }
                    #endregion
                    /* ==== */
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.InnerHtml = ex.Message;
                lblErrorMessage.Visible = true;
            }
        }

        protected Boolean IsValidData()
        {
            Boolean IsOk = true;

            try
            {
                /* Init Hide the Error Message */
                lblErrorUserName.Visible = false;
                lblErrorPassword.Visible = false;
                lblErrorMessage.Visible = false;

                /* Validate the all Text Fields */
                if (txtUserName.Text.Trim() == "") { IsOk = false; lblErrorUserName.Visible = true; }
                if (txtPassword.Text.Trim() == "") { IsOk = false; lblErrorPassword.Visible = true; }
            }
            catch (Exception ex)
            {
                IsOk = false;
            }
            return IsOk;
        }
    }
}