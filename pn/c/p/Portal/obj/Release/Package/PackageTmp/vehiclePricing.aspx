<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="vehiclePricing.aspx.cs" Inherits="Portal.vehiclePricing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- page content -->
    <div class="right_col" role="main">
        <div class="">
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2>Vehicles Pricing</h2>
                            <ul class="nav navbar-right">
                                <li>
                                    <a class="btn btn-primary" href='./vehiclePriceAdd.aspx'>Add New</a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <!-- start project list -->
                                <table id="datatable" class="table table-striped table-bordered">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Charges</th>
                                            <th>Vehicle Type</th>
                                            <th>Luxury/Economy</th>
                                            <th>Created At</th>
                                            <th>Updated At</th>
                                            <th style="width:15%;">#Edit</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:ListView runat="server" ID="Vehicles_ListView">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Eval("chargesID") %></td>
                                                    <td><%# Eval("charges") %></td>
                                                    <td><%# Eval("type") %></td>
                                                    <td><%# Eval("VehicleTypeIsNormal") %></td>
                                                    <td><%# Eval("createdAt") %></td>
                                                    <td><%# Eval("updatedAt") %></td>
                                                    <td>
                                                        <a class="btn btn-info btn-xs" href='./vehiclePriceDetails.aspx?chargesID=<%# Eval("chargesID") %>'><i class="fa fa-pencil"></i>Edit</a>
                                                        <asp:LinkButton class="btn btn-danger btn-xs" runat="server" Text="" CommandName='<%# Eval("chargesID") %>' OnClick="Delete_Click"><i class="fa fa-trash-o"></i>Delete</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:ListView>
                                    </tbody>
                                </table>
                            <!-- end project list -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /page content -->

</asp:Content>
