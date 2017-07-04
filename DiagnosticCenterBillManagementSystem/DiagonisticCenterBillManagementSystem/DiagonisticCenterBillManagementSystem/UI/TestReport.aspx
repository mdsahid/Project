<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteView.Master" AutoEventWireup="true" CodeBehind="TestReport.aspx.cs" Inherits="DiagonisticCenterBillManagementSystem.UI.TestReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpMainContent" runat="server">
    <div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <div class="panel panel-default row">
            <div class="panel-heading text-center">Test Report</div>
            <div class="col-md-9 row">
                <div class="col-md-5">
                    <div class="form-group">
                        <asp:Label ID="lblFromDate" runat="server" Text="From Date"></asp:Label>
                        <asp:TextBox ID="txtFromDate" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFromDate" ErrorMessage="From date is required" ForeColor="Red"></asp:RequiredFieldValidator>

                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblToDate" runat="server" Text="To Date"></asp:Label>
                        <asp:TextBox ID="txtToDate" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtToDate" ErrorMessage="To date is  required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <asp:Button ID="btnShowTest" runat="server" CssClass="btn btn-primary pull-right" Text="Show" OnClick="btnShowTest_Click" />
                    <br />
                    <br />
                    <div>
                        <asp:Label ID="lblSaveMessage" runat="server" Text=""></asp:Label>
                    </div>

                </div>

                <div class="col-md-6 col-md-offset-1">
                    <asp:GridView ID="GridViewTestShow" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" Width="547px">
                        <Columns>
                            <asp:TemplateField HeaderText="SL">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="testName" HeaderText="Test" />
                            <asp:BoundField DataField="TotalTest" HeaderText="Total Test" />
                            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" />
                        </Columns>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:GridView>

                    <div class="form-group">
                        <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label>
                        <asp:TextBox ID="txtTestTotal" CssClass="form-control" runat="server" Width="169px"></asp:TextBox>
                        <asp:Label ID="lblPDF" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Button ID="btnPDFShow" CssClass="btn btn-primary pull-Left" runat="server" Text="PDF" Width="67px" CausesValidation="False" OnClick="btnPDFShow_Click" />
                    </div>

                </div>

            </div>


        </div>
    </div>
</asp:Content>
