<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage-Fa.master" AutoEventWireup="true" CodeFile="Send-Order-Fa.aspx.cs" Inherits="Send_Order_Fa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <header class="page-header">
        <div class="container">
            <div class="row">
                <div class="col-xs-5 col-sm-6">
                    <h1>ارسال سفارش</h1>
                </div>
                <div class="col-xs-7 col-sm-6">
                    <div class="breadcrumbs">
                        <a href="Default-Fa.aspx" title="">خانه</a>
                        <i>/</i>
                        <span>ارسال سفارش</span>
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
                <a class="close" href="#" title="بستن" aria-label="close" data-dismiss="alert">×</a>
                <strong>اخطار!</strong> خطایی رخ داده است. لطفا ورودی های خود را چک نمایید.
            </div>
            <div class="alert alert-info fade in">
                <a class="close" href="#" title="بستن" aria-label="close" data-dismiss="alert">×</a>
                <strong>اخطار!</strong> خطایی رخ داده است. لطفا ورودی های خود را چک نمایید.
            </div>
            <div class="alert alert-warning fade in">
                <a class="close" href="#" title="بستن" aria-label="close" data-dismiss="alert">×</a>
                <strong>اخطار!</strong> خطایی رخ داده است. لطفا ورودی های خود را چک نمایید.
            </div>
            <div class="alert alert-danger fade in">
                <a class="close" href="#" title="بستن" aria-label="close" data-dismiss="alert">×</a>
                <strong>اخطار!</strong> خطایی رخ داده است. لطفا ورودی های خود را چک نمایید.
            </div>--%>
            <div class="form-group">
                <label>نام و نام خانوادگی:</label>
                <input type="text" class="form-control" placeholder="نام و نام خانوادگی خود را وارد نمایید" />
            </div>
            <div class="form-group">
                <label>ایمیل:</label>
                <input type="text" class="form-control" placeholder="ایمیل خود را وارد نمایید" />
            </div>
            <div class="row">
                <div class="form-group col-sm-6">
                    <label>دسته بندی:</label>
                    <select class="form-control">
                        <option>انتخاب دسته</option>
                        <option>دسته بندی 1</option>
                        <option>دسته بندی 2</option>
                        <option>دسته بندی 3</option>
                        <option>دسته بندی 4</option>
                    </select>
                </div>
                <div class="form-group col-sm-6">
                    <label>عنوان محصول:</label>
                    <select class="form-control">
                        <option>عنوان محصول 1</option>
                        <option>عنوان محصول 2</option>
                        <option>عنوان محصول 3</option>
                        <option>عنوان محصول 4</option>
                    </select>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-sm-6">
                    <label>مقدار:</label>
                    <input type="text" class="form-control" placeholder="مقدار را وارد نمایید" />
                </div>
                <div class="form-group col-sm-6">
                    <label class="hidden-xs">&nbsp;</label>
                    <span class="description-Text">مثال: 100 متر</span>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-sm-6">
                    <label>رنگ:</label>
                    <select class="form-control">
                        <option>رنگ 1</option>
                        <option>رنگ 2</option>
                        <option>رنگ 3</option>
                        <option>رنگ 4</option>
                    </select>
                </div>
                <div class="form-group col-sm-6">
                    <label>تاریخ سفارش:</label>
                    <input type="text" class="form-control" placeholder="تاریخ را وارد نمایید" />
                </div>
            </div>
            <div class="form-group">
                <label>توضیحات:</label>
                <textarea class="form-control" rows="4" placeholder="توضیحات سفارش …"></textarea>
            </div>
            <div class="form-group">
                <label>ارسال فایل:</label>
                <input type="file" class="form-control" />
                <p class="accept-format">(سایز فایل کوچکتر از 500KB باشد - فرمت فایل های قابل قبول pdf, jpg)</p>
            </div>
            <div class="form-group">
                <button type="submit" class="btn btn-submit btn-lg">ارسال</button>
            </div>
        </form>
    </div>
    <div class="visible-xs col-xs-12">
        <hr />
    </div>
    <div class="clearfix visible-xs"></div>
    <div class="col-sm-6">
        <h2 class="title-design mb25">راهنمای سفارش</h2>
        <ul class="help-box mb25">
            <li class="fa fa-chevron-left">تلفن همراه خود را به صورت صحیح وارد نمایید.</li>
            <li class="fa fa-chevron-left">آدرس محل سکونت خود را به طور دقیق و صحیح وارد نمایید.</li>
            <li class="fa fa-chevron-left">اطلاعات خصوصی و همچنین تلفن همراه شما نزد سایت محفوظ است و در اختیار اشخاص حقیقی یا حقوقی قرار نخواهد گرفت.</li>
        </ul>
        <div class="text-center">
            <img class="img-responsive img-guide" src="Images/guide-pic.jpg" title="" alt="" />
        </div>
    </div>
</asp:Content>
