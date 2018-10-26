<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfDrop.aspx.cs" Inherits="wfDrop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:DetailsView ID="dvCourseInfo" runat="server" AutoGenerateRows="False" Height="50px" OnPageIndexChanging="dvCourseInfo_PageIndexChanging" Width="363px" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
        <EditRowStyle BackColor="#2461BF" />
        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="RegistrationId" HeaderText="Registration" />
            <asp:BoundField DataField="Student.FullName" HeaderText="Student" />
            <asp:BoundField DataField="Course.Title" HeaderText="Course" />
            <asp:BoundField DataField="RegistrationDate" HeaderText="Date" />
            <asp:BoundField DataField="Grade" HeaderText="Grade" />
        </Fields>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
    </asp:DetailsView>
    <asp:LinkButton ID="lnkDrop" runat="server" OnClick="lnkDrop_Click">Drop Course</asp:LinkButton>
&nbsp;<asp:LinkButton ID="lnkBack" runat="server" OnClick="lnkBack_Click">Return to Registration Listing</asp:LinkButton>
    <br />
    <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
</asp:Content>

