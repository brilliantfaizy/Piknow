<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="booking.aspx.cs" Inherits="w.booking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!--Banner Start-->
            <div class="cp_inner-banner">
                <img src="images/banner/inner-banner-img-08.jpg" alt="">
                <!--Inner Banner Holder Start-->
                <div class="cp-inner-banner-holder">
                    <div class="container">
                    <h2>View a booking</h2>
                      <!--Breadcrumb Start-->
                       <ul class="breadcrumb">
                         <li><a href="default.aspx">Home</a></li>
                         <li class="active">View a booking</li>
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

                <!--Booking Section Start-->
                <section class="cp-booking-section cp-booking-section2 pd-tb80">
                    <div class="container">
                         <div class="cp-heading-style1">
                            <h2>Book <span>Car Now</span></h2>
                        </div>
                        <!--Booking Form Outer Start-->
                        <div class="cp-booking-form-outer cp-booking-form-outer2">
                             <div method="get">
                                <div class="cp-booking-outer">
                                    <div class="booking-inner-holder">
                                        <label>Pick-up Location</label>
                                        <select>
                                            <option value="">UK</option>
                                            <option value="">USA</option>
                                            <option value="">UAE</option>
                                            <option value="">Canada</option>
                                            <option value="">Denmark</option>
                                            <option value="">Spain</option>
                                        </select>
                                    </div>
                                    <div class="booking-inner-holder">
                                        <label>Pick-up Date</label>
                                        <div class="booking-date">
                                            <div class="inner">
                                                <input type="text" placeholder="31">
                                                <span>Day</span> 
                                            </div>
                                            <div class="inner">
                                                <input type="text" placeholder="10">
                                                <span>Month</span> 
                                            </div>
                                            <div class="inner">
                                                <input type="text" placeholder="2016">
                                                <span>Year</span> 
                                            </div>
                                            <div class="inner inner2">
                                                <span>at</span> 
                                            </div>
                                            <div class="inner">
                                               <select>
                                                   <option value="">20</option>
                                                   <option value="">19</option>
                                                   <option value="">18</option>
                                                   <option value="">17</option>
                                                   <option value="">16</option>
                                               </select>
                                                <span>Hours</span> 
                                            </div>
                                            <div class="inner">
                                                <select>
                                                   <option value="">10</option>
                                                   <option value="">11</option>
                                                   <option value="">12</option>
                                                   <option value="">13</option>
                                                   <option value="">14</option>
                                               </select>
                                                <span>Minutas</span> 
                                            </div>
                                            <div class="inner inner2">
                                                <i class="fa fa-calendar-check-o"></i>
                                            </div>
                                        </div>
                                    </div>
                                  
                                </div>
                               
                                <!--Booking Outer Start-->
                                <div class="cp-booking-outer">
                                    <div class="booking-inner-holder">
                                        <label>Drop-up Location</label>
                                        <select>
                                            <option value="">Uk</option>
                                            <option value="">USA</option>
                                            <option value="">UAE</option>
                                            <option value="">Canada</option>
                                            <option value="">Denmark</option>
                                            <option value="">Spain</option>
                                        </select>
                                    </div>
                                    <div class="booking-inner-holder">
                                        <label>Drop-off Date </label>
                                        <div class="booking-date">
                                            <div class="inner">
                                                <input type="text" placeholder="31">
                                                <span>Day</span> 
                                            </div>
                                            <div class="inner">
                                                <input type="text" placeholder="10">
                                                <span>Month</span> 
                                            </div>
                                            <div class="inner">
                                                <input type="text" placeholder="2016">
                                                <span>Year</span> 
                                            </div>
                                            <div class="inner inner2">
                                                <span>at</span> 
                                            </div>
                                            <div class="inner">
                                               <select>
                                                   <option value="">20</option>
                                                   <option value="">19</option>
                                                   <option value="">18</option>
                                                   <option value="">17</option>
                                                   <option value="">16</option>
                                               </select>
                                                <span>Hours</span> 
                                            </div>
                                            <div class="inner">
                                                <select>
                                                   <option value="">10</option>
                                                   <option value="">11</option>
                                                   <option value="">12</option>
                                                   <option value="">13</option>
                                                   <option value="">14</option>
                                               </select>
                                                <span>Minutas</span> 
                                            </div>
                                            <div class="inner inner2">
                                                <i class="fa fa-calendar-check-o"></i>
                                            </div>
                                        </div>
                                    </div>
                                </div><!--Booking Outer End-->

                                <!--Booking Outer Start-->
                                <div class="cp-booking-outer">
                                    <div class="row">
                                        <div class="col-md-8 col-sm-8">
                                            <div class="booking-inner-holder booking-inner-holder2">
                                                <label>License type:</label>
                                                <select>
                                                    <option value="">Full European Liense</option>
                                                    <option value="">Full UK Liense</option>
                                                    <option value="">Full UAE Liense</option>
                                                    <option value="">Full USA Liense</option>
                                                </select>
                                            </div>
                                            <div class="booking-inner-holder booking-inner-holder2">
                                                <label>Currency:</label>
                                                <select>
                                                    <option value="">Dollar</option>
                                                    <option value="">Euro</option>
                                                    <option value="">Armenian dram</option>
                                                    <option value="">Bahraini dinar</option>
                                                    <option value="">Pound</option>
                                                </select>
                                            </div>
                                            <div class="booking-inner-holder booking-inner-holder2">
                                                <label>Drivers age:</label>
                                                <select>
                                                    <option value="">20</option>
                                                    <option value="">22</option>
                                                    <option value="">25</option>
                                                    <option value="">30</option>
                                                    <option value="">34</option>
                                                    <option value="">37</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="col-md-4 col-sm-4">
                                            <div class="booking-check-box">
                                                <span>Car Type</span>
                                                <label><input type="checkbox"> Standart Cars </label>
                                                <label><input type="checkbox"> Convertibles </label>
                                                <label><input type="checkbox"> Luxury </label>
                                                <label><input type="checkbox"> Cars </label>
                                                <label><input type="checkbox"> Vans </label>
                                                <label><input type="checkbox"> SUVs</label>
                                            </div>
                                        </div>
                                    </div>
                                </div><!--Booking Outer End-->
                                <button class="cp-btn-style1" type="submit">Search Now</button>
                            </div>
                        </div><!--Booking Form Outer End-->
                    </div>
                </section><!--Booking Section End-->

            </div><!--Main Content End-->

</asp:Content>
