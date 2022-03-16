<%@ Page Language="C#" MasterPageFile="/Backend.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="StudentManagementv2.Profile" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="col-xl-3">
    
</div>
<div class="col-xl-6">
    <div class="col-xl-12">
    <div class="card">
        <div class="card-body pt-3">
            <!-- Bordered Tabs -->
            <ul class="nav nav-tabs nav-tabs-bordered">

                <li class="nav-item">
                    <button class="nav-link active" data-bs-toggle="tab" data-bs-target="#profile-edit">Edit Profile</button>
                </li>

            </ul>
            <div class="tab-content pt-2">

                <div class="tab-pane fade profile-edit pt-3 active show" id="profile-edit">

                    <!-- Profile Edit Form -->
                    <form runat="server">
                        
                        <div class="col-12">
                                <label for="txtName" class="form-label">First Name</label>
                                <asp:TextBox ID="txtFirstName" class="form-control" runat="server"></asp:TextBox>
                                <div runat="server" id="lblErrorName" visible="false" class="invalid-feedback">Please, enter your name!</div>
                            </div>
                            <div class="col-12">
                                <label for="txtLastName" class="form-label">Last Name</label>
                                <asp:TextBox ID="txtLastName" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-12">
                                <label for="SelGender" class="form-label">Gender</label>
                                <asp:DropDownList  ID="SelGender"  class="form-control" runat="server">
                                    <asp:ListItem Selected="True">Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                </asp:DropDownList>
                                <div runat="server" id="lblGender" visible="false" class="invalid-feedback">Please, enter your name!</div>
                            </div>

                            <div class="col-12">
                                <label for="txtContactNo" class="form-label">Your Contact No</label>
                                <asp:TextBox ID="txtContactNo" class="form-control" runat="server"></asp:TextBox>
                                <div runat="server" id="lblErrorContactNo" visible="false" class="invalid-feedback">Please, enter your name!</div>
                            </div>

                            <div class="col-12">
                                <label for="txtEmail" class="form-label">Your Email/User Name</label>
                                <asp:TextBox  ID="txtEmail" type="email" class="form-control" runat="server" disabled="true"></asp:TextBox>
                                <div runat="server" id="lblErrorEmail" visible="false" class="invalid-feedback">Please enter a valid Email adddress!</div>
                            </div>

                            <div class="col-12">
                                <label for="txtPassword" class="form-label">Password</label>
                                <asp:TextBox ID="txtPassword" type="password" class="form-control" runat="server"></asp:TextBox>
                                <div runat="server" id="lblErrorPassword" visible="false" class="invalid-feedback">Please enter your password!</div>
                            </div>

                            <div class="col-12">
                                <asp:Button class="btn btn-primary w-100" ID="btnSaveChanges" runat="server" Text="Save Changes" OnClick="btnSaveChanges_Click"  />
                                 <div runat="server" id="lblErrorMessage" visible="false" class="invalid-feedback"></div>
                            </div>

                    </form>
                    <!-- End Profile Edit Form -->

                </div>

            </div>
            <!-- End Bordered Tabs -->
        </div>
    </div>
</div>
</div>
<div class="col-xl-2">
    
</div>
</asp:Content>



