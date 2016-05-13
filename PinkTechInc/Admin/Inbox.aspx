<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMenuMaster.master" AutoEventWireup="true" CodeBehind="Inbox.aspx.cs" Inherits="PinkTechInc.Admin.Inbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Inbox-->
    <div class="container-fluid">
        <div class="btn btn-group-xs">
            <a class="btn btn-info" href="/Admin/AdminMenu.aspx?ID=<%=Request.QueryString["ID"].ToString() %>">Profile</a>
            <a class="btn btn-info active" href="#">Inbox</a>
            <a class="btn btn-info" href="/Admin/SendMessage.aspx?ID=<%=Request.QueryString["ID"].ToString() %>">Send Message</a>
            <a class="btn btn-info" href="/Admin/Outbox.aspx?ID=<%=Request.QueryString["ID"].ToString() %>">Outbox</a>
        </div>
        <div class="panel panel-body">
            <asp:GridView ID="grdInbox" runat="server" CssClass="table table-striped table-hover table-condensed" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Subject" HeaderText="Subject" />
                    <asp:BoundField DataField="Sender" HeaderText="From" />
                    <asp:BoundField DataField="CreatedDate" HeaderText="Date" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
