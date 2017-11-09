
(function ($) {
    $.get = function (key) {
        key = key.replace(/[\[]/, '\\[');
        key = key.replace(/[\]]/, '\\]');
        var pattern = "[\\?&]" + key + "=([^&#]*)";
        var regex = new RegExp(pattern);
        var url = unescape(window.location.href);
        var results = regex.exec(url);
        if (results === null) {
            return null;
        } else {
            return results[1];
        }
    }
})(jQuery);

function llamadaAjax() {
    
    var parametro1 = 1;
    var parametro2 = 2;

    $.ajax({
        url: "Ajax/Ejemplo.aspx/funcion",
        type: "POST",
        data: '{parametro1: "' + parametro1 + '", parametro2: "' + parametro2 + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function () {
            $("#cargando").fadeIn();

        },
        success: function (response) {
            if (response.d.substring(11, 16) == ':[]}') {
                Mensaje("Sin datos.", 'danger', 'Alerta');
            } else {
                Mensaje("Valor devuelto: " + response.d, 'success', 'Nota');
            }
        },
        error: function (response) {
            Mensaje("Se produjo un error al cargar los datos. El servidor devolvió el siguiente mensaje:<br /><br />" + response, 'danger', 'Alerta');
        },
        cache: false
    });
}


function verifincid() {
    $("#incidencia").hide();
    var incidencia = $("#txt_incidencia").val();
    var usuario = $("#lbl_usuario").html();
    var user = escape(usuario);
    //event.preventDefault();
    $.ajax({
        url: "Ajax/Ejemplo.aspx/ValIncid",
        type: "POST",
        data: '{incidencia: "' + incidencia + '", usuario: "' + user + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function () {
            $("#cargando").fadeIn();

        },
        success: function (response) {
            if (response.d.substring(11, 16) == ':[]}') {
                Mensaje("Sin Datos.", 'danger', 'Alerta');
                $("#incidencia").show();
            } else {
                if (response.d == 'No se puede encontrar la tabla 0.' || response.d == 'Cannot find table 0.') {
                    Mensaje("Incidencia inválida", 'danger', 'Alerta');
                    $("#incidencia").show();
                } else {
                    Mensaje("Incidencia válida", 'success', 'Nota');
                    setTimeout(function () { window.location = "PIN.aspx?incidencia=" + incidencia + "&hash=" + response.d.substring(20, 84); }, 2000);

                }
            }
        },
        error: function (response) {
            Mensaje("Incidencia inválida", 'danger', 'Alerta');
            $("#incidencia").show();
        },
        cache: false
    });
}

function alta() {
    var user = $.get("user");
    var rnd = $.get("rnd");

    window.location = "DNI.aspx?rnd=" + rnd + "&user=" + user + "&tramite=Alta"
}

function tramite(tramite) {
    var user = $.get("user");
    var rnd = $.get("rnd");

    window.location = "DNIC.aspx?rnd=" + rnd + "&user=" + user + "&tramite=" + tramite
}

function verifident() {
    $("#identidad").hide();
    var identidad = $("#txt_identidad").val();
    var hash = $.get("hash")
    var incidencia = $.get("incidencia")
    //event.preventDefault();
    $.ajax({
        url: "Ajax/Ejemplo.aspx/ValIdent",
        type: "POST",
        data: '{identidad: "' + identidad + '",hash: "' + hash + '",incidencia: "' + incidencia + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function () {
            $("#cargando").fadeIn();

        },
        success: function (response) {
            if (response.d.substring(11, 16) == ':[]}') {
                $("#identidad").show();
            } else {
                if (response.d == 'No se puede encontrar la tabla 0.' || response.d == 'Cannot find table 0.') {
                    Mensaje("Usuario inválido", 'danger', 'Alerta');
                    $("#identidad").show();
                    } else {
                    Mensaje("Bienvenido: " +response.d.substring(response.d.indexOf('"Vendedor":"') + 12, response.d.indexOf("}]") - 1), 'success', 'Nota');
                    setTimeout(function () { window.location = "Tramite.aspx?rnd=" + response.d.substring(response.d.indexOf('"rnd":"') + 7, response.d.indexOf('","')) + "&user=" + response.d.substring(response.d.indexOf('"Vendedor":"') + 12, response.d.indexOf("}]") - 1); }, 2000);

                }
             }
        },
        error: function (response) {

            $("#identidad").show();
        },
        cache: false
    });
}

