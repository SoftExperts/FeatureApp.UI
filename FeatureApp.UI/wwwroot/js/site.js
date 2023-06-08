// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            console.log(res);
            $('#form-modal .modal-body').html(res.html);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');

            // to make popup draggable
            //$('.modal-dialog').draggable({
            //    handle: ".modal-header"
            //});
        }
    })
}

$(function () {
    $("#loaderbody").addClass('hide');

    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hide');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hide');
    });
});
$(function () {
    $(".navbar-nav li").click(function () {
        $(".nav-item").removeClass("active");
        $(this).addClass("active");
    });
    //var pathname = window.location.pathname;
    //console.log("Current page", pathname);
})
