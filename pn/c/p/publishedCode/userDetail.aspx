<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userDetail.aspx.cs" Inherits="Portal.userDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- page content -->
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3>User Detail</h3>
                </div>
            </div>
            <div class="clearfix"></div>

            <div class="row">

                <div class="col-md-12 col-xs-12">
                    <div class="x_panel">
                        <div class="x_content">
                            <div class="form-horizontal form-label-left">

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Full Name</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_fullname" type="text" class="form-control" placeholder="Enter full name" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Email</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_email" type="text" class="form-control" placeholder="Enter email address" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Password</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_password" type="text" class="form-control" placeholder="Enter password" />
                                    </div>
                                </div>

                                <%--<div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Bithday</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_birthday" disabled="disabled" type="text" class="form-control" placeholder="Enter birthday format (mm/dd/yyyy)" />
                                    </div>
                                </div>--%>

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Number</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_number" type="text" class="form-control" placeholder="+923162984629" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-3 col-sm-3 col-xs-12 control-label">User Approve</label>

                                    <div class="col-md-6 col-sm-9 col-xs-12">

                                        <div class="radio">
                                            <label>
                                                <input runat="server" id="userApproved" type="radio" name="userApproved" />
                                                Approved
                                            </label>
                                            <label>
                                                <input runat="server" id="userNotApproved" type="radio" name="userApproved" />
                                                Not Approved
                                            </label>
                                        </div>

                                    </div>
                                </div>

                               <%-- <div class="form-group">
                                    <label class="col-md-3 col-sm-3 col-xs-12 control-label">Fast Track Is Auto</label>

                                    <div class="col-md-6 col-sm-9 col-xs-12">

                                        <div class="radio">
                                            <label>
                                                <input runat="server" id="fastTrackIsAutoActive" type="radio" class="flat" name="fastTrackIsAuto" />
                                                Active
                                            </label>
                                            <label>
                                                <input runat="server" id="fastTrackIsAutoNotActive" type="radio" class="flat" name="fastTrackIsAuto" />
                                                In Active
                                            </label>
                                        </div>

                                    </div>
                                </div>--%>

                                <div class="ln_solid"></div>
                                <div class="form-group">
                                    <div class="col-md-6 col-sm-9 col-xs-12 col-md-offset-4">
                                        <%--<button type="button" class="btn btn-primary">Cancel</button>--%>
                                        <a href="users.aspx" class="btn btn-primary">Cancel</a>
                                        <%--<asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary" onclick="resetUser_Profile">Reset</asp:LinkButton>--%>
                                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success" onclick="saveUser_Profile">Save</asp:LinkButton>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>
    </div>
    <!-- /page content -->

</asp:Content>
