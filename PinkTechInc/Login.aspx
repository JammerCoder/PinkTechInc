<%@ Page Title="" Language="C#" MasterPageFile="~/PinkTechIncSiteMaster1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PinkTechInc.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table align="center" border="1">
            <th colspan="2">Login
            </th>
            <tr>
                <td>
                    <asp:Label ID="lblUserName" runat="server" Text="User Name" />
                </td>
                <td>
                    <asp:TextBox class="textBox" ID="txtUserName" runat="server" />
                    <asp:RequiredFieldValidator class="text-danger" ID="rfvUserName" runat="server" 
                        ErrorMessage="User Name is required!" 
                        ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassword" runat="server" Text="Password" />
                </td>
                <td>
                    <asp:TextBox class="textBox" ID="txtPassword" runat="server" TextMode="Password" />
                    <asp:RequiredFieldValidator class="text-danger" ID="rfvPassword" runat="server" 
                        ErrorMessage="Password is required!" 
                        ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button class="control" ID="btnLogin" runat="server" Text="Login" />
                </td>

            </tr>
            <tr>
                <td colspan="2">
                    <asp:Literal ID="litLoginMessage" runat="server" />
                    <asp:HyperLink class="hyp" ID="hypHome" runat="server" NavigateUrl="~/Home.aspx">Home</asp:HyperLink>
                </td>

            </tr>
        </table>
    </div>
</asp:Content>
