<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageForm.Master" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="WebViewApplication.MainForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Main Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
    <style>
        body{
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    Home
    <br />
    <%=(Session["user"].Equals("admin") ? "Administrator version" : "User: "+Session["user"]) %>
    <table>

        <tr>
            <td>Name</td>
            <td>Price</td>
            <td>Stock</td>
            <td>In Cart</td>
        </tr>

        <%foreach (WebViewApplication.Model.Powder powder in powders)
            {
        %>
                <tr>
                    <td><%=powder.name %></td>
                    <td><%=powder.price %></td>
                    <td><%=powder.stock %></td>
                    <td><%=(Session[powder.id.ToString()] != null ? Session[powder.id.ToString()] : 0 )%></td>  
                    <td><a href="MainForm.aspx?insert=true&id=<%=powder.id %>">Add To Cart!</a></td> 
                    <td><a href="MainForm.aspx?update=true&id=<%=powder.id %>">Delete From Cart!</a></td>
                    <% if (Session["user"].Equals("admin"))
                        {
                    
                    %>                     
                            <td><a href="MainForm.aspx?delete=true&id=<%=powder.id %>">Delete Product!</a></td>
                    <%
                        }
                    %>
                </tr>
        <%
            } 
        %>
        <tr><td colspan="4"><%=error %></td></tr>
        <tr><td colspan="4"><asp:Button Text="Check Out!" ID="CheckOut" runat="server" OnClick="Unnamed1_Click" /></td></tr>
    </table>

   

</asp:Content>
