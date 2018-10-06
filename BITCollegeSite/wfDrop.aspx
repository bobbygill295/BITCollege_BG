<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfDrop.aspx.cs" Inherits="wfDrop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:DetailsView ID="dvCourseInfo" runat="server" AutoGenerateRows="False" Height="50px" Width="363px">
        <Fields>
            <asp:BoundField DataField="RegistrationId" HeaderText="Registration" />
            <asp:BoundField DataField="Student.FullName" HeaderText="Student" />
            <asp:BoundField DataField="Course.Title" HeaderText="Course" />
            <asp:BoundField DataField="RegistrationDate" HeaderText="Date" />
            <asp:BoundField DataField="Grade" HeaderText="Grade" />
        </Fields>
    </asp:DetailsView>
    <asp:LinkButton ID="lnkDrop" runat="server">Drop Course</asp:LinkButton>
&nbsp;<asp:LinkButton ID="lnkBack" runat="server">Return to Registration Listing</asp:LinkButton>
    <br />
    <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
</asp:Content>

