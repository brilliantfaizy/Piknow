<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="contact-us.aspx.cs" Inherits="w.contact_us" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!--Banner Start-->
            <div class="cp_inner-banner">
                <img src="images/banner/inner-banner-img-08.jpg" alt="">
                <!--Inner Banner Holder Start-->
                <div class="cp-inner-banner-holder">
                    <div class="container">
                    <h2>Contact Us</h2>
                      <!--Breadcrumb Start-->
                       <ul class="breadcrumb">
                         <li><a href="default.aspx">Home</a></li>
                         <li class="active">Contact Us</li>
                       </ul><!--Breadcrumb End-->
                    </div>
              
                </div><!--Inner Banner Holder End-->
                <div class="animate-bus">
                    <img src="images/animate-bus2.png" alt="">
                </div>
            </div>
           <!--Banner End-->

            <!--Main Content Start-->
            <div id="cp-main-content">

                <!--Contact Us Section Start-->
                <section class="cp-contact-us-section pd-tb80">
                    <div class="container">
                        <!--Contact Inner Holder Start-->
                        <div class="cp-contact-inner-holder">
                           <h3>Keep in Touch</h3>
                           <p>The Company downminor offences are fine and will not incur any additional fee's. Any other offences should be checked with our reservations  urna nibh ut, our reservations alias consequatur aut perferendis doloribus asurna etiam libero nisl, in magna feugia.</p>

                           <!--Get In Outer Start-->
                           <div class="cp-get-in-outer">
                                <div class="row">
                                    <div class="col-md-4 col-sm-4">
                                        <div class="inner-holder">
                                            <i class="fa fa-paper-plane"></i>
                                            <a href="mailto:#">Info @ lorem ipsum.uk</a>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-4">
                                        <div class="inner-holder">
                                            <i class="fa fa-map-marker"></i>
                                            <p>Ukraine, Kiev, Khreshatik str.</p>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-4">
                                        <div class="inner-holder">
                                            <i class="fa fa-phone"></i>
                                            <p>+38 066 475 30 22</p>
                                        </div>
                                    </div>
                                </div>
                            </div><!--Get In Outer End-->

                            <!--Form Box Start-->
                            <div class="cp-form-box cp-form-box2">
                                <h3>Leave a Reply</h3>
                                <div action="form.php" method="post">
                                    <div class="row">
                                        <div class="col-md-3 col-sm-6">
                                            <div class="inner-holder">
                                                <input type="text" placeholder="Your Name" name="name" required pattern="[a-zA-Z ]+">
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-6">
                                            <div class="inner-holder">
                                                <input type="text" placeholder="Email Address" name="email" required pattern="^[a-zA-Z0-9-\_.]+@[a-zA-Z0-9-\_.]+\.[a-zA-Z0-9.]{2,5}$">
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-6">
                                            <div class="inner-holder">
                                                <input type="text" placeholder="Subject" name="subject" required>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-6">
                                            <div class="inner-holder">
                                                <input type="text" placeholder="Website" name="website" required>
                                            </div>
                                        </div>
                                        <div class="col-md-12 col-sm-12">
                                            <div class="inner-holder">
                                                <textarea placeholder="Message" name="comment" required></textarea>
                                            </div>
                                        </div>
                                        <div class="col-md-12 col-sm-12">
                                            <div class="inner-holder">
                                                <button type="submit" class="btn-submit" onclick="submitclick();" value="Submit">Submit</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div><!--Form Box End-->
                        </div><!--Contact Inner Holder End-->
                    </div>
                </section><!--Contact Us Section End-->

            </div><!--Main Content End-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
                            <script src="https://smtpjs.com/v2/smtp.js"></script>
							
                            <script type="text/javascript">

                            function submitclick(){

                            	//alert(email.value);
                                Email.send("astdevelopers@gmail.com",
                            	"piknow.smtp@gmail.com",
                            	"Contact Form",
                            	"Hello " +'<br>' + name.value + '<br> ' + email.value + '<br>' + website.value + '<br>' + subject.value +'<br>'+ comment.value,
                            	"smtp.elasticemail.com",
                            	"hussainallstartechnology@gmail.com",
                            	"6fab55fe-6f06-4be4-b53a-a2724cad2614"); } 
                            				                            	
                            </script>
  

</asp:Content>
