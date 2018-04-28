<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Companies.aspx.cs" Inherits="Portal.Companies" %>

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
                        <h2>All Companies</h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">

                        <table id="datatable" class="table table-striped table-bordered">
                            <thead>
                                <tr>
                                    <th>Company Name</th>
                                    <th>Email</th>
                                    <th>Phone Number</th>
                                    <th>Come From</th>
                                    <th>Is Confirmed</th>
                                    <th>Created At</th>
                                    <th>#View</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView ID="Companies_ListView" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("company_name") %></td>
                                            <td><%# Eval("email") %></td>
                                            <td><%# Eval("phoneNumber") %></td>
                                            <td><%# Eval("comeFrom") %></td>
                                            <td><%# Eval("isConfirmed") %></td>
                                            <td><%# Eval("createdAt") %></td>
                                            <%--<td><a class="btn btn-info btn-xs" href='./CompanyDetail.aspx?company_id=<%# Eval("company_id") %>'><i class="fa fa-pencil"></i>Edit</a></td>--%>
                                            <td><a class="btn btn-info btn-xs" href='./TotalAmount.aspx?company_id=<%# Eval("company_id") %>'><i class="fa fa-eye"></i>View</a></td>
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
