<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cityAdd.aspx.cs" Inherits="Portal.cityAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- page content -->
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3>Add New</h3>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-xs-12">
                    <div class="x_panel">
                        <div class="x_content">
                            <div class="form-horizontal form-label-left">

                                <div class="form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">City Name</label>
                                    <div class="col-md-6 col-sm-9 col-xs-12">
                                        <input runat="server" id="txt_cityName" type="text" class="form-control" placeholder="Enter city name" />
                                    </div>
                                </div>

                                <div class="ln_solid"></div>
                                <div class="form-group">
                                    <div class="col-md-6 col-sm-9 col-xs-12 col-md-offset-5">
                                        <a href="Cities.aspx" class="btn btn-primary">Cancel</a>
                                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success" onclick="addCity_Click">Add</asp:LinkButton>
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
