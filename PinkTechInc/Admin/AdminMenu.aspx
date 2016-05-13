<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMenuMaster.master" AutoEventWireup="true" CodeBehind="AdminMenu.aspx.cs" Inherits="PinkTechInc.Admin.AdminMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Profile-->
    <div class="container-fluid">
        <div class="btn btn-group-xs">
            <a class="btn btn-info active" href="#">Profile</a>
            <a class="btn btn-info" href="/Admin/Inbox.aspx?ID=<%=Request.QueryString["ID"].ToString() %>">Inbox</a>
            <a class="btn btn-info" href="/Admin/SendMessage.aspx?ID=<%=Request.QueryString["ID"].ToString() %>">Send Message</a>
            <a class="btn btn-info" href="/Admin/Outbox.aspx?ID=<%=Request.QueryString["ID"].ToString() %>">Outbox</a>
        </div>
        <div class="panel panel-info">
            <div class="panel-heading">Personal Information</div>
            <div class="panel-body">
                <div class="col-sm-3">
                    <asp:Image ID="imgProfilePhoto" runat="server" Height="80" Width="80" ImageUrl="~/images/profilephoto.jpg" />
                </div>
                <div class="col-sm-9">
                    <p class="page-header">
                        Name: <strong>
                            <asp:Literal ID="litAccountName" runat="server" /></strong>
                        <br />
                        Address: <strong>
                            <asp:Literal ID="litAddress" runat="server" /></strong>
                        <br />
                        Contact Info: <strong>
                            <asp:Literal ID="litContact" runat="server" /></strong>
                        <br />
                        Role: <strong>
                            <asp:Literal ID="litRole" runat="server" /></strong>
                        <br />
                    </p>
                </div>
            </div>
            <div class="panel-footer">
                <div class="btn-group-xs">
                    <a class="btn btn-info">Edit Profile</a>
                    <a class="btn btn-info">Change Password</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