function verifdni() {
    $("#dnic").hide();
    var dni = $("#txt_dni").val();
    var tipo = $("#tipo_doc").val();
    var user = $.get("user");
    var rnd = $.get("rnd");
    //event.preventDefault();
    $.ajax({
        url: "Ajax/Ejemplo.aspx/ValDNI",
        type: "POST",
        data: '{DNI: "' + dni + '",tipodoc: "' + tipo + '",User: "' + user + '",rnd: "' + rnd + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function () {
            $("#cargando").fadeIn();
        },
        success: function (response) {
            if (response.d.substring(11, 16) == ':[]}') {
                $("#dnic").show();
            } else {
                if (response.d == 'No se puede encontrar la tabla 0.' || response.d == 'Cannot find table 0.') {
                    Mensaje("DNI inválido", 'danger', 'Alerta');
                    $("#dnic").show();
                } else {
                    if (response.d.substring(response.d.indexOf('"DNI":"') + 7, response.d.indexOf('","tipo')) == 0) {
                        Mensaje("El DNI no existe, se ingresa nueva alta.", 'success', 'Nota');
                        setTimeout(function () { window.location = "Altas.aspx"; }, 2000);
                    }
                    else {
                        Mensaje("DNI validado: " + response.d.substring(response.d.indexOf('"DNI":"') + 7, response.d.indexOf('","tipo')), 'success', 'Nota');
                        setTimeout(function () { window.location = "ANI.aspx?user=" + user + "&rnd=" + rnd + "&dni=" + dni; }, 2000);
                    }
                }
            }
        },
        error: function (response) {
            $("#dnic").show();
        },
        cache: false
    });
}

function verifani() {
    $("#dnic").hide();
    var ani = $("#txt_ani").val();
    var user = $.get("user");
    var rnd = $.get("rnd");
    var dni = $.get("dni");
    //event.preventDefault();
    $.ajax({
        url: "Ajax/Ejemplo.aspx/ValANI",
        type: "POST",
        data: '{ANI: "' + ani + '",DNI: "' + dni + '",User: "' + user + '",rnd: "' + rnd + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function () {
            $("#cargando").fadeIn();
        },
        success: function (response) {
            if (response.d.substring(11, 16) == ':[]}') {
                $("#dnic").show();
            } else {
                if (response.d == 'No se puede encontrar la tabla 0.' || response.d == 'Cannot find table 0.') {
                    Mensaje("ANI inválido", 'danger', 'Alerta');
                    $("#dnic").show();
                } else {
                        Mensaje("ANI validado: " + response.d.substring(response.d.indexOf('"ANI":"') + 7, response.d.indexOf('","')), 'success', 'Nota');
                        setTimeout(function () { window.location = "Altas.aspx"; }, 2000);
                }
            }
        },
        error: function (response) {
            $("#dnic").show();
        },
        cache: false
    });
}

function verifanic() {
    $("#dnic").hide();
    var ani = $("#txt_ani").val();
    var user = $.get("user");
    var rnd = $.get("rnd");
    var tramite = $.get("tramite");
    var dni = $.get("dni");
    var tipo="dni"
    //event.preventDefault();
    $.ajax({
        url: "Ajax/Ejemplo.aspx/ValANIC",
        type: "POST",
        data: '{ANI: "' + ani + '", DNI: "' + dni + '",tipodoc: "' + tipo + '",User: "' + user + '",rnd: "' + rnd + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function () {
            $("#cargando").fadeIn();
        },
        success: function (response) {
            if (response.d.substring(11, 16) == ':[]}') {
                $("#dnic").show();
            } else {
                if (response.d == 'No se puede encontrar la tabla 0.' || response.d == 'Cannot find table 0.') {
                    $("#dnic").show();
                } else {
                    if (response.d.substring(response.d.indexOf('"DNI":"') + 7, response.d.indexOf('","tipo')) == 0 && tramite == "porta") {
                        setTimeout(function () { window.location = "Formularios.aspx?tramite=" + tramite; }, 2000);
                    }
                    else {
                        if (response.d.substring(response.d.indexOf('"DNI":"') + 7, response.d.indexOf('","tipo')) == 0) {
                            $("#dnic").show();
                        }
                        else {
                            Mensaje("ANI validado: " + response.d.substring(response.d.indexOf('"ANI":"') + 7, response.d.indexOf('","')), 'success', 'Nota');
                            setTimeout(function () { window.location = "Formularios.aspx?tramite=" + tramite; }, 2000);
                        }

                    }

                }
            }
        },
        error: function (response) {
            $("#dnic").show();
        },
        cache: false
    });
}

