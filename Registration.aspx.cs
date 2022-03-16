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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            /* Declearation */
            String[] Params,Values;
            Boolean IsAlreadyExist = false;
            DataTable dtValidation = new DataTable();
            App_Start.Interface.IDataSource IDataSource = Injection.DeFaultConnection();

            try
            {
                if (IsValidData())
                {
                    /* ==== */
                    /* Check Duplicate Entry Validation */
                    #region"Check Duplicate"
                    Params = new string[3];
                    Values = new string[3];

                    Params[0] = DataBase.SP_UsersAccount.UserName.ToString();
                    Values[0] = txtEmail.Text.Trim();

                    Params[1] = DataBase.SP_UsersAccount.Usertype.ToString();
                    Values[1] = "Student";

                    Params[2] = DataBase.SP_UsersAccount.Entrytype.ToString();
                    Values[2] = "CheckDuplicate";

                    /* Get the Matched Student Details */
                    var ObjValidationResponse = IDataSource.GetData(DataBase.Tables.SP_UsersAccount.ToString(), Params, Values);
                    if (ObjValidationResponse.Status == "Success") dtValidation = ObjValidationResponse.Result;
                    if (dtValidation.Rows.Count > 0)
                    {
                        IsAlreadyExist = true;
                        lblErrorMessage.InnerHtml = "Email already exists, try other email";
                        lblErrorMessage.Visible = true;
                    }
                    #endregion
                    /* ==== */

                    if (!IsAlreadyExist)
                    {
                        Params = new string[9];
                        Values = new string[9];

                        Params[0] = DataBase.SP_UsersAccount.FirstName.ToString();
                        Values[0] = txtFirstName.Text.Trim();

                        Params[1] = DataBase.SP_UsersAccount.LastName.ToString();
                        Values[1] = txtLastName.Text.Trim();

                        Params[2] = DataBase.SP_UsersAccount.Email.ToString();
                        Values[2] = txtEmail.Text.Trim();

                        Params[3] = DataBase.SP_UsersAccount.Gender.ToString();
                        Values[3] = SelGender.SelectedValue.Trim(); 

                        Params[4] = DataBase.SP_UsersAccount.ContactNo.ToString();
                        Values[4] = txtContactNo.Text.Trim();

                        Params[5] = DataBase.SP_UsersAccount.UserName.ToString();
                        Values[5] = txtEmail.Text.Trim();

                        Params[6] = DataBase.SP_UsersAccount.Password.ToString();
                        Values[6] = txtPassword.Text.Trim();

                        Params[7] = DataBase.SP_UsersAccount.Usertype.ToString();
                        Values[7] = "Student";

                        Params[8] = DataBase.SP_UsersAccount.Entrytype.ToString();
                        Values[8] = "INSERT";

                        var ObjResponse = IDataSource.Execute(DataBase.Tables.SP_UsersAccount.ToString(), Params, Values);
                        if (ObjResponse.Status == "Success")
                        {
                            /* Goto Welcome Page */
                       
                            Response.Redirect("/Welcome");
                        }
                    }
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
                lblErrorName.Visible = false;
                lblErrorContactNo.Visible = false;
                lblErrorEmail.Visible = false;
                lblErrorPassword.Visible = false;
                lblErrorMessage.Visible = false;

                /* Validate the all Text Fields */
                if (txtFirstName.Text.Trim() == "") 
                { 
                    IsOk = false; lblErrorName.Visible = true; 
                }
                if (txtContactNo.Text.Trim() == "") 
                { 
                    IsOk = false; lblErrorContactNo.Visible = true; 
                }
                if (txtEmail.Text.Trim() == "") 
                { IsOk = false; lblErrorEmail.Visible = true; 
                }
                if (txtPassword.Text.Trim() == "") 
                { IsOk = false; lblErrorPassword.Visible = true;
                }
            }
            catch (Exception ex)
            {
                IsOk = false;
            }
            return IsOk;
        }
    }
}