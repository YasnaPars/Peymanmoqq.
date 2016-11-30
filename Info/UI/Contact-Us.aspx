<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contact-Us.aspx.cs" Inherits="Contact_Us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="http://maps.googleapis.com/maps/api/js?sensor=false" type="text/javascript"></script>
    <script src="Scripts/gmap3.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#gmap').gmap3({
                map: {
                    options: {
                        center: [36.298109, 59.568371],
                        zoom: 14,
                        scrollwheel: false
                    }
                },
                marker: {
                    values: [
                      { latLng: [36.298109, 59.568371], data: "Peyman Moquette" }
                    ],
                    options: {
                        draggable: false
                    },
                    events: {
                        mouseover: function (marker, event, context) {
                            var map = $(this).gmap3("get"),
                              infowindow = $(this).gmap3({ get: { name: "infowindow" } });
                            if (infowindow) {
                                infowindow.open(map, marker);
                                infowindow.setContent(context.data);
                            } else {
                                $(this).gmap3({
                                    infowindow: {
                                        anchor: marker,
                                        options: { content: context.data }
                                    }
                                });
                            }
                        },
                        mouseout: function () {
                            var infowindow = $(this).gmap3({ get: { name: "infowindow" } });
                            if (infowindow) {
                                infowindow.close();
                            }
                        }
                    }
                }
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <header class="page-header">
        <div class="container">
            <div class="row">
                <div class="col-xs-5 col-sm-6">
                    <h1>Contact Us</h1>
                </div>
                <div class="col-xs-7 col-sm-6">
                    <div class="breadcrumbs pull-right">
                        <a href="/" title="">Home</a>
                        <i>/</i>
                        <span>Contact Us</span>
                    </div>
                </div>
            </div>
        </div>
    </header>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="col-xs-12">
        <h2 class="title-design mb25">Contact Us</h2>
    </div>
    <div class="col-xs-12">
        <div id="gmap"></div>
    </div>
    <div class="col-sm-7 col-sm-push-5">
        <div class="form-info">
            <p>Please send comments, let us know your feedback.</p>
            <div class="col-xs-12">
                <div class="row">
                    <i class="fa fa-map-marker"></i>
                    <div class="col-xs-10 col-sm-9 col-md-10 col-lg-11">
                        <span>Factory:</span>
                        <p>7th Sanat Ave, Kavian Industrial State - Bet Mashhad - Farima Rd, Mashhad - IRAN</p>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="row">
                    <i class="fa fa-map-marker"></i>
                    <div class="col-xs-10 col-sm-9 col-md-10 col-lg-11">
                        <span>Head Office:</span>
                        <p>IRAN - Mashhad - Felestin Sq. - Aboozar 1 St. No.69</p>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="row">
                    <i class="fa fa-phone"></i>
                    <div class="col-xs-10 col-sm-9 col-md-10 col-lg-11">
                        <span>Tell:</span>
                        <p>(+98) 51-38474157 - (+98) 51-38474158 - (+98) 51-38469771</p>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="row">
                    <i class="fa fa-fax"></i>
                    <div class="col-xs-10 col-sm-9 col-md-10 col-lg-11">
                        <span>Fax:</span>
                        <p>(+98) 51-38474156</p>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="row">
                    <i class="fa fa-mobile"></i>
                    <div class="col-xs-10 col-sm-9 col-md-10 col-lg-11">
                        <span>Mobile:</span>
                        <p>(+98) 915-109-6939</p>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="row">
                    <i class="fa fa-send"></i>
                    <div class="col-xs-10 col-sm-9 col-md-10 col-lg-11">
                        <span>Telegram:</span>
                        <p>(+98) 915-109-6939</p>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="row">
                    <i class="fa fa-envelope"></i>
                    <div class="col-xs-10 col-sm-9 col-md-10 col-lg-11">
                        <span>Email:</span>
                        <a href="mailto:peymanmq@gmail.com" title="">peymanmq@gmail.com</a>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
            <div class="clear"></div>
        </div>
    </div>
    <div class="visible-xs col-xs-12">
        <hr />
    </div>
    <div class="clearfix visible-xs"></div>
    <div class="col-sm-5 col-sm-pull-7">
        <form class="form-contact" role="form">
            <%--    <div class="alert alert-success fade in">
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
                <label>Subject:</label>
                <input type="text" class="form-control" placeholder="Enter Subject" />
            </div>
            <div class="form-group">
                <label>Text Messaging:</label>
                <textarea class="form-control" rows="6" placeholder="Enter Your Message …"></textarea>
            </div>
            <div class="form-group">
                <button type="submit" class="btn btn-submit btn-lg">Submit</button>
            </div>
        </form>
    </div>
</asp:Content>
