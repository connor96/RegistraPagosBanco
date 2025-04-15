function obteneropcion(valor) {

    var _caburl = _cabecera();

    if (valor == 1) {
        location.href = _caburl + "/" + "RegistroVoucherMP/RegistroCiclo/";
    } else {

        location.href = _caburl + "/" + "RegistroVoucherMP/ListarCiclo/";

    }
}
