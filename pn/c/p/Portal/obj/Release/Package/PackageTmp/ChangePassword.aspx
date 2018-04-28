<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Portal.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <title>Karenro Change Password</title>

    <!-- Bootstrap -->
    <link href="./vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <!-- Font Awesome -->
    <link href="./vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet"/>
    <!-- NProgress -->
    <link href="./vendors/nprogress/nprogress.css" rel="stylesheet"/>
    <!-- Animate.css -->
    <link href="./vendors/animate.css/animate.min.css" rel="stylesheet"/>

    <!-- Custom Theme Style -->
    <%--<link href="./build/css/custom.min.css" rel="stylesheet"/>--%>
    <link href="./build/css/custom.css" rel="stylesheet"/>
  </head>
<body class="login">

    <form id="form1" runat="server">

         <div id="google_translate_element"></div>
        <script type="text/javascript">
            function googleTranslateElementInit() {
                new google.translate.TranslateElement({ pageLanguage: 'en', includedLanguages: 'en,fa', layout: google.translate.TranslateElement.FloatPosition.TOP_LEFT, autoDisplay: true }, 'google_translate_element');
            }
        </script>
        <!--<script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>-->

        <div>
      <a class="hiddenanchor" id="signin"></a>

      <div class="login_wrapper">
        <div class="animate form login_form">
          <section class="login_content">
            <div class="form">
              <h1>Change Password</h1>
              
              <div>
                <input runat="server" id="txt_passwordLogin" onkeypress="handleKeyPress(event)" type="password" class="form-control" placeholder="Password" required="" />
              </div>

              <div>
                <input runat="server" id="txt_cpasswordLogin" onkeypress="handleKeyPress(event)" type="password" class="form-control" placeholder="Confirm Password" required="" />
              </div>

                <asp:HiddenField runat="server" ID="txt_userNumber" />
                <asp:HiddenField runat="server" ID="txt_userToken" />

              <div>
                <asp:LinkButton ID="updateBtn" class="btn btn-default submit" runat="server" Text="" OnClick="Update_Click">Update</asp:LinkButton>
              </div>

              <div class="clearfix"></div>

              <div class="separator">
                <div class="clearfix"></div>
                <br />

                <div>
                  <h1><i class="glyphicon glyphicon-map-marker"></i> Karenro!</h1>
                  <p>©2017 All Rights Reserved. Karenro!. Privacy and Terms</p>
                </div>
              </div>
            </div>
          </section>
        </div>

      </div>
    </div>
    </form>
    <script type="text/javascript">

        function handleKeyPress(e) {
            var key = e.keyCode || e.which;
            if (key == 13) {
                loginBtn.click();
            }
        }

    </script>
</body>
</html>
