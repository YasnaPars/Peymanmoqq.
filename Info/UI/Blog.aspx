<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Blog.aspx.cs" Inherits="Blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <header class="page-header">
        <div class="container">
            <div class="row">
                <div class="col-xs-5 col-sm-6">
                    <h1>Blog</h1>
                </div>
                <div class="col-xs-7 col-sm-6">
                    <div class="breadcrumbs">
                        <a href="/" title="">Home</a>
                        <i>/</i>
                        <span>Blog</span>
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
    <div class="col-sm-6 col-md-4">
        <article class="post-blog">
            <a class="pic-blog" href="Show-Blog.aspx" title="">
                <img class="img-responsive" src="Images/blog-pic1.jpg" title="" alt="" />
            </a>
            <div class="box-blog">
                <ul class="info-blog">
                    <li>
                        <a href="Show-Blog.aspx" title="">
                            <i class="fa fa-calendar"></i>
                            12 Oct. 2016
                        </a>
                    </li>
                    <li>
                        <a href="Show-Blog.aspx" title="">
                            <i class="fa fa-comment"></i>
                            12 Comments
                        </a>
                    </li>
                </ul>
                <h3>
                    <a href="Show-Blog.aspx" title="">The news title goes here. The news title goes here.</a>
                </h3>
                <p>The news title goes here. The news title goes here. The news title goes here. The news title goes here. The news title goes here. The news title goes here. The news title goes here.</p>
                <a href="Show-Blog.aspx" title="">
                    <i class="fa fa-long-arrow-right"></i>
                    Read More
                </a>
                <div class="clearfix"></div>
            </div>
        </article>
    </div>
    <div class="col-sm-6 col-md-4">
        <article class="post-blog">
            <a class="pic-blog" href="Show-Blog.aspx" title="">
                <img class="img-responsive" src="Images/blog-pic4.jpg" title="" alt="" />
            </a>
            <div class="box-blog">
                <ul class="info-blog">
                    <li>
                        <a href="Show-Blog.aspx" title="">
                            <i class="fa fa-calendar"></i>
                            12 Oct. 2016
                        </a>
                    </li>
                    <li>
                        <a href="Show-Blog.aspx" title="">
                            <i class="fa fa-comment"></i>
                            12 Comments
                        </a>
                    </li>
                </ul>
                <h3>
                    <a href="Show-Blog.aspx" title="">The news title goes here. The news title goes here.</a>
                </h3>
                <p>The news title goes here. The news title goes here. The news title goes here. The news title goes here. The news title goes here. The news title goes here. The news title goes here.</p>
                <a href="Show-Blog.aspx" title="">
                    <i class="fa fa-long-arrow-right"></i>
                    Read More
                </a>
                <div class="clearfix"></div>
            </div>
        </article>
    </div>
    <div class="col-sm-6 col-md-4">
        <article class="post-blog">
            <a class="pic-blog" href="Show-Blog.aspx" title="">
                <img class="img-responsive" src="Images/blog-pic3.jpg" title="" alt="" />
            </a>
            <div class="box-blog">
                <ul class="info-blog">
                    <li>
                        <a href="Show-Blog.aspx" title="">
                            <i class="fa fa-calendar"></i>
                            12 Oct. 2016
                        </a>
                    </li>
                    <li>
                        <a href="Show-Blog.aspx" title="">
                            <i class="fa fa-comment"></i>
                            12 Comments
                        </a>
                    </li>
                </ul>
                <h3>
                    <a href="Show-Blog.aspx" title="">The news title goes here. The news title goes here.</a>
                </h3>
                <p>The news title goes here. The news title goes here. The news title goes here. The news title goes here. The news title goes here. The news title goes here. The news title goes here.</p>
                <a href="Show-Blog.aspx" title="">
                    <i class="fa fa-long-arrow-right"></i>
                    Read More
                </a>
                <div class="clearfix"></div>
            </div>
        </article>
    </div>
    <div class="col-sm-6 col-md-4">
        <article class="post-blog">
            <a class="pic-blog" href="Show-Blog.aspx" title="">
                <img class="img-responsive" src="Images/blog-pic2.jpg" title="" alt="" />
            </a>
            <div class="box-blog">
                <ul class="info-blog">
                    <li>
                        <a href="Show-Blog.aspx" title="">
                            <i class="fa fa-calendar"></i>
                            12 Oct. 2016
                        </a>
                    </li>
                    <li>
                        <a href="Show-Blog.aspx" title="">
                            <i class="fa fa-comment"></i>
                            12 Comments
                        </a>
                    </li>
                </ul>
                <h3>
                    <a href="Show-Blog.aspx" title="">The news title goes here. The news title goes here.</a>
                </h3>
                <p>The news title goes here. The news title goes here. The news title goes here. The news title goes here. The news title goes here. The news title goes here. The news title goes here.</p>
                <a href="Show-Blog.aspx" title="">
                    <i class="fa fa-long-arrow-right"></i>
                    Read More
                </a>
                <div class="clearfix"></div>
            </div>
        </article>
    </div>
    <div class="col-sm-6 col-md-4">
        <article class="post-blog">
            <a class="pic-blog" href="Show-Blog.aspx" title="">
                <img class="img-responsive" src="Images/blog-pic1.jpg" title="" alt="" />
            </a>
            <div class="box-blog">
                <ul class="info-blog">
                    <li>
                        <a href="Show-Blog.aspx" title="">
                            <i class="fa fa-calendar"></i>
                            12 Oct. 2016
                        </a>
                    </li>
                    <li>
                        <a href="Show-Blog.aspx" title="">
                            <i class="fa fa-comment"></i>
                            12 Comments
                        </a>
                    </li>
                </ul>
                <h3>
                    <a href="Show-Blog.aspx" title="">The news title goes here. The news title goes here.</a>
                </h3>
                <p>The news title goes here. The news title goes here. The news title goes here. The news title goes here. The news title goes here. The news title goes here. The news title goes here.</p>
                <a href="Show-Blog.aspx" title="">
                    <i class="fa fa-long-arrow-right"></i>
                    Read More
                </a>
                <div class="clearfix"></div>
            </div>
        </article>
    </div>
    <div class="col-sm-6 col-md-4">
        <article class="post-blog">
            <a class="pic-blog" href="Show-Blog.aspx" title="">
                <img class="img-responsive" src="Images/blog-pic4.jpg" title="" alt="" />
            </a>
            <div class="box-blog">
                <ul class="info-blog">
                    <li>
                        <a href="Show-Blog.aspx" title="">
                            <i class="fa fa-calendar"></i>
                            12 Oct. 2016
                        </a>
                    </li>
                    <li>
                        <a href="Show-Blog.aspx" title="">
                            <i class="fa fa-comment"></i>
                            12 Comments
                        </a>
                    </li>
                </ul>
                <h3>
                    <a href="Show-Blog.aspx" title="">The news title goes here. The news title goes here.</a>
                </h3>
                <p>The news title goes here. The news title goes here. The news title goes here. The news title goes here. The news title goes here. The news title goes here. The news title goes here.</p>
                <a href="Show-Blog.aspx" title="">
                    <i class="fa fa-long-arrow-right"></i>
                    Read More
                </a>
                <div class="clearfix"></div>
            </div>
        </article>
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
</asp:Content>
