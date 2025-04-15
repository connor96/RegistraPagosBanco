function nuevoVoucher() {
    var _caburl = _cabecera();
    location.href = _caburl + "/" + "RegistroVoucherMP/";
}

function listaVouchers() {
    var _caburl = _cabecera();
    location.href = _caburl + "/" + "ListaVoucher/";
}

function downloadReport() {
    var _caburl = _cabecera();
    location.href = _caburl + "/" + "RegistroVoucherMP/GeneratePdf";
}

function nuevoVoucherPV() {
    var _caburl = _cabecera();
    location.href = _caburl + "/" + "RegistroVoucherPV/";
}

function downloadReportPV() {
    var _caburl = _cabecera();
    location.href = _caburl + "/" + "RegistroVoucherPV/GeneratePdf";
}


function nuevoVoucherNinios() {
    var _caburl = _cabecera();
    location.href = _caburl + "/" + "RegistroVoucherMP/RegistroNinios";
}

function listaVouchersNinios() {
    var _caburl = _cabecera();
    location.href = _caburl + "/" + "ListaVoucher/";
}