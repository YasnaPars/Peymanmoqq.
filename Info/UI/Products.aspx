<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Plugins/FancyBox/fancybox.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <header class="page-header">
        <div class="container">
            <div class="row">
                <div class="col-xs-5 col-sm-6">
                    <h1>Products</h1>
                </div>
                <div class="col-xs-7 col-sm-6">
                    <div class="breadcrumbs">
                        <a href="/" title="">Home</a>
                        <i>/</i>
                        <span>Products</span>
                    </div>
                </div>
            </div>
        </div>
    </header>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="select-group">
        <div class="form-horizontal col-xs-12 col-sm-5 col-md-4">
            <div class="form-group">
                <label class="control-label col-xs-5 col-sm-4 col-md-4">Category:</label>
                <div class="col-xs-7 col-sm-8 col-lg-7">
                    <select class="form-control">
                        <option>All</option>
                        <option>The First Category</option>
                        <option>The Second Category</option>
                        <option>The Third Category</option>
                    </select>
                </div>
            </div>
        </div>
        <div class="form-horizontal col-xs-12 col-sm-4 col-md-3">
            <div class="form-group">
                <label class="control-label col-xs-5 col-sm-6 col-lg-5">Count:</label>
                <div class="col-xs-7 col-sm-6">
                    <select class="form-control">
                        <option>12</option>
                        <option>48</option>
                        <option>120</option>
                        <option>600</option>
                    </select>
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
    </div>
    <div class="col-xs-6 col-sm-4 col-md-3">
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
    <div class="col-xs-6 col-sm-4 col-md-3">
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
    <div class="col-xs-6 col-sm-4 col-md-3">
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
    <div class="col-xs-6 col-sm-4 col-md-3">
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
    <div class="col-xs-6 col-sm-4 col-md-3">
        <div class="products">
            <div class="offer-focus">
                <img class="img-responsive" src="Images/product05.jpg" title="" alt="" />
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
                <a href="Show-Product.aspx" title="">Product Name 5
                    <span>Code Product: -</span>
                </a>
            </h3>
        </div>
    </div>
    <div class="col-xs-6 col-sm-4 col-md-3">
        <div class="products">
            <div class="offer-focus">
                <img class="img-responsive" src="Images/product06.jpg" title="" alt="" />
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
                <a href="Show-Product.aspx" title="">Product Name 6
                    <span>Code Product: 4090</span>
                </a>
            </h3>
        </div>
    </div>
    <div class="col-xs-6 col-sm-4 col-md-3">
        <div class="products">
            <div class="offer-focus">
                <img class="img-responsive" src="Images/product07.jpg" title="" alt="" />
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
                <a href="Show-Product.aspx" title="">Product Name 7
                    <span>Code Product: 309</span>
                </a>
            </h3>
        </div>
    </div>
    <div class="col-xs-6 col-sm-4 col-md-3">
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
                <a href="Show-Product.aspx" title="">Product Name 8
                    <span>Code Product: 4090</span>
                </a>
            </h3>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="col-xs-12 text-center">
        <ul class="pagination">
            <li>
                <a href="#">1</a>
            </li>
            <li class="active">
                <a href="#">2</a>
            </li>
            <li>
                <a href="#">3</a>
            </li>
            <li>
                <a href="#">4</a>
            </li>
            <li class="disabled">
                <a>...</a>
            </li>
            <li>
                <a href="#">9</a>
            </li>
            <li>
                <a href="#">10</a>
            </li>
        </ul>
    </div>

    <script src="Plugins/FancyBox/fancybox.js" type="text/javascript"></script>
    <script src="Plugins/FancyBox/mousewheel-3.0.6.js" type="text/javascript"></script>
</asp:Content>
