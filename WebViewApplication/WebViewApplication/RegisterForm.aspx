<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageForm.Master" AutoEventWireup="true" CodeBehind="RegisterForm.aspx.cs" Inherits="WebViewApplication.RegisterForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Register Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
    <style>
        body{
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">

    <table>
        <tr>
            <td colspan="2">Register Form</td>
        </tr>
        <tr>
            <td>Name: </td>
            <td><asp:TextBox runat="server" ID="name" /></td>
        </tr>
        <tr>
            <td>Username: </td>
            <td><asp:TextBox runat="server" ID="username" /></td>
        </tr>
        <tr>
            <td>Password: </td>
            <td><asp:TextBox runat="server" ID="password" TextMode="Password" /></td>
        </tr>        
        <tr>
            <td><asp:Button Text="Register!" ID="registerButton" runat="server" OnClick="registerButton_Click" /></td>
            <td><asp:Button Text="Back" ID="backButton" runat="server" OnClick="backButton_Click" /></td>
        </tr>
        <tr>
            <td colspan="2"><%if (message != null) { %><%=message %><% } %></td>
        </tr>
    </table>

</asp:Content>
