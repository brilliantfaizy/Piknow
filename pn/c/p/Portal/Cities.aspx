<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cities.aspx.cs" Inherits="Portal.Cities" %>
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
                    <h2>Cities</h2>
                      <ul class="nav navbar-right">
                      <li>
                          <a class="btn btn-primary" href='./cityAdd.aspx'>Add New</a>
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
                          <th style="width: 20%">City Name</th>
                          <th>Created At</th>
                          <th>Updated At</th>
                          <th style="width: 20%">#Edit</th>
                        </tr>
                      </thead>
                      <tbody>
                          <asp:ListView runat="server" ID="Cities_ListView">
                              <ItemTemplate>
                                  <tr>
                                      <td><%# Eval("cityID") %></td>
                                        <td><%# Eval("cityName") %></td>
                                        <td><%# Eval("createdAt") %></td>
                                        <td><%# Eval("updatedAt") %></td>
                                      <td>
                                        <a class="btn btn-info btn-xs" href='./cityDetails.aspx?cityID=<%# Eval("cityID") %>'><i class="fa fa-pencil"></i>Edit</a>
                                         <asp:LinkButton class="btn btn-danger btn-xs" runat="server" Text="" CommandName='<%# Eval("cityID") %>' OnClick="Delete_Click"><i class="fa fa-trash-o"></i>Delete</asp:LinkButton>
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
