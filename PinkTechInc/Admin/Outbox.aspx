<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMenuMaster.master" AutoEventWireup="true" CodeBehind="Outbox.aspx.cs" Inherits="PinkTechInc.Admin.Outbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Sent Messages-->
    <div id="sent" class="container-fluid">
        <div class="btn btn-group-xs">
            <a class="btn btn-info" href="/Admin/AdminMenu.aspx?ID=<%=Request.QueryString["ID"].ToString() %>">Profile</a>
            <a class="btn btn-info" href="/Admin/Inbox.aspx?ID=<%=Request.QueryString["ID"].ToString() %>">Inbox</a>
            <a class="btn btn-info " href="/Admin/SendMessage.aspx?ID=<%=Request.QueryString["ID"].ToString() %>">Send Message</a>
            <a class="btn btn-info active" href="#">Outbox</a>
        </div>
        <div class="panel panel-body">
            <asp:GridView ID="grdSent" runat="server" CssClass="table table-striped table-hover table-condensed" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Subject" HeaderText="Subject" />
                    <asp:BoundField DataField="Recepients" HeaderText="Recepients" />
                    <asp:BoundField DataField="CreatedDate" HeaderText="Date Sent" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
