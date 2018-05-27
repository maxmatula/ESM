$(function () {

    setTimeout(function () {
        $(".preloader").fadeOut();
    }, 500);
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
    if ($('#particles').length) {
        /* particlesJS.load(@dom-id, @path-json, @callback (optional)); */
        particlesJS.load('particles', '/Scripts/particlesjs-config.json', function () {
            console.log('callback - particles.js config loaded');
        });
    }

    var inputs = document.querySelectorAll('input[type="file"]');
    Array.prototype.forEach.call(inputs, function (input) {
        var label = input.nextElementSibling,
            labelVal = label.innerHTML;

        input.addEventListener('change', function (e) {
            var fileName = '';
            if (this.files && this.files.length > 1)
                fileName = (this.getAttribute('data-multiple-caption') || '').replace('{count}', this.files.length);
            else
                fileName = e.target.value.split('\\').pop();

            if (fileName)
                label.querySelector('span').innerHTML = fileName;
            else
                label.innerHTML = labelVal;
        });
    });

});