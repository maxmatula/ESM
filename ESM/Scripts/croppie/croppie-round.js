var $element = $('#croop-image');
$element.croppie({
    enableExif: false,
    viewport: {
        width: 300,
        height: 300,
        type: 'circle'
    },
    boundary: {
        width: 400,
        height: 400
    }
});

function readFile(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (event) {
            $element.croppie('bind', {
                url: event.target.result
            });
        };
        reader.readAsDataURL(input.files[0]);
    } else {
        alert('Sorry - you\'re browser doesn\'t support the FileReader API');
    }
}
$('#upload').on('change', function () { readFile(this); });
$('#form').on('submit', function (ev) {
    $element.croppie('result', 'canvas').then(function (resp) {
        $('#imagebase64').val(resp);
    });
});