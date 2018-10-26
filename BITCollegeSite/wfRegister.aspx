<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfRegister.aspx.cs" Inherits="wfRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="lblCourseSelector" runat="server" Text="Course Selector:"></asp:Label>
    <asp:DropDownList ID="ddlCourses" runat="server" AutoPostBack="True">
    </asp:DropDownList>
    <br />
    <asp:Label ID="lblRegistrationNotes" runat="server" Text="Registration Notes:"></asp:Label>
    <asp:TextBox ID="txtNotes" runat="server"></asp:TextBox>
    <asp:Label ID="lblMessage" runat="server">Notes are required for Web registrations</asp:Label>
    <br />
    <asp:LinkButton ID="lnkRegister" runat="server" OnClick="lnkRegister_Click">Register</asp:LinkButton>
    <asp:LinkButton ID="lnkBack" runat="server" OnClick="lnkBack_Click">Return to Registration Listing</asp:LinkButton>
    <br />
    <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
</asp:Content>

