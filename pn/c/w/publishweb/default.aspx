<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="w._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Banner Start-->
    <div class="cp_banner">
        <!--Banner Slider Start-->
        <div class="owl-carousel" id="cp_banner-slider">
            <!--Banner Item Holder Start-->
            <div class="item">
                <img src="images/banner/banner-img-01.jpg" alt="">
                <!--Banner Caption Start-->
                <div class="cp-banner-caption">
                    <div class="container">
                        <div class="banner-inner-holder">
                            <strong class="banner-title">Book a Car</strong>
                            <h2>A rELIABLE WAY TO TRAVEL</h2>
                            <a href="#" style="display: none;" class="cp-btn-style1">Book Now</a>
                        </div>
                    </div>
                </div>
                <!--Banner Caption End-->
            </div>
            <!--Banner Item Holder End-->

            <!--Banner Item Holder Start-->
            <div class="item">
                <img src="images/banner/banner-img-02.jpg" alt="">
                <!--Banner Caption Start-->
                <div class="cp-banner-caption">
                    <div class="container">
                        <div class="banner-inner-holder">
                            <strong class="banner-title">Save Time</strong>
                            <h2>Save time when you arrive!</h2>
                            <a href="#" style="display: none;" class="cp-btn-style1">Book Now</a>
                        </div>
                    </div>
                </div>
                <!--Banner Caption End-->
            </div>
            <!--Banner Item Holder End-->

            <!--Banner Item Holder Start-->
            <div class="item">
                <img src="images/banner/banner-img-03.jpg" alt="">
                <!--Banner Caption Start-->
                <div class="cp-banner-caption">
                    <div class="container">
                        <div class="banner-inner-holder">
                            <strong class="banner-title">Get Startd!</strong>
                            <h2>Travel for a day. Save $50 Texy.</h2>
                            <a href="#" style="display: none;" class="cp-btn-style1">Book Now</a>
                        </div>
                    </div>
                </div>
                <!--Banner Caption End-->
            </div>
            <!--Banner Item Holder End-->

        </div>
        <!--Banner Slider End-->
    </div>
    <!--Banner End-->

    <!--Main Content Start-->
    <div id="cp-main-content">

        <section class="pd-tb80" style="margin-top: -40px;">
            <div class="container">
                <div class="cp-heading-style1">
                    <h2>How it works?</h2>
                </div>
                <!--Awwards innner Outer Start-->
                <div class="cp-inner-awwards-holder">
                    <ul>
                        <li><span>Step-1</span>  -  Download app,register yourself. </li>
                        <li><span>Step-2</span>  -  Open your location accessibility. </li>
                        <li><span>Step-3 </span>-  Take a ride or accept a ride request. </li>
                        <li><span>Step-4</span>  -  Lift on a car or pick up your passenger. </li>
                        <li><span>Step-5 </span>-  Once arrival confirmed start the ride. </li>
                        <li><span>Step-6 </span>-  The processes to access where to drop off.</li>
                        <li><span>Step-7 </span>-  Pay the cash and rate the driver. </li>
                    </ul>
                </div>
                <!--Awwards innner Outer End-->
            </div>
        </section>

        <!--Mobile App Section Start-->
        <section class="cp-mobile-app-section pd-tb80">
            <div class="container">
                <div class="cp-heading-style1">
                    <h2>GET APP TO <span>GET STARTED</span></h2>
                </div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4">
                        <ul class="cp-app-btn">
                            <li style="margin-right: 10px;"><a href="#">
                                <img src="images/app-img.png" alt="" /></a></li>
                            <li style="margin-left: 10px;"><a href="#">
                                <img src="images/g-play-img.png" alt="" /></a></li>
                        </ul>
                    </div>
                    <div class="col-md-4"></div>
                </div>
                <div class="row" style="display: none;">
                    <div class="col-md-6 col-sm-12">
                        <div class="cp-app-thumb">
                            <img class="app-img1" src="images/mobile-img-02.png" alt="">
                            <img class="app-img2" src="images/mobile-img-01.png" alt="">
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12">
                        <div class="cp-app-text">
                            <h4>Downlaod the PikNow voucher app free!
                                <br>
                                Say Goodbye to paper vouchers</h4>
                            <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. </p>
                            <p>But the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. </p>
                            <strong>Search PikNow on iphone & Android market places</strong>
                            <ul class="cp-app-btn">
                                <li><a href="#">
                                    <img src="images/g-play-img.png" alt=""></a></li>
                                <li><a href="#">
                                    <img src="images/app-img.png" alt=""></a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!--Mobile App Section End-->

        <style type="text/css">

            .cp-form-box .inner-holder #noSeats{
                    width: 100%;
                    font-size: 14px;
                    color: #444;
                    background-color: #fff;
                    border: none;
                    border: 1px solid #b9b9b9;
                    padding: 0 20px;
                    height: 50px;
                    line-height: 50px;
                    position: relative;
                    z-index: 99;
                }

        </style>
        <!--Mobile App Section Start-->
        <section class="cp-mobile-app-section pd-tb80">
            <div class="container">
                <div class="cp-heading-style1">
                    <h2>RIDE PRICE <span>CALCULATOR</span></h2>

                    <div class="row cp-form-box" style="margin-top: 60px;">

                        <div class="col-md-4 col-sm-4">
                            <div class="inner-holder">
                                <input id="place_from" type="text" placeholder="place from" name="place_from" required />
                            </div>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <div class="inner-holder">
                                <input id="place_to" type="text" placeholder="place to" name="place_to" required />
                            </div>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <div class="inner-holder">
                                <select id="noSeats" required>
                                    <option value="Seats">Seats</option>
                                    <option value="1">1</option>
                                    <option value="2">2</option>
                                    <option value="3">3</option>
                                    <option value="4">4</option>
                                </select>
                            </div>
                        </div>

                        <div class="col-md-4 col-xs-offset-5 col-sm-4">
                            <div class="inner-holder">
                                <button id="btnCalculate" type="submit" style="float:inherit;" class="btn-submit" value="Submit">Submit</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!--Mobile App Section End-->

        <!--Car Section Start-->
        <section class="cp-car-section pd-tb80" style="display: none;">
            <div class="container">
                <div class="cp-heading-style1">
                    <h2>Our Vehicle <span>Types</span></h2>
                </div>
                <div class="cp-tabs-holder">
                    <!-- Nav tabs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li class="active"><a href="#tab-01" aria-controls="tab-01" role="tab" data-toggle="tab">Town Car</a></li>
                        <li><a href="#tab-02" aria-controls="tab-02" role="tab" data-toggle="tab">Hybrid Car</a></li>
                        <li><a href="#tab-03" aria-controls="tab-03" role="tab" data-toggle="tab">Limousine Car</a></li>
                        <li><a href="#tab-04" aria-controls="tab-04" role="tab" data-toggle="tab">SUV Car</a></li>
                    </ul>
                    <!-- Tab panes -->
                    <div class="tab-content">
                        <div role="tabpanel" class="tab-pane fade in active" id="tab-01">
                            <div class="row">
                                <div class="col-md-4 col-sm-6">
                                    <!--Car Holder Start-->
                                    <article class="cp-car-holder">
                                        <figure class="cp-thumb">
                                            <img src="images/car-img-01.jpg" alt="">
                                        </figure>
                                        <div class="cp-text">
                                            <h3>Cci-Fiat 500</h3>
                                            <ul class="cp-meta-listed">
                                                <li>Mileage: <span>130 000 km</span></li>
                                                <li>Volume capacity: <span>1.3l</span></li>
                                                <li>Price: <strong>$25.899</strong></li>
                                            </ul>
                                            <a href="booking.aspx" style="display: none;" class="cp-btn-style1">Book Now</a>
                                        </div>
                                    </article>
                                    <!--Car Holder End-->
                                </div>
                                <div class="col-md-4 col-sm-6">
                                    <!--Car Holder Start-->
                                    <article class="cp-car-holder">
                                        <figure class="cp-thumb">
                                            <img src="images/car-img-02.jpg" alt="">
                                        </figure>
                                        <div class="cp-text">
                                            <h3>Toyotie </h3>
                                            <ul class="cp-meta-listed">
                                                <li>Mileage: <span>140 000 km </span></li>
                                                <li>Volume capacity: <span>2.3l</span></li>
                                                <li>Price: <strong>$29.895</strong></li>
                                            </ul>
                                            <a href="booking.aspx" style="display: none;" class="cp-btn-style1">Book Now</a>
                                        </div>
                                    </article>
                                    <!--Car Holder End-->
                                </div>
                                <div class="col-md-4 col-sm-6">
                                    <!--Car Holder Start-->
                                    <article class="cp-car-holder">
                                        <figure class="cp-thumb">
                                            <img src="images/car-img-03.jpg" alt="">
                                        </figure>
                                        <div class="cp-text">
                                            <h3>Fiat 800</h3>
                                            <ul class="cp-meta-listed">
                                                <li>Mileage: <span>155 000 km</span></li>
                                                <li>Volume capacity: <span>1.6l</span></li>
                                                <li>Price: <strong>$35.899</strong></li>
                                            </ul>
                                            <a href="booking.aspx" style="display: none;" class="cp-btn-style1">Book Now</a>
                                        </div>
                                    </article>
                                    <!--Car Holder End-->
                                </div>
                            </div>
                        </div>
                        <div role="tabpanel" class="tab-pane fade" id="tab-02">
                            <div class="row">
                                <div class="col-md-4 col-sm-6">
                                    <!--Car Holder Start-->
                                    <article class="cp-car-holder">
                                        <figure class="cp-thumb">
                                            <img src="images/car-img-02.jpg" alt="">
                                        </figure>
                                        <div class="cp-text">
                                            <h3>Cci-Fiat 500</h3>
                                            <ul class="cp-meta-listed">
                                                <li>Mileage: <span>130 000 km</span></li>
                                                <li>Volume capacity: <span>1.3l</span></li>
                                                <li>Price: <strong>$25.899</strong></li>
                                            </ul>
                                            <a href="booking.aspx" style="display: none;" class="cp-btn-style1">Book Now</a>
                                        </div>
                                    </article>
                                    <!--Car Holder End-->
                                </div>
                                <div class="col-md-4 col-sm-6">
                                    <!--Car Holder Start-->
                                    <article class="cp-car-holder">
                                        <figure class="cp-thumb">
                                            <img src="images/car-img-03.jpg" alt="">
                                        </figure>
                                        <div class="cp-text">
                                            <h3>Toyotie </h3>
                                            <ul class="cp-meta-listed">
                                                <li>Mileage: <span>140 000 km </span></li>
                                                <li>Volume capacity: <span>2.3l</span></li>
                                                <li>Price: <strong>$29.895</strong></li>
                                            </ul>
                                            <a href="booking.aspx" style="display: none;" class="cp-btn-style1">Book Now</a>
                                        </div>
                                    </article>
                                    <!--Car Holder End-->
                                </div>
                                <div class="col-md-4 col-sm-6">
                                    <!--Car Holder Start-->
                                    <article class="cp-car-holder">
                                        <figure class="cp-thumb">
                                            <img src="images/car-img-01.jpg" alt="">
                                        </figure>
                                        <div class="cp-text">
                                            <h3>Fiat 800</h3>
                                            <ul class="cp-meta-listed">
                                                <li>Mileage: <span>155 000 km</span></li>
                                                <li>Volume capacity: <span>1.6l</span></li>
                                                <li>Price: <strong>$35.899</strong></li>
                                            </ul>
                                            <a href="booking.aspx" style="display: none;" class="cp-btn-style1">Book Now</a>
                                        </div>
                                    </article>
                                    <!--Car Holder End-->
                                </div>
                            </div>
                        </div>
                        <div role="tabpanel" class="tab-pane fade" id="tab-03">
                            <div class="row">
                                <div class="col-md-4 col-sm-6">
                                    <!--Car Holder Start-->
                                    <article class="cp-car-holder">
                                        <figure class="cp-thumb">
                                            <img src="images/car-img-03.jpg" alt="">
                                        </figure>
                                        <div class="cp-text">
                                            <h3>Cci-Fiat 500</h3>
                                            <ul class="cp-meta-listed">
                                                <li>Mileage: <span>130 000 km</span></li>
                                                <li>Volume capacity: <span>1.3l</span></li>
                                                <li>Price: <strong>$25.899</strong></li>
                                            </ul>
                                            <a href="booking.aspx" style="display: none;" class="cp-btn-style1">Book Now</a>
                                        </div>
                                    </article>
                                    <!--Car Holder End-->
                                </div>
                                <div class="col-md-4 col-sm-6">
                                    <!--Car Holder Start-->
                                    <article class="cp-car-holder">
                                        <figure class="cp-thumb">
                                            <img src="images/car-img-01.jpg" alt="">
                                        </figure>
                                        <div class="cp-text">
                                            <h3>Toyotie </h3>
                                            <ul class="cp-meta-listed">
                                                <li>Mileage: <span>140 000 km </span></li>
                                                <li>Volume capacity: <span>2.3l</span></li>
                                                <li>Price: <strong>$29.895</strong></li>
                                            </ul>
                                            <a href="booking.aspx" style="display: none;" class="cp-btn-style1">Book Now</a>
                                        </div>
                                    </article>
                                    <!--Car Holder End-->
                                </div>
                                <div class="col-md-4 col-sm-6">
                                    <!--Car Holder Start-->
                                    <article class="cp-car-holder">
                                        <figure class="cp-thumb">
                                            <img src="images/car-img-02.jpg" alt="">
                                        </figure>
                                        <div class="cp-text">
                                            <h3>Fiat 800</h3>
                                            <ul class="cp-meta-listed">
                                                <li>Mileage: <span>155 000 km</span></li>
                                                <li>Volume capacity: <span>1.6l</span></li>
                                                <li>Price: <strong>$35.899</strong></li>
                                            </ul>
                                            <a href="booking.aspx" class="cp-btn-style1" style="display: none;">Book Now</a>
                                        </div>
                                    </article>
                                    <!--Car Holder End-->
                                </div>
                            </div>
                        </div>
                        <div role="tabpanel" class="tab-pane fade" id="tab-04">
                            <div class="row">
                                <div class="col-md-4 col-sm-6">
                                    <!--Car Holder Start-->
                                    <article class="cp-car-holder">
                                        <figure class="cp-thumb">
                                            <img src="images/car-img-03.jpg" alt="">
                                        </figure>
                                        <div class="cp-text">
                                            <h3>Cci-Fiat 700</h3>
                                            <ul class="cp-meta-listed">
                                                <li>Mileage: <span>120 000 km</span></li>
                                                <li>Volume capacity: <span>1.3l</span></li>
                                                <li>Price: <strong>$25.899</strong></li>
                                            </ul>
                                            <a href="booking.aspx" class="cp-btn-style1" style="display: none;">Book Now</a>
                                        </div>
                                    </article>
                                    <!--Car Holder End-->
                                </div>
                                <div class="col-md-4 col-sm-6">
                                    <!--Car Holder Start-->
                                    <article class="cp-car-holder">
                                        <figure class="cp-thumb">
                                            <img src="images/car-img-02.jpg" alt="">
                                        </figure>
                                        <div class="cp-text">
                                            <h3>Toyotie </h3>
                                            <ul class="cp-meta-listed">
                                                <li>Mileage: <span>140 000 km </span></li>
                                                <li>Volume capacity: <span>2.3l</span></li>
                                                <li>Price: <strong>$29.895</strong></li>
                                            </ul>
                                            <a href="booking.aspx" class="cp-btn-style1" style="display: none;">Book Now</a>
                                        </div>
                                    </article>
                                    <!--Car Holder End-->
                                </div>
                                <div class="col-md-4 col-sm-6">
                                    <!--Car Holder Start-->
                                    <article class="cp-car-holder">
                                        <figure class="cp-thumb">
                                            <img src="images/car-img-01.jpg" alt="">
                                        </figure>
                                        <div class="cp-text">
                                            <h3>Fiat 800</h3>
                                            <ul class="cp-meta-listed">
                                                <li>Mileage: <span>155 000 km</span></li>
                                                <li>Volume capacity: <span>1.6l</span></li>
                                                <li>Price: <strong>$35.899</strong></li>
                                            </ul>
                                            <a href="booking.aspx" class="cp-btn-style1" style="display: none;">Book Now</a>
                                        </div>
                                    </article>
                                    <!--Car Holder End-->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </section>
        <!--Car Section End-->

        <!--Why Choose Section Start-->
        <section class="cp-why-choose-section pd-tb80" style="display: none;">
            <div class="container">
                <!--Why Choose Text-->
                <div class="cp-why-choose-text" style="display: none;">
                    <span class="choose-btn">Book your cab with confidence</span>
                    <h3>Why Choose</h3>
                    <h2><span>PIKNOW</span> for car hire </h2>
                    <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly or randomised words which don't  believable. </p>
                    <a href="booking.aspx" style="display: none;" class="cp-btn-style1">Book Now</a>
                </div>
                <!--Why Choose Text-->

                <div class="cp-heading-style1">
                    <h2>Why <span>PIKNOW</span></h2>
                </div>

                <div class="cp-why-choose-listed row">
                    <div class="col-md-3">
                        <div class="cp-box">
                            <%--<img src="images/why-choose-img-01.png" alt="">--%>
                            <span class="icon-cash19 icomoon"></span>
                            <h3>Inclusive Rates</h3>
                            <p>We offers Fully Inclusive car hire rates.There are no additional insurances that you need to purchase locally.</p>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="cp-box">
                            <%--<img src="images/why-choose-img-03.png" alt="">--%>
                            <span class="icon-transport1105 icomoon"></span>
                            <h3>Easy Searching</h3>
                            <p>We offers Fully Inclusive car hire rates.There are no additional insurances that you need to purchase locally.</p>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="cp-box">
                            <%--<img src="images/why-choose-img-02.png" alt="">--%>
                            <span class="icon-house158 icomoon"></span>
                            <h3>Home Pickup</h3>
                            <p>We offers Fully Inclusive car hire rates.There are no additional insurances that you need to purchase locally.</p>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="cp-box">
                            <%--<img src="images/why-choose-img-01.png" alt="">--%>
                            <span class="icon-cash19 icomoon"></span>
                            <h3>Inclusive Rates</h3>
                            <p>We offers Fully Inclusive car hire rates.There are no additional insurances that you need to purchase locally.</p>
                        </div>
                    </div>
                </div>

                <!--Why Choose Listed-->
                <ul class="cp-why-choose-listed" style="display: none;">
                    <li>
                        <div class="cp-box">
                            <%--<img src="images/why-choose-img-01.png" alt="">--%>
                            <span class="icon-cash19 icomoon"></span>
                            <h3>Inclusive Rates</h3>
                            <p>We offers Fully Inclusive car hire rates.There are no additional insurances that you need to purchase locally.</p>
                        </div>
                    </li>
                    <li>
                        <div class="cp-box">
                            <%--<img src="images/why-choose-img-03.png" alt="">--%>
                            <span class="icon-transport1105 icomoon"></span>
                            <h3>Easy Searching</h3>
                            <p>We offers Fully Inclusive car hire rates.There are no additional insurances that you need to purchase locally.</p>
                        </div>
                    </li>
                    <li>
                        <div class="cp-box">
                            <%--<img src="images/why-choose-img-02.png" alt="">--%>
                            <span class="icon-house158 icomoon"></span>
                            <h3>Home Pickup</h3>
                            <p>We offers Fully Inclusive car hire rates.There are no additional insurances that you need to purchase locally.</p>
                        </div>
                    </li>

                    <li>
                        <div class="cp-box">
                            <%--<img src="images/why-choose-img-01.png" alt="">--%>
                            <span class="icon-cash19 icomoon"></span>
                            <h3>Inclusive Rates</h3>
                            <p>We offers Fully Inclusive car hire rates.There are no additional insurances that you need to purchase locally.</p>
                        </div>
                    </li>
                </ul>
                <!--Why Choose Listed End-->

            </div>
        </section>
        <!--Why Choose Section End-->

        <!--Why Choose Section Start-->
        <section class="cp-why-choose-section pd-tb80" style="display: none;">
            <div class="container">
                <!--Why Choose Text-->
                <div class="cp-why-choose-text">
                    <span class="choose-btn">Book your cab with confidence</span>
                    <h3>Why Choose</h3>
                    <h2><span>PIKNOW</span> for car hire </h2>
                    <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly or randomised words which don't  believable. </p>
                    <a href="booking.aspx" style="display: none;" class="cp-btn-style1">Book Now</a>
                </div>
                <!--Why Choose Text-->

                <!--Why Choose Listed-->
                <ul class="cp-why-choose-listed">
                    <li>
                        <div class="cp-box">
                            <img src="images/why-choose-img-01.png" alt="">
                            <h3>Inclusive Rates</h3>
                            <span class="icon-cash19 icomoon"></span>
                            <p>We offers Fully Inclusive car hire rates.There are no additional insurances that you need to purchase locally.</p>
                        </div>
                    </li>
                    <li>
                        <div class="cp-box">
                            <img src="images/why-choose-img-03.png" alt="">
                            <h3>Easy Searching</h3>
                            <span class="icon-transport1105 icomoon"></span>
                            <p>We offers Fully Inclusive car hire rates.There are no additional insurances that you need to purchase locally.</p>
                        </div>
                    </li>
                    <li>
                        <div class="cp-box">
                            <img src="images/why-choose-img-02.png" alt="">
                            <h3>Home Pickup</h3>
                            <span class="icon-house158 icomoon"></span>
                            <p>We offers Fully Inclusive car hire rates.There are no additional insurances that you need to purchase locally.</p>
                        </div>
                    </li>
                </ul>
                <!--Why Choose Listed End-->

            </div>
        </section>
        <!--Why Choose Section End-->

        <!--Driver Section Start-->
        <section style="display: none;" class="cp-driver-section pd-tb80">
            <div class="container">
                <div class="cp-heading-style1">
                    <h2>Drivers <span>For Hire</span></h2>
                </div>
                <div class="row">
                    <div class="col-md-3 col-sm-6 col-xs-12">
                        <!--Driver Box Start-->
                        <figure class="cp-driver-box">
                            <img src="images/driver-img-01.jpg" alt="">
                            <figcaption class="cp-caption">
                                <h4><span>Anita Doe</span></h4>
                                <ul class="cp-meta-listed">
                                    <li>Cab: <span>Driver</span></li>
                                    <li>Age: <span>27</span></li>
                                </ul>
                            </figcaption>
                        </figure>
                        <!--Driver Box End-->
                    </div>
                    <div class="col-md-3 col-sm-6 col-xs-12">
                        <!--Driver Box Start-->
                        <figure class="cp-driver-box">
                            <img src="images/driver-img-02.jpg" alt="">
                            <figcaption class="cp-caption">
                                <h4><span>Adam Eli</span></h4>
                                <ul class="cp-meta-listed">
                                    <li>Part time: <span>Driver</span></li>
                                    <li>Age: <span>25</span></li>
                                </ul>
                            </figcaption>
                        </figure>
                        <!--Driver Box End-->
                    </div>
                    <div class="col-md-3 col-sm-6 col-xs-12">
                        <!--Driver Box Start-->
                        <figure class="cp-driver-box">
                            <img src="images/driver-img-03.jpg" alt="">
                            <figcaption class="cp-caption">
                                <h4><span>Johni Yoe</span></h4>
                                <ul class="cp-meta-listed">
                                    <li>Full time: <span>Driver</span></li>
                                    <li>Age: <span>29</span></li>
                                </ul>
                            </figcaption>
                        </figure>
                        <!--Driver Box End-->
                    </div>
                    <div class="col-md-3 col-sm-6 col-xs-12">
                        <!--Driver Box Start-->
                        <figure class="cp-driver-box">
                            <img src="images/driver-img-04.jpg" alt="">
                            <figcaption class="cp-caption">
                                <h4><span>Anita Doe</span></h4>
                                <ul class="cp-meta-listed">
                                    <li>Cab: <span>Driver</span></li>
                                    <li>Age: <span>21</span></li>
                                </ul>
                            </figcaption>
                        </figure>
                        <!--Driver Box End-->
                    </div>
                </div>
            </div>
        </section>
        <!--Driver Section End-->

        <!--Testimonial Section Start-->
        <section class="cp-testimonial-section pd-tb80" style="display: none;">
            <div class="container">
                <div class="cp-heading-style2">
                    <h2>Latest <span>Reviews</span></h2>
                </div>
                <div class="owl-carousel" id="cp-testimonial-slider">
                    <div class="item">
                        <div class="cp-testimonial-inner">
                            <div class="row">
                                <div class="col-md-8 col-sm-8">
                                    <div class="cp-text">
                                        <strong>Highly recommended by our customers</strong>
                                        <blockquote class="cp-blockquote">
                                            Sabemos que el diferencial está en los detalles, y es por ello que nuestros se
                                                    vicios en alquiler de vehículos, tanto en el sector turístico como en el empr
                                                    sarial, se destacan por su calidad y buen gusto para brindarte una experien
                                                    cia única, segura y agradable.
                                        </blockquote>
                                        <span>ALBERT EISHAL, ART DIRECTOR</span>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-4">
                                    <span class="cp-icon">
                                        <i class="fa fa-user"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="cp-testimonial-inner">
                            <div class="row">
                                <div class="col-md-8 col-sm-8">
                                    <div class="cp-text">
                                        <strong>Highly recommended by our clients</strong>
                                        <blockquote class="cp-blockquote">
                                            Tanto en el sector turístico como en el empr
                                                    sarial, se destacan por su calidad y buen gusto para brindarte una experien
                                                    cia única, segura y agradable Sabemos que el diferencial está en los detalles, y es por ello que nuestros se
                                                    vicios en alquiler de vehículos, .
                                        </blockquote>
                                        <span>Niky John, ART DIRECTOR</span>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-4">
                                    <span class="cp-icon">
                                        <i class="fa fa-user"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="cp-testimonial-inner">
                            <div class="row">
                                <div class="col-md-8 col-sm-8">
                                    <div class="cp-text">
                                        <strong>Highly recommended by our customers</strong>
                                        <blockquote class="cp-blockquote">
                                            Sabemos que el diferencial está en los detalles, y es por ello que nuestros se
                                                    vicios en alquiler de vehículos, tanto en el sector turístico como en el empr
                                                    sarial, se destacan por su calidad y buen gusto para brindarte una experien
                                                    cia única, segura y agradable.
                                        </blockquote>
                                        <span>William Bard, ART DIRECTOR</span>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-4">
                                    <span class="cp-icon">
                                        <i class="fa fa-user"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!--Testimonial Section End-->



        <!--News & Faq Section Start-->
        <section class="cp-faq-section pd-tb80">
            <div class="container">
                <div class="cp-heading-style1">
                    <h2>Our News & <span>Faqs</span></h2>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <!--Testimonial Outer Start-->
                        <div class="cp-testimonial-outer">
                            <div class="owl-carousel" id="cp-test-slider2">
                                <div class="item">
                                    <!--Testimonial Box Strat-->
                                    <div class="cp-testimonial-box">
                                        <span class="date">Feb 12, 2016</span>
                                        <h4>Here is the best way  to collect your car</h4>
                                        <p>Speeding and minor offences are fine and will not incur any additional fee's. any other offences should be checked with our reservations  urna nibh ut,  etiam libero nisl, in magna fusce in feugia.... </p>
                                        <div class="test-bottom">
                                            <div class="thumb">
                                                <img class="img-circle" src="images/test-sm-thumb.jpg" alt="">
                                            </div>
                                            <p>By Jennifer Freemean</p>
                                        </div>
                                    </div>
                                    <!--Testimonial Box End-->
                                </div>
                                <div class="item">
                                    <!--Testimonial Box Strat-->
                                    <div class="cp-testimonial-box">
                                        <span class="date">Feb 20, 2016</span>
                                        <h4>Here is the best way  to collect your car</h4>
                                        <p>Speeding and minor offences are fine and will not incur any additional fee's. any other offences should be checked with our reservations  urna nibh ut,  etiam libero nisl, in magna fusce in feugia.... </p>
                                        <div class="test-bottom">
                                            <div class="thumb">
                                                <img class="img-circle" src="images/test-sm-thumb.jpg" alt="">
                                            </div>
                                            <p>By Niky Bard</p>
                                        </div>
                                    </div>
                                    <!--Testimonial Box End-->
                                </div>
                                <div class="item">
                                    <!--Testimonial Box Strat-->
                                    <div class="cp-testimonial-box">
                                        <span class="date">June 2, 2016</span>
                                        <h4>Here is the best way  to collect your car</h4>
                                        <p>Speeding and minor offences are fine and will not incur any additional fee's. any other offences should be checked with our reservations  urna nibh ut,  etiam libero nisl, in magna fusce in feugia.... </p>
                                        <div class="test-bottom">
                                            <div class="thumb">
                                                <img class="img-circle" src="images/test-sm-thumb.jpg" alt="">
                                            </div>
                                            <p>By allie johnfar</p>
                                        </div>
                                    </div>
                                    <!--Testimonial Box End-->
                                </div>
                            </div>
                        </div>
                        <!--Testimonial Outer End-->
                    </div>
                    <div class="col-md-6">
                        <!--Accordian Item Start-->
                        <div class="cp-accordian-item">
                            <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                <div class="panel panel-default">
                                    <div class="panel-heading" role="tab" id="cp-tab-One">
                                        <div class="panel-title">
                                            <a role="button" data-toggle="collapse" data-parent="#accordion" href="#cp-tab-collapse1" aria-expanded="true" aria-controls="cp-tab-collapse1">What do your rates include?
                                            </a>
                                        </div>
                                    </div>
                                    <div id="cp-tab-collapse1" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="cp-tab-One">
                                        <div class="panel-body">
                                            <div class="cp-thumb">
                                                <img src="images/car-sm-01.jpg" alt="">
                                            </div>
                                            <div class="cp-text">
                                                <p>Speeding and minor offences are fine and will not incur any additional fee's. Any other offences should be checked with our reservations....</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading" role="tab" id="cp-tab-Two">
                                        <div class="panel-title">
                                            <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#cp-tab-collapse2" aria-expanded="false" aria-controls="cp-tab-collapse2">Can I drive the vehicle out of State? 
                                            </a>
                                        </div>
                                    </div>
                                    <div id="cp-tab-collapse2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="cp-tab-Two">
                                        <div class="panel-body">
                                            <div class="cp-thumb">
                                                <img src="images/car-sm-01.jpg" alt="">
                                            </div>
                                            <div class="cp-text">
                                                <p>Speeding and minor offences are fine and will not incur any additional fee's. Any other offences should be checked with our reservations....</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading" role="tab" id="cp-tab-Three">
                                        <div class="panel-title">
                                            <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#cp-tab-collapse3" aria-expanded="false" aria-controls="cp-tab-collapse3">Are there any hidden charges? 
                                            </a>
                                        </div>
                                    </div>
                                    <div id="cp-tab-collapse3" class="panel-collapse collapse" role="tabpanel" aria-labelledby="cp-tab-Three">
                                        <div class="panel-body">
                                            <div class="cp-thumb">
                                                <img src="images/car-sm-01.jpg" alt="">
                                            </div>
                                            <div class="cp-text">
                                                <p>Speeding and minor offences are fine and will not incur any additional fee's. Any other offences should be checked with our reservations....</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading" role="tab" id="cp-tab-Four">
                                        <div class="panel-title">
                                            <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#cp-tab-collapse4" aria-expanded="false" aria-controls="cp-tab-collapse4">One Way Rental and how much they cost? 
                                            </a>
                                        </div>
                                    </div>
                                    <div id="cp-tab-collapse4" class="panel-collapse collapse" role="tabpanel" aria-labelledby="cp-tab-Four">
                                        <div class="panel-body">
                                            <div class="cp-thumb">
                                                <img src="images/car-sm-01.jpg" alt="">
                                            </div>
                                            <div class="cp-text">
                                                <p>Speeding and minor offences are fine and will not incur any additional fee's. Any other offences should be checked with our reservations....</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <a href="faq-terms.aspx" class="cp-read-more">More FAQs</a>
                        </div>
                        <!--Accordian Item End-->
                    </div>
                </div>
            </div>
        </section>
        <!--News & Faq Section End-->

        <script>
            // This example displays an address form, using the autocomplete feature
            // of the Google Places API to help users fill in the information.

            // This example requires the Places library. Include the libraries=places
            // parameter when you first load the API. For example:
            // <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&libraries=places">

            var placeSearch, autocomplete1, autocomplete2;

            function initAutocomplete() {

                //var latitude1 = 39.46;
                //var longitude1 = -0.36;
                //var latitude2 = 40.40;
                //var longitude2 = -3.68;

                //var distance = google.maps.geometry.spherical.computeDistanceBetween(new google.maps.LatLng(latitude1, longitude1), new google.maps.LatLng(latitude2, longitude2));
                //console.log(distance);


                // Create the autocomplete object, restricting the search to geographical
                // location types.
                autocomplete1 = new google.maps.places.Autocomplete(
                    /** @type {!HTMLInputElement} */(document.getElementById('place_from')),
                    { types: ['geocode'] });

                // When the user selects an address from the dropdown, populate the address
                // fields in the form.
                autocomplete1.addListener('place_changed', fillInAddressFrom);

                autocomplete2 = new google.maps.places.Autocomplete(
                    /** @type {!HTMLInputElement} */(document.getElementById('place_to')),
                    { types: ['geocode'] });

                // When the user selects an address from the dropdown, populate the address
                // fields in the form.
                autocomplete2.addListener('place_changed', fillInAddressTo);
            }

            function fillInAddressFrom() {
                // Get the place details from the autocomplete object.
                var place = autocomplete1.getPlace();
                console.log(place.geometry.location.lat());
                console.log(place.geometry.location.lng());

            }

            function fillInAddressTo() {
                // Get the place details from the autocomplete object.
                var place = autocomplete2.getPlace();
                console.log(place.geometry.location.lat());
                console.log(place.geometry.location.lng());
            }

            // Bias the autocomplete object to the user's geographical location,
            // as supplied by the browser's 'navigator.geolocation' object.
            function geolocate() {
                alert("abc");
                if (navigator.geolocation) {
                    navigator.geolocation.getCurrentPosition(function (position) {
                        var geolocation = {
                            lat: position.coords.latitude,
                            lng: position.coords.longitude
                        };
                        var circle = new google.maps.Circle({
                            center: geolocation,
                            radius: position.coords.accuracy
                        });
                        autocomplete1.setBounds(circle.getBounds());
                        autocomplete2.setBounds(circle.getBounds());
                    });
                }
            }


           
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyA6ThAukLIKJS4cF0xAom43OykaY_4lZ_w&libraries=places,geometry&callback=initAutocomplete" async defer></script>
    </div>
    <!--Main Content End-->

</asp:Content>
