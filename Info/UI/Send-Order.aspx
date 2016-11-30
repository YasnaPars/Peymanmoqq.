<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Send-Order.aspx.cs" Inherits="Send_Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <header class="page-header">
        <div class="container">
            <div class="row">
                <div class="col-xs-5 col-sm-6">
                    <h1>Send Order</h1>
                </div>
                <div class="col-xs-7 col-sm-6">
                    <div class="breadcrumbs">
                        <a href="/" title="">Home</a>
                        <i>/</i>
                        <span>Send Order</span>
                    </div>
                </div>
            </div>
        </div>
    </header>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="col-sm-6">
        <form class="form-contact" role="form">
            <%--<div class="alert alert-success fade in">
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
            <div class="row">
                <div class="form-group col-sm-6">
                    <label>Category:</label>
                    <select class="form-control">
                        <option>Select Category</option>
                        <option>Category 1</option>
                        <option>Category 2</option>
                        <option>Category 3</option>
                        <option>Category 4</option>
                    </select>
                </div>
                <div class="form-group col-sm-6">
                    <label>Product Title:</label>
                    <select class="form-control">
                        <option>Product Title 1</option>
                        <option>Product Title 2</option>
                        <option>Product Title 3</option>
                        <option>Product Title 4</option>
                    </select>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-sm-6">
                    <label>Amount:</label>
                    <input type="text" class="form-control" placeholder="Enter Amount" />
                </div>
                <div class="form-group col-sm-6">
                    <label class="hidden-xs">&nbsp;</label>
                    <span class="description-Text">Example: 100 Meters</span>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-sm-6">
                    <label>Color:</label>
                    <select class="form-control">
                        <option>Color 1</option>
                        <option>Color 2</option>
                        <option>Color 3</option>
                        <option>Color 4</option>
                    </select>
                </div>
                <div class="form-group col-sm-6">
                    <label>Order Date:</label>
                    <input type="text" class="form-control" placeholder="Enter Dates" />
                </div>
            </div>
            <div class="form-group">
                <label>Description:</label>
                <textarea class="form-control" rows="4" placeholder="Description Order …"></textarea>
            </div>
            <div class="form-group">
                <label>Send File:</label>
                <input type="file" class="form-control" />
                <p class="accept-format">(File Size Is Smaller Than 500KB - Acceptable File Format pdf, jpg)</p>
            </div>
            <div class="form-group">
                <button type="submit" class="btn btn-submit btn-lg">Submit</button>
            </div>
        </form>
    </div>
    <div class="visible-xs col-xs-12">
        <hr />
    </div>
    <div class="clearfix visible-xs"></div>
    <div class="col-sm-6">
        <h2 class="title-design mb25">Order Guide</h2>
        <ul class="help-box mb25">
            <li class="fa fa-chevron-right">Enter your mobile and fixed properly.</li>
            <li class="fa fa-chevron-right">Address Enter your location accurately and correctly.</li>
            <li class="fa fa-chevron-right">Private information as well as your mobile phone with the site is secure and will not be available to natural or legal persons.</li>
        </ul>
        <div class="text-center">
            <img class="img-responsive img-guide" src="Images/guide-pic.jpg" title="" alt="" />
        </div>
    </div>
</asp:Content>
