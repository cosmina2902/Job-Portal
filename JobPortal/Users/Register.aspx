<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UseMasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="JobPortal.Users.Register" %> <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
    <div class="container pt-50 pb-40">
      <div class="row">
        <div class="col-12 pb-20">
          <asp:Label ID="lblMsg" runat="server" Visible="true"></asp:Label>
        </div>
        <div class="col-12">
          <h2 class="contact-title ">Sign Up</h2>
        </div>
        <div class="col-lg-6">
          <div class="form-contact contact_form">
            <div class="row">
              <div class="col-12">
                <h4 align="center">Login Information</h4>
              </div>
              <div class="col-12">
                <div class="form-group">
                  <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
                  <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Enter Unique Username" required></asp:TextBox><%--                                        
									<textarea class="form-control w-100" name="message" id="message" cols="30" rows="9" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Enter Message'" placeholder=" Enter Message"></textarea>--%>
                </div>
              </div>
              <div class="col-sm-6">
                <div class="form-group"><%--                                        
									<input class="form-control valid" name="name" id="name" type="text" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Enter your name'" placeholder="Enter your name">--%> <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                  <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter Password" required></asp:TextBox>
                </div>
              </div>
              <div class="col-sm-6">
                <div class="form-group">
                  <asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>
                  <asp:TextBox ID="txtConfirmPasswprd" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter Confirm Password" required></asp:TextBox>
                  <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords & Conform Password should be same!" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPasswprd" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:CompareValidator><%--                                        
										<input class="form-control valid" name="email" id="email" type="email" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Enter email address'" placeholder="Email">--%>
                </div>
              </div>
              <div class="col-12">
                <h4 align="center"> Personal Information </h4>
              </div>
              <div class="col-12">
                <div class="form-group">
                  <asp:Label ID="Label4" runat="server" Text="Full Name"></asp:Label>
                  <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Enter  Full Name" required></asp:TextBox>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Name must be in characters" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ControlToValidate="txtFullName" ValidationExpression="^[a-zA-z\s]+$"></asp:RegularExpressionValidator>
                </div>
              </div>
              <div class="col-12">
                <div class="form-group">
                  <asp:Label ID="Label5" runat="server" Text="Adress"></asp:Label>
                  <asp:TextBox ID="txtAdress" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="Enter Adress" required></asp:TextBox>
                </div>
              </div>
              <div class="col-12">
                <div class="form-group">
                  <asp:Label ID="Label6" runat="server" Text="Mobile Number"></asp:Label>
                  <asp:TextBox ID="txtMobileNum" runat="server" CssClass="form-control" placeholder="Enter Mobile Number" required></asp:TextBox>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please enter a valid number" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ControlToValidate="txtMobileNum" ValidationExpression="^((\+)?(\d{2}))?0?(7(\d{2})([- .])?(\d{3})([- .])?(\d{3}))$"></asp:RegularExpressionValidator>
                </div>
              </div>
              <div class="col-12">
                <div class="form-group">
                  <asp:Label ID="Label7" runat="server" Text="Email"></asp:Label>
                  <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email" required TextMode="Email"></asp:TextBox>
                </div>
              </div>
              <div class="col-12">
                <div class="form-group">
                  <asp:Label ID="Label8" runat="server" Text="Country"></asp:Label>
                  <asp:DropDownList ID="ddlCountry" runat="server" DataSourceID="SqlDataSource1" CssClass="form-control w-100" AppendDataBoundItems="true" DataTextField="CountryName" DataValueField="CountryName">
                    <asp:ListItem Value="0">Select Country</asp:ListItem>
                  </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select a Country" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" ControlToValidate="ddlCountry"></asp:RequiredFieldValidator>
                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:JobPortalConnectionString %>" SelectCommand="SELECT [CountryName] FROM [Country]">
                  </asp:SqlDataSource>
                </div>
              </div>
            </div>
            <div class="form-group mt-3">
              <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="button button-contactForm boxed-btn mr-4" OnClick="btnSend_Click" />
              <span class="clickLink">
                <a href="Login.aspx" style="color:black"> Already Register? CLick Here </a>
              </span>
            </div>
          </div>
        </div>
      </div>
      <div class="col-lg-3 offset-lg-1 ml-0">
        <div class="media contact-info">
          <span class="contact-info__icon">
            <i class="ti-home"></i>
          </span>
          <div class="media-body">
            <h3>Univeristatea Politehnica</h3>
            <p>Vasile Parvan</p>
          </div>
        </div>
        <div class="media contact-info">
          <span class="contact-info__icon">
            <i class="ti-tablet"></i>
          </span>
          <div class="media-body">
            <h3>0256-945</h3>
            <p>Mon to Fri 9am to 6pm</p>
          </div>
        </div>
        <div class="media contact-info">
          <span class="contact-info__icon">
            <i class="ti-email"></i>
          </span>
          <div class="media-body">
            <h3>cosmina.recea@student.upt.ro</h3>
            <p>Send us your query anytime! I'm always here for you</p>
          </div>
        </div>
      </div>
    </div>
  </section>
</asp:Content>