var xPadding = 90;
var yPadding = 30;

// Retorna el valor maximo en Y de los datos 
function getMaxY(data) {
    var max = 0;

    for (var i = 0; i < data.values.length; i++) {
        if (data.values[i].Y > max) {
            max = data.values[i].Y;
        }
    }

    max += 10 - max % 10;
    return max;
}

// Retorna el valor maximo en X de la lista (siempre será el mismo)
function getMaxX(data) {
    var max = 0;

    for (var i = 0; i < data.values.length; i++) {
        if (data.values[i].X > max) {
            max = data.values[i].X;
        }
    }

    max += 10 - max % 10;
    return max;
}

// Retorna el pixel "x" del canvas
function getXPixel(val, graph, data) {

    return ((graph.width - 100 - xPadding) / getMaxX(data)) * val + (xPadding * 0.8);
}

// Retorna el pixel "y" del canvas
function getYPixel(val, graph, data) {

    return graph.height - (((graph.height - yPadding) / getMaxY(data)) * val) - yPadding;
}

// Simplifica los valores
function obtenerDivisor(ingresos) {

    var divisor = 1;
    var numeroDigitos = 0;
    for (var i = 0; i < ingresos.length; i++) {

        if (ingresos[i] != 'x')
            if (numeroDigitos < ingresos[i].length)
                numeroDigitos = ingresos[i].length;
    }

    for (var i = 1; i < numeroDigitos - 1; i++)
        divisor = divisor * 10;

    return divisor;
}

// Llena los datos del grafico para los dias
function llenarDatos(ingresos, divisor) {
    var datos = { values: [] }

    for (var i = 0; i < ingresos.length; i++) {

        datos.values.push({ X: 0, Y: 0 });
        datos.values[i].X = i + 1;
        if (ingresos[i] != 'x')
            datos.values[i].Y = ingresos[i] / divisor;
    }

    return datos;
}

function generarGrafica() {

    var graph = document.getElementById("graficoDia");;
    var c = graph.getContext('2d');
    var ingresos = $('.hiddenValoresDias').val().split("$");
    var fechaDia = $('.hiddenFechaDia').val();
    var divisor = obtenerDivisor(ingresos);
    var data = llenarDatos(ingresos, divisor);

    c.lineWidth = 2;
    c.strokeStyle = '#095587';
    c.font = 'italic 8pt sans-serif';
    c.textAlign = "center";

    // Dibuja los ejes
    c.beginPath();
    c.moveTo(xPadding, 10);
    c.lineTo(xPadding, graph.height - yPadding);
    c.lineTo(graph.width - 45, graph.height - yPadding);
    c.stroke();
    c.fillStyle = '#fff';
    c.fillRect(xPadding + 2, 9, graph.width - 135, graph.height - yPadding - 10);

    // Dibuja el texto en X
    for (var i = 0; i < data.values.length; i++) {
        c.beginPath();
        c.moveTo(getXPixel(data.values[i].X + i * 0.5, graph, data), graph.height - yPadding);
        c.lineTo(getXPixel(data.values[i].X + i * 0.5, graph, data), graph.height - yPadding + 5);
        c.stroke();
        if (i == data.values.length - 1) {
            c.fillStyle = '#00c408';
            c.fillText(fechaDia, getXPixel(data.values[i].X + i * 0.5, graph, data), graph.height - yPadding + 20);
        }
    }

    // Dibuja el texto en Y
    c.fillStyle = '#2980B9';
    c.textAlign = "right"
    c.textBaseline = "middle";

    for (var i = 0; i < getMaxY(data) ; i += 5) {
        if (i != 0) {

            c.beginPath();
            c.moveTo(xPadding, getYPixel(i, graph, data));
            c.lineTo(xPadding - 5, getYPixel(i, graph, data));
            c.stroke();
        }
        c.fillText(i * divisor, xPadding - 10, getYPixel(i, graph, data));
    }

    c.strokeStyle = '#f00';

    // Dibuja las lineas del gráfico
    c.beginPath();
    c.moveTo(getXPixel(data.values[0].X, graph, data), getYPixel(data.values[0].Y, graph, data));
    for (var i = 1; i < data.values.length; i++) {
        c.lineTo(getXPixel(data.values[i].X + i * 0.5, graph, data), getYPixel(data.values[i].Y, graph, data));
    }
    c.stroke();

    // Dibuja los puntos
    c.fillStyle = '#084268';

    for (var i = 0; i < data.values.length; i++) {
        if (data.values[i].Y != 0 || i == data.values.length - 1) {
            c.beginPath();
            c.arc(getXPixel(data.values[i].X + i * 0.5, graph, data), getYPixel(data.values[i].Y, graph, data), 4, 0, Math.PI * 2, true);
            c.fill();
        }
    }


}


