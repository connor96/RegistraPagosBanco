
function agregar() {

    var idConcepto = $("#varconcepto").val();
    console.log(idConcepto);

    if (idConcepto != null) {
        if (idConcepto == 31) {
            swal({
                title: 'Aviso Importante',
                text: "El costo del libro físico se ha incrementado por gastos de importación y traslados debido a la situación por la que pasa el país.",
                type: 'question',
                showCancelButton: true,
                confirmButtonColor: '#0a9c00',
                cancelButtonColor: 'red',
                confirmButtonText: 'Agregar libro',
                cancelmButtonText: 'Cancelar',
                reverseButtons: true
            }).then((result) => {
                if (result.value) {
                    var _caburl = _cabecera();
                    var url = _caburl + "/ConsultaPago/TableVouchers";
                    var data = { id: idConcepto, operacion: "agregar" };
                    $("#tablemontos").load(url, data);
                    $('#exampleModalCenter').modal('hide');
                    $("#varconcepto").val("0");
                } else {
                    $("#varconcepto").val("0");
                }
            });

        } else {
            var _caburl = _cabecera();
            var url = _caburl + "/ConsultaPago/TableVouchers";
            var data = { id: idConcepto, operacion: "agregar" };
            $("#tablemontos").load(url, data);
            $('#exampleModalCenter').modal('hide');
            $("#varconcepto").val("0");
        }

    } else {
        $("#varconcepto").addClass("is-invalid");
    }
}

function quitarelemento(item) {

    var _caburl = _cabecera();

    var url = _caburl + "/ConsultaPago/TableVouchers";
    var data = { id: item, operacion: "quitar" };
    $("#tablemontos").load(url, data);
}

function agregarlibro() {
    var _caburl = _cabecera();
    var idConcepto = $("#varlibro").val();

    if (idConcepto != null) {
        swal({
            title: 'Aviso Importante',
            text: "El costo del libro físico se ha incrementado por gastos de importación y traslados debido a la situación por la que pasa el país.",
            type: 'question',
            showCancelButton: true,
            confirmButtonColor: '#0a9c00',
            cancelButtonColor: 'red',
            confirmButtonText: 'Agregar libro',
            cancelmButtonText: 'Cancelar',
            reverseButtons: true
        }).then((result) => {
            if (result.value) {
                var _caburl = _cabecera();
                var url = _caburl + "/ConsultaPago/TableVouchers";
                var data = { id: idConcepto, operacion: "libro" };
                $("#tablemontos").load(url, data);
                $('#modalLibros').modal('hide');
                $("#varlibro").val("0");
            } else {
                $("#varlibro").val("0");
            }
        });

    } else {

        $("#varlibro").addClass("is-invalid");
    }
    
}

function validardeuda() {
    var concepto = $("#varconcepto").val();
    console.log(concepto);

}

function validalibro() {
    $("#varlibro").removeClass("is-invalid");
    $("#varlibro").addClass("is-valid");
}

function validaconcepto() {
    $("#varconcepto").removeClass("is-invalid");
    $("#varconcepto").addClass("is-valid");
}

function _lanzaralerta(estados, codcursiguiente) {
    switch (estados) {
        case 0:
            console.log('normal');
            break;
        case 1:
            //alertaninios("Kiddies 1");
            //break;
            console.log('normal');
            break;
        case 2:
            //alertaninios("Prekinder 1");
            //break;
            console.log('normal');
            break;
        case 3:
            //alertaninios("Kinder 1");
            //break; 
            console.log('normal');
            break;
        case 4:
            //alertaninios("Kids1");
            //break;
            console.log('normal');
            break;
        case 5:
            //alertaninios("Junior 1");
            //break;
            console.log('normal');
            break;
        case 6:
            alertaninios2();
            break;
        default:
            console.log("Valor no admitido");
            break;
    }
}

function alertaninios(texto_alt) {
    swal({
        title: "Aviso Importante",
        text: "El alumno podría de pasar al ciclo " + texto_alt +" por su edad, Si usted lo desea comuníquese con cualquiera de los siguiente numero de acuerdo a su sede: Huancayo 918817969, Huánuco: 938564260, Huamanga: 959156500, La Merced: 956929296",
        type: "warning",
        showCancelButton: false,
        confirmButtonColor: '#ff0d00',
        //cancelButtonColor: '#d33',
        confirmButtonText: 'ok',
        //cancelButtonText: "Cancelar"
    });
}

function alertaninios2() {
    swal({
        title: "Aviso Importante",
        text: "Le indicamos que el siguiente sub-nivel es el Kids, para niños de 6 años a más. Su niño(a) todavía no cumple 6 años. Por favor, escriba a academico@icpnarc.edu.pe o llame al 918817969 para obtener mayor información al respecto.",
        type: "warning",
        showCancelButton: false,
        confirmButtonColor: '#ff0d00',
        //cancelButtonColor: '#d33',
        confirmButtonText: 'ok',
        //cancelButtonText: "Cancelar"
    });
}


function registrarpago() {
    var _caburl = _cabecera();
    location.href = _caburl + "/" + "RegistroVoucherMP";
}