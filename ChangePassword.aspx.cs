using StudentManagementv2.App_Start.DataConnection;
using StudentManagementv2.App_Start.DataSecurity;
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
    public partial class ChangePassword : System.Web.UI.Page
    {
        private String t_UserId = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Read the Query String */
            if (Request.QueryString["Code"] != null && Request.QueryString["Code"] != string.Empty)
            {
                t_UserId = Request.QueryString["Code"];
                t_UserId = DataSecurity.DecodeFrom64(t_UserId);
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
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
                    /* Check the UserId Validation */
                    #region"Check Duplicate"
                    Params = new string[3];
                    Values = new string[3];

                    Params[0] = DataBase.SP_UsersAccount.UserId.ToString();
                    Values[0] = t_UserId;

                    Params[1] = DataBase.SP_UsersAccount.Usertype.ToString();
                    Values[1] = "Student";

                    Params[2] = DataBase.SP_UsersAccount.Entrytype.ToString();
                    Values[2] = "Select";

                    /* Get the Matched Student Details */
                    var ObjValidationResponse = IDataSource.GetData(DataBase.Tables.SP_UsersAccount.ToString(), Params, Values);
                    if (ObjValidationResponse.Status == "Success") dtValidation = ObjValidationResponse.Result;
                    if (dtValidation.Rows.Count == 0)
                    {
                        lblErrorMessage.InnerHtml = "Couldn't find your account, Contact with your admin";
                        lblErrorMessage.Visible = true;
                    }
                    else
                    {
                        /* ==== */
                        /* Set the New Password */
                        Params = new string[4];
                        Values = new string[4];

                        Params[0] = DataBase.SP_UsersAccount.UserId.ToString();
                        Values[0] = t_UserId;

                        Params[1] = DataBase.SP_UsersAccount.Password.ToString();
                        Values[1] = txtPassword.Text.Trim();

                        Params[2] = DataBase.SP_UsersAccount.Usertype.ToString();
                        Values[2] = "Student";

                        Params[3] = DataBase.SP_UsersAccount.Entrytype.ToString();
                        Values[3] = "ChangePassword";

                        var ObjResponse = IDataSource.Execute(DataBase.Tables.SP_UsersAccount.ToString(), Params, Values);
                        if (ObjResponse.Status == "Success")
                        {
                            /* Goto Welcome Page */
                            Response.Redirect("/Login");
                        }
                        /* ==== */

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
                lblErrorPassword.Visible = false;
                lblErrorConfirmPassword.Visible = false;
                lblErrorPasswordNotMatch.Visible = false;

                /* Validate the all Text Fields */
                if (txtPassword.Text.Trim() == "") { IsOk = false; lblErrorPassword.Visible = true; }
                if (txtConfirmPassword.Text.Trim() == "") { IsOk = false; lblErrorConfirmPassword.Visible = true; }
                if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim()) { IsOk = false; lblErrorPasswordNotMatch.Visible = true; }

            }
            catch (Exception ex)
            {
                IsOk = false;
            }
            return IsOk;
        }
    }
}
