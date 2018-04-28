<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="vehicleDetail.aspx.cs" Inherits="Portal.vehicleDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- page content -->
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3>Vehicle Detail</h3>
                </div>
            </div>
            <div class="clearfix"></div>

            <div class="row">

                <div class="col-md-12 col-xs-12">
                    <div class="x_panel">
                        <div class="x_content">
                            <div class="form-horizontal form-label-left">

                                <%--<div class="form-group">
                                  <label class="control-label col-md-3 col-sm-3 col-xs-12">Vehicle Type</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <div class="radio">
                                            <label>
                                                <input runat="server" id="VehicleTypeSedan" type="radio" class="flat" name="VehicleType" />
                                                Sedan
                                            </label>
                                            <label>
                                                <input runat="server" id="VehicleTypeVan" type="radio" class="flat" name="VehicleType" />
                                                Van
                                            </label>
                                            <label>
                                                <input runat="server" id="VehicleTypeBus" type="radio" class="flat" name="VehicleType" />
                                                Bus
                                            </label>
                                        </div>
                                    </div>
                                </div>--%>

                                <%--<div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Brand</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_brand" type="text" class="form-control" placeholder="Enter vehicle brand" />
                                    </div>
                                </div>--%>

                                <%--<div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Model</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_model" type="text" class="form-control" placeholder="Enter vehicle model" />
                                    </div>
                                </div>--%>

                               <%-- <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Color</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_color" type="text" class="form-control" placeholder="Enter vehicle color" />
                                    </div>
                                </div>--%>

                                <%--<div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Insurance Number</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_insurance" type="text" class="form-control" placeholder="Enter insurance number" />
                                    </div>
                                </div>--%>

                                <%--<div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Plate Number</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_plate" type="text" class="form-control" placeholder="Enter plate number" />
                                    </div>
                                </div>--%>

                                <div class="form-group">
                                    <label class="col-md-3 col-sm-3 col-xs-12 control-label">Vehicle Approve</label>

                                    <div class="col-md-6 col-sm-9 col-xs-12">

                                        <div class="radio">
                                            <label>
                                                <input runat="server" id="vehicleApproved" type="radio" name="vehicleApproved" />
                                                Approved
                                            </label>
                                            <label>
                                                <input runat="server" id="vehicleNotApproved" type="radio" name="vehicleApproved" />
                                                Not Approved
                                            </label>
                                        </div>

                                    </div>
                                </div>

                                 <%--<div class="form-group">
                                    <label class="col-md-3 col-sm-3 col-xs-12 control-label">Select Vehicle</label>

                                    <div class="col-md-6 col-sm-9 col-xs-12">

                                        <div class="radio">
                                            <label>
                                                <input runat="server" id="VehicleTypeLuxury" type="radio" class="flat" name="VehicleTypeIsNormal" />
                                                Luxury
                                            </label>
                                            <label>
                                                <input runat="server" id="VehicleTypeEconomy" type="radio" class="flat" name="VehicleTypeIsNormal" />
                                                Economy
                                            </label>
                                        </div>

                                    </div>
                                </div>--%>

                                <div class="ln_solid"></div>
                                <div class="form-group">
                                    <div class="col-md-6 col-sm-9 col-xs-12 col-md-offset-4">
                                        <a href="vehicles.aspx" class="btn btn-primary">Cancel</a>
                                        <%--<asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-success" OnClick="resetVehicle_Data">Reset</asp:LinkButton>--%>
                                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success" OnClick="saveVehicle_Data">Save</asp:LinkButton>
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
