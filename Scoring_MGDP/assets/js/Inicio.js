$(document).ready(function () {
    
    $('.seccion1').parallax("25%", 0.5, true);
    $('.seccion6').parallax("25%", 0.5, true);
    var wow = new WOW(
        {
            offset: 50
            //mobile: false
            // live: true
        }
    );
    wow.init();

    $(".preloader").fadeOut();
    $("#faceoff").delay(200).fadeOut("slow");


    $('#ir-arriba a').click(function () {
        $("html,body").animate({ scrollTop: 0 }, 750);
        return false;
    });

    //--------------- SmoothSroll--------------------

    $('a.scrollto').bind('click.smoothscroll', function (event) {
        event.preventDefault();

        var ancho = $(window).width();
        var scrollAnimationTime = 680,
            scrollAnimation = 'easeOutCubic';
        var offset = 0;
        if (ancho < 767) {
            offset = 61;
        } else {
            offset = 50;
        }

        $("#navbar-collapse").collapse('hide');
        var target = this.hash;
        $('html, body').stop().animate({
            'scrollTop': $(target).offset().top - offset
        }, scrollAnimationTime, scrollAnimation, function () {
            window.location.hash = target;
        });
    });
});

$(window).scroll(function () {

    var winWidth = $(window).width();

    //Comentar esto y agregar el slideDown en el load si se quiere la barra visible todo el tiempo
    if (winWidth > 767) {
        var $scrollHeight = $(window).scrollTop();
        if ($scrollHeight > 400) {
            //$(".botonera").css("margin-left", "-245px !important");

                $('#HeaderCompleto').slideUp(300);
                $('.datosUsuarioHeaderScroll').removeClass("hidden");

         
        } else {

                $('#HeaderCompleto').slideDown(300);
                $('.datosUsuarioHeaderScroll').addClass("hidden");

        }
    }

    //got o top
    if ($(this).scrollTop() > 100) {
        $('#ir-arriba a').fadeIn('slow');
    } else {
        $('#ir-arriba a').fadeOut('slow');
    }
});

var fullScreenHome = function () {
    if (matchMedia("(min-width: 992px) and (min-height: 500px)").matches) {
        "use strict"; //RUN JS IN STRICT MODE
        var height = $(window).height() - 130   ;
        contH = $(".fondoConImagen").height(),
        //contH = $(".banner-carousel .col-sm-12").height(),
        contMT = (height / 2) - (contH / 2);
        $(".fondoConImagen").css('min-height', height + "px");
        //$(".banner-carousel").css('min-height', height + "px");
        //$(".trans-bg").css('min-height', height + "px");
        //$(".banner .col-sm-12").css('margin-top', (contMT - 270) + "px");
        //$(".fondoConImagen").css('margin-top', (contMT - 10) + "px");
    }

    var winWidth = $(window).width();

    //Comentar esto y agregar el slideDown en el load si se quiere la barra visible todo el tiempo
    if (winWidth < 767) {
        $('#HeaderCompleto').fadeIn(400);
    } else {
        var $scrollHeight = $(window).scrollTop();
        if ($scrollHeight > 400) {
            //$('#HeaderCompleto').slideUp(400);
            $('#HeaderCompleto').hide(600);

        } else {
            //$('#HeaderCompleto').slideDown(400);
            $('#HeaderCompleto').show(600);
        }
    }

}

$(document).ready(fullScreenHome);
$(window).resize(fullScreenHome);