﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="NewJob.aspx.cs" Inherits="JobPortal.Admin.NewJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-image: url('../Images/bg.jpg'); width:100%; height:720px; background-repeat:no-repeat; background-size:cover; background-attachment:fixed">
        <div class="container pt-4 pb-4">
            <%--<div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>--%>
            <div class="btn-toolbar justify-content-between mb-3">
                <div class="btn-group">
                     <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
                <div class =" input-group h-25">
                    <asp:HyperLink ID="linkBack" runat="server" NavigateUrl="~/Admin/ListJob.aspx" CssClass="btn btn-secondary" Visible="false">< Back</asp:HyperLink>
                   
                </div>
            </div>
            <h3 class="text-center"><%Response.Write(Session["title"]); %></h3>
            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="txtJobTitle" style="font-weight:600">Job Tile</label>
                    <asp:TextBox ID="txtJobTitle" runat="server" CssClass="form-control" placeholder="Ex. Web Developer"></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3">
                    <label for="txtNumOfPOst" style="font-weight:600">Number Of Post</label>
                    <asp:TextBox ID="txtNumOfPOst" runat="server" CssClass="form-control" placeholder="Enter Number Of Position" TextMode="Number" required></asp:TextBox>
                </div>
            </div>



            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-12 pt-3">
                    <label for="txtDescription" style="font-weight:600">Description</label>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" placeholder="Enter a Job Description" TextMode="MultiLine" required></asp:TextBox>
                </div>
                 
            </div>
             <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="txtQualification" style="font-weight:600">Qualification/Education Required</label>
                    <asp:TextBox ID="txtQualification" runat="server" CssClass="form-control" placeholder="Ex. MCA, BTech, MBA" required></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3">
                    <label for="txtExperience" style="font-weight:600">Experience Required</label>
                    <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control" placeholder="Ex. 2  Years, 1.5 Years" required></asp:TextBox>
                </div>
            </div>


           
            <div class="row mr-lg-5 ml-lg-5 mb-3">
                 <div class="col-md-6 pt-3">
                    <label for="txtSpecialization" style="font-weight:600">Specialization Required</label>
                    <asp:TextBox ID="txtSpecialization" runat="server" CssClass="form-control" placeholder="Enter Specialization" TextMode="MultiLine" required></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3">
                    <label for="txtLastDate" style="font-weight:600">Last Date to Aplly</label>
                    <asp:TextBox ID="txtLastDate" runat="server" CssClass="form-control" placeholder="Enter Last Day To Apply" required TextMode="Date"></asp:TextBox>
                </div>
            </div>


           
             <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="txtSalary" style="font-weight:600">Salary</label>
                    <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" placeholder="Enter Salary" required></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3">
                    <label for="ddlJobType" style="font-weight:600">Job Type</label>
                    <asp:DropDownList ID="ddlJobType" runat="server" CssClass="form-control" >
                        <asp:ListItem Value="0">Select Job Type</asp:ListItem>
                        <asp:ListItem >Full Time</asp:ListItem>
                        <asp:ListItem >Part Time</asp:ListItem>
                        <asp:ListItem >Remote</asp:ListItem>
                        <asp:ListItem >Freelance</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Job Type is required" ForeColor="Red" 
                        ControlToValidate="ddlJobType" InitialValue="0" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="txtCompany" style="font-weight:600">Company/Oraganization Name</label>
                    <asp:TextBox ID="txtCompany" runat="server" CssClass="form-control" placeholder="Enter Company/Oraganization Name" required></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3">
                    <label for="ddlJobType" style="font-weight:600">Company/Oraganization Logo</label>
                   <asp:FileUpload ID="fuCompanyLogo" runat="server" CssClass="form-control" ToolTip=".jpg, .jpeg, .png extension only" />
                </div>
            </div>


            
            <div class="row mr-lg-5 ml-lg-5 mb-3">
                 <div class="col-md-6 pt-3">
                    <label for="txtWebsite" style="font-weight:600">Website</label>
                    <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control" placeholder="Ex. www.Continental.ro" TextMode="Url" ></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3">
                    <label for="txtEmail" style="font-weight:600">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email" TextMode="Email" required ></asp:TextBox>
                </div>
            </div>


             <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-12 pt-3">
                    <label for="txtAdress" style="font-weight:600">Adress</label>
                    <asp:TextBox ID="txtAdress" runat="server" CssClass="form-control" placeholder="Enter Work Location" 
                        TextMode="MultiLine" required></asp:TextBox>
                </div>
            </div>



             <div class="row mr-lg-5 ml-lg-5 mb-3">
                 <div class="col-md-6 pt-3">
                    <label for="txtWebsite" style="font-weight:600">Country</label>
                      <asp:DropDownList ID="ddlCountry" runat="server" DataSourceID="SqlDataSource1" CssClass="form-control w-100" AppendDataBoundItems="true" DataTextField="CountryName" DataValueField="CountryName">
                    <asp:ListItem Value="0">Select Country</asp:ListItem>
                  </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select a Country" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" ControlToValidate="ddlCountry"></asp:RequiredFieldValidator>
                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:JobPortalConnectionString %>" SelectCommand="SELECT [CountryName] FROM [Country]">
                  </asp:SqlDataSource>
                </div>
                <div class="col-md-6 pt-3">
                    <label for="txtLocality" style="font-weight:600">Locality</label>
                    <asp:TextBox ID="txtLocality" runat="server" CssClass="form-control" placeholder="Ex. Timisoara"  required ></asp:TextBox>
                </div>
            </div>

             <div class="row mr-lg-5 ml-lg-5 mb-3 pt-4">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-primary btn-block" BackColor="#7200cf" Text="Add Job" OnClick="btnAdd_Click"/>
            </div>
        </div>

        </div>

       

    </div>
</asp:Content>