<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userProfile.aspx.cs" Inherits="Portal.userProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- page content -->
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3>User Profile</h3>
                </div>

            </div>

            <div class="clearfix"></div>

            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2>User Report <small>Activity report</small></h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <div class="col-md-3 col-sm-3 col-xs-12 profile_left">
                                <div class="profile_img">
                                    <div id="crop-avatar">
                                        <!-- Current avatar -->
                                        <img runat="server" id="profile_pic" class="img-responsive avatar-view" src="images/picture.jpg" alt="Avatar" />
                                    </div>
                                </div>
                                <h3 runat="server" id="lbl_fullname">Samuel Doe</h3>
                                <ul class="list-unstyled user_data">
                                    <li><i class="fa fa-map-marker user-profile-icon"></i>&nbsp;&nbsp;<span runat="server" id="lbl_email">San Francisco, California, USA</span></li>
                                    <li><i class="fa fa-phone user-profile-icon"></i>&nbsp;&nbsp;<span runat="server" id="lbl_number">San Francisco, California, USA</span></li>
                                    <li><i class="fa fa-language user-profile-icon"></i>&nbsp;&nbsp;<span runat="server" id="lbl_language">San Francisco, California, USA</span></li>
                                    <li><i class="fa fa-user user-profile-icon"></i>&nbsp;&nbsp;<span runat="server" id="lbl_gender">San Francisco, California, USA</span></li>
                                    <li><i class="fa fa-info user-profile-icon"></i>&nbsp;&nbsp;<span runat="server" id="lbl_status">San Francisco, California, USA</span></li>
                                    <li><i class="fa fa-check user-profile-icon"></i>&nbsp;&nbsp;<span runat="server" id="lbl_approved">San Francisco, California, USA</span></li>
                                    <li><i class="fa fa-birthday-cake user-profile-icon"></i>&nbsp;&nbsp;<span runat="server" id="lbl_birthday">San Francisco, California, USA</span></li>
                                    <li><i class="fa fa-credit-card user-profile-icon"></i>&nbsp;&nbsp;<span runat="server" id="lbl_receive_email">San Francisco, California, USA</span></li>
                                    <li><i class="fa fa-money user-profile-icon"></i>&nbsp;&nbsp;<span runat="server" id="lbl_fastTrackIsAuto">San Francisco, California, USA</span></li>
                                </ul>

                                <asp:LinkButton class="btn btn-success" ID="LinkBtn_editProfile" runat="server"><i class="fa fa-edit m-right-xs"></i>Edit Profile</asp:LinkButton>
                                <br />

                                <!-- start skills -->
                                <h4 style="display:none;">Skills</h4>
                                <ul style="display:none;" class="list-unstyled user_data">
                                    <li>
                                        <p>Web Applications</p>
                                        <div class="progress progress_sm">
                                            <div class="progress-bar bg-green" role="progressbar" data-transitiongoal="50"></div>
                                        </div>
                                    </li>
                                    <li>
                                        <p>Website Design</p>
                                        <div class="progress progress_sm">
                                            <div class="progress-bar bg-green" role="progressbar" data-transitiongoal="70"></div>
                                        </div>
                                    </li>
                                    <li>
                                        <p>Automation & Testing</p>
                                        <div class="progress progress_sm">
                                            <div class="progress-bar bg-green" role="progressbar" data-transitiongoal="30"></div>
                                        </div>
                                    </li>
                                    <li>
                                        <p>UI / UX</p>
                                        <div class="progress progress_sm">
                                            <div class="progress-bar bg-green" role="progressbar" data-transitiongoal="50"></div>
                                        </div>
                                    </li>
                                </ul>
                                <!-- end of skills -->

                            </div>
                            <div class="col-md-9 col-sm-9 col-xs-12">

                                <div class="profile_title" style="display:none;">
                                    <div class="col-md-6">
                                        <h2>User Activity Report</h2>
                                    </div>
                                    <div class="col-md-6">
                                        <div id="reportrange" class="pull-right" style="margin-top: 5px; background: #fff; cursor: pointer; padding: 5px 10px; border: 1px solid #E6E9ED">
                                            <i class="glyphicon glyphicon-calendar fa fa-calendar"></i>
                                            <span>December 30, 2014 - January 28, 2015</span> <b class="caret"></b>
                                        </div>
                                    </div>
                                </div>
                                <!-- start of user-activity-graph -->
                                <div id="graph_bar" style="display :none;width: 100%; height: 280px;"></div>
                                <!-- end of user-activity-graph -->

                                <div class="" role="tabpanel" data-example-id="togglable-tabs">
                                    <ul id="myTab" class="nav nav-tabs bar_tabs" role="tablist">
                                        <li role="presentation" class="active"><a href="#tab_content1" id="home-tab" role="tab" data-toggle="tab" aria-expanded="true">Offered Rides</a>
                                        </li>
                                        <li role="presentation" class=""><a href="#tab_content2" role="tab" id="profile-tab" data-toggle="tab" aria-expanded="false">Taken Rides</a>
                                        </li>
                                        <li role="presentation" class=""><a href="#tab_content3" role="tab" id="profile-tab2" data-toggle="tab" aria-expanded="false">Transaction</a>
                                        </li>
                                    </ul>
                                    <div id="myTabContent" class="tab-content">
                                        <div role="tabpanel" class="tab-pane fade active in" id="tab_content1" aria-labelledby="home-tab">

                                            <ul class="messages">
                                                <asp:ListView ID="Offers_ListView" runat="server">
                                                    <ItemTemplate>
                                                        <li>
                                                            <img src="<%# Eval("picture") %>" class="avatar" alt="Avatar">
                                                            <div class="message_date">
                                                                <%-- <h3 class="date text-info">24</h3>--%>
                                                                <p class="month" style="width: 83px;"><%# String.Format("{0:f}", Eval("datetime")) %></p>
                                                            </div>
                                                            <div class="message_wrapper">
                                                                <%--<h4 class="heading">Desmond Davison</h4>--%>
                                                                <h5 class="heading"><b>From : </b><%# Eval("from_place") %> - <b>To :</b> <%# Eval("to_place") %></h5>
                                                                <h5 class="heading"><b>Seats : </b><%# Eval("no_seats") %> - <b>Charter : </b><%# Eval("charter") %> - <b>Price per seat : </b><%# Eval("price") %></h5>
                                                                <h5 class="heading"><b>Status : </b><%# Eval("status") %> - <b>Offer Status : </b><%# Eval("statusType") %></h5>
                                                                <h5 class="heading"><b>Brand : </b><%# Eval("brand") %> - <b>Color : </b><%# Eval("color") %></h5>
                                                                <h5 class="heading"><b>Model : </b><%# Eval("model") %> - <b>Insurance # : </b><%# Eval("insuranceNumber") %></h5>
                                                                <h5 class="heading"><b>Plate # : </b><%# Eval("plateNumber") %> - <b>Vehicle Type : </b><%# Eval("vehicleType") %></h5>
                                                                <blockquote class="message"><%# Eval("ride_comment") %></blockquote>
                                                                <br />
                                                            </div>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                            </ul>

                                        </div>
                                        <div role="tabpanel" class="tab-pane fade" id="tab_content2" aria-labelledby="profile-tab">

                                            <ul class="messages">
                                                <asp:ListView ID="TakenRides_ListView" runat="server">
                                                    <ItemTemplate>
                                                        <li>
                                                            <img src="<%# Eval("picture") %>" class="avatar" alt="Avatar">
                                                            <div class="message_date">
                                                                <p class="month" style="width: 83px;"><%# String.Format("{0:f}", Eval("datetime")) %></p>
                                                            </div>
                                                            <div class="message_wrapper">
                                                                <h4 class="heading"><%# Eval("full_name") %></h4>
                                                                <h5 class="heading"><b>From : </b><%# Eval("from_place") %> - <b>To :</b> <%# Eval("to_place") %></h5>
                                                                <h5 class="heading"><b>Price : </b><%# Eval("price") %> - <b>Ride Status : </b><%# Eval("rideStatus") %></h5>
                                                                <h5 class="heading"><b>Brand : </b><%# Eval("brand") %> - <b>Color : </b><%# Eval("color") %></h5>
                                                                <h5 class="heading"><b>Plate # : </b><%# Eval("plateNumber") %> - <b>Vehicle Type : </b><%# Eval("vehicleType") %> - <b>Ride Type : </b><%# Eval("rideType") %></h5>
                                                                <br />
                                                            </div>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                            </ul>

                                        </div>
                                        <div role="tabpanel" class="tab-pane fade" id="tab_content3" aria-labelledby="profile-tab">
                                            <table class="data table table-striped no-margin">
                                                <thead>
                                                    <tr>
                                                        <th>#</th>
                                                        <th>Title</th>
                                                        <th>Datetime</th>
                                                        <th>Debit</th>
                                                        <th>Credit</th>
                                                        <th>Balance</th>
                                                        <th>Recharged By</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:ListView ID="Transaction_ListView" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td><%# Eval("transaction_ID") %></td>
                                                                <td><%# Eval("transaction_Title") %></td>
                                                                <td><%# Eval("transaction_datetime") %></td>
                                                                <td><%# Eval("Debit") %></td>
                                                                <td><%# Eval("Credit") %></td>
                                                                <td><%# Eval("Balance") %></td>
                                                                <td><%# Eval("rechargedBy") %></td>
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
                </div>
            </div>
        </div>
    </div>
    <!-- /page content -->

</asp:Content>
