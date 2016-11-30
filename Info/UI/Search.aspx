<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <header class="page-header">
        <div class="container">
            <div class="row">
                <div class="col-xs-5 col-sm-6">
                    <h1>Search</h1>
                </div>
                <div class="col-xs-7 col-sm-6">
                    <div class="breadcrumbs">
                        <a href="/" title="">Home</a>
                        <i>/</i>
                        <span>Search</span>
                    </div>
                </div>
            </div>
        </div>
    </header>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="col-sm-5 col-md-4 col-lg-3">
        <div class="search-box">
            <form class="form-block" role="form">
                <div class="form-group">
                    <input type="text" class="form-control" placeholder="Search..." />
                    <button type="submit" class="btn" title="Search">Search</button>
                </div>
            </form>
            <div class="title-result">
                Search Results for
                <span>"The Word"</span>
                <span>0 Records Found</span>
            </div>
            <div class="select-group">
                <div class="form-horizontal col-xs-12">
                    <div class="form-group">
                        <label class="control-label">Count:</label>
                        <select class="form-control">
                            <option>12</option>
                            <option>48</option>
                            <option>120</option>
                            <option>600</option>
                        </select>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-sm-7 col-md-8 col-lg-9">
        <div class="search-result">
            <%--<h4>Record not found.</h4>--%>
            <ul>
                <li>
                    <h3>
                        <a href="Show-Blog.aspx" title="">Search Title</a>
                    </h3>
                    <p>Here is the text searched. Here is the text searched. Here is the text searched. Here is the text searched. Here is the text searched. Here is the text searched.</p>
                    <a href="Show-Blog.aspx" title="Read More">Read More...</a>
                    <div class="clearfix"></div>
                </li>
                <li>
                    <h3>
                        <a href="Show-Blog.aspx" title="">Search Title</a>
                    </h3>
                    <p>Here is the text searched. Here is the text searched. Here is the text searched. Here is the text searched. Here is the text searched. Here is the text searched.</p>
                    <a href="Show-Blog.aspx" title="Read More">Read More...</a>
                    <div class="clearfix"></div>
                </li>
                <li>
                    <h3>
                        <a href="Show-Blog.aspx" title="">Search Title</a>
                    </h3>
                    <p>Here is the text searched. Here is the text searched. Here is the text searched. Here is the text searched. Here is the text searched. Here is the text searched.</p>
                    <a href="Show-Blog.aspx" title="Read More">Read More...</a>
                    <div class="clearfix"></div>
                </li>
                <li>
                    <h3>
                        <a href="Show-Blog.aspx" title="">Search Title</a>
                    </h3>
                    <p>Here is the text searched. Here is the text searched. Here is the text searched. Here is the text searched. Here is the text searched. Here is the text searched.</p>
                    <a href="Show-Blog.aspx" title="Read More">Read More...</a>
                    <div class="clearfix"></div>
                </li>
            </ul>
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
    </div>
</asp:Content>
