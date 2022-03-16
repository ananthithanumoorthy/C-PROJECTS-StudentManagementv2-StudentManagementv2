<%@ Page Title="Welcome Page" Language="C#" MasterPageFile="/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="StudentManagementv2.Registration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-5 col-md-6 d-flex flex-column align-items-center justify-content-center">

                <div class="card mb-3">

                    <div class="card-body">

                        <div class="pt-4 pb-2">
                            <h5 class="card-title text-center pb-0 fs-4">Create an Account</h5>
                            <p class="text-center small">Enter your personal details to create account</p>
                        </div>

                        <form class="row g-3 needs-validation" novalidate runat="server">
                            <div class="col-6">
                                <label for="txtName" class="form-label">First Name</label>
                                <asp:TextBox ID="txtFirstName" class="form-control" runat="server"></asp:TextBox>
                                <div runat="server" id="lblErrorName" visible="False" class="invalid-feedback">Please, enter your name!</div>
                            </div>
                            <div class="col-6">
                                <label for="txtLastName" class="form-label">Last Name</label>
                                <asp:TextBox ID="txtLastName" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-6">
                                <label for="SelGender" class="form-label">Gender</label>
                                <asp:DropDownList ID="SelGender" runat="server">
                                    <asp:ListItem Selected="True">Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                </asp:DropDownList>
                                <div runat="server" id="lblGender" visible="false" class="invalid-feedback">Please select gender</div>
                            </div>

                            <div class="col-6">
                                <label for="txtContactNo" class="form-label">Your Contact No</label>
                                <asp:TextBox ID="txtContactNo" class="form-control" runat="server"></asp:TextBox>
                                <div runat="server" id="lblErrorContactNo" visible="false" class="invalid-feedback">Please, enter Contact number!</div>
                            </div>

                            <div class="col-6">
                                <label for="txtEmail" class="form-label">Your Email/User Name</label>
                                <asp:TextBox ID="txtEmail" type="email" class="form-control" runat="server"></asp:TextBox>
                                <div runat="server" id="lblErrorEmail" visible="false" class="invalid-feedback">Please enter a valid Email adddress!</div>
                            </div>

                            <div class="col-6">
                                <label for="txtPassword" class="form-label">Password</label>
                                <asp:TextBox ID="txtPassword" type="password" class="form-control" runat="server"></asp:TextBox>
                                <div runat="server" id="lblErrorPassword" visible="false" class="invalid-feedback">Please enter your password!</div>
                            </div>

                            <div class="col-12">
                                <asp:Button class="btn btn-primary w-100" ID="btnCreateAccount" runat="server" Text="Create Account" OnClick="btnCreateAccount_Click" />
                                 <div runat="server" id="lblErrorMessage" visible="false" class="invalid-feedback"></div>
                            </div>
                            <div class="col-12">
                                <p class="small mb-0">Already have an account? <a href="/Login">Log in</a></p>
                            </div>
                        </form>

                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
