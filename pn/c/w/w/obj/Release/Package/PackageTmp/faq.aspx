<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="faq.aspx.cs" Inherits="w.faq" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Banner Start-->
            <div class="cp_inner-banner">
                <img src="images/banner/inner-banner-img-05.jpg" alt="">
                <!--Inner Banner Holder Start-->
                <div class="cp-inner-banner-holder">
                    <div class="container">
                    <h2>Faqs</h2>
                      <!--Breadcrumb Start-->
                       <ul class="breadcrumb">
                         <li><a href="default.aspx">Home</a></li>
                         <li class="active">Faqs</li>
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
            
                 <!--Faq Section Start-->
                 <section class="cp-faq-section pd-tb80">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-6">
                               <!--Faq Outer Start-->
                                <div class="cp-faq-holder">
                                    <h3>ASK A QUESTION?</h3>
                                     <!-- Nav tabs -->
                                      <ul class="nav nav-tabs" role="tablist">
                                        <li class="active"><a href="#ask-tab1" aria-controls="ask-tab1" role="tab" data-toggle="tab">Town Car</a></li>
                                        <li><a href="#ask-tab2" aria-controls="ask-tab2" role="tab" data-toggle="tab">Hybrid Car</a></li>
                                      </ul>
                                     <!-- Tab panes -->
                                     <div class="tab-content">
                                        <div role="tabpanel" class="tab-pane fade in active" id="ask-tab1">
                                             <!-- Tab panes -->
                                             <div class="cp-ask-tab-inner">
                                                <p>Find the answer to your query using our Frequently Asked Questions section. Just type your question: </p>
                                                <form method="get">
                                                    <textarea></textarea>
                                                    <a href="#" class="cp-btn-style2">Search Now</a>
                                                </form>
                                            </div>
                                        </div>
                                        <div role="tabpanel" class="tab-pane fade in" id="ask-tab2">
                                             <!-- Tab panes -->
                                             <div class="cp-ask-tab-inner">
                                                <p>Find the answer to your query using our Frequently Asked Questions section. </p>
                                                <form method="get">
                                                    <textarea></textarea>
                                                    <a href="#" class="cp-btn-style2">Search Now</a>
                                                </form>
                                            </div>
                                        </div>
                                    </div><!-- Tab panes End -->
                                </div><!--Faq Outer End-->
                            </div>
                            <div class="col-md-6">
                                <!--Faq Outer Start-->
                                <div class="cp-faq-holder">
                                    <h3>Our Top Rated Question</h3>
                                    <ul class="cp-listed">
                                        <li><a href="#">1. How do I book for a ride with Your Car?</a></li>
                                        <li><a href="#">2. What are the different modes of payment you support?</a></li>
                                        <li><a href="#">3. Which are the locations of operation at the moment?</a></li>
                                        <li><a href="#">4. Can I book Car for someone else using my credit card?</a></li>
                                        <li><a href="#">5. How do I book for a ride with Your Car?</a></li>
                                    </ul>
                                </div><!--Faq Outer End-->
                            </div>
                            <div class="col-md-12">
                                <!--Faq Tab Holder Start-->
                                <div class="cp-faq-tabs-holder pd-t80">
                                     <!-- Nav tabs -->
                                      <ul class="nav nav-tabs" role="tablist">
                                        <li class="active"><a href="#faq-tab1" aria-controls="faq-tab1" role="tab" data-toggle="tab">Top Questions</a></li>
                                        <li><a href="#faq-tab2" aria-controls="faq-tab2" role="tab" data-toggle="tab">Where can you find us</a></li>
                                        <li><a href="#faq-tab3" aria-controls="faq-tab3" role="tab" data-toggle="tab">Our cars</a></li>
                                        <li><a href="#faq-tab4" aria-controls="faq-tab4" role="tab" data-toggle="tab">Lost & found</a></li>
                                        <li><a href="#faq-tab5" aria-controls="faq-tab5" role="tab" data-toggle="tab">Car App</a></li>
                                      </ul>
                                     <!-- Tab panes -->

                                    <!-- Tab panes -->
                                    <div class="tab-content">
                                        <div role="tabpanel" class="tab-pane fade in active" id="faq-tab1">
                                            <!--Faq Listed Start-->
                                            <ul class="cp-faq-listed">
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by John Doe </li>
                                                                <li>12 Feb,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style1">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by Nelson </li>
                                                                <li>21 Feb,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style1">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by John Doe </li>
                                                                <li>12 march,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style1">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by Niky Bard </li>
                                                                <li>23 Feb ,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style1">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by William Doe </li>
                                                                <li>25 Feb,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style1">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by Alle johnfer </li>
                                                                <li>09 march,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style1">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by John Doe </li>
                                                                <li>12 march,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style1">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                            </ul>
                                        </div>
                                        <div role="tabpanel" class="tab-pane fade in" id="faq-tab2">
                                            <!--Faq Listed Start-->
                                            <ul class="cp-faq-listed">
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by John Doe </li>
                                                                <li>12 Feb,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by Nelson </li>
                                                                <li>21 Feb,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by John Doe </li>
                                                                <li>12 march,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by Niky Bard </li>
                                                                <li>23 Feb ,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by William Doe </li>
                                                                <li>25 Feb,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                            </ul>
                                        </div>
                                        <div role="tabpanel" class="tab-pane fade in" id="faq-tab3">
                                             <!--Faq Listed Start-->
                                            <ul class="cp-faq-listed">
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by John Doe </li>
                                                                <li>12 march,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by Niky Bard </li>
                                                                <li>23 Feb ,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by William Doe </li>
                                                                <li>25 Feb,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by Alle johnfer </li>
                                                                <li>09 march,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by John Doe </li>
                                                                <li>12 march,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                            </ul><!--Tab Listed End-->
                                        </div>
                                        <div role="tabpanel" class="tab-pane fade in" id="faq-tab4">
                                             <!--Faq Listed Start-->
                                            <ul class="cp-faq-listed">
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by John Doe </li>
                                                                <li>12 Feb,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by Nelson </li>
                                                                <li>21 Feb,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by John Doe </li>
                                                                <li>12 march,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by Niky Bard </li>
                                                                <li>23 Feb ,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by William Doe </li>
                                                                <li>25 Feb,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by Alle johnfer </li>
                                                                <li>09 march,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                            </ul>
                                        </div>
                                        <div role="tabpanel" class="tab-pane fade in" id="faq-tab5">
                                             <!--Faq Listed Start-->
                                            <ul class="cp-faq-listed">
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by Nelson </li>
                                                                <li>21 Feb,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by John Doe </li>
                                                                <li>12 march,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by Niky Bard </li>
                                                                <li>23 Feb ,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by William Doe </li>
                                                                <li>25 Feb,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                                <li>
                                                    <!--Faq Box Start-->
                                                    <div class="cp-faq-box">
                                                        <div class="cp-top">
                                                            <h4>What do your rates include?</h4>
                                                            <ul class="listed">
                                                                <li>by Alle johnfer </li>
                                                                <li>09 march,2016 </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cp-bottom">
                                                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even  red alteration in some form, by injected humour, or randomised words which don't look even sligh  tly believable. </p>
                                                            <a href="#" class="cp-btn-style2">Ask Now</a>
                                                        </div>
                                                    </div>
                                                    <!--Faq Box End-->
                                                </li>
                                            </ul>
                                        </div>
                                    </div>

                                </div><!--Faq Tab Holder End-->

                                <!--Faq Button Holder Start-->
                                <div class="cp-faq-btn-holder pd-t80">
                                    <strong>Our answers can not help you? Let’s talk with us</strong>
                                    <a href="contact-us.aspx" class="cp-btn-style1">Contact Us</a>
                                </div><!--Faq Button Holder End-->
                            </div>
                        </div>
                    </div>
                 </section><!--Faq Section End-->

            </div><!--Main Content End-->

</asp:Content>
