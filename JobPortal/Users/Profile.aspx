<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UseMasterPage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="JobPortal.Users.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container pt-5 pb-5">
        <div class="main-body">
            <asp:Label ID="lblMsg" runat="server" ></asp:Label>
            <asp:DataList ID="dlProfile" runat="server" width="100%" OnItemCommand="dlProfile_ItemCommand" >
                <ItemTemplate>
                    <div class="row gutters-sm">
                        <div class="col-md-4 mb-3">
                            <div class="card">
                                <div class="card-body">
                                    <div class="d-flex flex-column align-center text-center " style="align-items:center" >
                                       <img src="../Images/avatar.png" alt="UserPic" class="rounded-circle" width="150" align="center"/>
                                        <div class="mt-3">
                                            <h4 class="text-capitalize"><%# Eval("Name") %></h4>
                                            <p class="text-secondary mb-1">@<%# Eval("Username") %></p>
                                            <p class="text-muted font-size-sm text-capitalize">
                                                <i class="fas fa-map-marker-alt"></i> <%# Eval("Country") %>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="card mb-3">
                                <div class="card-body">
                                    <div class="row">
                                         <div class="col-sm-3">
                                             <h6 class="mb-0">Full Name</h6>
                                         </div>
                                        <div class="col-sm-9 text-secondary text-capitalize">
                                           <%# Eval("Name") %>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <h6 class="mb-0">Email</h6>
                                        </div>
                                        <div class="col-sm-9 text-secondary text-capitalize">
                                            <%# Eval("Email") %>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <h6 class="mb-0">Mobile</h6>
                                        </div>
                                        <div class="col-sm-9 text-secondary text-capitalize">
                                            <%# Eval("Mobile") %>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <h6 class="mb-0">Address</h6>
                                        </div>
                                        <div class="col-sm-9 text-secondary text-capitalize">
                                            <%# Eval("Adress") %>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <h6 class="mb-0">Resume Upload</h6>
                                        </div>
                                        <div class="col-sm-9 text-secondary text-capitalize">
                                            <%# Eval("Resume")== DBNull.Value? "Not Uploaded" : "Uploaded" %>
                                        </div>
                                    </div>
                                     <div class="row">
                                        <div class="col-sm-12 pt-4">
                                            <label for="fuXMLCv" align="center">Incarca Cv-ul tau in format XML</label>
                                          <asp:FileUpload ID="fuXMLCv" runat="server" CssClass="form-control" ToolTip=".xml extension only" />

                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <asp:Label ID="Label1" runat="server" ></asp:Label>
                                            <asp:Label ID="Label2" runat="server" ></asp:Label>
                                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button button-contactForm boxed-btn" 
                                                CommandName="EditUserProfile"  CommandArgument='<%# Eval("Username") %>'/>
                                       <asp:Button ID="Button1" runat="server" Text="View Resume" CssClass="button button-contactForm boxed-btn" Style="margin-left:335px" 
                                           CommandName="VizualizareCV" CommandArgument="VizualizareCv"/>

                                        </div>
                                    </div>
                                   
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>



</asp:Content>
