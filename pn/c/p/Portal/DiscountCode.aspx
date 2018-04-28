<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DiscountCode.aspx.cs" Inherits="Portal.DiscountCode" %>

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
                            <h2>Discount Codes</h2>
                            <ul class="nav navbar-right">
                                <li>
                                    <a class="btn btn-primary" href='./discountCodeAdd.aspx'>Add New</a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <!-- start project list -->
                           <table id="datatable" class="table table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th style="width: 1%">#</th>
                                        <th>Discount Fee</th>
                                        <th>Discount Code</th>
                                        <th>Available Number</th>
                                        <th>Expire Date</th>
                                        <th>Created At</th>
                                        <th>Updated At</th>
                                        <th style="width: 20%">#Edit</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:ListView runat="server" ID="DiscountCode_ListView">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("discountID") %></td>
                                                <td><%# Eval("discountFee") %></td>
                                                <td><%# Eval("discountCode") %></td>
                                                <td><%# Eval("availableNumber") %></td>
                                                <td><%# Eval("expireDate") %></td>
                                                <td><%# Eval("createdAt") %></td>
                                                <td><%# Eval("updatedAt") %></td>
                                                <td>
                                                    <a class="btn btn-info btn-xs" href='./discountDetails.aspx?discountID=<%# Eval("discountID") %>'><i class="fa fa-pencil"></i>Edit</a>
                                                    <asp:LinkButton class="btn btn-danger btn-xs" runat="server" Text="" CommandName='<%# Eval("discountID") %>' OnClick="Delete_Click"><i class="fa fa-trash-o"></i>Delete</asp:LinkButton>
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
