$(function () {
    $(".main-header__links .parent").click(function () {
        $(this).toggleClass('active').children('.child').stop().slideToggle();
    });
    $(".main-header__links > ul > li").click(function () {
        $(this).toggleClass('active').siblings().removeClass('active');
    });

    //Login page
    setInterval(function () {
        $('.login__content').fadeIn("slow");
    }, 1000);
    //default page
    setInterval(function () {
        $('.main-content').fadeIn("slow");
    }, 100);

    /* particlesJS.load(@dom-id, @path-json, @callback (optional)); */
    particlesJS.load('particles', '/Scripts/particlesjs-config.json', function () {
        console.log('callback - particles.js config loaded');
    });

});