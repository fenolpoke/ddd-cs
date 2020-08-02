<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageForm.Master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="WebViewApplication.LoginForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Login Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
    <style>
        body{
            align-content:center;
            text-align:center;
        }
        table{
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <table>
        <tr>
            <td colspan="2">Login Form</td>
        </tr>
        <tr>
            <td>Username</td>
            <td><asp:TextBox runat="server" ID="username"/></td>
        </tr>
        <tr>
            <td>Password</td>
            <td><asp:TextBox runat="server" ID="password" TextMode="Password"/></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CheckBox Text="Remember me" runat="server" ID="remember"/></td>
        </tr>
        <tr>
            <td><asp:Button Text="Login" ID="loginButton" runat="server" OnClick="loginButton_Click" /></td>
            <td><asp:Button Text="Register" ID="registerButton" runat="server" OnClick="registerButton_Click" /></td>
        </tr>
        <tr>
            <td colspan="2"><%if (message != null) { %><%=message %><% } %></td>
        </tr>
        
    </table>
</asp:Content>
