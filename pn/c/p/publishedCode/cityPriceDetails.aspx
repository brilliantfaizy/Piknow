<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cityPriceDetails.aspx.cs" Inherits="Portal.cityPriceDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- page content -->
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3>City Price Detail</h3>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-xs-12">
                    <div class="x_panel">
                        <div class="x_content">
                            <div class="form-horizontal form-label-left">

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">From City Name</label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:DropDownList class="form-control" ID="fromCity_dropDown" runat="server">
                                        <asp:ListItem Value="1">abc</asp:ListItem>
                                    </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">To City Name</label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:DropDownList class="form-control" ID="toCity_dropDown" runat="server">
                                        <asp:ListItem Value="1">abc</asp:ListItem>
                                    </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Charges</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_charges" type="text" class="form-control" placeholder="Enter charges" />
                                    </div>
                                </div>

                                <div class="form-group">
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
                                </div>

                                <div class="form-group">
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
                                </div>

                                <div class="ln_solid"></div>
                                <div class="form-group">
                                    <div class="col-md-6 col-sm-9 col-xs-12 col-md-offset-4">
                                        <a href="CitiesPricing.aspx" class="btn btn-primary">Cancel</a>
                                        <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary" OnClick="reset_Click">Reset</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success" OnClick="save_Click">Save</asp:LinkButton>
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
