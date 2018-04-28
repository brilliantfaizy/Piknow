<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Transactions.aspx.cs" Inherits="Portal.Transactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- page content -->
    <div class="right_col" role="main">
        <div class="">

            <div class="clearfix"></div>

            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2>All Transactions</h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <table id="datatable-buttons" class="table table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Full Name</th>
                                        <th>User Type</th>
                                        <th>Transaction Title</th>
                                        <th>Datetime</th>
                                        <th>Received Commission</th>
                                        <th>Debit</th>
                                        <th>Credit</th>
                                        <th>Balance</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:ListView ID="Transaction_ListView" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("transaction_ID") %></td>
                                                <td><%# Eval("full_name") %></td>
                                                <td><%# Eval("type") %></td>
                                                <td><%# Eval("transaction_Title") %></td>
                                                <td><%# Eval("transaction_datetime") %></td>
                                                <td><%# Eval("receivedCommission") %></td>
                                                <td><%# Eval("Debit") %></td>
                                                <td><%# Eval("Credit") %></td>
                                                <td><%# Eval("Balance") %></td>
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
    </div>
    <!-- /page content -->

</asp:Content>
