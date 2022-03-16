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
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSend_Click(object sender, EventArgs e)
        {

            /* Declearation */
            String[] Params, Values;
            DataTable dtValidation = new DataTable();
            App_Start.Interface.IDataSource IDataSource = Injection.DeFaultConnection();
            App_Start.Interface.ISendMail ISendMails = Injection.DeFaultMailService();

            try
            {
                if (IsValidData())
                {
                    /* ==== */
                    /* Check the Email Validation */
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
                    if (dtValidation.Rows.Count == 0)
                    {
                        lblErrorMessage.InnerHtml = "Couldn't find your account, Please enter your vaild email";
                        lblErrorMessage.Visible = true;
                    }
                    else
                    {
                        /* ==== */
                        /* Send Email Notification Message */
                        var ObjectResponse = ISendMails.SendMail(
                              SendTo: txtEmail.Text.Trim(),
                              Subject: "Forgot Password",
                              BodyContent: "https://localhost:44340/ChangePassword?Code=" + DataSecurity.EncodePasswordToBase64(dtValidation.Rows[0][DataBase.SP_UsersAccount.UserId.ToString()].ToString())
                              );
                        if (ObjectResponse.Status == "Success")
                        {
                            /* Goto Welcome Page */
                            Response.Redirect("/Welcome");
                        }
                        else
                        {
                            /* Display the Error Message */
                            lblErrorMessage.InnerText = ObjectResponse.Message;
                            lblErrorMessage.Visible = true;
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
                lblErrorEmail.Visible = false;

                /* Validate the all Text Fields */
                if (txtEmail.Text.Trim() == "") { IsOk = false; lblErrorEmail.Visible = true; }

            }
            catch (Exception ex)
            {
                IsOk = false;
            }
            return IsOk;
        }

    }
}
