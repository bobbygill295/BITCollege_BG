<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfStudent.aspx.cs" Inherits="wfStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="False" 
        AutoGenerateSelectButton="True" 
        onselectedindexchanged="gvCourses_SelectedIndexChanged" Width="664px">
        <Columns>
            <asp:BoundField DataField="CourseNumber" HeaderText="Course" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="CreditHours" HeaderText="Credit Hours" />
            <asp:BoundField DataField="CourseType" HeaderText="Course Type" />
            <asp:BoundField DataField="TuitionAmount" HeaderText="Tuition" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:LinkButton ID="btnRegister" runat="server">Register for a course</asp:LinkButton>
    <br />
    <asp:Label ID="lblResults" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="lblError" runat="server" Text="Label" Visible="False" 
        ForeColor="Red"></asp:Label>
</asp:Content>

