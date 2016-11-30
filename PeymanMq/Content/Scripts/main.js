var isMobile = false;
var isDesktop = false;

$(window).on("load resize", function (e) {
    // Mobile Detection
    if (Modernizr.mq('only all and (max-width: 767px)')) {
        isMobile = true;
    } else {
        isMobile = false;
    }

    // Tablet And Mobile Detection
    if (Modernizr.mq('only all and (max-width: 1024px)')) {
        isDesktop = false;
    } else {
        isDesktop = true;
    }

    ToTop(isMobile);
});

// To Top Button
function ToTop(mobile) {
    if (mobile == false) {
        if (!$('#back-top').length) {
            $('body').append('<a href="#" id="back-top"><i class="fa fa-chevron-up"></i></a>');
        }

        $(window).scroll(function () {
            if ($(this).scrollTop() > 100) {
                $('#back-top').slideDown('fast');
            } else {
                $('#back-top').slideUp('fast');
            }
        });

        $('#back-top').click(function (e) {
            e.preventDefault();
            $("html, body").animate({
                scrollTop: 0
            }, 800, 'easeInOutCirc');
        });
    } else {
        if ($('#back-top').length) {
            $('#back-top').remove();
        }
    }
}

$(document).ready(function () {
    "use strict";

    // Main Menu
    InitializeMainMenu();

    // Revolution Slider
    if ($('#rsDemoWrapper').length) {
        $('.tp-banner').revolution(
            {
                delay: 5000,
                startwidth: 1000,
                startheight: 550,
                hideThumbs: 10,
                fullWidth: "on",
                forceFullWidth: "on"
            });

        $('#rsDemoWrapper').css('visibility', 'visible');
    }

    // OwlCarousel
    try {
        $("#owl-demo").owlCarousel({
            autoPlay: 2500,
            items: 4,
            navigation: true,
            stopOnHover: true,
            itemsDesktop: [1199, 3],
            itemsDesktopSmall: [979, 3]
        });
    } catch (e) {
    }

    // FancyBox
    try {
        $('.fancybox').fancybox();
    } catch (e) {
    }

    // Tooltip
    try {
        $('.Tooltip').tooltip({
            placement: 'auto'
        });
    } catch (e) {
    }

    // Carousel
    try {
        $("#myCarousel").carousel({
            interval: 3000
        });
    } catch (e) {
    }
});