function verifdniani() {
    $("#dnic").hide();
    var dni = $("#txt_dni").val();
    var tipo = $("#tipo_doc").val();
    var user = $.get("user");
    var rnd = $.get("rnd");
    var tramite = $.get("tramite");
    //event.preventDefault();
    $.ajax({
        url: "Ajax/Ejemplo.aspx/ValDNIANI",
        type: "POST",
        data: '{DNI: "' + dni + '",tipodoc: "' + tipo + '",User: "' + user + '",rnd: "' + rnd + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function () {
            $("#cargando").fadeIn();
        },
        success: function (response) {
            if (response.d.substring(11, 16) == ':[]}') {
                $("#dnic").show();
            } else {
                if (response.d == 'No se puede encontrar la tabla 0.' || response.d == 'Cannot find table 0.') {
                    $("#dnic").show(); 
                } else {
                    if (response.d.substring(response.d.indexOf('"DNI":"') + 7, response.d.indexOf('","tipo')) == 0) {
                        if (tramite == 'porta') {
                            setTimeout(function () { window.location = "Formularios.aspx?tramite=" + tramite; }, 2000);
                        }
                        else {
                            $("#dnic").show();
                        }
                        
                    }
                    else {
                        setTimeout(function () { window.location = "ANIC.aspx?user=" + user + "&rnd=" + rnd + "&dni=" + dni + "&tramite=" + tramite; }, 2000);
                    }

                }
            }
        },
        error: function (response) {
            $("#dnic").show();
        },
        cache: false
    });
}

