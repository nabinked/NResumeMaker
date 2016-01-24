// Write your Javascript code.
$(document).ajaxStart(function () {
    startLoader();
});
$(document).ajaxStop(function () {
    stopLoader();
    $("form").removeData("validator");
    $("form").removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse("form");
});

$('body').on('submit', '.form', function () {
    startLoader();
});

function startLoader() {
    $('.ajax-loader').loader({
        dimensions: 5,
        radius: 15,
        color: '#191970',
        boxes: 6,
        interval: 2000
    });
}

function stopLoader() {
    $('.ajax-loader').clearLoader();
}

$(document).on('click', '.refresh', function(parameters) {
    window.location.reload(true);
});
