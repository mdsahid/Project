<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteView.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="DiagonisticCenterBillManagementSystem.UI.Payment" %>

    <asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
     <script>
         function HideLblBillNo() {
             document.getElementById("<%=lblBillMessage.ClientID %>").style.display = "none";
         }

    </script>
    <div class="panel panel-default">
        <div class="panel-heading text-center">Patient Payment Status</div>
        <div class="col-md-9 row">
            <div class="col-md-5">
                <div class="form-group">
                    <asp:Label ID="lblBillNoSearch" CssClass="control-label" runat="server" Text="Bill No"></asp:Label>
                    <asp:TextBox ID="txtBillNoSearch" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="lblBillMessage" runat="server" Text=""></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBillNoSearch" ErrorMessage="Bill number is required" ForeColor="Red" ValidationGroup="BillNo"></asp:RequiredFieldValidator>
                </div>
                <asp:Button ID="btnSearch" OnClientClick="HideLblBillNo()"  CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnSearch_Click" ValidationGroup="BillNo" />
            </div>
            <div class="col-md-6 col-md-offset-1">
                
                    <asp:GridView ID="PaymentGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                        <Columns>
                            <asp:TemplateField HeaderText="SL">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="tName" HeaderText="Test" />
                            <asp:BoundField DataField="testFee" HeaderText="Fee" />
                        </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                
                <asp:HiddenField ID="HiddenFieldBillNo" runat="server" />
                <div>
                    <asp:Label ID="lblBillDateMsg" runat="server" Font-Size="15px"   Text="Bill Date: "></asp:Label>
                   
                     <asp:Label ID="lblBillDate" runat="server" Font-Size="20px"   Text=""></asp:Label>
                </div>
                <br />
                <div>
                    <asp:Label ID="lblTotalFeeMsg" runat="server" Font-Size="15px"  Text="Total Fee: "></asp:Label>
                    
                    <asp:Label ID="lblTotalFee" runat="server" Font-Size="20px"  Text=""></asp:Label>
                </div>
                <br />
                <div>
                    <asp:Label ID="lblPaidMsg" runat="server" Font-Size="15px"  Text="Paid Amount:"></asp:Label>
                     
                    <asp:Label ID="lblPaid" runat="server" Font-Size="20px"  Text=""></asp:Label>
                </div>
                <br />
                <div> 
                    <asp:Label ID="lblDueMsg" runat="server" Font-Size="15px"  Text="Due Amount: "></asp:Label>
                    
                    <asp:Label ID="lblDue" runat="server" Font-Size="20px"  Text=""></asp:Label>
                </div>
                <br />
                <div>
                    <asp:Label ID="lblAmount" runat="server" Text="Amount"></asp:Label>
                    <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="lblPaymentMsg" runat="server" Text=""></asp:Label>
                </div>
                <asp:Button ID="paySave" runat="server"  Text="Pay" CssClass="btn btn-primary pull-right" OnClick="paySave_Click" Width="116px" ValidationGroup="Amount" />
            </div>
        </div>
    </div>
</asp:Content>
