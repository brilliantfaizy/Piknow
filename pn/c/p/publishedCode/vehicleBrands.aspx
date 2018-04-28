<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="vehicleBrands.aspx.cs" Inherits="Portal.vehicleBrands" %>

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
                            <h2>Vehicles Brand</h2>
                            <ul class="nav navbar-right">
                                <li>
                                    <a class="btn btn-primary" href='./vehicleBrandAdd.aspx'>Add New</a>
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
                                            <th>Brand</th>
                                            <th>Model</th>
                                            <th>Created At</th>
                                            <th>Updated At</th>
                                            <th style="width:15%;">#Edit</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:ListView runat="server" ID="Brand_ListView">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Eval("brand_id") %></td>
                                                    <td><%# Eval("brand") %></td>
                                                    <td><%# Eval("model") %></td>
                                                    <td><%# Eval("createdAt") %></td>
                                                    <td><%# Eval("updatedAt") %></td>
                                                    <td>
                                                        <a class="btn btn-info btn-xs" href='./vehicleBrandDetails.aspx?brand_id=<%# Eval("brand_id") %>'><i class="fa fa-pencil"></i>Edit</a>
                                                        <asp:LinkButton class="btn btn-danger btn-xs" runat="server" Text="" CommandName='<%# Eval("brand_id") %>' OnClick="Delete_Click"><i class="fa fa-trash-o"></i>Delete</asp:LinkButton>
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