function Guardar(tipo_operacion,usuario,hash) {

    ValidarCompletos();
    var tramite = tipo_operacion

    if (incompletos == 0) {

        if ($("#txt_datos_nombre").length > 0) {
            var txt_datos_nombre = $("#txt_datos_nombre").val();
        } else {
            var txt_datos_nombre = "";
        }
        
        if ($("#txt_fcnac_linea").length > 0) {
            var txt_datos_fcnac_linea = $("#txt_fcnac_linea").val();
        } else {
            var txt_datos_fcnac_linea = "";
        }

        if ($("#txt_datos_sexo").length > 0) {
            var txt_datos_sexo = $("#txt_datos_sexo").val();
        } else {
            var txt_datos_sexo = "";
        }

        if ($("#txt_datos_domicilio").length > 0) {
            var txt_datos_domicilio = $("#txt_datos_domicilio").val();
        } else {
            var txt_datos_domicilio = "";
        }

        if ($("#txt_datos_nrosim2").length > 0) {
            var txt_datos_nrosim2 = $("#txt_datos_nrosim2").val();
        } else {
            var txt_datos_nrosim2 = "";
        }

        if ($("#txt_datos_oper_donante").length > 0) {
            var txt_datos_oper_donante = $("#txt_datos_oper_donante").val();
        } else {
            var txt_datos_oper_donante = "";
        }
        if ($("#txt_datos_numeropin").length > 0) {
            var txt_datos_numeropin = $("#txt_datos_numeropin").val();
        } else {
            var txt_datos_numeropin = "";
        }
        if ($("#txt_datos_factura").length > 0) {
            var txt_datos_factura = $("#txt_datos_factura").val();
        } else {
            var txt_datos_factura = "";
        }
        if ($("#txt_datos_aniaportar").length > 0) {
            var txt_datos_aniaportar = $("#txt_datos_aniaportar").val();
        } else {
            var txt_datos_aniaportar = "";
        }

        if ($("#txt_datos_vtagarantia").length > 0) {
            var txt_datos_vtagarantia = $("#txt_datos_vtagarantia").val();
        } else {
            var txt_datos_vtagarantia = "";
        }

        var combo_plan = $("#combo_plan").val();
        var txt_datos_modsim = $("#txt_datos_modsim").val();
        var txt_datos_nrosim = $("#txt_datos_nrosim").val();
        var txt_datos_equipomarca = $(".equipomarca").val();
        var txt_datos_equipomodelo = $(".equipomodelo").val();
        var txt_datos_nroimei = $("#txt_datos_nroimei").val();
        var txt_datos_nroremito = $("#txt_datos_nroremito").val();

        //event.preventDefault();
        $.ajax({
            cache: false,
            url: 'Ajax/Ejemplo.aspx/Guardar',
            type: "POST",
            data: '{nombre: "' + txt_datos_nombre + '",fcnac_linea: "' + txt_datos_fcnac_linea + '",sexo: "' + txt_datos_sexo + '",domicilio: "' + txt_datos_domicilio + '",plan: "' + combo_plan + '",modsim: "' + txt_datos_modsim + '",nrosim: "' + txt_datos_nrosim + '",nrosim2: "' + txt_datos_nrosim2 + '",equipomarca: "' + txt_datos_equipomarca + '",equipomodelo: "' + txt_datos_equipomodelo + '",nroimei: "' + txt_datos_nroimei + '",nroremito: "' + txt_datos_nroremito + '",tipo_operacion: "' + tipo_operacion + '",txt_datos_oper_donante: "' + txt_datos_oper_donante + '",txt_datos_numeropin: "' + txt_datos_numeropin + '",txt_datos_factura: "' + txt_datos_factura + '",txt_datos_aniaportar: "' + txt_datos_aniaportar + '",tramite: "' + tramite + '",txt_datos_vtagarantia:"' + txt_datos_vtagarantia + '",usuario: "' + usuario + '",hash: "' + hash + '" }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend: function () {
                $("#cargando").fadeIn();

            },
            success: function (data) {
                if (data.d.substring(data.d.indexOf('"id":"') + 6, data.d.indexOf('"}],"')) >= 1) {
                    $('html,body').animate({ scrollTop: 0 }, 'slow');
                    $("#cargando").fadeOut();
                    if (tramite == 'Altas' || tramite == 'cbioeq') {
                        setTimeout(function () { window.location = "DatosPago.aspx?cd_tramite=" + data.d.substring(data.d.indexOf('"id":"') + 6, data.d.indexOf('"}],"')); }, 2000);
                    }
                    else {
                        if (tramite == 'casimctenohabla') {
                            setTimeout(function () { window.location = "Mensaje.aspx?tipo=ctenohablaagente&rnd=" + hash + "&user=" + usuario+""; }, 2000);
                            //ModalSimple("Atención", "<span style='font-size:20px;' class='negrita'>Generá un ticket en Mercurio para solicitar el cuelgue de una de las SIMS: <br/> Sistemas y Tecnología > Canales indirectos > Cte. no habla.</sapn><br/><br/> Muchas Gracias! <a class='btn bg-azul blanco margen10 animado sombraFx2 btn-lg pull-right' href='Tramite.aspx?rnd=" + hash + "&user=" + usuario + "'> Volver</a>");
                            $('input[id^="txt_datos_"]').each(function () { $(this).val(""); });
                        }
                        else {
                            //setTimeout(function () { window.location = "Tramite.aspx?rnd=" + hash + "&user=" + usuario + ""; }, 2000);
                            setTimeout(function () { window.location = "AniContacto.aspx?rnd=" + hash + "&user=" + usuario + "&cd_tramite=" + data.d.substring(data.d.indexOf('"id":"') + 6, data.d.indexOf('"}],"')) + ""; }, 2000);
                        }
                    }
                } else {
                }
            }
        });

    } else {
    }
}

