<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteView.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="DiagonisticCenterBillManagementSystem.UI.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpMainContent" runat="server">

    <script>
        function Hide() {
            document.getElementById("<%=lblMessage.ClientID %>").style.display = "none";
        }
    </script>
    <div class="panel panel-default row">
        <div class="panel-heading text-center">Test</div>
        <div class="col-md-9">
            <div class="row">
                <div class="col-md-5">
                    <div class="form-group">
                        <asp:Label ID="lblTestName" runat="server" Text="Test Name"></asp:Label>
                        <asp:TextBox ID="txtTestName" CssClass="form-control" runat="server"></asp:TextBox>
                         
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTestName" ErrorMessage="Test name is required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="Fee"></asp:Label>
                        <asp:TextBox ID="txtTestFee" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTestFee" ErrorMessage="Test fee is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Type Name"></asp:Label>
                        <asp:DropDownList ID="ddlTestType" CssClass="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlTestType" Display="Dynamic" ErrorMessage="Select a type name" ForeColor="Red" InitialValue="--Select Type--"></asp:RequiredFieldValidator>
                    </div>
                    <asp:Button ID="btnTestSave" OnClientClick="Hide()"  runat="server" Text="Save" CssClass="btn btn-primary pull-right" OnClick="btnTestSave_Click" />
                   <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </div>

                <div class="col-md-5 col-md-offset-2">
                    <asp:GridView ID="GridViewTest" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" Style="width: 100% !important" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
                        <Columns>
                            <asp:TemplateField HeaderText="SL">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Test" HeaderText="Name" />
                            <asp:BoundField DataField="Fee" HeaderText="Fee" />
                            <asp:BoundField DataField="Type" HeaderText="Type" />
                        </Columns>
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#594B9C" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#33276A" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
   

</asp:Content>
