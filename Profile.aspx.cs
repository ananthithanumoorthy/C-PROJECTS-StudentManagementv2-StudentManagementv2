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
    public partial class Profile : System.Web.UI.Page
    {
        private string t_CurrentUserId = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Sesstion Not Exist then redirect to Welcome Page */
            if (Session["CurrentUserId"] != null)
            {
                /* Get the Current UserId From Session */
                t_CurrentUserId = Session["CurrentUserId"].ToString();
            }

            /* Load the Profile Details */
            if (!IsPostBack) OnSetProfile(t_CurrentUserId);
        }

        private void OnSetProfile(string CurrentUserId)
        {

            /* Declearation */
            String[] Params, Values;
            DataTable dtValidation = new DataTable();
            App_Start.Interface.IDataSource IDataSource = Injection.DeFaultConnection();


            /* ==== */
            /* Bind the Profile Details */
            #region"Bind the Profile Details"
            Params = new string[3];
            Values = new string[3];

            Params[0] = DataBase.SP_UsersAccount.UserId.ToString();
            Values[0] = CurrentUserId;

            Params[1] = DataBase.SP_UsersAccount.Usertype.ToString();
            Values[1] = "Student";

            Params[2] = DataBase.SP_UsersAccount.Entrytype.ToString();
            Values[2] = "Select";

            /* Get the Matched Student Details */
            var ObjValidationResponse = IDataSource.GetData(DataBase.Tables.SP_UsersAccount.ToString(), Params, Values);
            if (ObjValidationResponse.Status == "Success") dtValidation = ObjValidationResponse.Result;
            if (dtValidation.Rows.Count > 0)
            {
                txtFirstName.Text = dtValidation.Rows[0][DataBase.SP_UsersAccount.FirstName.ToString()].ToString();
                txtLastName.Text = dtValidation.Rows[0][DataBase.SP_UsersAccount.LastName.ToString()].ToString();
                txtEmail.Text = dtValidation.Rows[0][DataBase.SP_UsersAccount.Email.ToString()].ToString();
                txtPassword.Text = dtValidation.Rows[0][DataBase.SP_UsersAccount.Password.ToString()].ToString();
                SelGender.SelectedValue = dtValidation.Rows[0][DataBase.SP_UsersAccount.Gender.ToString()].ToString();
            }
            #endregion
            /* ==== */

        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            /* Declearation */
            String[] Params, Values;
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
                        if (dtValidation.Rows[0][DataBase.SP_UsersAccount.UserId.ToString()].ToString() != t_CurrentUserId)
                        {
                            IsAlreadyExist = true;
                            lblErrorMessage.InnerHtml = "Email already exists, try other email";
                            lblErrorMessage.Visible = true;
                        }
                    }
                    #endregion
                    /* ==== */

                    if (!IsAlreadyExist)
                    {
                        Params = new string[10];
                        Values = new string[10];

                        Params[0] = DataBase.SP_UsersAccount.UserId.ToString();
                        Values[0] = t_CurrentUserId;

                        Params[1] = DataBase.SP_UsersAccount.FirstName.ToString();
                        Values[1] = txtFirstName.Text.Trim();

                        Params[2] = DataBase.SP_UsersAccount.LastName.ToString();
                        Values[2] = txtLastName.Text.Trim();

                        Params[3] = DataBase.SP_UsersAccount.Email.ToString();
                        Values[3] = txtEmail.Text.Trim();

                        Params[4] = DataBase.SP_UsersAccount.Gender.ToString();
                        Values[4] = SelGender.SelectedValue.Trim();

                        Params[5] = DataBase.SP_UsersAccount.ContactNo.ToString();
                        Values[5] = txtContactNo.Text.Trim();

                        Params[6] = DataBase.SP_UsersAccount.UserName.ToString();
                        Values[6] = txtEmail.Text.Trim();

                        Params[7] = DataBase.SP_UsersAccount.Password.ToString();
                        Values[7] = txtPassword.Text.Trim();

                        Params[8] = DataBase.SP_UsersAccount.Usertype.ToString();
                        Values[8] = "Student";

                        Params[9] = DataBase.SP_UsersAccount.Entrytype.ToString();
                        Values[9] = "Update";

                        var ObjResponse = IDataSource.Execute(DataBase.Tables.SP_UsersAccount.ToString(), Params, Values);
                        if (ObjResponse.Status == "Success")
                        {
                            /* Goto Welcome Page */
                            Response.Redirect("/Home");
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
                if (txtFirstName.Text.Trim() == "") { IsOk = false; lblErrorName.Visible = true; }
                if (txtContactNo.Text.Trim() == "") { IsOk = false; lblErrorContactNo.Visible = true; }
                if (txtEmail.Text.Trim() == "") { IsOk = false; lblErrorEmail.Visible = true; }
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