<%@ Page Title="" Language="C#" MasterPageFile="~/PinkTechIncSiteMaster1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PinkTechInc.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table align="center" width="300px" height="200" border="0">
            <tr>
                <td class="container">
                    <div class="form-box">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h2 class="text-center">Welcome</h2>
                                <h6 class="small text-center">Please provide your Login Name and Password...</h6>
                            </div>
                            <div class="panel-body">
                                <form class="form-signin">
                                    <div>
                                        <asp:TextBox class="form-control" ID="txtUserName" runat="server" placeholder="Login Name" />
                                        <asp:RequiredFieldValidator class="text-danger" ID="rfvUserName" runat="server"
                                            ErrorMessage="User Name is required!"
                                            ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                                    </div>
                                    <div>
                                        <asp:TextBox class="form-control" ID="txtPassword" runat="server" TextMode="Password" placeholder="Password" OnTextChanged="txtPassword_TextChanged" />
                                        <asp:RequiredFieldValidator class="text-danger" ID="rfvPassword" runat="server"
                                            ErrorMessage="Password is required!"
                                            ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                                    </div>
                                    <div>
                                        <asp:Button class="btn btn-lg btn-primary btn-block" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /> <br />
                                        <asp:Literal ID="litLoginMessage" runat="server" />
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
