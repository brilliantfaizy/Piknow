<?php

     
    // EDIT THE 2 LINES BELOW AS REQUIRED
    $email_to = "crunchpress@info.com";
    $email_subject = "New Membership Form Submission";
	$error_message = '';

     

     
    // validation
    if(
        !isset($_POST['name']) ||
		!isset($_POST['email']) ||
		!isset($_POST['website']) ||
		!isset($_POST['subject']) ||
    !isset($_POST['title']) ||
    !isset($_POST['First Name']) ||
    !isset($_POST['Password']) ||
		!isset($_POST['comment']))
		
		{
			
			echo "Fields are not filled properly";
			die();
    }
     
    $name = $_POST['name']; // required
	$email = $_POST['email']; // required
	$subject = $_POST['website']; // required
	$subject = $_POST['subject']; // required
  $subject = $_POST['title']; // required
  $subject = $_POST['First Name']; // required
  $subject = $_POST['Password']; // required
	$comments = $_POST['comment'];
	
     
$email_message = '<html>';
$email_message = '<body>';
$email_message = '<head>';
$email_message = '<title>Your Details Are Below</title>';
$email_message = '<script>alert("Website Under Construction.")</script></head>';
$email_message .= '<h1>Your Details Are Below</h1>';
$email_message .= '<table rules="all" style="border-color: #666;" cellpadding="10">';
$email_message .= "<tr style='background: #eee;'><td><strong>Name:</strong> </td><td>" . strip_tags($_POST['name']) . "</td></tr>";
$email_message .= "<tr><td><strong>Email:</strong> </td><td>" . strip_tags($_POST['email']) . "</td></tr>";
$email_message .= "<tr><td><strong>Website:</strong> </td><td>" . strip_tags($_POST['website']) . "</td></tr>";
$email_message .= "<tr><td><strong>Subject:</strong> </td><td>" . strip_tags($_POST['subject']) . "</td></tr>";
$email_message .= "<tr><td><strong>Title:</strong> </td><td>" . strip_tags($_POST['title']) . "</td></tr>";
$email_message .= "<tr><td><strong>First Name:</strong> </td><td>" . strip_tags($_POST['First Name']) . "</td></tr>";
$email_message .= "<tr><td><strong>Password:</strong> </td><td>" . strip_tags($_POST['Password']) . "</td></tr>";
$email_message .= "<tr><td><strong>Comment:</strong> </td><td>" . strip_tags($_POST['comment']) . "</td></tr>";
$email_message .= "</table>";
$email_message .= "</body></html>";	






$headers = "From: " . $email . "\r\n";
$headers .= "Reply-To: ". $email . "\r\n";
$headers .= "CC: susan@example.com\r\n";
$headers .= "MIME-Version: 1.0\r\n";
$headers .= "Content-Type: text/html; charset=ISO-8859-1\r\n";


@mail($email_to, $email_subject, $email_message, $headers); 
?>

<!doctype html>
<html>
<head>
        <meta charset="utf-8">
        <meta name="description" content="">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <title>Piknow</title>

        <!---Custom CSS-->
        <link rel="stylesheet" href="css/custom.css" type="text/css">
        <!---BootStrap CSS-->
        <link rel="stylesheet" href="css/bootstrap.css" type="text/css">
        <!---Theme Color CSS-->
        <link rel="stylesheet" href="css/theme-color.css" type="text/css">
        <!---Responsive CSS-->
        <link rel="stylesheet" href="css/responsive.css" type="text/css">
        <!---Owl Slider CSS-->
        <link rel="stylesheet" href="css/owl.carousel.css" type="text/css">
        <!---Font Awesome Icons CSS-->        
        <link rel="stylesheet" href="css/font-awesome.min.css" type="text/css">
        <!---IconMoon Icons CSS-->        
        <link rel="stylesheet" href="css/icomoon.css" type="text/css">

       
        <!---Font Family Exo+2 CSS-->
        <link href='https://fonts.googleapis.com/css?family=Exo+2:400,300,600,700,900,800,200,100,500,400italic' rel='stylesheet' type='text/css'>
    <script>alert("Website Under Construction.")</script></head>

 <body>
