<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="JobList.aspx.cs" Inherits="JobPortal.Admin.JobList"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div style="background-image: url('../Images/bg.jpg'); width:100%; height:720px; background-repeat:no-repeat; background-size:cover; background-attachment:fixed">
        <div class="container-fluid pt-4 pb-4" style="height: 55px">
            <div>
                <asp:Label runat="server" ID="lblMsg"></asp:Label>
            <h3 class="text-center">Job List/ Details</h3>

                <div class="row mb-3 pt-sm-3">
                    <div class="col-md-12">
                        <asp:GridView runat="server" ID="GridView1" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" 
                            CssClass="table table-hover table-bordered" PageSize="5" EmptyDataText="No record to display..!"
                            AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="JobId">
                            <Columns>
                              
                                <asp:BoundField DataField="Sr.No" HeaderText="Sr.No">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>


                                 <asp:BoundField DataField="Title" HeaderText="Job Title">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                 <asp:BoundField DataField="NoOfPost" HeaderText="NoOfPost">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                

                                 <asp:BoundField DataField="Qualification" HeaderText="Qualification">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                 <asp:BoundField DataField="Experience" HeaderText="Experience">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                 <asp:BoundField DataField="LastDayToApply" HeaderText="Valid Till">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                 <asp:BoundField DataField="Company Name" HeaderText="Company">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                
                              
                            </Columns>
                        </asp:GridView>
                        
                    </div>
                </div>

            </div>
         </div>
    </div>


</asp:Content>
