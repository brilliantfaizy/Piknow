<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Government.aspx.cs" Inherits="Portal.Government" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <title>Karenro Government Login</title>

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
      <a class="hiddenanchor" id="signup"></a>
      <a class="hiddenanchor" id="signin"></a>

      <div class="login_wrapper">
        <div class="animate form login_form">
          <section class="login_content">
            <div class="form">
              <h1>Login Form</h1>
              <div>
                <input runat="server" id="txt_usernameLogin" onkeypress="handleKeyPress(event)" type="text" class="form-control" placeholder="Username" required="" />
              </div>
              <div>
                <input runat="server" id="txt_passwordLogin" onkeypress="handleKeyPress(event)" type="password" class="form-control" placeholder="Password" required="" />
              </div>
                <div class="checkbox">
                <label><input id="Persist" runat="server" type="checkbox" /> Remember me</label>
              </div>
              <div>
                <%--<a class="btn btn-default submit" href="users.aspx">Log in</a>--%>
                <asp:LinkButton ID="loginBtn" class="btn btn-default submit" runat="server" Text="" OnClick="Login_Click">Log in</asp:LinkButton>
                <%--<a class="reset_pass" href="#">Lost your password?</a>--%>
              </div>

              <div class="clearfix"></div>

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
