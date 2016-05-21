<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMenuMaster.master" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="PinkTechInc.Admin.SendMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Create New Message-->
        <div class="container-fluid">
            <div class="btn btn-group-xs">
                <a class="btn btn-info" href="/Admin/AdminMenu.aspx?ID=<%=Request.QueryString["ID"].ToString() %>">Profile</a>
                <a class="btn btn-info" href="/Admin/Inbox.aspx?ID=<%=Request.QueryString["ID"].ToString() %>">Inbox</a>
                <a class="btn btn-info active" href="#">Send Message</a>
                <a class="btn btn-info" href="/Admin/Outbox.aspx?ID=<%=Request.QueryString["ID"].ToString() %>">Outbox</a>
            </div>
            <div class="panel panel-primary">
                <div class="panel-heading">Create New Message</div>
                <div class="panel-body">
                    <form>
                        <div class="input-group-sm">
                            <div class="form-group-sm">
                                <asp:DropDownList ID="drdRecepient" runat="server" CssClass="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator class="text-danger" ID="rfvRecepient" runat="server"
                                    ErrorMessage="Recepient is required!"
                                    ControlToValidate="drdRecepient"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group-sm">
                                <asp:TextBox class="form-control" ID="txtSubject" runat="server" placeholder="Subject" />
                                <asp:RequiredFieldValidator class="text-danger" ID="rfvSubject" runat="server"
                                    ErrorMessage="Subject is required!"
                                    ControlToValidate="txtSubject"></asp:RequiredFieldValidator>

                            </div>
                            <div class="form-group-sm">
                                <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" ></asp:TextBox>
                                <asp:RequiredFieldValidator class="text-danger" ID="rfvMessage" runat="server"
                                    ErrorMessage="Message cannot be empty!"
                                    ControlToValidate="txtMessage"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </form>
                </div>
                <div class="panel-footer">
                    <span>
                        <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" CssClass="btn btn-sm btn-success" />
                        <asp:Literal ID="litErrorMessages" runat="server" /></span>
                </div>
            </div>
        </div>
</asp:Content>
