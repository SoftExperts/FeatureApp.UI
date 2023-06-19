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
        }
    })
}

function deleteConfirmation(url) {
    $.ajax({
        url: url,
        type: "html",
        success: function (data) {
            $("#modal_container_delete").html(data.html);
            console.log(data);
            $("#modal_DeleteConfirm").modal('show');
        },
        error: function (p1, p2, p3) {
            console.log("Error occurred in deleting record.")
        }
    });
}
function deleteRecord() {
    var idToDelete = $("#idToDelete").val();
    var controller = $("#controllerName").val();
    var action = $("#actionName").val();

    $.ajax({
        url: "/" + controller + "/" + action + "?id=" + idToDelete, // Set the URL of the MVC controller action
        type: "POST", // Set the HTTP method (POST, GET, etc.)
        data: { id: idToDelete }, // Pass the GUID as a string parameter
        traditional: true, // Set traditional parameter serialization

        success: function (data) {
            $("#modal_DeleteConfirm").modal('hide');
            window.location.href = `/${controller}/${data.redirectUrl}`;
        },
        error: function (xhr, status, error) {
            // Handle any error that occurs during the AJAX call
            console.log("AJAX call failed:", error);
        }
    });
}
