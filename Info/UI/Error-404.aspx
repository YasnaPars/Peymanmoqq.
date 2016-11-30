<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Error-404.aspx.cs" Inherits="Error_404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <header class="page-header">
        <div class="container">
            <div class="row">
                <div class="col-xs-5 col-sm-6">
                    <h1>Error 404 Page</h1>
                </div>
                <div class="col-xs-7 col-sm-6">
                    <div class="breadcrumbs">
                        <a href="/" title="">Home</a>
                        <i>/</i>
                        <span>Error 404 Page</span>
                    </div>
                </div>
            </div>
        </div>
    </header>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3">
        <article class="error-page text-center">
            <i class="fa fa-unlink"></i>
            <h2>The Page Cannot Be Found</h2>
            <p>The page you are looking for might have been removed, had its name changed or is temporarily unavailable.</p>
            <a href="/" class="btn btn-lg btn-submit">Back To Homepage</a>
        </article>
    </div>
</asp:Content>
