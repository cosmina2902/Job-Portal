<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ListJob.aspx.cs" Inherits="JobPortal.Admin.ListJob" %>
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
                        <asp:HiddenField runat="server" ID="confirm" Value="No" />
                        <asp:GridView runat="server" ID="GridView1" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" 
                            CssClass="table table-hover table-bordered" PageSize="5" EmptyDataText="No record to display..!"
                            AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="JobId" OnRowDeleting="GridView1_RowDeleting" 
                            OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                              
                                <asp:BoundField DataField="Sr.No" HeaderText="Sr.No">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>


                                 <asp:BoundField DataField="Title" HeaderText="Job Title">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                 <asp:BoundField DataField="NrOfPost" HeaderText="NoOfPost">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                

                                 <asp:BoundField DataField="Qualification" HeaderText="Qualification">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                 <asp:BoundField DataField="Experience" HeaderText="Experience">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                 <asp:BoundField DataField="LastDayToAPply" HeaderText="Valid Till" DataFormatString="{0:dd MMMM yyyy}">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                 <asp:BoundField DataField="CompanyName" HeaderText="Company">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                 <asp:BoundField DataField="Country" HeaderText="Country">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                 <asp:BoundField DataField="Locality" HeaderText="Locality">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>


                                 <asp:BoundField DataField="CreateDate" HeaderText="PostedDate" DataFormatString="{0:dd MMMM yyyy}">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditJob" runat="server" CommandName="EditJob" CommandArgument='<%# Eval("JobId")%>'>
                                            <asp:Image ID="Img" runat="server" ImageUrl="../assets/img/icon/pencil.png" Height="25px"/>
                                        </asp:LinkButton>
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </ItemTemplate>
                                </asp:TemplateField>


                               <asp:CommandField CausesValidation="false" HeaderText="Delete" ShowDeleteButton="true"
                                            DeleteImageUrl="../assets/img/icon/trash.png" ButtonType="Image"
                                            ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="25px" >
                                            <ControlStyle Height="25px" Width="25px" />
                                            <ItemStyle HorizontalAlign="Center"/>
                                        </asp:CommandField>
                            </Columns>

                            <HeaderStyle BackColor="#7200cf" ForeColor="White"/>
                        </asp:GridView>
                        
                    </div>
                </div>

            </div>
         </div>
    </div>

</asp:Content>
