

<%@ Page Title="Forgot Password" Language="C#" MasterPageFile="/FrontEnd.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="StudentManagementv2.ChangePassword" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
          <div class="row justify-content-center">
            <div class="col-lg-4 col-md-6 d-flex flex-column align-items-center justify-content-center">

              <div class="card mb-3">

                <div class="card-body">

                  <div class="pt-4 pb-2">
                    <h5 class="card-title text-center pb-0 fs-4">Change Password</h5>
                  </div>

                    <form class="row g-3 needs-validation" novalidate runat="server">

                        <div class="col-12">
                            <label for="txtEmail" class="form-label">Password</label>
                            <div class="input-group has-validation">
                                <asp:TextBox ID="txtPassword" type="password" class="form-control" runat="server"></asp:TextBox>
                                <div runat="server" id="lblErrorPassword" visible="false" class="invalid-feedback">Please enter your new password.</div>
                            </div>
                        </div>
                        <div class="col-12">
                            <label for="txtEmail" class="form-label">Confirm Password</label>
                            <div class="input-group has-validation">
                                <asp:TextBox ID="txtConfirmPassword" type="password" class="form-control" runat="server"></asp:TextBox>
                                <div runat="server" id="lblErrorConfirmPassword" visible="false" class="invalid-feedback">Please enter Confirm password.</div>
                                <div runat="server" id="lblErrorPasswordNotMatch" visible="false" class="invalid-feedback">Confirm password does't match.</div>
                            </div>
                        </div>
                        <div class="col-12">
                            <asp:Button class="btn btn-primary w-100" ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
                            <div runat="server" id="lblErrorMessage" visible="false" class="invalid-feedback"></div>
                        </div>
                    </form>

                </div>
              </div>
            </div>
          </div>
        </div>

</asp:Content>