// Main Menu
function InitializeMainMenu() {
    "use strict";
    var $mainMenu = $('#main-menu').children('ul');

    if (Modernizr.mq('only all and (max-width: 767px)')) {
        var addActiveClass = false;

        $("a.hasSubMenu").unbind('click');
        $('li', $mainMenu).unbind('mouseenter mouseleave');

        $("a.hasSubMenu").on("click", function (e) {
            e.preventDefault();
            addActiveClass = $(this).parent("li").hasClass("Nactive");

            if ($(this).parent("li").hasClass('primary')) {
                $("li", $mainMenu).removeClass("Nactive");
            } else {
                $("li:not(.primary)", $mainMenu).removeClass("Nactive");
            }

            if (!addActiveClass) {
                $(this).parents("li").addClass("Nactive");
            } else {
                $(this).parent().parent('li').addClass("Nactive");
            }

            return;
        });

    } else if (Modernizr.mq('only all and (max-width: 1024px)') && Modernizr.touch) {
        $("a.hasSubMenu").attr('href', '');
        $("a.hasSubMenu").on("touchend", function (e) {
            var $li = $(this).parent(),
            $subMenu = $li.children('.subMenu');

            if ($(this).data('clicked_once')) {
                if ($li.parent().is($(':gt(1)', $mainMenu))) {
                    if ($subMenu.css('display') == 'block') {
                        $li.removeClass('hover');
                        $subMenu.css('display', 'none');
                    } else {
                        $('.subMenu').css('display', 'none');
                        $subMenu.css('display', 'block');
                    }
                } else {
                    $('.subMenu').css('display', 'none');
                }

                $(this).data('clicked_once', false);

            } else {
                $li.parent().find('li').removeClass('hover');
                $li.addClass('hover');

                if ($li.parent().is($(':gt(1)', $mainMenu))) {
                    $li.parent().find('.subMenu').css('display', 'none');
                    $subMenu.css('right', $subMenu.parent().outerWidth(true));
                    $subMenu.css('display', 'block');
                } else {
                    $('.subMenu').css('display', 'none');
                    $subMenu.css('display', 'block');
                }

                $('a.hasSubMenu').data('clicked_once', false);
                $(this).data('clicked_once', true);
            }

            e.preventDefault();
            return false;
        });

        window.addEventListener("orientationchange", function () {
            $('a.hasSubMenu').parent().removeClass('hover');
            $('.subMenu').css('display', 'none');
            $('a.hasSubMenu').data('clicked_once', false);
        }, true);
    } else {
        $("li", $mainMenu).removeClass("Nactive");
        $('a', $mainMenu).unbind('click');
        $('li', $mainMenu).hover(
            function () {
                var $this = $(this),
                $subMenu = $this.children('.subMenu');

                if ($subMenu.length) {
                    $this.addClass('hover').stop();
                } else {
                    if ($this.parent().is($(':gt(1)', $mainMenu))) {
                        $this.stop(false, true).fadeIn('slow');
                    }
                }

                if ($this.parent().is($(':gt(1)', $mainMenu))) {
                    $subMenu.stop(true, true).fadeIn(200, 'easeInOutQuad');
                    $subMenu.css('right', $subMenu.parent().outerWidth(true));

                } else {
                    $subMenu.stop(true, true).delay(100).fadeIn(50, 'easeInOutQuad');
                }

            }, function () {
                var $nthis = $(this),
                $subMenu = $nthis.children('ul');

                if ($nthis.parent().is($(':gt(1)', $mainMenu))) {
                    $nthis.children('ul').hide();
                    $nthis.children('ul').css('right', 0);
                } else {
                    $nthis.removeClass('hover');
                    $('.subMenu').stop(true, true).delay(200).fadeOut();
                }

                if ($subMenu.length) {
                    $nthis.removeClass('hover');
                }
            });
    }
}

