<%@ Page Title="" Language="C#" MasterPageFile="~/PinkTechIncSiteMaster1.Master" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="PinkTechInc.UserHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table border="1">
            <tr class="container" >
                <td width="540" height="520">
                    <h1>USER HOME</h1>
                    <h3 class="lead">Welcome</h3>
                    <p class="dl-horizontal"></p>
                    <p>
                        User Name: <b>
                            <asp:Label ID="lblUserName" runat="server" /></b>
                    </p>
                    <br />
                    <p>
                        Full Name: <b>
                            <asp:Label ID="lblFullName" runat="server" /></b>
                    </p>
                    <br />
                    <p>
                        Role: <b>
                            <asp:Label ID="lblUserRole" runat="server" /></b>
                    </p>
                </td>
                <td width="540" height="520"></td>
            </tr>
        </table>
    </div>
</asp:Content>
