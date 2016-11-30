<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sitemap.aspx.cs" Inherits="Sitemap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <header class="page-header">
        <div class="container">
            <div class="row">
                <div class="col-xs-5 col-sm-6">
                    <h1>Sitemap</h1>
                </div>
                <div class="col-xs-7 col-sm-6">
                    <div class="breadcrumbs">
                        <a href="/" title="">Home</a>
                        <i>/</i>
                        <span>Sitemap</span>
                    </div>
                </div>
            </div>
        </div>
    </header>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="col-xs-12">
        <h2 class="title-design mb25">Main Links</h2>
        <ul class="sitemap">
            <li>
                <a href="/" title="">Default</a>
            </li>
            <li>
                <a href="Blog.aspx" title="">News</a>
            </li>
            <li>
                <a href="Products.aspx" title="">Products</a>
            </li>
            <li>
                <a href="/" title="">Certificates</a>
            </li>
            <li>
                <a href="Rule.aspx" title="">Rules</a>
            </li>
            <li>
                <a href="About-Us.aspx" title="">About Us</a>
            </li>
            <li>
                <a href="Contact-Us.aspx" title="">Contact Us</a>
            </li>
        </ul>
    </div>
</asp:Content>
