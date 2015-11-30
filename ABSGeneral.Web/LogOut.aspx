<%@ Page Title="ABS:: Log Out" Language="C#" MasterPageFile="~/Site0.Master" AutoEventWireup="true" CodeBehind="LogOut.aspx.cs" Inherits="ABSGeneral.Web.LogOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
       

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Logged Out
    </h3>
    <h4>You are logged out click <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">HERE</asp:HyperLink>  to log in again! </h4>
</asp:Content>
