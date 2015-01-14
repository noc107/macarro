var data = "";

$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: " web_07_facturacion.aspx/LoadData",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            JSON.stringify(msg);
            data = msg.d.split(" ");
            $("#middle_place_holder__textBoxCorreoCliente").autocomplete({ source: data });
        }

    });
});