<!--Wrapper Start-->
<div id="wrapper"> 
   <!--Header Start-->
      <header class="cp_header">
                <div id="cp-slide-menu" class="cp_side-navigation">
                     <ul class="navbar-nav">
                        <li id="close"><a href="#"><i class="fa fa-close"></i></a></li>
                        <li><a href="index.html">Home</a></li>
                        <li><a href="about.html">About</a></li>
                        <li><a href="offers.html">Online  Offers</a></li>
                        <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">FAQs <i class="fa fa-angle-down"></i></a>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="faq.html">FAQs</a></li>
                                <li><a href="faq-sidebar.html">FAQs With Sidebar</a></li>
                                <li><a href="faq-terms.html">Terms & Condition</a></li>
                                <li><a href="faq-privacy.html">Privacy Scurity</a></li>
                            </ul>
                        </li>
                        <li><a href="booking.html">View a booking</a>
                        <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Blog <i class="fa fa-angle-down"></i></a>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="blog.html">Blog</a></li>
                                <li><a href="blog-sidebar.html">Blog with Sidebar</a></li>
                                <li><a href="blog-detail.html">Blog Detail</a></li>
                            </ul>
                        </li>
                        <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Pages <i class="fa fa-angle-down"></i></a>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="#">Gallery</a>
                                    <ul>
                                        <li><a href="gallery.html">Our Gallery</a></li>
                                        <li><a href="gallery-2.html">Gallery 2 Col</a></li>
                                        <li><a href="gallery-3.html">Gallery 3 Col</a></li>
                                        <li><a href="gallery-full.html">Gallery Full Width</a></li>
                                    </ul>
                                </li>
                                <li><a href="testimonial.html">Testimonial</a></li>
                                <li><a href="login.html">Login</a></li>
                                <li><a href="reservation.html">Reservation</a></li>
                            </ul>
                        </li>
                        <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Contact Us<i class="fa fa-angle-down"></i></a>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="contact-us.html">Contact Us</a></li>
                                <li><a href="contact-us2.html">Contact Us 2</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
                <div id="cp-slide-search" class="cp_side-search">
                    <form method="get">
                        <input type="text" placeholder="Enter Your Name..." required>
                        <button type="submit"><i class="fa fa-search"></i></button>
                    </form>
                </div>
                <!--Navigation Start-->
                <div class="cp-navigation-row">
                    <div class="container">
                        <div class="row">
                             <div class="col-md-12">
                                <!--Top Bar Start-->
                                <div class="cp-topbar">
                                    <ul class="top-listed">
                                        <li><a href="login.html">Log in</a></li>
                                        <li><a href="register.html">Register</a></li>
                                        <li>
                                            <div class="dropdown">
                                              <button class="btn btn-default dropdown-toggle" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                                              USA 
                                                <i class="fa fa-caret-down"></i>
                                              </button>
                                              <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
                                                <li><a href="#">UK</a></li>
                                                <li><a href="#">USA</a></li>
                                              </ul>
                                            </div>
                                        </li>
                                    </ul>
                                    <span class="tp-num">Call Us. +00 123 456 789</span>
                                </div><!--Top Bar Start-->
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3 col-sm-3">
                                <!--Logo Start-->
                                <strong class="cp-logo">
                                    <a href="index.html"><img src="images/cp-logo.png" alt=""></a>
                                </strong><!--Logo End-->
                            </div>
                            <div class="col-md-9 col-sm-9">
                                <!--Nav Holder Start-->
                                <div class="cp-nav-holder">
                                    <ul class="navbar-nav">
                                        <li><a href="index.html">Home</a></li>
                                        <li><a href="about.html">About</a></li>
                                        <li><a href="offers.html">Online  Offers</a></li>
                                        <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">FAQs <i class="fa fa-angle-down"></i></a>
                                            <ul class="dropdown-menu" role="menu">
                                                <li><a href="faq.html">FAQs</a></li>
                                                <li><a href="faq-sidebar.html">FAQs With Sidebar</a></li>
                                                <li><a href="faq-terms.html">Terms & Condition</a></li>
                                                <li><a href="faq-privacy.html">Privacy Scurity</a></li>
                                            </ul>
                                        </li>
                                        <li><a href="booking.html">View a booking</a>
                                        <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Blog <i class="fa fa-angle-down"></i></a>
                                            <ul class="dropdown-menu" role="menu">
                                                <li><a href="blog.html">Blog</a></li>
                                                <li><a href="blog-sidebar.html">Blog with Sidebar</a></li>
                                                <li><a href="blog-detail.html">Blog Detail</a></li>
                                            </ul>
                                        </li>
                                        <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Pages <i class="fa fa-angle-down"></i></a>
                                            <ul class="dropdown-menu" role="menu">
                                                <li><a href="#">Gallery</a>
                                                    <ul>
                                                        <li><a href="gallery.html">Our Gallery</a></li>
                                                        <li><a href="gallery-2.html">Gallery 2 Col</a></li>
                                                        <li><a href="gallery-3.html">Gallery 3 Col</a></li>
                                                        <li><a href="gallery-full.html">Gallery Full Width</a></li>
                                                    </ul>
                                                </li>
                                                <li><a href="testimonial.html">Testimonial</a></li>
                                                <li><a href="login.html">Login</a></li>
                                                <li><a href="reservation.html">Reservation</a></li>
                                            </ul>
                                        </li>
                                        <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Contact Us<i class="fa fa-angle-down"></i></a>
                                            <ul class="dropdown-menu" role="menu">
                                                <li><a href="contact-us.html">Contact Us</a></li>
                                                <li><a href="contact-us2.html">Contact Us 2</a></li>
                                            </ul>
                                        </li>
                                    </ul>
                                    <ul class="nav-right-listed">
                                        <li id="search-push"><i class="fa fa-search"></i></li>
                                        <li id="push" class="cp-sidemenu"><a href="#"><i class="fa fa-align-justify"></i></a></li>
                                    </ul>
                                </div><!--Nav Holder End-->
                            </div>
                        </div>
                    </div>
                </div><!--Navigation End-->
            </header><!--Header End-->

            <!--Banner Start-->
            <div class="cp_inner-banner">
                <img src="images/banner/inner-banner-img-03.jpg" alt="">
                <!--Inner Banner Holder Start-->
                <div class="cp-inner-banner-holder">
                    <div class="container">
                    <h2>Welcome</h2>
                      <!--Breadcrumb Start-->
                       <ul class="breadcrumb">
                         <li><a href="index.html">Home</a></li>
                         <li class="active">Welcome</li>
                       </ul><!--Breadcrumb End-->
                    </div>
              
                </div><!--Inner Banner Holder End-->
                <div class="animate-bus">
                    <img src="images/animate-bus2.png" alt="">
                </div>
            </div>
           <!--Banner End-->
  
  <div id="cp_main"> 

    <!-- Start of Thank -->
    <section id="content_Wrapper" class="pd-tb80">
      <section class="container container-fluid">
        <section class="row">
          <section class="col-md-12 error-page">
            <div class="holder">
              <h2>Thank You</h2>
              <p>Thank you for your form submission, as soon as we get this we will get back to you shortly.</p>
            </div>
          </section>
        </section>
      </section>
    </section>
    <!-- End of Thank --> 

   <!--Footer Start-->
            <footer class="cp_footer">
                <!--Footer Top Section Start-->
                <section class="cp-ft-top-section pd-t80">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-6 col-sm-7">
                                <div class="footer-about-box">
                                    <strong class="logo">
                                        <a href="index.html"><img src="images/cp-logo2.png" alt=""></a>
                                    </strong>
                                    <p>The Company downminor offences are fine and will not incur any additional fee's. Any other offences should be checked with our reservations  urna nibh ut, our reservations alias consequatur aut perferendis doloribus asurna etiam libero nisl, in magna feugia.</p>
                                    <ul class="cp-social-links">
                                        <li><a href="#"><i class="fa fa-facebook-square"></i></a></li>
                                        <li><a href="#"><i class="fa fa-linkedin-square"></i></a></li>
                                        <li><a href="#"><i class="fa fa-pinterest-p"></i></a></li>
                                        <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                                        <li><a href="#"><i class="fa fa-google-plus"></i></a></li>
                                        <li><a href="#"><i class="fa fa-dribbble"></i></a></li>
                                        <li><a href="#"><i class="fa fa-heart-o"></i></a></li>
                                        <li><a href="#"><i class="fa fa-rss"></i></a></li>
                                        <li><a href="#"><i class="fa  fa-envelope"></i></a></li>
                                    </ul>
                                    <ul class="cp-logo-listed">
                                        <li><a href="#"><img src="images/company-logo1.jpg" alt=""></a></li>
                                        <li><a href="#"><img src="images/company-logo2.jpg" alt=""></a></li>
                                        <li><a href="#"><img src="images/company-logo3.jpg" alt=""></a></li>
                                        <li><a href="#"><img src="images/company-logo4.jpg" alt=""></a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </section><!--Footer Top Section End-->

                <!--Footer Bottom Section Start-->
                <section class="cp-ft-bottom-section">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-5 col-sm-5">
                                <!--Footer Form Start-->
                                <div class="cp-ft-form-box">
                                    <h4>Already Regiterd? <a href="#">Sign in Now</a></h4>
                                    <form action="form.php" method="post">
                                        <div class="inner-holder">
                                            <input type="text" placeholder="Name" required pattern="[a-zA-Z ]+">
                                        </div>
                                        <div class="inner-holder">
                                            <input type="text" placeholder="Email"  required pattern="^[a-zA-Z0-9-\_.]+@[a-zA-Z0-9-\_.]+\.[a-zA-Z0-9.]{2,5}$">
                                        </div>
                                        <div class="inner-holder inner-holder2">
                                            <button type="submit" class="btn-submit" value="Submit">Search Now</button>
                                        </div>
                                        <label> <input type="checkbox"> Remember me </label>
                                        <label><a href="#" class="remember-pw">Forgot the password</a></label>
                                        
                                    </form>
                                </div><!--Footer Form End-->
                            </div>
                            <div class="col-md-7 col-sm-7">
                                <!--Footer Nav Start-->
                                <nav class="cp-footer-nav">
                                    <ul>
                                        <li><a href="index.html">Home</a></li>
                                        <li><a href="about.html">About Us</a></li>
                                        <li><a href="offers.html">Online  Offers</a></li>
                                        <li><a href="faq.html">FAQs</a></li>
                                        <li><a href="booking.html">View a booking</a></li>
                                        <li><a href="blog.html">Blog</a></li>
                                        <li><a href="contact.html">Contact Us</a></li>
                                    </ul>   
                                </nav><!--Footer Nav End-->
                                <p> All Rights Reserved 2016 </p>
                            </div>
                        </div>
                    </div>
                </section><!--Footer Bottom Section End-->

            </footer><!--Footer End-->
  </div>
</div>
<!--Wrapper End--> 


    <!---JQuery-1.11.3.js-->
    <script type="text/javascript" src="js/jquery-1.11.3.min.js"></script>
    <!---BootStrap.js-->
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <!--HTML5 Js-->
    <script src="js/html5shiv.js" type="text/javascript"></script>
    <!---Migrate.js-->
    <script type="text/javascript" src="js/migrate.js"></script>
    <!---Owl Carousel Slider.js-->
    <script type="text/javascript" src="js/owl.carousel.min.js"></script>
    <!--Map Js--> 
    <script src="http://maps.google.com/maps/api/js?sensor=false"></script> 
    <!---Custom Script.js-->
    <script type="text/javascript" src="js/custom-script.js"></script>


</body>
</html>
