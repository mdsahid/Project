<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteView.Master" AutoEventWireup="true" CodeBehind="UnPaidBillReport.aspx.cs" Inherits="DiagonisticCenterBillManagementSystem.UI.UnPaidBillReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpMainContent" runat="server">
     <div>
        <div class="panel panel-default row">
            <div class="panel-heading text-center">Unpaid Bill Report</div>
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtToDate" ErrorMessage="To date is required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <asp:Button ID="btnShowUnpaidBill" CssClass="btn btn-primary pull-right" runat="server" Text="Show" OnClick="btnShowUnpaidBill_Click" />
                    <br />
                    <br />
                    <div>
                        <asp:Label ID="lblSaveMessage" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </div>

                </div>

                <div class="col-md-6 col-md-offset-1">
                    <asp:GridView ID="GridViewUnpaidBillShow" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"> 
                        <Columns>
                            <asp:TemplateField HeaderText="SL">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="BillNo" HeaderText="Bill Number" />
                            <asp:BoundField DataField="MobileNo" HeaderText="Contact No" />
                            <asp:BoundField DataField="PatientName" HeaderText="PatientName" />
                            <asp:BoundField DataField="UnpaidBill" HeaderText="Bill Amount" />
                        </Columns>
                    </asp:GridView>

                    <div class="form-group">
                        <span>Total</span>
                        <asp:TextBox ID="txtUnpaidTotal" runat="server" Width="169px" CssClass="form-control"></asp:TextBox> <br />
                        <asp:Button ID="btnPDFShow" CssClass="btn btn-primary pull-Left" runat="server" Text="PDF" Width="67px" OnClick="btnPDFShow_Click" CausesValidation="False" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