function generarGraficaMes() {

    var graph = document.getElementById("graficoMes");;
    var c = graph.getContext('2d');
    var ingresos = $('.hiddenValoresMes').val().split("$");
    var fechaMes = $('.hiddenFechaMes').val();
    var divisor = obtenerDivisor(ingresos);
    var data = llenarDatos(ingresos, divisor);
    console.log(ingresos);
    c.lineWidth = 2;
    c.strokeStyle = '#095587';
    c.font = 'italic 8pt sans-serif';
    c.textAlign = "center";

    // Dibuja los ejes
    c.beginPath();
    c.moveTo(xPadding, 10);
    c.lineTo(xPadding, graph.height - yPadding);
    c.lineTo(graph.width - 45, graph.height - yPadding);
    c.stroke();
    c.fillStyle = '#fff';
    c.fillRect(xPadding + 2, 9, graph.width - 135, graph.height - yPadding - 10);

    // Dibuja el texto en X
    for (var i = 0; i < data.values.length; i++) {
        c.beginPath();
        c.moveTo(getXPixel(data.values[i].X + i * 0.8, graph, data), graph.height - yPadding);
        c.lineTo(getXPixel(data.values[i].X + i * 0.8, graph, data), graph.height - yPadding + 5);
        c.stroke();
        if (i == data.values.length - 1) {
            c.fillStyle = '#00c408';
            c.fillText(fechaMes, getXPixel(data.values[i].X + i * 0.8, graph, data), graph.height - yPadding + 20);
        }
    }

    // Dibuja el texto en Y
    c.fillStyle = '#2980B9';
    c.textAlign = "right"
    c.textBaseline = "middle";

    for (var i = 0; i < getMaxY(data) ; i += 5) {
        if (i != 0) {

            c.beginPath();
            c.moveTo(xPadding, getYPixel(i, graph, data));
            c.lineTo(xPadding - 5, getYPixel(i, graph, data));
            c.stroke();
        }
        c.fillText(i * divisor, xPadding - 10, getYPixel(i, graph, data));
    }

    c.strokeStyle = '#f00';

    // Dibuja las lineas del gráfico
    c.beginPath();
    c.moveTo(getXPixel(data.values[0].X, graph, data), getYPixel(data.values[0].Y, graph, data));
    for (var i = 1; i < data.values.length; i++) {
        c.lineTo(getXPixel(data.values[i].X + i * 0.8, graph, data), getYPixel(data.values[i].Y, graph, data));
    }
    c.stroke();

    // Dibuja los puntos
    c.fillStyle = '#084268';

    for (var i = 0; i < data.values.length; i++) {
        if (data.values[i].Y != 0 || i == data.values.length - 1) {
            c.beginPath();
            c.arc(getXPixel(data.values[i].X + i * 0.8, graph, data), getYPixel(data.values[i].Y, graph, data), 4, 0, Math.PI * 2, true);
            c.fill();
        }
    }


}


$(document).ready(function () {

    $('.radioCierreCaja').change(function () {

        $('#middle_place_holder_RequiredFieldValidator1, #middle_place_holder_RequiredFieldValidator2').css('visibility', 'hidden')

        if ($('.cierreCajaDefault').hasClass('visible')) {

            $('.cierreCajaDefault').removeClass('visible')
            $('.cierreCajaDefault').css('visibility', 'hidden')
            $('.cierreCajaDefault').css('position', 'absolute')
        }

        if ($(this).hasClass('radioDia')) {

            $('.cierreCajaMes').css('visibility', 'hidden')
            $('.cierreCajaMes').css('position', 'absolute')
            $('.cierreCajaDia').css('visibility', 'visible')
            $('.cierreCajaDia').css('position', 'relative')
        }
        else {

            $('.cierreCajaDia').css('visibility', 'hidden')
            $('.cierreCajaDia').css('position', 'absolute')
            $('.cierreCajaMes').css('visibility', 'visible')
            $('.cierreCajaMes').css('position', 'relative')
        }

    })


})