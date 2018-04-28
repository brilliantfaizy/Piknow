<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="generalData.aspx.cs" Inherits="Portal.generalData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- page content -->
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3>General Data</h3>
                </div>
            </div>
            <div class="clearfix"></div>

            <div class="row">

                <div class="col-md-12 col-xs-12">
                    <div class="x_panel">
                        <div class="x_content">
                            <div class="form-horizontal form-label-left">

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Percent Detect</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_percentDetect" type="text" class="form-control" placeholder="Enter amount" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Passenger Detect</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_passengerDetect" type="text" class="form-control" placeholder="Enter amount" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Fast Track Check In Amount</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_fastTrackAmount" type="text" class="form-control" placeholder="Enter amount" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">Per KM Amount</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_perKM" type="text" class="form-control" placeholder="Enter amount" />
                                    </div>
                                </div>

                                <div class="ln_solid"></div>
                                <div class="form-group">
                                    <div class="col-md-6 col-sm-9 col-xs-12 col-md-offset-4">
                                        <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary" onclick="resetGeneral_Data">Reset</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success" onclick="saveGeneral_Data">Save</asp:LinkButton>
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
