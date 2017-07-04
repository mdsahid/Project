<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteView.Master" AutoEventWireup="true" CodeBehind="TestTypes.aspx.cs" Inherits="DiagonisticCenterBillManagementSystem.UI.TestTypes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpMainContent" runat="server">
    <div class="panel panel-default row">
        <div class="panel-heading text-center">Test Type</div>
        <div class="col-xs-6 col-md-offset-2">
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Type Name"></asp:Label>
                <asp:TextBox ID="txtTypeName" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:HiddenField ID="HiddenField1" runat="server" />

                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

            </div>
            <div class="form-group">

                <asp:Button ID="btnTypeSave" CssClass="btn btn-primary pull-right" runat="server" Text="Save" OnClick="btnTypeSave_Click" />

            </div>
            <br />
            <br />
            <div>
                <asp:Label ID="lblSaveMessage" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="col-md-8 col-md-offset-2">
            <asp:GridView ID="testTypeGridView" runat="server" CssClass="table table-bordered" Style="width: 100% !important" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <Columns>
                    <asp:TemplateField HeaderText="SL" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Left" Width="5%"></HeaderStyle>

                    </asp:TemplateField>

                    <asp:BoundField DataField="typeName" HeaderText="Type" />
                </Columns>
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
