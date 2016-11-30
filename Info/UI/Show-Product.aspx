<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Show-Product.aspx.cs" Inherits="Show_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Plugins/FancyBox/fancybox.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <header class="page-header">
        <div class="container">
            <div class="row">
                <div class="col-xs-5 col-sm-6">
                    <h1>Show Product</h1>
                </div>
                <div class="col-xs-7 col-sm-6">
                    <div class="breadcrumbs">
                        <a href="/" title="">Home</a>
                        <i>/</i>
                        <a href="Products.aspx" title="">Products</a>
                        <i>/</i>
                        <span>Show Product</span>
                    </div>
                </div>
            </div>
        </div>
    </header>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="col-sm-4 col-sm-push-8">
        <div class="offer-focus">
            <img class="img-responsive" src="Images/product02.jpg" title="" alt="" />
            <div class="offer-filter">
                <div class="offer-hover">
                    <div class="offer-hover2">
                        <a class="fancybox" href="Images/product02.jpg" data-fancybox-group="gallery" title="Product Name 1">
                            <i class="fa fa-search" title="Zom"></i>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-sm-8 col-sm-pull-4">
        <div class="product-info">
            <h2 class="title-design mb25">Product Name 1</h2>
            <ul>
                <li>
                    <span>Code:</span>
                    309
                </li>
                <li>
                    <span>Factory:</span>
                    Peyman Moquette
                </li>
                <li>
                    <span>Release Date:</span>
                    29 oct. 2016
                </li>
                <li>
                    <span>Colors:</span>
                    <ul>
                        <li>
                            <i class="fa fa-check"></i>
                            White
                        </li>
                        <li>
                            <i class="fa fa-check"></i>
                            Gray
                        </li>
                        <li>
                            <i class="fa fa-check"></i>
                            Violet
                        </li>
                        <li>
                            <i class="fa fa-check"></i>
                            Navy blue
                        </li>
                    </ul>
                </li>
            </ul>
            <div class="clearfix"></div>
            <div class="rating-box">
                <i class="fa fa-info-circle" title="Please click to rate"></i>
                <span>Rating 5.00 out of 5 by 11 person</span>
                <div class="offer-rate">
                    <i class="fa fa-star Tooltip" data-placement="top" data-toggle="tooltip" data-original-title="Bad" title=""></i>
                    <i class="fa fa-star Tooltip" data-placement="top" data-toggle="tooltip" data-original-title="Weak" title=""></i>
                    <i class="fa fa-star Tooltip" data-placement="top" data-toggle="tooltip" data-original-title="Normal" title=""></i>
                    <i class="fa fa-star-o Tooltip" data-placement="top" data-toggle="tooltip" data-original-title="Good" title=""></i>
                    <i class="fa fa-star-o Tooltip" data-placement="top" data-toggle="tooltip" data-original-title="Excellent" title=""></i>
                </div>
            </div>
            <p>Here is the original product description. Here is the original product description. Here is the original product description. Here is the original product description.</p>
            <p>Here is the original product description. Here is the original product description. Here is the original product description.</p>
            <a class="btn btn-lg btn-submit" href="#" title="">
                <i class="fa fa-download"></i>
                Download Catalog
            </a>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="col-xs-12">
        <div class="content-dynamic">
            <h3>More Information About Product:</h3>
            <p>Here is more information about the product. Here is more information about the product. Here is more information about the product. Here is more information about the product. Here is more information about the product. Here is more information about the product. Here is more information about the product. Here is more information about the product.</p>
            <p>Here is more information about the product. Here is more information about the product. Here is more information about the product. Here is more information about the product. Here is more information about the product. Here is more information about the product.</p>
            <img class="img-responsive" src="Images/product02.jpg" style="width: 35%; margin: 10px auto 20px;" title="" alt="" />
            <h3>Specifications:</h3>
            <p>
                1. Specifications goes here 1
                        <br />
                2. Specifications goes here 2
                        <br />
                3. Specifications goes here 3
                        <br />
                4. Specifications goes here 4
                        <br />
                5. Specifications goes here 5
            </p>
            <p>Here is more information about the product. Here is more information about the product. Here is more information about the product. Here is more information about the product. Here is more information about the product. Here is more information about the product. Here is more information about the product. Here is more information about the product.</p>
            <p>Here is more information about the product. Here is more information about the product. Here is more information about the product. Here is more information about the product. Here is more information about the product. Here is more information about the product.</p>
            <img class="img-responsive" src="Images/product03.jpg" style="width: 35%; margin: 10px auto 20px;" title="" alt="" />
            <img class="img-responsive" src="Images/product04.jpg" style="width: 35%; margin: 10px auto 20px;" title="" alt="" />
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="col-xs-12">
        <hr />
    </div>
    <div class="col-sm-12 col-md-8">
        <div class="comment-box">
            <h3>Comments (5)</h3>
            <div class="media">
                <a>
                    <img src="Images/avatar.png" title="" alt="" />
                </a>
                <div class="media-body">
                    <div>
                        <h4 class="media-heading">Joey Tribbiani</h4>
                        <div class="offer-rate">
                            <i class="fa fa-star"></i>
                            <i class="fa fa-star"></i>
                            <i class="fa fa-star-o"></i>
                            <i class="fa fa-star-o"></i>
                            <i class="fa fa-star-o"></i>
                        </div>
                    </div>
                    <span>February 29, 2012</span>
                    <div>Cras et quam lorem. Fusce rhoncus consequat nulla ut gravida. Sed adipiscing, lacus ac commodo scelerisque, est erat eleifend augue, nec viverra ligula lacus sed arcu</div>
                </div>
            </div>
            <div class="media">
                <a>
                    <img src="Images/avatar.png" title="" alt="" />
                </a>
                <div class="media-body">
                    <div>
                        <h4 class="media-heading">Monica Geller</h4>
                    </div>
                    <span>February 29, 2012</span>
                    <div>Cras et quam lorem. Fusce rhoncus consequat nulla ut gravida. Sed adipiscing, lacus ac commodo scelerisque, est erat eleifend augue, nec viverra ligula lacus sed arcu</div>
                </div>
            </div>
            <div class="media">
                <a>
                    <img src="Images/avatar.png" title="" alt="" />
                </a>
                <div class="media-body">
                    <div>
                        <h4 class="media-heading">Phoebe Buffay</h4>
                        <div class="offer-rate">
                            <i class="fa fa-star"></i>
                            <i class="fa fa-star-o"></i>
                            <i class="fa fa-star-o"></i>
                            <i class="fa fa-star-o"></i>
                            <i class="fa fa-star-o"></i>
                        </div>
                    </div>
                    <span>February 29, 2012</span>
                    <div>Cras et quam lorem. Fusce rhoncus consequat nulla ut gravida. Sed adipiscing, lacus ac commodo scelerisque, est erat eleifend augue, nec viverra ligula lacus sed arcu</div>
                </div>
            </div>
            <div class="media">
                <a>
                    <img src="Images/avatar.png" title="" alt="" />
                </a>
                <div class="media-body">
                    <div>
                        <h4 class="media-heading">Chandler Bing</h4>
                        <div class="offer-rate">
                            <i class="fa fa-star"></i>
                            <i class="fa fa-star"></i>
                            <i class="fa fa-star"></i>
                            <i class="fa fa-star"></i>
                            <i class="fa fa-star"></i>
                        </div>
                    </div>
                    <span>February 29, 2012</span>
                    <div>Cras et quam lorem. Fusce rhoncus consequat nulla ut gravida. Sed adipiscing, lacus ac commodo scelerisque, est erat eleifend augue, nec viverra ligula lacus sed arcu</div>
                </div>
            </div>
            <div class="media">
                <a>
                    <img src="Images/avatar.png" title="" alt="" />
                </a>
                <div class="media-body">
                    <div>
                        <h4 class="media-heading">Ross Geller</h4>
                    </div>
                    <span>February 29, 2012</span>
                    <div>Cras et quam lorem. Fusce rhoncus consequat nulla ut gravida. Sed adipiscing, lacus ac commodo scelerisque, est erat eleifend augue, nec viverra ligula lacus sed arcu</div>
                </div>
            </div>
            <hr />
            <h3>Post A Comment</h3>
            <form class="form-contact" role="form">
                <%-- <div class="alert alert-success fade in">
                    <a class="close" href="#" title="Close" aria-label="close" data-dismiss="alert">×</a>
                    <strong>Warning!</strong> Best check yo self, you're not looking too good.
                </div>
                <div class="alert alert-info fade in">
                    <a class="close" href="#" title="Close" aria-label="close" data-dismiss="alert">×</a>
                    <strong>Warning!</strong> Best check yo self, you're not looking too good.
                </div>
                <div class="alert alert-warning fade in">
                    <a class="close" href="#" title="Close" aria-label="close" data-dismiss="alert">×</a>
                    <strong>Warning!</strong> Best check yo self, you're not looking too good.
                </div>
                <div class="alert alert-danger fade in">
                    <a class="close" href="#" title="Close" aria-label="close" data-dismiss="alert">×</a>
                    <strong>Warning!</strong> Best check yo self, you're not looking too good.
                </div>--%>
                <div class="form-group">
                    <label>Name:</label>
                    <input type="text" class="form-control" placeholder="Enter Name" />
                </div>
                <div class="form-group">
                    <label>Email:</label>
                    <input type="text" class="form-control" placeholder="Enter Email" />
                </div>
                <div class="form-group">
                    <label>Comment:</label>
                    <textarea class="form-control" rows="4" placeholder="Enter Your Message …"></textarea>
                </div>
                <div class="form-group rating-box">
                    <i class="fa fa-info-circle" title="Please click to rate"></i>
                    <span>Rating 5.00 out of 5 by 11 person</span>
                    <div class="offer-rate">
                        <i class="fa fa-star Tooltip" data-placement="top" data-toggle="tooltip" data-original-title="Bad" title=""></i>
                        <i class="fa fa-star Tooltip" data-placement="top" data-toggle="tooltip" data-original-title="Weak" title=""></i>
                        <i class="fa fa-star Tooltip" data-placement="top" data-toggle="tooltip" data-original-title="Normal" title=""></i>
                        <i class="fa fa-star-o Tooltip" data-placement="top" data-toggle="tooltip" data-original-title="Good" title=""></i>
                        <i class="fa fa-star-o Tooltip" data-placement="top" data-toggle="tooltip" data-original-title="Excellent" title=""></i>
                    </div>
                </div>
                <div class="form-group">
                    <button type="submit" class="btn btn-submit btn-lg">Submit</button>
                </div>
            </form>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="col-xs-12">
        <hr />
    </div>
    <div class="col-xs-12">
        <h3 class="title-design mb25">Several other product</h3>
    </div>
    <div class="clearfix"></div>
    <div class="col-xs-6 col-md-3">
        <div class="products">
            <div class="offer-focus">
                <img class="img-responsive" src="Images/product01.jpg" title="" alt="" />
                <div class="offer-filter">
                    <div class="offer-hover">
                        <div class="offer-hover2">
                            <a class="fancybox" href="Show-Product.aspx" title="">
                                <i class="fa fa-link" title="View Product"></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <h3>
                <a href="Show-Product.aspx" title="">Product Name 1
                    <span>Code Product: 4090</span>
                </a>
            </h3>
        </div>
    </div>
    <div class="col-xs-6 col-md-3">
        <div class="products">
            <div class="offer-focus">
                <img class="img-responsive" src="Images/product02.jpg" title="" alt="" />
                <div class="offer-filter">
                    <div class="offer-hover">
                        <div class="offer-hover2">
                            <a class="fancybox" href="Show-Product.aspx" title="">
                                <i class="fa fa-link" title="View Product"></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <h3>
                <a href="Show-Product.aspx" title="">Product Name 2
                    <span>Code Product: 309</span>
                </a>
            </h3>
        </div>
    </div>
    <div class="col-xs-6 col-md-3">
        <div class="products">
            <div class="offer-focus">
                <img class="img-responsive" src="Images/product03.jpg" title="" alt="" />
                <div class="offer-filter">
                    <div class="offer-hover">
                        <div class="offer-hover2">
                            <a class="fancybox" href="Show-Product.aspx" title="">
                                <i class="fa fa-link" title="View Product"></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <h3>
                <a href="Show-Product.aspx" title="">Product Name 3
                    <span>Code Product: -</span>
                </a>
            </h3>
        </div>
    </div>
    <div class="col-xs-6 col-md-3">
        <div class="products">
            <div class="offer-focus">
                <img class="img-responsive" src="Images/product04.jpg" title="" alt="" />
                <div class="offer-filter">
                    <div class="offer-hover">
                        <div class="offer-hover2">
                            <a class="fancybox" href="Show-Product.aspx" title="">
                                <i class="fa fa-link" title="View Product"></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <h3>
                <a href="Show-Product.aspx" title="">Product Name 4
                    <span>Code Product: 309</span>
                </a>
            </h3>
        </div>
    </div>

    <script src="Plugins/FancyBox/fancybox.js" type="text/javascript"></script>
    <script src="Plugins/FancyBox/mousewheel-3.0.6.js" type="text/javascript"></script>
</asp:Content>
