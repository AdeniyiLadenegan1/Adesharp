// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    $('.fa-bars').click(function () {
        $(this).toggleClass('fa-times');
        $('.nav').toggleClass('nav-toggle');
    });

    $(window).on('load scroll', function () {

        $('.fa-bars').removeClass('fa-times');
        $('.nav').removeClass('nav-toggle');

        if ($(window).scrollTop() > 10) {
            $('header').addClass('header-active');
        } else {
            $('header').removeClass('header-active');
        }
    });
    $('.fire').magnificPopup({
        delegate: 'a',
        type: 'image',
        gallery: {
            enabled: true
        }
    })
    $('.emergency').magnificPopup({
        delegate: 'b',
        type: 'image',
        gallery: {
            enabled: true
        }
    })
});




