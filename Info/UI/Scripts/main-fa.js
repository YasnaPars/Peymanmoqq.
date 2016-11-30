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

