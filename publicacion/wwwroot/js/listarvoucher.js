function detalles(idtransaccion,tipo){
    console.log(idtransaccion);
    console.log(tipo);
    var _caburl = _cabecera();
    //pension

    var url = _caburl + "/ListaVoucher/DetalleVoucher";
    var data = { idTransaccion: idtransaccion };
    $("#modaldescripcion").load(url, data, function () {
        $('#exampleModalCenter').modal('show');
    });

    //if (tipo == "1") {

    //    var url = _caburl + "/ListaVoucher/DetalleMP";
    //    var data = { idTransaccion: idtransaccion };
    //    $("#modaldescripcion").load(url, data, function () {
    //        $('#exampleModalCenter').modal('show');
    //    });

    //    //otro
    //} else {
    //    var url = _caburl + "/ListaVoucher/DetallePV";
    //    var data = { idTransaccion: idtransaccion };
    //    $("#modaldescripcion").load(url, data, function () {
    //        $('#exampleModalCenter').modal('show');
    //    });

    //}
}

function downloadReportPV(idtransaccion) {
    var _caburl = _cabecera();

    $.ajax({
        url: _caburl + "/ListaVoucher/DetalleMPjson",
        type: "POST",
        data: { idTransaccion: idtransaccion },
        success: function (resultado) {
            location.href = _caburl + "/" + "ListaVoucher/GeneratePdfPV";
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function downloadReportMP(idtransaccion) {
    var _caburl = _cabecera();

    $.ajax({
        url: _caburl + "/ListaVoucher/DetalleMPjson",
        type: "POST",
        data: { idTransaccion: idtransaccion },
        success: function (resultado) {
            location.href = _caburl + "/" + "ListaVoucher/GeneratePdf";
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


function nuevoVoucherPV() {
    var _caburl = _cabecera();
    location.href = _caburl + "/" + "RegistroVoucherPV/";
}

function nuevoVoucherMP() {
    var _caburl = _cabecera();
    location.href = _caburl + "/" + "RegistroVoucherMP/";
}

function detallesenlace(ciclo) {
    var _caburl = _cabecera();
    var url = _caburl + "/ListaVoucher/ModalCurso";
    var data = { idCiclo: ciclo };
    $("#modalclases").load(url, data, function () {
        $('#exampleModalCenter2').modal('show');
    });
}