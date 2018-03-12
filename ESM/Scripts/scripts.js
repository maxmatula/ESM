$(function () {
    $(".main-header__links .parent").click(function () {
        $(this).toggleClass('active').children('.child').slideToggle();
        console.log("Siema");
    });
    $(".main-header__links > ul > li").click(function () {
        $(this).toggleClass('active').siblings().removeClass('active');
    });
});