function GuardarDatos(cd_tramite, usuario, hash) {

    ValidarCompletos();

    if (incompletos == 0) {

        var txt_fccupon = $("#txt_fccupon").val();
        var txt_datos_nrorecibo = $("#txt_datos_nrorecibo").val();
        var txt_datos_tarjeta = $("#txt_datos_tarjeta").val();
        var txt_datos_postnetera = $("#txt_datos_postnetera").val();
        var txt_datos_nrocomercio = $("#txt_datos_nrocomercio").val();
        var txt_datos_cantcuotas = $("#txt_datos_cantcuotas").val();
        var txt_datos_nrolote = $("#txt_datos_nrolote").val();
        var txt_datos_nrocupon = $("#txt_datos_nrocupon").val();
        var txt_datos_importe = $("#txt_datos_importe").val();

        //event.preventDefault();
        $.ajax({
            cache: false,
            url: 'Ajax/Ejemplo.aspx/DatosGuardar',
            type: "POST",
            data: '{txt_fccupon: "' + txt_fccupon + '",txt_datos_nrorecibo: "' + txt_datos_nrorecibo + '",txt_datos_tarjeta: "' + txt_datos_tarjeta + '",txt_datos_postnetera: "' + txt_datos_postnetera + '",txt_datos_nrocomercio: "' + txt_datos_nrocomercio + '",txt_datos_cantcuotas: "' + txt_datos_cantcuotas + '",txt_datos_nrolote: "' + txt_datos_nrolote + '",txt_datos_nrocupon: "' + txt_datos_nrocupon + '",txt_datos_importe: "' + txt_datos_importe + '",cd_tramite: "' + cd_tramite + '",usuario: "' + usuario + '",hash: "' + hash + '" }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend: function () {
                $("#cargando").fadeIn();

            },
            success: function (data) {
                if (data.d.substring(data.d.indexOf('"id":"') + 6, data.d.indexOf('"}],"')) >= 1) {
                    Mensaje('Datos cargados correctamente.', 'success', 'Nota');
                    $('html,body').animate({ scrollTop: 0 }, 'slow');
                    $("#cargando").fadeOut();
                    setTimeout(function () { window.location = "AniContacto.aspx?rnd=" + hash + "&user=" + usuario + "&cd_tramite=" + data.d.substring(data.d.indexOf('"id":"') + 6, data.d.indexOf('"}],"')) + ""; }, 2000);
                    //setTimeout(function () { window.location = "Tramite.aspx?rnd=" + hash + "&user=" + usuario + ""; }, 2000);
                } else {
                }
            }
        });

    } else {
        Mensaje('Campos incompletos o con tipo de dato erróneo, revisá por favor.', 'danger', 'Alerta');
    }
}

function guardocont(usuario, hash) {
    setTimeout(function () { window.location = "Tramite.aspx?rnd=" + hash + "&user=" + usuario + ""; }, 2000);
}


function comboModelo() {
    var marca = $("#txt_equipomarca").val();
    if (marca != 'Sin Equipo') {
        $(".sequip").show().prop("disabled",false);
    }
    else {
        $(".sequip").hide().prop("disabled", true);
    }
    //event.preventDefault();
    $.ajax({
        url: "Ajax/Ejemplo.aspx/traermodeloequipo",
        type: "POST",
        data: '{marca: "' + marca + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function () {
            $("#cargando").fadeIn()
            ;

        },
        success: function (response) {
            if (response.d == 'No se puede encontrar la tabla 0.' || response.d == 'Cannot find table 0.') {
            } else {
                $("#txt_equipomodelo").empty();
                $("#txt_equipomodelo").removeAttr('disabled');
                var jsonData = JSON.parse(response.d);
                $.each(jsonData.items, function (iIndex, sElement) {
                    
                    $("#txt_equipomodelo").append("<option>" + sElement.MOSTRAR + "</option>");
                    });
            }
        },
        error: function (response) {
            $("#incidencia").show();
        },
        cache: false
    });
}