/*جدید*/
(function ($) {
    // بدست آوردن کوئری استرینگ ها
    function GetParameterByName(name, url) {
        if (!url) {
            url = window.location.href;
        }

        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);

        if (!results) {
            return null;
        }

        if (!results[2]) {
            return '';
        }

        return decodeURIComponent(results[2].replace(/\+/g, " "));
    }

    var sw1 = true;
    var keyword = GetParameterByName('keyword');

    function AddAntiForgeryToken(data) {
        data.__RequestVerificationToken = $("input[name=__RequestVerificationToken]").val();
        return data;
    }

    // دراپ دوان تغییر دسته و زیر دسته
    $("#ddlCategoryWithSubItem").on('change', function () {
        if (sw1) {
            var ddlSubItem = $('#ddlSubItem'),
                hdfSubItemID = $('#HiddenSubItemID');

            $.ajax({
                url: subItemUrl,
                data: AddAntiForgeryToken({ itemID: hdfSubItemID.val(), categoryID: parseInt($.trim($(this).val())) }),
                type: 'POST',
                cache: false,
                dataType: "json",
                beforeSend: function () {
                    ddlSubItem.prev('.display-none').fadeIn('fast');
                    sw1 = false;
                },
                success: function (result) {
                    ddlSubItem.prev('.display-none').fadeOut('fast');
                    ddlSubItem.empty();
                    $(result.List).each(function () {
                        $(document.createElement('option')).attr('value', this.Value).attr('selected', this.Selected).text(this.Text).appendTo(ddlSubItem);
                    });

                    sw1 = true;
                },
                error: function () {
                    ddlSubItem.prev('.display-none').fadeOut('fast');
                    ddlSubItem.empty();
                    $(document.createElement('option')).attr('value', "").text("لطفا یک گزینه را انتخاب نمایید").appendTo(ddlSubItem);
                    sw1 = true;
                }
            });
        }

        return false;
    });

    try {
        $("#ddlCategoryWithSubItem").change();
    } catch (e) {
    }

    $("#ddlSubItem").on('change', function () {
        $('#HiddenSubItemID').val($(this).val());
    });
    // پایان دراپ دوان تغییر دسته و زیر دسته

    // صفحه بندی
    var pageIndex = 1,
        rowIndex = 1,
        pageSize = 12;

    if ($('#ddlPageSize').val() != "" && $('#ddlPageSize').val() != undefined && $('#ddlPageSize').val() != NaN) {
        pageSize = parseInt($.trim($('#ddlPageSize').val()));
    }

    try {
        Handlebars.registerHelper('index', function () {
            return ((pageIndex - 1) * pageSize) + rowIndex++;
        });
    } catch (e) {
    }

    try {
        Handlebars.registerHelper("ifActive", function (value, options) {
            if (value == "فعال") {
                return options.fn(this);
            }
            else {
                return options.inverse(this);
            }
        });
    } catch (e) {
    }

    $('.pagination').delegate('a.paging', 'click', function () {
        if (sw1) {
            pageIndex = parseInt($(this).data('index'));
            rowIndex = 1;
            GetData();
        }
    });

    function GetData() {
        $.ajax({
            url: selectUrl,
            data: AddAntiForgeryToken({ pageIndex: pageIndex, pageSize: pageSize, category: $.trim($('#ddlCategory').val()), keyword: keyword }),
            type: 'POST',
            cache: false,
            dataType: "json",
            beforeSend: function () {
                sw1 = false;
                $('.loadingPart').fadeIn('fast');
                $(".emptyResult").html("");
            },
            success: function (result) {
                var template = Handlebars.compile($("#entry-template").html()),
                    output = template({ List: result.List });
                $('.loadingPart').fadeOut('fast');
                $("#grdData .tbody").html(output);
                $(".totalRows").html(result.TotalRows + ' رکورد یافت شد');

                if (result.TotalRows > 0) {
                    MakePaging(Math.ceil(result.TotalRows / pageSize), pageIndex);
                }
                else {
                    $(".pagination").html("");
                    $(".emptyResult").html("رکوردی یافت نشد");
                }

                // فراخوانی پلاگین امتیازدهی (rateit)
                try {
                    $('div.rateit, span.rateit').rateit();
                } catch (e) {
                }

                sw1 = true;
            },
            error: function () {
                $(".emptyResult").html("خطایی رخ داده است. لطفا مجددا تلاش نمایید.");
                $('.loadingPart').fadeOut('fast');
                sw1 = true;
            }
        });
    }

    try {
        GetData();
    } catch (e) {
    }

    $('#ddlPageSize').on('change', function () {
        if (sw1) {
            pageSize = parseInt($.trim($(this).val()));
            pageIndex = 1;
            rowIndex = 1;
            GetData();
        }
    });

    function MakePaging(totalPages, pageIndex) {
        var start = 1,
            totalPages = parseInt(totalPages),
            center = [], before = "", after = "";

        if (pageIndex > 6) {
            start = pageIndex - 3;
        }

        for (var i = start; i < start + 7; i++) {
            if (i > totalPages) {
                break;
            }

            center.push("<li");

            if (i == pageIndex) {
                center.push(" class='active'><a title='صفحه " + i + "'>");
            }
            else {
                center.push("><a class='paging' data-index='" + i + "' title='صفحه " + i + "'>");
            }

            center.push(i + "</a></li>");
        }

        if (totalPages > 7) {
            if (pageIndex > 6) {
                before = "<li><a class='paging' data-index='1' title='صفحه اول'>1</a></li><li><a title='...'>...</a></li>";

                if (pageIndex + 4 <= totalPages) {
                    after = "<li><a title='...'>...</a></li><li><a class='paging' data-index='" + totalPages + "' title='صفحه آخر'>" + totalPages + "</a></li>";
                }
            }
            else {
                after = "<li><a title='...'>...</a></li><li><a class='paging' data-index='" + totalPages + "' title='صفحه آخر'>" + totalPages + "</a></li>";
            }
        }
        else {
            if (pageIndex > 6) {
                before = "<li><a class='paging' data-index='1' title='صفحه اول'>1</a></li><li><a title='...'>...</a></li>";
            }
        }

        $(".pagination").html(before + center.join("") + after);
    }
    // پایان صفحه بندی

    // اضافه کردن maxlength بصورت اتوماتیک
    try {
        $('[data-val-length-max]').each(function () {
            $(this).attr('maxlength', $(this).attr('data-val-length-max'));
        });
    } catch (e) {
    }

    // تغییر دسته بندی
    $('#ddlCategory').on('change', function () {
        if (sw1) {
            $('#ddlPageSize').change();
        }
    });

    // سریالیز کردن فرم
    $.fn.serializeObject = function () {
        var o = {},
            a = this.serializeArray();

        $.each(a, function () {
            if (o[this.name] !== undefined) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }

                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });

        return o;
    };

    // ارسال نظر و سوال
    $('form.sendComment').submit(function (e) {
        $this = $(this);

        if (sw1) {
            if ($this.valid()) {
                $.ajax({
                    url: insertUrl,
                    data: AddAntiForgeryToken({ model: $this.serializeObject() }),
                    type: 'POST',
                    cache: false,
                    dataType: "json",
                    beforeSend: function () {
                        $('.loadingPart').fadeIn('fast');
                        $('.msgAlert', $this).html("");
                        sw1 = false;
                    },
                    success: function (result) {
                        $("#Captcha").val('').focus();;
                        $("img.imgCaptcha").attr("src", "/Captcha/CaptchaImage?prefix=4&width=130&height=22&date" + new Date().getTime());
                        $('.msgAlert', $this).html(result);
                        $('.loadingPart').fadeOut('fast');
                        sw1 = true;
                    },
                    error: function (xhr, status) {
                        try {
                            $('.msgAlert', $this).html(xhr.responseText);
                        } catch (e) {
                            $('.msgAlert', $this).html("خطایی رخ داده است. لطفا مجددا تلاش نمایید");
                        }

                        $('.loadingPart').fadeOut('fast');
                        sw1 = true;
                    }
                });
            }
        }

        e.preventDefault();
    });

    // فراخوانی ckeditor
    try {
        var editor = CKEDITOR.replace('Body', { // آی دی عنصر مورد نظر
            contentsLangDirection: 'rtl',
            language: "fa",
            skin: "moonocolor",
            removeButtons: 'Save,NewPage,Templates'
        });
    } catch (e) {
    }

    // کادر جستجو
    $('input.txtSearch').keydown(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            $(this).closest('form').find('.btnSearch').click();
            return false;
        }
    });

    // دکمه جستجو
    $('.btnSearch').click(function () {
        window.location.replace(searchUrl + "?keyword=" + $(this).closest('form').find('.txtSearch').val())
    });

    // فراخوانی پلاگین امتیازدهی (rateit)
    try {
        $('div.rateit, span.rateit').rateit({
            min: 0,
            max: 5,
            resetable: false
        }
        ).bind('over', function (event, value) { $(this).attr('title', value); })
         .on('beforerated', function (e, value) {
             if (!confirm('امتیاز شما: ' + value + ' ستاره. آیا مطمئن هستید؟')) {
                 e.preventDefault();
             }
         }).bind('rated', function (e) {
             var ri = $(this);
             var value = ri.rateit('value');
             var itemID = ri.closest('.rating-box').find('input[type="hidden"][name="ItemID"]').val() // var itemID = ri.data('itemid');
             ri.rateit('readonly', true);

             if (sw1) {
                 $.ajax({
                     url: insertRate,
                     data: AddAntiForgeryToken({  itemID: itemID, value: value }),
                     type: 'POST',
                     cache: false,
                     dataType: "json",
                     beforeSend: function () {
                         $('.msgAlert').html("");
                         sw1 = false;
                     },
                     success: function (result) {
                         $('.msgAlert').html(result);
                         sw1 = true;
                     },
                     error: function (jxhr, msg, err) {
                         try {
                             $('.msgAlert').html(msg);
                         } catch (e) {
                             $('.msgAlert').html("خطایی رخ داده است. لطفا مجددا تلاش نمایید");
                         }

                         sw1 = true;
                     }
                 });
             }
         });
    } catch (e) {
    }

    // اجباری کردن انتخاب چک باکس سمت کاربر
    $.validator.addMethod("booleanrequired", function (value, element, param) {
        if (!this.depend(param, element)) {
            return "dependency-mismatch";
        }

        return element.checked;
    });

    $.validator.unobtrusive.adapters.addBool("booleanrequired");
}(jQuery));