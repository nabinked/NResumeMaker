// Write your Javascript code.


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


$(document).on('click', '.refresh', function (evt) {
    evt.preventDefault();
    console.log(window.location.reload);
    window.location.reload(true);
});

$('body').on('click', '.form-toggle-button', function () {
    $(this).closest('.form-toggle-wrapper').find('.form-toggle').toggle(100);
});

$('.get-form-ajax').on('click', function () {
    var $this = $(this);
    var url = $this.attr("data-load-form-url");
    var params = JSON.parse($this.attr("data-get-form-params"));
    var targetLoadElementId = $this.attr("data-target-element-id");
    var $targetLoadElement = $this.closest('[id=' + targetLoadElementId + ']');
    getAjaxForm(url, params, $targetLoadElement);
});

function getAjaxForm(url, params, targetLoadElement) {
    // Assign handlers immediately after making the request,
    // and remember the jqxhr object for this request
    var jqxhr = $.get(url, params, function (html) {
        targetLoadElement.html(html);

    })
      .fail(function (jqXhr
, textStatus, errorThrown) {
          console.log(jqXhr);
          alert(textStatus + ' ' + errorThrown);
      })
      .always(function () {
      });
}


$(document).on('click', '.confirm-form-post', function (evt) {
    evt.preventDefault();
    var form = $(this).closest('form');
    confirm('Are you sure ?', '', true, form);

});

function confirm(title, message, closeIcon, form) {
    $.confirm({
        title: title,
        confirmButton: "Yes",
        cancelButton: "No",
        closeIcon: closeIcon,
        icon: 'fa fa-exclamation',
        confirm: function () {
            form.submit();
        },
        cancel: function () {
            console.log('Prompt canceled!');
        }
    });
};

$(document).on('scroll', function () {
    localStorage['page'] = document.URL;
    localStorage['scrollTop'] = $(document).scrollTop();
});

$(document).ready(function () {
    if (localStorage['page'] === document.URL) {
        if (localStorage['scrollTop'] + $(window).height() > $(document).height()) {
            //$(document).scrollTop($(document).height() - $(window).height());
            $(document).scrollTop(localStorage['scrollTop']);
        } else {
            $(document).scrollTop(localStorage['scrollTop']);

        }
    }
});

$(document).ready(function () {
    //Convert address tags to google map links - Michael Jasper 2012
    $('address').each(function () {
        var link = "<a target=_blank href=http://maps.google.com/maps?q=" + encodeURIComponent($(this).text()) + ">" + $(this).html() + "</a>";
        $(this).html(link);
    });
});