<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyForgotPassword.aspx.cs" Inherits="Portal.CompanyForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Company Forgot Password</title>
    <link href="./css/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        #regContainer {
            margin-top: 3%;
        }

        .panel-login {
            border-color: #ccc;
            background-color: #f9f8f8;
            -webkit-box-shadow: 0px 2px 3px 0px rgba(0,0,0,0.2);
            -moz-box-shadow: 0px 2px 3px 0px rgba(0,0,0,0.2);
            box-shadow: 0px 2px 3px 0px rgba(0,0,0,0.2);
        }

            .panel-login > .panel-heading {
                text-align: center;
            }

                .panel-login > .panel-heading a {
                    text-decoration: none;
                    font-weight: bold;
                    font-size: 28px;
                    -webkit-transition: all 0.1s linear;
                    -moz-transition: all 0.1s linear;
                    transition: all 0.1s linear;
                }

                    .panel-login > .panel-heading a.active {
                        font-size: 34px;
                    }

                .panel-login > .panel-heading hr {
                    margin-top: 10px;
                    margin-bottom: 0px;
                    clear: both;
                    border: 0;
                    height: 1px;
                    background-image: -webkit-linear-gradient(left,rgba(0, 0, 0, 0),rgba(0, 0, 0, 0.15),rgba(0, 0, 0, 0));
                    background-image: -moz-linear-gradient(left,rgba(0,0,0,0),rgba(0,0,0,0.15),rgba(0,0,0,0));
                    background-image: -ms-linear-gradient(left,rgba(0,0,0,0),rgba(0,0,0,0.15),rgba(0,0,0,0));
                    background-image: -o-linear-gradient(left,rgba(0,0,0,0),rgba(0,0,0,0.15),rgba(0,0,0,0));
                }

            .panel-login input[type="text"], .panel-login input[type="email"], .panel-login input[type="password"] {
                height: 45px;
                border: 1px solid #ddd;
                font-size: 16px;
                -webkit-transition: all 0.1s linear;
                -moz-transition: all 0.1s linear;
                transition: all 0.1s linear;
            }

            .panel-login input:hover,
            .panel-login input:focus {
                outline: none;
                -webkit-box-shadow: none;
                -moz-box-shadow: none;
                box-shadow: none;
                border-color: #ccc;
            }

        .btn-login {
            background-color: #3D9DB3;
            outline: none;
            color: #fff;
            font-size: 14px;
            height: auto;
            font-weight: normal;
            padding: 14px 0;
            text-transform: uppercase;
            border-color: #2d92a9;
        }

            .btn-login:hover,
            .btn-login:focus {
                color: #fff;
                background-color: #198da8;
                border-color: #53A3CD;
            }

        .btn-register {
            background-color: #17ae47;
            outline: none;
            color: #fff;
            font-size: 14px;
            height: auto;
            font-weight: normal;
            padding: 14px 0;
            text-transform: uppercase;
            border-color: #1CB94A;
        }

            .btn-register:hover,
            .btn-register:focus {
                color: #fff;
                background-color: #1CA347;
                border-color: #1CA347;
            }

        .fullscreen_bg {
            position: fixed;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            background-size: cover;
            background-position: 50% 50%;
            background-image: url('https://jointgroup.es/wp-content/uploads/2016/11/joint-network-group.jpg');
            background-repeat: repeat;
        }

        .panel-heading a {
            font-size: 48px;
            color: rgb(6, 106, 117);
            padding: 2px 0 10px 0;
            font-family: 'FranchiseRegular','Arial Narrow',Arial,sans-serif;
            font-weight: bold;
            text-align: center;
            padding-bottom: 30px;
        }

        .panel-heading a {
            background: -webkit-repeating-linear-gradient(-45deg, rgb(18, 83, 93), rgb(18, 83, 93) 20px, rgb(64, 111, 118) 20px, rgb(64, 111, 118) 40px, rgb(18, 83, 93) 40px);
            -webkit-text-fill-color: transparent;
            -webkit-background-clip: text;
        }
    </style>
    <script type="text/javascript" src="./js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="./js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <div id="google_translate_element"></div>
        <script type="text/javascript">
            function googleTranslateElementInit() {
                new google.translate.TranslateElement({ pageLanguage: 'en', includedLanguages: 'en,fa', layout: google.translate.TranslateElement.FloatPosition.TOP_LEFT, autoDisplay: true }, 'google_translate_element');
            }
        </script>
        <!--<script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>-->

        <div id="fullscreen_bg" class="fullscreen_bg" />
        <div id="regContainer" class="container">
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <div class="panel panel-login">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-6">
                                    <a href="#" class="active" id="login-form-link">Forgot Password</a>
                                </div>
                            </div>
                            <hr />
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">

                                    <div id="login-form" role="form" style="display: block;">
                                        <div class="form-group">
                                            <label for="email">Email</label>
                                            <asp:TextBox ID="txt_email_login" TabIndex="1" class="form-control" onkeypress="handleKeyPress(event)" placeholder="Email Address" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="form-group text-center">
                                          <a href="Company.aspx">Back to login</a>
                                        </div>

                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-sm-6 col-sm-offset-3">
                                                    <asp:LinkButton ID="login_btn" OnClick="login_click" TabIndex="4" class="form-control btn btn-login" runat="server">Submit</asp:LinkButton>
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
        </div>
    </form>
    
    <script type="text/javascript">

        function handleKeyPress(e) {
            var key = e.keyCode || e.which;
            if (key == 13) {
                login_btn.click();
            }
        }

    </script>

</body>
</html>
