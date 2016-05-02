<%@ Page Title="" Language="C#" MasterPageFile="~/PinkTechIncSiteMaster1.Master" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="PinkTechInc.UserHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h1>USER HOME</h1>
        <h3 class="lead">Welcome</h3>
        <p class="dl-horizontal"></p>
        <p>User Name: <b>
            <asp:Label ID="lblUserName" runat="server" /></b></p>
        <br />
        <p>Full Name: <b>
            <asp:Label ID="lblFullName" runat="server" /></b></p>
        <br />
        <p>Role: <b>
            <asp:Label ID="lblUserRole" runat="server" /></b></p>
    </div>
</asp:Content>
