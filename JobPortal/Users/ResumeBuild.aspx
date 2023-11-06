<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UseMasterPage.Master" AutoEventWireup="true" CodeBehind="ResumeBuild.aspx.cs" Inherits="JobPortal.Users.ResumeBuild" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


       <section>
          
    <div class="container pt-50 pb-40">
      <div class="row">
        <div class="col-12 pb-20">
          <asp:Label ID="lblMsg" runat="server" Visible="true"></asp:Label>
        </div>
        <div class="col-12">
          <h2 class="contact-title">View your CV</h2>
        </div>
        <div class="col-lg-6">
          <div class="form-contact contact_form">
            <div class="row">
              <div class="col-12">
                  
                <h5 >Personal Information</h5>
              </div>
            
              <div class="col-sm-6">
                <div class="form-group">
                    <asp:Label ID="lbl" runat="server" Text="First Name"></asp:Label>
                  <asp:TextBox ID="txtFirstName" runat="server"  CssClass="form-control" ></asp:TextBox>
                </div>
              </div>
              <div class="col-sm-6">
                <div class="form-group">
                  <asp:Label ID="Label3" runat="server" Text="Last Name"></asp:Label>
                  <asp:TextBox ID="txtLastName" runat="server"  CssClass="form-control" ></asp:TextBox>
               
                </div>
              </div>


               <div class="col-12">
                <div class="form-group">
                  <asp:Label ID="Email" runat="server" Text="Email"></asp:Label>
                  <asp:TextBox ID="txtEmail" runat="server"  CssClass="form-control" ></asp:TextBox>
                </div>
              </div>

               

                 <div class="col-sm-6">
                <div class="form-group">
                    <asp:Label ID="Birthday" runat="server" Text="Birthday"></asp:Label>
                  <asp:TextBox ID="txtBirthday" runat="server" TextMode="DateTime" CssClass="form-control" ></asp:TextBox>
                </div>
              </div>
              <div class="col-sm-6">
                <div class="form-group">
                  <asp:Label ID="Gender" runat="server" Text="Gender"></asp:Label>
                  <asp:TextBox ID="txtGender" runat="server"  CssClass="form-control"  ></asp:TextBox>
               
                </div>
              </div>
                
                 <div class="col-12">
                <h5 >Last/Curent Job Information</h5>
              </div>

                  <div class="col-sm-6">
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="Start Date"></asp:Label>
                  <asp:TextBox ID="txtStartDayWork" runat="server" TextMode="DateTime" CssClass="form-control" ></asp:TextBox>
                </div>
              </div>
              <div class="col-sm-6">
                <div class="form-group">
                  <asp:Label ID="Label2" runat="server" Text="End Date"></asp:Label>
                  <asp:TextBox ID="txtEndDateWork" runat="server"  CssClass="form-control" ></asp:TextBox>
               
                </div>
              </div>


                 <div class="col-12">
                <div class="form-group">
                  <asp:Label ID="Label9" runat="server" Text="Organization"></asp:Label>
                  <asp:TextBox ID="txtOrganization" runat="server" CssClass="form-control" ></asp:TextBox>
                </div>
              </div>
                
                  <div class="col-sm-6">
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" Text="Position"></asp:Label>
                  <asp:TextBox ID="txtPosition" runat="server" TextMode="DateTime" CssClass="form-control" ></asp:TextBox>
                </div>
              </div>
              <div class="col-sm-6">
                <div class="form-group">
                  <asp:Label ID="Label5" runat="server" Text="Type"></asp:Label>
                  <asp:TextBox ID="txtType" runat="server"  CssClass="form-control" ></asp:TextBox>
               
                </div>
              </div>

                
                

                 <div class="col-12">
                <div class="form-group">
                  <asp:Label ID="Label12" runat="server" Text="Activity"></asp:Label>
                  <asp:TextBox ID="txtActivity" runat="server" CssClass="form-control"  TextMode="MultiLine"></asp:TextBox>
                </div>
              </div>

               <div class="col-12">
                <h5>Education</h5>
              </div>

                <div class="col-12">
                <div class="form-group">
                  <asp:Label ID="Label11" runat="server" Text="Title"></asp:Label>
                  <asp:TextBox ID="txtTitleED" runat="server"  CssClass="form-control" ></asp:TextBox>
               
                </div>
              </div>

                 <div class="col-sm-6">
                <div class="form-group">
                    <asp:Label ID="Label10" runat="server" Text="Start Date"></asp:Label>
                  <asp:TextBox ID="txtStartDateEd" runat="server" TextMode="DateTime" CssClass="form-control" ></asp:TextBox>
                </div>
              </div>

                  <div class="col-sm-6">
                <div class="form-group">
                    <asp:Label ID="Label8" runat="server" Text="End Date"></asp:Label>
                  <asp:TextBox ID="txtEndDateEd" runat="server" TextMode="DateTime" CssClass="form-control" ></asp:TextBox>
                </div>
              </div>
              


                



                 <div class="col-12">
                <div class="form-group">
                    <asp:Label ID="Label13" runat="server" Text="Qualification Title"></asp:Label>
                  <asp:TextBox ID="txtQualificationtitle" runat="server"  CssClass="form-control" ></asp:TextBox>
                </div>
              </div>
              <div class="col-sm-6">
                <div class="form-group">
                  <asp:Label ID="Label14" runat="server" Text="Qualification Level"></asp:Label>
                  <asp:TextBox ID="txtQualificationlevel" runat="server"  CssClass="form-control" ></asp:TextBox>
               
                </div>
              </div>
                <div class="col-sm-6">
                <div class="form-group">
                    <asp:Label ID="Label17" runat="server" Text="Qualification Sector"></asp:Label>
                  <asp:TextBox ID="TextBox2" runat="server"  CssClass="form-control" ></asp:TextBox>
                </div>
              </div>


                 <div class="col-sm-6">
                <div class="form-group">
                    <asp:Label ID="Label15" runat="server" Text="Language"></asp:Label>
                  <asp:TextBox ID="txtLanguage" runat="server"  CssClass="form-control" ></asp:TextBox>
                </div>
              </div>

                <div class="col-sm-6">
                <div class="form-group">
                  <asp:Label ID="Label16" runat="server" Text="Proficiency"></asp:Label>
                  <asp:TextBox ID="txtProficiency" runat="server"  CssClass="form-control" ></asp:TextBox>
               
                </div>
              </div>


                 
             
                <div class="col-12">
                <h5>Skils</h5>
              </div>


                 <div class="col-12">
                <div class="form-group">
                    <asp:Label ID="Label6" runat="server" Text="Name Skil"></asp:Label>
                  <asp:TextBox ID="txtNameSkil" runat="server"  CssClass="form-control" ></asp:TextBox>
                </div>
              </div>

                 <div class="col-12">
                <div class="form-group">
                    <asp:Label ID="Label7" runat="server" Text="Description"></asp:Label>
                  <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control" ></asp:TextBox>
                </div>
              </div>
             

            </div>
            <div class="form-group mt-3">
              <asp:Button ID="btnGenButton" runat="server" Text="View PDF CV" CssClass="button button-contactForm boxed-btn mr-4" OnClick="btnGenButton_Click"/>
              
                <p>If you are happy with the information generate your cv </p>
              
            </div>
          </div>
        </div>
      </div>
    
    </div>
  </section>
     

</asp:Content>
