<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="companyDetail.aspx.cs" Inherits="Portal.companyDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- page content -->
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3>Company Detail</h3>
                </div>
            </div>
            <div class="clearfix"></div>

            <div class="row">

                <div class="col-md-12 col-xs-12">
                    <div class="x_panel">
                        <div class="x_content">
                            <div class="form-horizontal form-label-left">

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Company Name</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_company_name" type="text" class="form-control" placeholder="Enter company name" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Email</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_email" readonly="true" type="text" class="form-control" placeholder="Enter email" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Phone Number</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_phoneNumber" type="text" class="form-control" placeholder="Enter phone number" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Password</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_password" type="text" class="form-control" placeholder="Enter password" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Come From</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_comeFrom" readonly="true" type="text" class="form-control" placeholder="Enter come from" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">CEO ID</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <a target="_blank" id="img_ceoID_link" href="" runat="server">
                                        <img runat="server" width="50" id="img_ceoID_path" src="" class="img-responsive avatar-view" alt="Avatar" />
                                        </a>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Permissions</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <a target="_blank" id="img_permissions_link" href="" runat="server">
                                        <img runat="server" width="50" id="img_permissions_path" src="" class="img-responsive avatar-view" alt="Avatar" />
                                            </a>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Company Certificate</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <a target="_blank" id="img_companyCertificate_link" href="" runat="server">
                                        <img runat="server" width="50" id="img_companyCertificate_path" src="" class="img-responsive avatar-view" alt="Avatar" />
                                            </a>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-3 col-sm-3 col-xs-12 control-label">Company Confirm</label>

                                    <div class="col-md-6 col-sm-9 col-xs-12">

                                        <div class="radio">
                                            <label>
                                                <input runat="server" id="companyConfirm" type="radio" class="flat" name="companyConfirm" />
                                                Confirm
                                            </label>
                                            <label>
                                                <input runat="server" id="companyNotConfirm" type="radio" class="flat" name="companyConfirm" />
                                                Not Confirm
                                            </label>
                                        </div>
                                    </div>
                                </div>

                                <div class="ln_solid"></div>
                                <div class="form-group">
                                    <div class="col-md-6 col-sm-9 col-xs-12 col-md-offset-4">
                                        <a href="Companies.aspx" class="btn btn-primary">Cancel</a>
                                        <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-success" OnClick="reset_Data">Reset</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success" OnClick="save_Data">Save</asp:LinkButton>
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
