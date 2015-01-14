/*
$(function () {
    $("#dialog").hide();
    $("#infoButton").on("click", function () {
        $("#dialog").show();
        $("#dialog").dialog();
    });
});
*/

var tamHorario = 0;
var categoriaSeleccionada = 0;

function validateLength(oSrc, args) {  
    var options = $("[id*=middle_place_holder_listboxHorario] option")
    tamHorario = options.length    
    args.IsValid = ((args.Value.length >= 1)  && (tamHorario >= 1));
} 

function validateCategoria(oSrc, args) {
    otraCategoria = $('#middle_place_holder_inputCategoriaOtro').val();    
    args.IsValid = ( ( args.Value.length >= 1 && otraCategoria.length > 0) || ( categoriaSeleccionada == 0 ) );

}

function Check(textBox, maxLength) {
    if (textBox.value.length > maxLength) {
      
        textBox.value = textBox.value.substr(0, maxLength);
    }
}


$(document).ready(function () {

    $('#inputDescripcion').keypress(function (e) {
        textbox = document.getElementById("inputDescripcion");
        if (textBox.value.length > maxLength) {

            textBox.value = textBox.value.substr(0, maxLength);
        }
    });

    $('.cambioCategoria').change(function () {
        if ($(this).val() == 'Otro') {
            categoriaSeleccionada = 1;
            $('.divCategoriaOtro').css('visibility', 'visible')
            $('.formulario').css('min-height', '580px')
            $('.divCategoriaOtro').css('position', 'relative')
        }
        else {
            categoriaSeleccionada = 0;
            $('.divCategoriaOtro').css('visibility', 'hidden')
            $('.formulario').css('min-height', '520px')           
            //$('.divCategoriaOtro').text("");
            $('.divCategoriaOtro').css('position', 'absolute')
        }
    });


    $('.listaHorasIni').hide();
    $('.listaHorasFin').hide();
    var numHoraIni = 0;
    var numHoraFin = 0;
    $('.dropdownlistHoraIni').val('-- : --')
    $('.dropdownlistHoraFin').val('-- : --')
    var texto;

    $('.relojIni').on('click', function () {
        if (numHoraIni == 0) {
            $('.listaHorasIni').fadeIn(200);
            numHoraIni = 1;
            if (numHoraFin == 1) {
                $('.listaHorasFin').fadeOut(200);
                numHoraFin = 0;
            }
        } else {
            $('.listaHorasIni').fadeOut(200);
            numHoraIni = 0;
        }
    });

    $('.relojFin').on('click', function () {
        if (numHoraFin == 0) {
            $('.listaHorasFin').fadeIn(200);
            numHoraFin = 1;
        } else {
            $('.listaHorasFin').fadeOut(200);
            numHoraFin = 0;
        }
    });

    $('.listaHorasIni').mouseleave(function () {
        $('.listaHorasIni').fadeOut(200)
        numHoraIni = 0;

    })

    $('.listaHorasFin').mouseleave(function () {
        $('.listaHorasFin').fadeOut(200)
        numHoraFin = 0;

    })

    // Ajustar la hora de fin dependiendo de la hora de inicio, se valida turno "am" o "pm", se escribe valor default, se incrementa hasta llegar a las 12:00 am
    $('.listaHorasIni ul li').on('click', function () {
        //$('.dropdownlistHoraIni').text($(this).text())
        $('.dropdownlistHoraIni').val($(this).text());
        $('.dropdownlistHoraFin').val("-- : --");
        $('.listaHorasIni').fadeOut(200);
        numHoraIni = 0;

        var horaIni = $(this).text().split(':')      // split de la hora de inicio selecionada
        var turno = horaIni[1].split(' ');           // turno "am" o "pm"
        var esManana = false;                        // indicador de "am"
        var ceroInicial = ''                         // variable de cero por delante de valores con 1 digito
        var noche = false                            // indicador de noche "pm"
        $('.listaHorasFin ul').empty();
        if (turno[1] == 'am')
            esManana = true;

        for (var i = parseInt(horaIni[0]) ; i <= 12; i++) {
            if (i + 1 > 12 && !esManana && !noche) {
                esManana = false;
                i = 0
                noche = true
            }
            else if (i + 1 == 12 && !noche && esManana)
                esManana = false;
            else if (i < 11 && !esManana && !noche)
                noche = true;
            else if ((i >= 11 && noche) || (i == 11 && !noche)) {
                $('.listaHorasFin ul').append('<li value="' + ceroInicial + (1 + i).toString() + ':00 am' + '">' + ceroInicial + (1 + i).toString() + ':00 am' + '</li>')
                break                                // fin del ciclo
            }

            if (i + 1 < 10)
                ceroInicial = '0'
            else
                ceroInicial = ''

            if (esManana) {
                if (turno[0] != '30')
                    $('.listaHorasFin ul').append('<li value="' + ceroInicial + (1 + i).toString() + ':00 am' + '">' + ceroInicial + (1 + i).toString() + ':00 am' + '</li>')
                $('.listaHorasFin ul').append('<li value="' + ceroInicial + (1 + i).toString() + ':30 am' + '">' + ceroInicial + (1 + i).toString() + ':30 am' + '</li>')
            }
            else {
                if (turno[0] != '30')
                    $('.listaHorasFin ul').append('<li value="' + ceroInicial + (1 + i).toString() + ':00 pm' + '">' + ceroInicial + (1 + i).toString() + ':00 pm' + '</li>')
                $('.listaHorasFin ul').append('<li value="' + ceroInicial + (1 + i).toString() + ':30 pm' + '">' + ceroInicial + (1 + i).toString() + ':30 pm' + '</li>')
            }

            turno[0] = '00'
        }
    });


    $('.listaHorasFin').on('click', 'li', function () {
        $('.dropdownlistHoraFin').val($(this).text());
        $('.listaHorasFin').fadeOut(200);
        numHoraFin = 0;
    })

    /*
    
    $('.botonMas').click(function () {
        if ($('.dropdownlistHoraIni').val() !=  '-- : --' && $('.dropdownlistHoraFin').val() !=  '-- : --') {
            $('.horasListbox').append('<option value="' + $('.dropdownlistHoraIni').val() + ' a ' + $('.dropdownlistHoraFin').val() + '">' + $('.dropdownlistHoraIni').val() + ' a ' + $('.dropdownlistHoraFin').val() + '</option>')
            tamHorario = tamHorario + 1; 
            $('.dropdownlistHoraIni').val('-- : --')
            $('.dropdownlistHoraFin').val('-- : --')
        }       
    })

    $('.botonMenos').click(function () {
        if ($('.horasListbox').val() != null) {
            $('.horasListbox option[value="' + $('.horasListbox').val() + '"]').remove()
            tamHorario = tamHorario - 1;
        }
    })
    */
    
    $('.dropdownlistHoraIni, .dropdownlistHoraFin').focus(function(){
        texto = $(this).val();
    })

    $('.dropdownlistHoraIni, .dropdownlistHoraFin').keyup(function () {
        $(this).val(texto);
    })

    $('.dropdownlistHoraIni, .dropdownlistHoraFin').keydown(function () {
        $(this).val(texto);
    })
})