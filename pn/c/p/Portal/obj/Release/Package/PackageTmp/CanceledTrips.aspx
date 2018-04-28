<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="CanceledTrips.aspx.cs" Inherits="Portal.CanceledTrips" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- page content -->
    <div class="right_col" role="main">
        <div class="row">

            <div class="clearfix"></div>

            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Canceled Trips</h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <table id="datatable" class="table table-striped table-bordered">
                            <thead>
                                <tr>
                                    <th>Ride Id</th>
                                    <th>Full Name</th>
                                    <th>Email Address</th>
                                    <th>Number</th>
                                    <th>From Place</th>
                                    <th>To Place</th>
                                    <th>Ride Type</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView ID="User_ListView" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("rideID") %></td>
                                            <td><%# Eval("full_name") %></td>
                                            <td><%# Eval("email") %></td>
                                            <td><%# Eval("number") %></td>
                                            <td><%# Eval("from_place") %></td>
                                            <td><%# Eval("to_place") %></td>
                                            <td><%# Eval("rideType") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /page content -->

</asp:Content>
