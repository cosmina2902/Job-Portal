<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UseMasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JobPortal.Users.Login" %> <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
  <section>
    <div class="container pt-50 pb-40">
      <div class="row">
        <div class="col-12 pb-20">
          <asp:Label ID="lblMsg" runat="server" Visible="true"></asp:Label>
        </div>
        <div class="col-12">
          <h2 class="contact-title " align="center">Sign In</h2>
        </div>
          <div class="col-lg-6 mx-auto">
              <div class="form-contact contact_form">
                  <div class="row">
                      <div class="col-12">
                          <div class="form-group">
                              <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
                              <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Enter Unique Username" required></asp:TextBox>
                          </div>
                      </div>
                      <div class="col-12">
                          <div class="form-group">
                              <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                              <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter Password" required></asp:TextBox>
                          </div>
                      </div>
                      <div class="col-sm-12">
                          <div class="form-group">
                              <asp:Label ID="Label3" runat="server" Text="LoginType"></asp:Label>
                              <asp:DropDownList ID="ddlLoginType" runat="server" CssClass="form-control w-100">
                                  <asp:ListItem Value="0">Select Login Type</asp:ListItem>
                                  <asp:ListItem>Admin</asp:ListItem>
                                  <asp:ListItem>User</asp:ListItem>
                              </asp:DropDownList>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="UserType is required"
                                  ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0"
                                  ControlToValidate="ddlLoginType"></asp:RequiredFieldValidator>

                          </div>
                      </div>
                  </div>
                  <div class="form-group mt-3">
                      <asp:Button ID="btnLogIn" runat="server" Text="Log In" CssClass="button button-contactForm boxed-btn mr-4" OnClick="btnLogIn_Click" />
                      <span class="clickLink">
                          <a href="Register.aspx" style="color: black">Don't have an account? Click Here </a>
                      </span>
                  </div>
              </div>
          </div>
      </div>
    </div>
  </section>
</asp:Content>