<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteView.Master" AutoEventWireup="true" CodeBehind="Patient.aspx.cs" Inherits="DiagonisticCenterBillManagementSystem.UI.Patient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpMainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading text-center">Patient Test Setup</div>
        <div class="col-md-9 row">
            <div class="col-md-5">
                <div class="form-group">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:Label ID="lblTxtName" runat="server" Text="Patient Name"></asp:Label>
                    <asp:TextBox ID="txtPatientName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPatientName" Display="Dynamic" ErrorMessage="Patient name is required" ForeColor="Red"></asp:RequiredFieldValidator>

                </div>
                <div class="form-group">
                    <asp:Label ID="lblTxtMobile" runat="server" Text="Mobile No"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="txtMobileNo" runat="server"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Mobile number is required" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Contact no must be number" ForeColor="Red" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="txtDateOfBirth" runat="server" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDateOfBirth" Display="Dynamic" ErrorMessage="Date of birth is required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblTestName" runat="server" Text="Test Name"></asp:Label>
                    <asp:DropDownList CssClass="form-control" ID="ddlTestName" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlTestName_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlTestName" Display="Dynamic" ErrorMessage="Select a test name" ForeColor="Red" InitialValue="--Select Test--" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblTestFee" runat="server" Text="Test Fee"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="txtFeeOfTest" runat="server"></asp:TextBox>
                </div>

                <asp:Button ID="btnTestAdd" runat="server" Text="Add" OnClick="btnTestAdd_Click" CssClass="btn btn-primary pull-right" />

            </div>

            <div class="col-md-5 col-md-offset-1">
                <asp:GridView ID="GridOfTestRequest" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" Style="width: 100% !important">
                    <Columns>
                        <asp:TemplateField HeaderText="SL">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>

                            <HeaderStyle HorizontalAlign="Left" Width="5%"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="tName" HeaderText="Test" />
                        <asp:BoundField DataField="testFee" HeaderText="Fee" />
                    </Columns>
                </asp:GridView>

                <span>Total</span>
                <asp:TextBox ID="txtTotalTestAmount" runat="server" CssClass="form-control pull-right"></asp:TextBox>
                <br />
                <br />
                <br />
                <asp:Button ID="btnTestRequst" runat="server" Text="Save" OnClick="btnTestRequst_Click" CssClass="btn btn-primary pull-left" />





                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

            </div>

        </div>

    </div>
</asp:Content>
