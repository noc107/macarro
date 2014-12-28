function VerificarOperacion(id)
{
    var elemento = document.getElementById(id);
    if (elemento != null && elemento != undefined) {
        var r = confirm("¿Desea o está seguro de modificar?");
        if (r === true) {
            elemento.value = "1";

        }
        else {
            elemento.value = "0";
        }
    }
    return false;
}



function VerificarOperacionGestion(id) {
    var elemento = document.getElementById(id);
    if (elemento != null && elemento != undefined) {
        var r = confirm("¿Desea o está seguro de eliminar?");
        if (r === true) {
            elemento.value = "1";

        }
        else {
            elemento.value = "0";
        }
    }
    return false;
}