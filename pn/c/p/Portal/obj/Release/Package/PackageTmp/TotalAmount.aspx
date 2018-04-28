<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TotalAmount.aspx.cs" Inherits="Portal.TotalAmount" %>

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
                            <h2><asp:Label ID="lbl_companyName1" runat="server"></asp:Label> <small>Company Transactions Details</small></h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">

                            <section class="content invoice">
                                <!-- title row -->
                                <div class="row">
                                    <div class="col-xs-12 invoice-header">
                                        <h1>
                                            <i class="fa fa-globe"></i><asp:Label ID="lbl_companyName2" runat="server"></asp:Label>
                                            <small class="pull-right">Created Date: <asp:Label ID="lbl_date" runat="server"></asp:Label></small>
                                        </h1>
                                    </div>
                                    <!-- /.col -->
                                </div>
                                <!-- info row -->
                                <div class="row invoice-info">

                                    <div class="col-sm-6 invoice-col">
                                        <address>
                                            Come From: <asp:Label ID="lbl_comeFrom" runat="server"></asp:Label>
                                            <br />
                                            Phone: <asp:Label ID="lbl_phone" runat="server"></asp:Label>
                                            <br />
                                            Email: <asp:Label ID="lbl_email" runat="server"></asp:Label>
                                        </address>
                                    </div>

                                    <div class="col-sm-6 invoice-col">
                                        
                                        <div class="col-sm-4">
                                            <asp:HyperLink Target="_blank" ToolTip="CEO ID" runat="server" ID="lbtn_CEO_ID">
                                              <asp:Image Width="150" ID="img_CEO_ID" runat="server" />
                                            </asp:HyperLink>
                                        </div>

                                        <div class="col-sm-4">
                                            <asp:HyperLink Target="_blank" ToolTip="Permissions" runat="server" ID="lbtn_Permissions">
                                                <asp:Image Width="150" ID="img_Permissions" runat="server" />
                                            </asp:HyperLink>
                                        </div>

                                        <div class="col-sm-4">
                                            <asp:HyperLink Target="_blank" runat="server" ToolTip="Company Certificate" ID="lbtn_CompanyCertificate">
                                                <asp:Image Width="150" ID="img_CompanyCertificate" runat="server" />
                                            </asp:HyperLink>
                                        </div>

                                    </div>
                                    <!-- /.col -->
                                </div>
                                <!-- /.row -->

                                <!-- Table row -->
                                <div class="row">
                                    <div class="col-xs-12 table">
                                        <table class="table table-striped">
                                            <thead>
                                                <tr>
                                                    <th>User ID</th>
                                                    <th>Full Name</th>
                                                    <th>Email Address</th>
                                                    <th>Number</th>
                                                    <th>Language</th>
                                                    <th>Gender</th>
                                                    <th>Approved</th>
                                                    <th>Amount</th>
                                                    <th>#View</th>
                                                </tr>
                                            </thead>
                                                        <tbody>
                                            <asp:ListView ID="User_ListView" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%# Eval("user_id") %></td>
                                                        <td><%# Eval("full_name") %></td>
                                                        <td><%# Eval("email") %></td>
                                                        <td><%# Eval("number") %></td>
                                                        <td><%# Eval("language") %></td>
                                                        <td><%# Eval("gender") %></td>
                                                        <td><%# Eval("approved").ToString() %></td>
                                                        <td><%# Eval("Amount") %></td>
                                                        <td>
                                                            <%-- <asp:LinkButton runat="server" Text="View" CommandName='<%# Eval("user_id") %>' OnClick="Unnamed_Click"></asp:LinkButton>--%>
                                                            <a href='./userProfile.aspx?user_id=<%# Eval("user_id") %>' class="btn btn-primary btn-xs"><i class="fa fa-folder"></i>View </a>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:ListView>
                                        </tbody>
                                                    </table>
                                                </div>
                                                <!-- /.col -->
                                            </div>
                                            <!-- /.row -->

                         <div class="row">
                       
                        <!-- /.col -->
                        <div class="col-xs-6">
                          <p class="lead">Companies Total Amount</p>
                          <div class="table-responsive">
                            <table class="table">
                              <tbody>
                                <tr>
                                  <th>Total:</th>
                                  <td><asp:Label runat="server" ID="lbl_companiesTotal"></asp:Label></td>
                                </tr>
                              </tbody>
                            </table>
                          </div>
                        </div>
                        <!-- /.col -->
                      </div>
                      <!-- /.row -->

                                            <!-- this row will not appear when printing -->
                                            <div class="row no-print" style="display: none;">
                                                <div class="col-xs-12">
                                                    <button class="btn btn-default" onclick="window.print();"><i class="fa fa-print"></i>Print</button>
                                                    <button class="btn btn-success pull-right"><i class="fa fa-credit-card"></i>Submit Payment</button>
                                                    <button class="btn btn-primary pull-right" style="margin-right: 5px;"><i class="fa fa-download"></i>Generate PDF</button>
                                    </div>
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /page content -->
</asp:Content>
