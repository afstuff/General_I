<%@ Page Title="ABS:: Dashboard" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="ABSGeneral.Web.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/dashboard.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Dashboard   |   Welcome <asp:Label ID="lblUserName" runat="server"></asp:Label>;
    </h3>

</asp:Content>
