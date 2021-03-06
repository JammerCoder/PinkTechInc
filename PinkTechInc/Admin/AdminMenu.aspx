﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PinkTechIncSiteMaster1.Master" AutoEventWireup="true" CodeBehind="AdminMenu.aspx.cs" Inherits="PinkTechInc.AdminMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <table border="1">
            <tr class="container">
                <td width="540" height="520">
                    <div>
                        <ul class="nav nav-pills">
                            <li><a class="disabled" href="#">Tasks</a></li>
                            <li><a class="" href="#"><i class="glyphicon glyphicon-envelope"></i>Messages<asp:Label ID="lblNewMessage" runat="server" CssClass="badge alert-danger" /></a></li>
                        </ul>
                    </div>
                    <div class="container-fluid">
                        <h2 class="page-header">Welcome <strong><small>
                            <asp:Label ID="lblUserName" runat="server" /></small></strong>
                        </h2>
                        <ul class="nav nav-tabs">
                            <li class="active"><a data-toggle="tab" href="#profile">Profile</a></li>
                            <li><a data-toggle="tab" href="#messages">Inbox</a></li>
                            <li><a data-toggle="tab" href="#createnew">Create New</a></li>
                            <li><a data-toggle="tab" href="#sent">Sent</a></li>
                        </ul>
                        <div class="tab-content">
                            <!--Profile-->
                            <div id="profile" class="tab-pane fade in active">
                                <div class="panel panel-info">
                                    <div class="panel-heading">Personal Information</div>
                                    <div class="panel-body">
                                        <div class="col-sm-3">
                                            <asp:Image ID="imgProfilePhoto" runat="server" Height="80" Width="80" ImageUrl="~/images/profilephoto.jpg" />
                                        </div>
                                        <div class="col-sm-9">
                                            <p class="page-header">
                                                Name: <strong><asp:Literal ID="litAccountName" runat="server" /></strong>
                                                <br />
                                                Address: <strong><asp:Literal ID="litAddress" runat="server" /></strong>
                                                <br />
                                                Contact Info: <strong><asp:Literal ID="litContact" runat="server" /></strong>
                                                <br />
                                                Role: <strong><asp:Literal ID="litRole" runat="server" /></strong>
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
                            <!--Inbox-->
                            <div id="messages" class="tab-pane fade">
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
                            <!--Create New Message-->
                            <div id="createnew" class="tab-pane fade">
                                <div class="panel panel-primary">
                                    <div class="panel-heading">Create New Message</div>
                                    <div class="panel-body">
                                        <form>
                                            <div class="input-group-sm">
                                                <div class="form-group-sm">
                                                    <div class="input-group">
                                                        <asp:TextBox ID="txtRecepient" runat="server" placeholder="Recepient" CssClass="form-control" />
                                                        <span class="input-group-btn">
                                                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchRecepient" runat="server" Text="..." /></span>
                                                    </div>
                                                    <asp:RequiredFieldValidator class="text-danger" ID="rfvRecepient" runat="server"
                                                        ErrorMessage="Recepient is required!"
                                                        ControlToValidate="txtRecepient"></asp:RequiredFieldValidator>
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
                                        <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="btn btn-xs btn-success" />
                                    </div>
                                </div>
                            </div>
                            <!--Sent Messages-->
                            <div id="sent" class="tab-pane fade">
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
                        </div>
                    </div>
                </td>
                <td width="540" height="520"></td>
            </tr>
        </table>
    </div>
</asp:Content>
