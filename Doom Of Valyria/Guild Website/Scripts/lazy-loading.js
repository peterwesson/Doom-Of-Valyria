function LazyLoad(url, containerId) {
    var element = $('#' + containerId);

    element.addClass("spinner")

    $.ajax(url, {
        success: function (data) {
            element.html(data);
            element.removeClass("spinner")
        }
    })
}