<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Portal._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <!-- page content -->
        <div class="right_col" role="main">
          <!-- top tiles -->
          <div class="row tile_count">
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-user"></i> Total Users</span>
              <div class="count"><asp:Label class="count" ID="lbl_totalUsers" runat="server"></asp:Label></div>
              <span class="count_bottom"><i class="green"><i class="fa fa-sort-asc"></i>0% </i> From last Week</span>
            </div>

            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-map"></i> Successful Trips</span>
              <div class="count"><asp:Label class="count" ID="lbl_successfulTrips" runat="server"></asp:Label></div>
              <span class="count_bottom"><i class="green"><i class="fa fa-sort-asc"></i>0% </i> From last Week</span>
            </div>

              <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-map"></i> Pending Trips</span>
              <div class="count"><asp:Label class="count" ID="lbl_pendingTrips" runat="server"></asp:Label></div>
              <span class="count_bottom"><i class="green"><i class="fa fa-sort-asc"></i>0% </i> From last Week</span>
            </div>

              <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-map"></i> Canceled Trips</span>
              <div class="count"><asp:Label class="count" ID="lbl_canceledTrips" runat="server"></asp:Label></div>
              <span class="count_bottom"><i class="red"><i class="fa fa-sort-desc"></i>0% </i> From last Week</span>
            </div>

              <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-user"></i> Company Users</span>
              <div class="count"><asp:Label class="count" ID="lbl_companyUsers" runat="server"></asp:Label></div>
              <span class="count_bottom"><i class="green"><i class="fa fa-sort-asc"></i>0% </i> From last Week</span>
            </div>

              <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-user"></i> Government Users</span>
              <div class="count"><asp:Label class="count" ID="lbl_governmentUsers" runat="server"></asp:Label></div>
              <span class="count_bottom"><i class="green"><i class="fa fa-sort-asc"></i>0% </i> From last Week</span>
            </div>

          </div>
          <!-- /top tiles -->
        </div>
        <!-- /page content -->

</asp:Content>
