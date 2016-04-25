<%@ Page Title="" Language="C#" MasterPageFile="~/PinkTechIncSiteMaster1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PinkTechInc.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table border="1" width="1080px" height="520px">
            <tr>
                <td colspan ="3">
                    <asp:Image ID="imgHome1" runat="server" />
                    <p>Top Row Over 3 Columns</p>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Image ID="imgHome2" runat="server" Height="80px" Width="80px" />
                    <p>Bottom Row Column 1</p>
                </td>
                <td>
                    <asp:Image ID="imgHome3" runat="server" Height="80px" Width="80px"/>
                    <p>Bottom Row Column 2</p>
                </td>
                <td>
                    <asp:Image ID="imgHome4" runat="server" Height="80px" Width="80px"/>
                    <p>Bottom Row Column 3</p>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
