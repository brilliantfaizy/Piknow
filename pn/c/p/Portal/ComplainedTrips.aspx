<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ComplainedTrips.aspx.cs" Inherits="Portal.ComplainedTrips" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- page content -->
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3>Users Complaint</h3>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12">
                    <div class="x_panel">
                        <div class="x_content">
                            <div class="row">
                                <div class="clearfix"></div>

                                <asp:ListView ID="Complaint_ListView" runat="server">
                                    <ItemTemplate>

                                        <div class="col-md-4 col-sm-4 col-xs-12 profile_details">
                                            <div class="well profile_view">
                                                <div class="col-sm-12">
                                                    <h6 class="brief"><i><b>Complaint # <%# Eval("complaint_id") %></b></i> <i style="float:right;"><%# Eval("datetime") %></i></h6>
                                                    <div class="left col-xs-7">
                                                        <h2><%# Eval("full_name") %></h2>
                                                        <ul class="list-unstyled">
                                                            <li><i class="fa fa-user"></i> <%# Eval("tripAs") %></li>
                                                            <li><i class="fa fa-phone"></i> <%# Eval("number") %></li>
                                                            <li><i class="fa fa-building"></i> <%# Eval("from_place") %></li>
                                                            <li><i class="fa fa-building"></i> <%# Eval("to_place") %></li>
                                                        </ul>
                                                    </div>
                                                    <div class="right col-xs-5 text-center">
                                                        <img src="<%# Eval("profile_pic") %>" alt="" class="img-circle img-responsive">
                                                    </div>
                                                </div>
                                                <div class="col-xs-12 bottom text-center">
                                                    <div class="col-xs-12 col-sm-6 emphasis">
                                                        <p class="ratings">
                                                            <a><%# Eval("rating") %></a>

                                                            <%# myRating(Eval("rating").ToString()) %>
                                                           
                                                        </p>
                                                    </div>
                                                    <div class="col-xs-12 col-sm-6 emphasis">
                                                        <button type="button" title="<%# Eval("message") %>" class="btn btn-success btn-xs">
                                                            <i class="fa fa-user"></i><i class="fa fa-comments-o"></i>
                                                        </button>
                                                        <a class="btn btn-primary btn-xs" href='./userProfile.aspx?user_id=<%# Eval("user_id") %>'> <i class="fa fa-user"></i>View Profile</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </ItemTemplate>

                                </asp:ListView>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /page content -->
</asp:Content>
