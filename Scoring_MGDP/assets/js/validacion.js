function ValidarCompletos() {

    incompletos = 0;
    
    $('input[id^="txt_datos_"], textarea[id^="txt_datos_"], select[id^="txt_datos_"]').each(function () {
        if ($(this).val() == "") {
            //alert($(this).attr("name"));
            $(this).css({ 'border': 'solid 2px red', 'background-color': 'white' });
            incompletos += 1;
        } else {
            if ($(this).val().indexOf("_") < 0){
                if ($(this).hasClass("validaTexto")) {
                    ValidarTexto($(this));
                } else {
                    if ($(this).is('[class*="validaLargo"]')) {
                        var largoMaximo = $(this).attr("data-largo-maximo");
                        var largoMinimo = $(this).attr("data-largo-minimo");
                        ValidarLargo($(this), largoMaximo, largoMinimo);
                    } else {
                        if ($(this).hasClass("validaMail")) {
                            ValidarMail($(this));
                        } else {
                            if ($(this).hasClass("validaDominio")) {
                                ValidarDominio($(this));
                            } else {
                                if ($(this).attr("name") == "txt_datos_rb_id" && ($(this).val() > 254 || $(this).val() < 1)) { //
                                    incompletos += 1;
                                    $(this).css({ 'border': 'solid 2px red', 'background-color': 'white' });
                                } else {
                                    $(this).removeAttr('style');
                                }
                            }
                        }
                    }
                }
            } else {
                incompletos += 1; // Este es el guion bajo del input mask
            }
        }
    })
}

function ValidarTexto(input) {

    var valor = $(input).val();
    var re2 = /^([a-z_ /\\/ ñáéíóúÑÁÉÍÓÚ']{1,1000})$/i;

    if (!re2.test(valor)) {
        incompletos += 1;
        $(input).css({ 'border': 'solid 2px red', 'background-color': 'white' });
    } else {
        $(input).removeAttr('style');
    }

}

function ValidarDominio(input) {

    var valor = $(input).val();
    var re2 = /^([a-z_ /\\/]{1,20})$/i; // Acepta letras y barra

    if (!re2.test(valor) || valor.split("\\").length - 1 >= 2 || valor.split("\\").length - 1 == 0) {
        incompletos += 1;
        //Mensaje('El dominio permite sólo letras y una barra. No se aceptan números ni caracteres especiales, verificá por favor.', 'danger', 'Alerta');
        $(input).css({ 'border': 'solid 2px red', 'background-color': 'white' });
    } else {
        $(input).removeAttr('style');
    }

}


function ValidarMail(input) {

    var valor = $(input).val().toLowerCase();
    var re2 = /^\s*[\w\-\+_]+(\.[\w\-\+_]+)*\@[\w\-\+_]+\.[\w\-\+_]+(\.[\w\-\+_]+)*\s*$/;

    if (re2.test(valor)) {
        $(input).removeAttr('style');
    } else {
        $(input).css({ 'border': 'solid 2px red', 'background-color': 'white' });
        incompletos += 1;
    }

}

function ValidarLargo(input, largoMaximo, largoMinimo) {

    var valor = $(input).val();

    if (valor.length > largoMaximo) {
        incompletos += 1;
        $(input).css({ 'border': 'solid 2px red', 'background-color': 'white' });
    } else {
        if (valor.length < largoMinimo) {
            incompletos += 1;
            $(input).css({ 'border': 'solid 2px red', 'background-color': 'white' });
        } else {
            $(input).removeAttr('style');
        }
    }

}