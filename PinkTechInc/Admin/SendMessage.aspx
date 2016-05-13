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
                            <asp:ListBox ID="lstRecepient" runat="server" CssClass="form-control" Rows="3" />
                            <asp:RequiredFieldValidator class="text-danger" ID="rfvRecepient" runat="server"
                                ErrorMessage="Recepient is required!"
                                ControlToValidate="lstRecepient"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group-sm">
                            <asp:TextBox class="form-control" ID="txtSubject" runat="server" placeholder="Subject" />
                            <asp:RequiredFieldValidator class="text-danger" ID="rfvSubject" runat="server"
                                ErrorMessage="Subject is required!"
                                ControlToValidate="txtSubject"></asp:RequiredFieldValidator>

                        </div>
                        <div class="form-group-sm">
                            <textarea class="form-control" id="txtMessageArea" rows="7" required="required" spellcheck="True"></textarea>
                        </div>
                    </div>
                </form>
            </div>
            <div class="panel-footer">
                <span>
                    <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="btn btn-xs btn-success" OnClick="btnSend_Click" /></span>
                <span>
                    <asp:Literal ID="litErrorMessages" runat="server" /></span>
            </div>
        </div>
    </div>
</asp:Content>
