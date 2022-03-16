<%@ Page Title="Forgot Password" Language="C#" MasterPageFile="/FrontEnd.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="StudentManagementv2.ForgotPassword" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
          <div class="row justify-content-center">
            <div class="col-lg-4 col-md-6 d-flex flex-column align-items-center justify-content-center">

              <div class="card mb-3">

                <div class="card-body">

                  <div class="pt-4 pb-2">
                    <h5 class="card-title text-center pb-0 fs-4">Forgot Password</h5>
                  </div>

                    <form class="row g-3 needs-validation" novalidate runat="server">

                        <div class="col-12">
                            <label for="txtEmail" class="form-label">EMail Id</label>
                            <div class="input-group has-validation">
                                <asp:TextBox ID="txtEmail" type="email" class="form-control" runat="server"></asp:TextBox>
                                <div runat="server" id="lblErrorEmail" visible="false" class="invalid-feedback">Please enter your valid email.</div>
                            </div>
                        </div>
                        <div class="col-12">
                            <asp:Button class="btn btn-primary w-100" ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />
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
