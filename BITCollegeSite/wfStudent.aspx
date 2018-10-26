<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfStudent.aspx.cs" Inherits="wfStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="False" 
        AutoGenerateSelectButton="True" 
        onselectedindexchanged="gvCourses_SelectedIndexChanged" Width="664px" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="CourseNumber" HeaderText="Course" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="CreditHours" HeaderText="Credit Hours" />
            <asp:BoundField DataField="CourseType" HeaderText="Course Type" />
            <asp:BoundField DataField="TuitionAmount" HeaderText="Tuition" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <br />
    <asp:LinkButton ID="btnRegister" runat="server" OnClick="btnRegister_Click">Register for a course</asp:LinkButton>
    <br />
    <asp:Label ID="lblResults" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="lblError" runat="server" Text="Label" Visible="False" 
        ForeColor="Red"></asp:Label>
</asp:Content>

