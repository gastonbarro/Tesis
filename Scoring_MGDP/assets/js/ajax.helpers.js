
function comboModelo() {
    var marca = $("#txt_equipomarca").val();
    if (marca != 'Sin equipo') {
        $(".sequip").show().prop("disabled", false);
    }
    else {
        $(".sequip").hide().prop("disabled", true);
        return;
    }

    //event.preventDefault();
    $.ajax({
        url: "api/opciones/marca",
        type: "POST",
        data: '{marca: "' + marca + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function () {
            $("#cargando").fadeIn()
            ;

        },
        success: function (modelos) {
            if (modelos.lenght === 0) {
                Mensaje("Error al traer datos del combo", 'danger', 'Alerta');
            } else {
                $("#txt_equipomodelo").empty();
                $("#txt_equipomodelo").removeAttr('disabled');
                $.each(modelos, function (iIndex, modelo) {
                    $("#txt_equipomodelo").append(
                    $('<option></option>').val(modelo).html(modelo));
                });
            }
        },
        error: function (error) {
            Mensaje("Error al buscar el modelo. " + error.Message, 'danger', 'Alerta');
            $("#incidencia").show();
        },
        cache: false
    });
}

function comboSIMModelo() {
    var plan = $("#txt_modsim").val();
    if (plan != 'Mantener SIM') {
        $(".splan").show().prop("disabled", false);
    }
    else {
        $(".splan").hide().prop("disabled", true);
        return;
    }
}