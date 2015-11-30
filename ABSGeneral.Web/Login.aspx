<%@ Page Title="ABS:: Login" Language="C#" MasterPageFile="~/Site0.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ABSGeneral.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/login.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<h3>Login</h3>--%>
    <div class="col-md-4 col-md-offset-4" style="margin-top: 1%;">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">ABS:: Login Panel</h3>
            </div>
            <div class="panel-body" align="center">
                <img src="Content/images/User-icon.png" style="height: 120px; border: solid 1pt lightgray; padding: 10px;" class="img-circle" />
                <br />
                <br />
                <div id="loginOptionDiv" align="left" class="form-group-sm bg-success" style="padding: 7px 5px; margin-bottom: 7px;">
                    <span> Login Option&nbsp;&nbsp;&nbsp;&nbsp;</span>
                    <asp:RadioButtonList ID="rbnloginOption" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="0">&nbsp;&nbsp;User ID&nbsp;&nbsp;</asp:ListItem>
                        <asp:ListItem Value="1">&nbsp;&nbsp;User Email&nbsp;&nbsp;</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="form-horizontal" id="formEmail">
                    <div class="form-group">
                        <div class="col-sm-12">
                            <input type="email" required="required" class="form-control" id="txtEmail" placeholder="Email">
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-12">
                            <input type="password" required="required" class="form-control" id="txtPassword" placeholder="Password">
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-12" align="center">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox">
                                    Remember me
                                </label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-12">
                            <%--<asp:Button runat="server" ID="loginBtn" Text="Log in" class="btn btn-primary btn-sm" />--%>
                            <button type="submit" class="btn btn-primary btn-sm" id="loginBtn">Log in</button>
                        </div>
                    </div>
                </div>
                 <div class="form-horizontal" id="formId">
                    <div class="form-group">
                        <div class="col-sm-12">
                            <input type="text" required="required" class="form-control" id="txtUserID" placeholder="User ID">
                        </div>
                    </div>
                     <div class="form-group">
                        <div class="col-sm-12">
                            <input type="text" disabled="disabled" class="form-control" id="txtUserName" placeholder="User Name">
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-12">
                            <input type="password" required="required" class="form-control" id="txtPasswordID" placeholder="Password">
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-12" align="center">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox">
                                    Remember me
                                </label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-12">
                            <button type="submit" class="btn btn-primary btn-sm" id="loginBtnID">Log in</button>
                        </div>
                    </div>
                </div>
                
                <div class="form-horizontal">
                    <a class="btn-link pull-left" href="ForgortPassword.aspx">Forgot Password!</a>
                    <a class="btn-link pull-right" href="Register.aspx">New User Register!</a>
                </div>

            </div>
        </div>
    </div>


    <!-- Modal start -->
    <div class="modal fade" id="pleaseWaitDialog" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <span style="font-family: 'century-gothic'; font-size: 20pt; font-weight: bold;">Processing login...</span>
                </div>
                <div class="modal-body">
                    <span id="returnMsg"></span>
                    <div class="progress">
                        <div class="progress-bar progress-bar-success progress-bar-striped active" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%">
                            <%--<span class="sr-only">40% Complete (success)</span>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal ends -->
</asp:Content>
