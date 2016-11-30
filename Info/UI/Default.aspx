<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Plugins/Revolution-Slider/revolution-slider.css" rel="stylesheet" type="text/css" />
    <link href="Plugins/OwlCarousel/owlcarousel.css" type="text/css" rel="stylesheet" />
    <link href="Plugins/FancyBox/fancybox.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="rsDemoWrapper">
        <div class="tp-banner-container">
            <div class="tp-banner">
                <ul>
                    <li data-transition="fade" data-slotamount="7" data-masterspeed="1500">
                        <img src="Images/slider1.jpg" data-bgfit="cover" data-bgposition="left top" data-bgrepeat="no-repeat" alt="" />
                        <div class="tp-caption large_bold_white customin customout tp-resizeme"
                            data-x="center" data-hoffset="0"
                            data-y="200"
                            data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:5;scaleY:5;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                            data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0.75;scaleY:0.75;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                            data-speed="600"
                            data-start="1400"
                            data-easing="Power4.easeOut"
                            data-endspeed="600"
                            data-endeasing="Power0.easeIn"
                            style="z-index: 3">
                            Peyman Moquette
                        </div>
                        <div class="tp-caption medium_light_white customin customout tp-resizeme"
                            data-x="center" data-hoffset="0"
                            data-y="bottom" data-voffset="-200"
                            data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:5;scaleY:5;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                            data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0.75;scaleY:0.75;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                            data-speed="600"
                            data-start="1700"
                            data-easing="Power4.easeOut"
                            data-endspeed="600"
                            data-endeasing="Power0.easeIn"
                            style="z-index: 4">
                            The Best Of Moquette
                        </div>
                    </li>
                    <li data-transition="fade" data-slotamount="7" data-masterspeed="1500">
                        <img src="Images/slider2.jpg" data-bgfit="cover" data-bgposition="left top" data-bgrepeat="no-repeat" alt="" />
                        <div class="tp-caption largeblackbg skewfromleft tp-resizeme"
                            data-x="20" data-hoffset="0"
                            data-y="bottom" data-voffset="-250"
                            data-speed="600"
                            data-start="1400"
                            data-easing="Power4.easeOut"
                            data-endspeed="600"
                            data-endeasing="Power0.easeIn"
                            style="z-index: 3">
                            Enter the Future
                        </div>
                        <div class="tp-caption medium_light_white skewfromleft tp-resizeme"
                            data-x="20" data-hoffset="0"
                            data-y="330"
                            data-speed="600"
                            data-start="1700"
                            data-easing="Power4.easeOut"
                            data-endspeed="600"
                            data-endeasing="Power0.easeIn"
                            style="z-index: 3">
                            Made With Love
                        </div>
                    </li>
                    <li data-transition="fade" data-slotamount="7" data-masterspeed="1500">
                        <img src="Images/slider3.jpg" data-bgfit="cover" data-bgposition="left top" data-bgrepeat="no-repeat" alt="" />
                        <div class="tp-caption largeblackbg skewfromleft tp-resizeme"
                            data-x="20" data-hoffset="0"
                            data-y="bottom" data-voffset="-250"
                            data-speed="600"
                            data-start="1400"
                            data-easing="Power4.easeOut"
                            data-endspeed="600"
                            data-endeasing="Power0.easeIn"
                            style="z-index: 3">
                            Beautiful And Flexible
                        </div>
                        <div class="tp-caption medium_light_white skewfromleft tp-resizeme"
                            data-x="20" data-hoffset="0"
                            data-y="330"
                            data-speed="600"
                            data-start="1700"
                            data-easing="Power4.easeOut"
                            data-endspeed="600"
                            data-endeasing="Power0.easeIn"
                            style="z-index: 3">
                            More Than 100 Portfolio
                        </div>
                    </li>
                    <li data-transition="fade" data-slotamount="7" data-masterspeed="1500">
                        <img src="Images/slider4.jpg" data-bgfit="cover" data-bgposition="left top" data-bgrepeat="no-repeat" alt="" />
                        <div class="tp-caption largeblackbg skewfromleft tp-resizeme"
                            data-x="20" data-hoffset="0"
                            data-y="bottom" data-voffset="-250"
                            data-speed="600"
                            data-start="1400"
                            data-easing="Power4.easeOut"
                            data-endspeed="600"
                            data-endeasing="Power0.easeIn"
                            style="z-index: 3">
                            Beautiful Colors
                        </div>
                        <div class="tp-caption medium_light_white skewfromleft tp-resizeme"
                            data-x="20" data-hoffset="0"
                            data-y="330"
                            data-speed="600"
                            data-start="1700"
                            data-easing="Power4.easeOut"
                            data-endspeed="600"
                            data-endeasing="Power0.easeIn"
                            style="z-index: 3">
                            It Has Beautiful Color Schemes
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="box-title col-xs-12 text-center mb60">
        <h2 class="mb25">Peyman Moquette, The Best In Mashhad</h2>
        <h3>Along With The New Technology World</h3>
    </div>
    <div class="col-sm-4">
        <article class="box-icon">
            <a href="About-Us.aspx" title="">
                <div class="img-border">
                    <img class="img-circle img-responsive" src="Images/team-corporate-1.jpg" width="172" height="172" title="" alt="" />
                </div>
                <h3 class="mb25">Success Stories</h3>
                <p>Your Text Goes Here. Your Text Goes Here. Your Text Goes Here.</p>
            </a>
        </article>
    </div>
    <div class="col-sm-4">
        <article class="box-icon">
            <a href="About-Us.aspx" title="">
                <div class="img-border">
                    <img class="img-circle img-responsive" src="Images/team-corporate-2.jpg" width="172" height="172" title="" alt="" />
                </div>
                <h3 class="mb25">Custom Design</h3>
                <p>Your Text Goes Here. Your Text Goes Here. Your Text Goes Here.</p>
            </a>
        </article>
    </div>
    <div class="col-sm-4">
        <article class="box-icon">
            <a href="About-Us.aspx" title="">
                <div class="img-border">
                    <img class="img-circle img-responsive" src="Images/team-corporate-3.jpg" width="172" height="172" title="" alt="" />
                </div>
                <h3 class="mb25">Customer Support</h3>
                <p>Your Text Goes Here. Your Text Goes Here. Your Text Goes Here.</p>
            </a>
        </article>
    </div>
    <div class="clearfix"></div>
    <div class="col-xs-12">
        <hr class="line-lines text-center" />
    </div>
    <div class="clearfix"></div>
    <div class="box-title col-xs-12 text-center mb60">
        <h2 class="mb25">The Company's Pruducts</h2>
        <h3>New Listings Pruducts</h3>
    </div>
    <div class="col-xs-12">
        <section class="portfolio-mosaic">
            <div class="row">
                <div class="col-sm-6 col-md-3">
                    <article class="first text-center">
                        <a href="Products.aspx" title="">
                            <h2>Last Products</h2>
                        </a>
                    </article>
                </div>
                <div class="col-sm-6 col-md-3">
                    <article>
                        <figure>
                            <a href="Show-Product.aspx" title="">
                                <img class="img-responsive" src="Images/product02.jpg" width="700" height="545" title="" alt="" />
                            </a>
                            <figcaption>
                                <a href="Show-Product.aspx" title="">
                                    <h3>Title of Product</h3>
                                </a>
                                <p>Product Description. Product Description Goes Here. So Product Description Goes In Here. So Product Description Goes In Here.</p>
                            </figcaption>
                        </figure>
                    </article>
                </div>
                <div class="col-sm-6 col-md-3">
                    <article>
                        <figure>
                            <a href="Show-Product.aspx" title="">
                                <img class="img-responsive" src="Images/product03.jpg" width="700" height="545" title="" alt="" />
                            </a>
                            <figcaption>
                                <a href="Show-Product.aspx" title="">
                                    <h3>Title of Product</h3>
                                </a>
                                <p>Product Description. Product Description Goes Here. So Product Description Goes In Here. So Product Description Goes In Here.</p>
                            </figcaption>
                        </figure>
                    </article>
                </div>
                <div class="col-sm-6 col-md-3">
                    <article>
                        <figure>
                            <a href="Show-Product.aspx" title="">
                                <img class="img-responsive" src="Images/product01.jpg" width="700" height="545" title="" alt="" />
                            </a>
                            <figcaption>
                                <a href="Show-Product.aspx" title="">
                                    <h3>Title of Product</h3>
                                </a>
                                <p>Product Description. Product Description Goes Here. So Product Description Goes In Here. So Product Description Goes In Here.</p>
                            </figcaption>
                        </figure>
                    </article>
                </div>
                <div class="col-sm-6 col-md-3">
                    <article>
                        <figure>
                            <a href="Show-Product.aspx" title="">
                                <img class="img-responsive" src="Images/product04.jpg" width="700" height="545" title="" alt="" />
                            </a>
                            <figcaption>
                                <a href="Show-Product.aspx" title="">
                                    <h3>Title of Product</h3>
                                </a>
                                <p>Product Description. Product Description Goes Here. So Product Description Goes In Here. So Product Description Goes In Here.</p>
                            </figcaption>
                        </figure>
                    </article>
                </div>
                <div class="col-sm-6 col-md-3">
                    <article>
                        <figure>
                            <a href="Show-Product.aspx" title="">
                                <img class="img-responsive" src="Images/product06.jpg" width="700" height="545" title="" alt="" />
                            </a>
                            <figcaption>
                                <a href="Show-Product.aspx" title="">
                                    <h3>Title of Product</h3>
                                </a>
                                <p>Product Description. Product Description Goes Here. So Product Description Goes In Here. So Product Description Goes In Here.</p>
                            </figcaption>
                        </figure>
                    </article>
                </div>
                <div class="col-sm-6 col-md-3">
                    <article>
                        <figure>
                            <a href="Show-Product.aspx" title="">
                                <img class="img-responsive" src="Images/product07.jpg" width="700" height="545" title="" alt="" />
                            </a>
                            <figcaption>
                                <a href="Show-Product.aspx" title="">
                                    <h3>Title of Product</h3>
                                </a>
                                <p>Product Description. Product Description Goes Here. So Product Description Goes In Here. So Product Description Goes In Here.</p>
                            </figcaption>
                        </figure>
                    </article>
                </div>
                <div class="col-sm-6 col-md-3">
                    <article>
                        <figure>
                            <a href="Show-Product.aspx" title="">
                                <img class="img-responsive" src="Images/product05.jpg" width="700" height="545" title="" alt="" />
                            </a>
                            <figcaption>
                                <a href="Show-Product.aspx" title="">
                                    <h3>Title of Product</h3>
                                </a>
                                <p>Product Description. Product Description Goes Here. So Product Description Goes In Here. So Product Description Goes In Here.</p>
                            </figcaption>
                        </figure>
                    </article>
                </div>
            </div>
            <div class="clearfix"></div>
        </section>
    </div>
    <div class="clearfix"></div>
    <div class="col-xs-12">
        <hr class="line-lines text-center" />
    </div>
    <div class="clearfix"></div>
    <div class="box-title col-xs-12 text-center mb60">
        <h2 class="mb25">Last News</h2>
        <h3>Lastest Company News Goes Here</h3>
    </div>
    <div class="col-xs-12">
        <div class="box-items mb60">
            <div class="row">
                <article class="col-sm-6 col-md-3">
                    <figure>
                        <a href="Show-Blog.aspx" title="">
                            <img class="img-responsive" src="Images/news01.jpg" width="700" height="550" title="" alt="" />
                        </a>
                        <figcaption>
                            <ul>
                                <li>
                                    <a href="Show-Blog.aspx" title="Views">
                                        <i class="fa fa-eye"></i>150
                                    </a>
                                </li>
                                <li>
                                    <a href="Show-Blog.aspx" title="Comments">
                                        <i class="fa fa-comment"></i>4
                                    </a>
                                </li>
                                <li class="last">
                                    <a href="Show-Blog.aspx" title="Show">
                                        <i class="fa fa-link"></i>
                                    </a>
                                </li>
                            </ul>
                        </figcaption>
                    </figure>
                    <section class="box-content">
                        <h3>
                            <a href="Show-Blog.aspx" title="">News Title Goes Here. News Title Goes Here.</a>
                        </h3>
                        <p>The Text Goes Here. The Text Goes Here. The Text Goes Here. The Text Goes Here. The Text Goes Here.</p>
                        <a href="Show-Blog.aspx" title="">
                            <i class="fa fa-long-arrow-right"></i>
                            Read More
                        </a>
                        <div class="clearfix"></div>
                    </section>
                </article>
                <article class="col-sm-6 col-md-3">
                    <figure>
                        <a href="Show-Blog.aspx" title="">
                            <img class="img-responsive" src="Images/news02.jpg" width="700" height="550" title="" alt="" />
                        </a>
                        <figcaption>
                            <ul>
                                <li>
                                    <a href="Show-Blog.aspx" title="Views">
                                        <i class="fa fa-eye"></i>150
                                    </a>
                                </li>
                                <li>
                                    <a href="Show-Blog.aspx" title="Comments">
                                        <i class="fa fa-comment"></i>4
                                    </a>
                                </li>
                                <li class="last">
                                    <a href="Show-Blog.aspx" title="Show">
                                        <i class="fa fa-link"></i>
                                    </a>
                                </li>
                            </ul>
                        </figcaption>
                    </figure>
                    <section class="box-content">
                        <h3>
                            <a href="Show-Blog.aspx" title="">News Title Goes Here. News Title Goes Here.</a>
                        </h3>
                        <p>The Text Goes Here. The Text Goes Here. The Text Goes Here. The Text Goes Here. The Text Goes Here.</p>
                        <a href="Show-Blog.aspx" title="">
                            <i class="fa fa-long-arrow-right"></i>
                            Read More
                        </a>
                        <div class="clearfix"></div>
                    </section>
                </article>
                <article class="col-sm-6 col-md-3">
                    <figure>
                        <a href="Show-Blog.aspx" title="">
                            <img class="img-responsive" src="Images/news03.jpg" width="700" height="550" title="" alt="" />
                        </a>
                        <figcaption>
                            <ul>
                                <li>
                                    <a href="Show-Blog.aspx" title="Views">
                                        <i class="fa fa-eye"></i>150
                                    </a>
                                </li>
                                <li>
                                    <a href="Show-Blog.aspx" title="Comments">
                                        <i class="fa fa-comment"></i>4
                                    </a>
                                </li>
                                <li class="last">
                                    <a href="Show-Blog.aspx" title="Show">
                                        <i class="fa fa-link"></i>
                                    </a>
                                </li>
                            </ul>
                        </figcaption>
                    </figure>
                    <section class="box-content">
                        <h3>
                            <a href="Show-Blog.aspx" title="">News Title Goes Here. News Title Goes Here.</a>
                        </h3>
                        <p>The Text Goes Here. The Text Goes Here. The Text Goes Here. The Text Goes Here. The Text Goes Here.</p>
                        <a href="Show-Blog.aspx" title="">
                            <i class="fa fa-long-arrow-right"></i>
                            Read More
                        </a>
                        <div class="clearfix"></div>
                    </section>
                </article>
                <article class="col-sm-6 col-md-3">
                    <figure>
                        <a href="Show-Blog.aspx" title="">
                            <img class="img-responsive" src="Images/news04.jpg" width="700" height="550" title="" alt="" />
                        </a>
                        <figcaption>
                            <ul>
                                <li>
                                    <a href="Show-Blog.aspx" title="Views">
                                        <i class="fa fa-eye"></i>150
                                    </a>
                                </li>
                                <li>
                                    <a href="Show-Blog.aspx" title="Comments">
                                        <i class="fa fa-comment"></i>4
                                    </a>
                                </li>
                                <li class="last">
                                    <a href="Show-Blog.aspx" title="Show">
                                        <i class="fa fa-link"></i>
                                    </a>
                                </li>
                            </ul>
                        </figcaption>
                    </figure>
                    <section class="box-content">
                        <h3>
                            <a href="Show-Blog.aspx" title="">News Title Goes Here. News Title Goes Here.</a>
                        </h3>
                        <p>The Text Goes Here. The Text Goes Here. The Text Goes Here. The Text Goes Here. The Text Goes Here.</p>
                        <a href="Show-Blog.aspx" title="">
                            <i class="fa fa-long-arrow-right"></i>
                            Read More
                        </a>
                        <div class="clearfix"></div>
                    </section>
                </article>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <div id="owl-demo" class="owl-carousel col-xs-12">
        <div class="item">
            <div class="offer-focus">
                <img src="Images/thumb-certi01.jpg" title="" alt="" />
                <div class="offer-filter">
                    <div class="offer-hover">
                        <div class="offer-hover2">
                            <a class="fancybox" href="Images/certi01.jpg" data-fancybox-group="gallery" title="Title 1 Certification">
                                <i class="fa fa-search" title="Zoom"></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="item">
            <div class="offer-focus">
                <img src="Images/thumb-certi02.jpg" title="" alt="" />
                <div class="offer-filter">
                    <div class="offer-hover">
                        <div class="offer-hover2">
                            <a class="fancybox" href="Images/certi02.jpg" data-fancybox-group="gallery" title="Title 2 Certification">
                                <i class="fa fa-search" title="Zoom"></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="item">
            <div class="offer-focus">
                <img src="Images/thumb-certi03.jpg" title="" alt="" />
                <div class="offer-filter">
                    <div class="offer-hover">
                        <div class="offer-hover2">
                            <a class="fancybox" href="Images/certi03.jpg" data-fancybox-group="gallery" title="Title 3 Certification">
                                <i class="fa fa-search" title="Zoom"></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="item">
            <div class="offer-focus">
                <img src="Images/thumb-certi04.jpg" title="" alt="" />
                <div class="offer-filter">
                    <div class="offer-hover">
                        <div class="offer-hover2">
                            <a class="fancybox" href="Images/certi04.jpg" data-fancybox-group="gallery" title="Title 4 Certification">
                                <i class="fa fa-search" title="Zoom"></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="item">
            <div class="offer-focus">
                <img src="Images/thumb-certi05.jpg" title="" alt="" />
                <div class="offer-filter">
                    <div class="offer-hover">
                        <div class="offer-hover2">
                            <a class="fancybox" href="Images/certi05.jpg" data-fancybox-group="gallery" title="Title 5 Certification">
                                <i class="fa fa-search" title="Zoom"></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="item">
            <div class="offer-focus">
                <img src="Images/thumb-certi06.jpg" title="" alt="" />
                <div class="offer-filter">
                    <div class="offer-hover">
                        <div class="offer-hover2">
                            <a class="fancybox" href="Images/certi06.jpg" data-fancybox-group="gallery" title="Title 6 Certification">
                                <i class="fa fa-search" title="Zoom"></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="item">
            <div class="offer-focus">
                <img src="Images/thumb-certi07.jpg" title="" alt="" />
                <div class="offer-filter">
                    <div class="offer-hover">
                        <div class="offer-hover2">
                            <a class="fancybox" href="Images/certi07.jpg" data-fancybox-group="gallery" title="Title 7 Certification">
                                <i class="fa fa-search" title="Zoom"></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="item">
            <div class="offer-focus">
                <img src="Images/thumb-certi08.jpg" title="" alt="" />
                <div class="offer-filter">
                    <div class="offer-hover">
                        <div class="offer-hover2">
                            <a class="fancybox" href="Images/certi08.jpg" data-fancybox-group="gallery" title="Title 8 Certification">
                                <i class="fa fa-search" title="Zoom"></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="Plugins/Revolution-Slider/themepunch.plugins.min.js" type="text/javascript"></script>
    <script src="Plugins/Revolution-Slider/themepunch.revolution.min.js" type="text/javascript"></script>
    <script src="Plugins/OwlCarousel/owlcarousel.js" type="text/javascript"></script>
    <script src="Plugins/FancyBox/fancybox.js" type="text/javascript"></script>
    <script src="Plugins/FancyBox/mousewheel-3.0.6.js" type="text/javascript"></script>
</asp:Content>
