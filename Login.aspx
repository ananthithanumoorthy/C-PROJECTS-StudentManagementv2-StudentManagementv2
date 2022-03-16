<%@ Page Title="Login Page" Language="C#" MasterPageFile="/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StudentManagementv2.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
          <div class="row justify-content-center">
            <div class="col-lg-4 col-md-6 d-flex flex-column align-items-center justify-content-center">

              <div class="card mb-3">

                <div class="card-body">

                  <div class="pt-4 pb-2">
                    <h5 class="card-title text-center pb-0 fs-4">Login to Your Account</h5>
                    <p class="text-center small">Enter your username & password to login</p>
                  </div>

                    <form class="row g-3 needs-validation" novalidate runat="server">

                        <div class="col-12">
                            <label for="txtUserName" class="form-label">Username</label>
                            <div class="input-group has-validation">
                                &nbsp;<asp:TextBox ID="txtUserName" type="email" class="form-control" runat="server"></asp:TextBox>
                                <div runat="server" id="lblErrorUserName" visible="false" class="invalid-feedback">Please enter your username.</div>
                            </div>
                        </div>

                        <div class="col-12">
                            <label for="txtPassword" class="form-label">Password</label>
                            <asp:TextBox ID="txtPassword" type="password" class="form-control" runat="server"></asp:TextBox>
                            <div runat="server" id="lblErrorPassword" visible="false" class="invalid-feedback">Please enter your password!</div>
                        </div>

                        <div class="col-12">
                            <asp:Button class="btn btn-primary w-100" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                            <div runat="server" id="lblErrorMessage" visible="false" class="invalid-feedback"></div>
                        </div>
                        <div class="col-12">
                            <p class="small mb-0">Don't have account? <a href="/Registration">Create an account</a></p>
                        </div>
                    </form>

                </div>
              </div>
            </div>
          </div>
        </div>

</asp:Content>
