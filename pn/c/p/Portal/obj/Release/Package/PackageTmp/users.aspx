<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="users.aspx.cs" Inherits="Portal.users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .myImg {
            border-radius: 5px;
            cursor: pointer;
            transition: 0.3s;
        }

            .myImg:hover {
                opacity: 0.7;
            }

        /* The Modal (background) */
        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.9); /* Black w/ opacity */
        }

        /* Modal Content (image) */
        .modal-content {
            margin: auto;
            display: block;
            width: 80%;
            max-width: 700px;
        }

        /* Caption of Modal Image */
        #caption {
            margin: auto;
            display: block;
            width: 80%;
            max-width: 700px;
            text-align: center;
            color: #ccc;
            padding: 10px 0;
            height: 150px;
        }

        /* Add Animation */
        .modal-content, #caption {
            -webkit-animation-name: zoom;
            -webkit-animation-duration: 0.6s;
            animation-name: zoom;
            animation-duration: 0.6s;
        }

        @-webkit-keyframes zoom {
            from {
                -webkit-transform: scale(0);
            }

            to {
                -webkit-transform: scale(1);
            }
        }

        @keyframes zoom {
            from {
                transform: scale(0);
            }

            to {
                transform: scale(1);
            }
        }

        /* The Close Button */
        .close {
            position: absolute;
            top: 15px;
            right: 35px;
            color: #f1f1f1;
            font-size: 40px;
            font-weight: bold;
            transition: 0.3s;
        }

            .close:hover,
            .close:focus {
                color: #bbb;
                text-decoration: none;
                cursor: pointer;
            }

        /* 100% Image Width on Smaller Screens */
        @media only screen and (max-width: 700px) {
            .modal-content {
                width: 100%;
            }
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- page content -->
    <div class="right_col" role="main">
        <div class="row">

            <div class="clearfix"></div>

            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>All Users</h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <table id="datatable" class="table table-striped table-bordered">
                            <thead>
                                <tr>
                                    <th>User Id</th>
                                    <th>Full Name</th>
                                    <th>Email Address</th>
                                    <th>Number</th>
                                    <th>Gender</th>
                                    <th>Approved</th>
                                    <th>User Photo</th>
                                    <th>CNIC Front</th>
                                    <th>CNIC Back</th>
                                    <th>Created At</th>
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
                                            <td><%# Eval("gender") %></td>
                                            <td><%# getApproved(Eval("approved").ToString()) %></td>
                                            <td>
                                                <img src='<%# Eval("profile_pic") %>' height="100" class="myImg" onerror="this.style.display='none'" /></td>
                                            <td>
                                                <img src='<%# Eval("cnic_frant") %>' height="100" class="myImg" onerror="this.style.display='none'" /></td>
                                            <td>
                                                <img src='<%# Eval("cnic_back") %>' height="100" class="myImg" onerror="this.style.display='none'" /></td>
                                            <td><%# Eval("createdAt") %></td>
                                            <td>
                                                <%-- <asp:LinkButton runat="server" Text="View" CommandName='<%# Eval("user_id") %>' OnClick="Unnamed_Click"></asp:LinkButton>--%>
                                                <a target="_blank" href='./userDetail.aspx?user_id=<%# Eval("user_id") %>' class="btn btn-primary btn-xs"><i class="fa fa-folder"></i>View </a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>

        <!-- The Modal -->
        <div class="modal" id="myModal">
            <span class="close">&times;</span>
            <img class="modal-content" id="img01" src="" />
        </div>

    </div>
    <!-- /page content -->

    <script type="text/javascript">
        // Get the modal
        var modal = document.getElementById('myModal');

        // Get the image and insert it inside the modal - use its "alt" text as a caption
        var img = document.getElementsByClassName('myImg');
        var modalImg = document.getElementById("img01");

        for (var i = 0; i < img.length; i++) {
            img[i].onclick = function () {
                modal.style.display = "block";
                modalImg.src = this.src;
            }
        }

        // Get the <span> element that closes the modal
        var span = document.getElementsByClassName("close")[0];

        // When the user clicks on <span> (x), close the modal
        span.onclick = function () {
            modal.style.display = "none";
        }
    </script>

</asp:Content>
