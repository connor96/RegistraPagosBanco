
var _idCiclo;
var _idSede;
var _periodo;
var _mes;
var _anio;




$('#ddlsedes').change(function () {
    var n = $("#ddlsedes").val();
    //-----------------------------
    var today = new Date();
    var a = today.getFullYear();
    //---------------------------------
    var m = today.getMonth() + 1;
    //-----------------------------
    CargarNivel(n, a, m);
});

$('#ddlniveles').change(function () {
    var idsede = $("#ddlsedes").val();
    //---------------------------------
    var today = new Date();
    var anio = today.getFullYear();
    //---------------------------------
    var mes = today.getMonth() + 1;
    var codnivel = $("#ddlniveles").val();
    CargarFrecuencia(idsede, anio, mes, codnivel);

});

$('#ddlfrecuencia').change(function () {
    var n = $("#ddlsedes").val();
    //---------------------------------
    var today = new Date();
    var anio = today.getFullYear();
    //---------------------------------
    var mes = today.getMonth() + 1;
    var codnivel = $("#ddlniveles").val();
    var modalidad = $("#ddlfrecuencia").val();

    CargarCursos(n, anio, mes, codnivel, modalidad);
});


function CargarNivel(idsede, anio, mes) {
    cleanddl("ddlniveles");
    cleanddl("ddlfrecuencia");
    cleanddl("ddlcursos");
    var _caburl = _cabecera();

    $.ajax({
        url: _caburl + "/RegistroVoucherMP/ListarNivelesNinios",
        type: "POST",
        data: { idsede: idsede, anio: anio, mes: mes },
        success: function (resultado) {
            $.each(resultado, function (key, item) {
                $("#ddlniveles").append('<option value="' + item.codnivel + '">' + item.nivel + '</option>');
            });
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


function CargarFrecuencia(idsede, anio, mes, codnivel) {
    cleanddl("ddlfrecuencia");
    cleanddl("ddlcursos");
    var _caburl = _cabecera();
    $.ajax({
        url: _caburl + "/RegistroVoucherMP/ListarFrecuenciaNinio",
        type: "POST",
        data: { idsede: idsede, anio: anio, mes: mes, codnivel: codnivel },
        success: function (resultado) {
            console.log(resultado);
            $.each(resultado, function (key, item) {
                $("#ddlfrecuencia").append('<option value="' + item.idmodalidad + '">' + item.modalidad_esp + '</option>');
            });
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function cleanddl(objeto) {
    $("#" + objeto)
        .empty()
        .append("<option disabled selected>Selecciona una opción</option>");
}

function CargarCursos(idsede, anio, mes, codnivel, modalidad) {
    cleanddl("ddlcursos");
    var _caburl = _cabecera();
    $.ajax({
        url: _caburl + "/RegistroVoucherMP/ListarCursosNinios",
        type: "POST",
        data: { idsede: idsede, anio: anio, mes: mes, codnivel: codnivel, modalidad: modalidad },
        success: function (resultado) {
            $.each(resultado, function (key, item) {
                $("#ddlcursos").append('<option value="' + item.curso + '">' + item.curso + '</option>');
            });
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


function obtenerhorarios() {

    if ($('#ddlsedes').val() == null) {
        alerta();
    } else {
        $("#loading").addClass("version").addClass("text-center");
        console.log("Entro a listar frecuencia");
        //---------------------------------
        var today = new Date();
        var a = today.getFullYear();
        //---------------------------------
        var m = today.getMonth() + 2;
        var s = $("#ddlsedes").val();
        var cn = $("#ddlniveles").val();
        var mod = $("#ddlfrecuencia").val();
        var cur = $("#ddlcursos").val();
        //---------------------------------
        var url = _obtenerurl();
        var data = { idsede: s, nivel: cn, modalidad:mod, curso:cur};
        $("#tablaalumnos").load(url, data);
    }
}

function alerta() {
    swal({
        title: "Seleccione los datos que faltan",
        //text: "Esta acción ya no se podrá deshacer, Así que piénsalo bien.",
        type: "error",
        showCancelButton: false,
        confirmButtonColor: '#ff0d00',
        //cancelButtonColor: '#d33',
        confirmButtonText: 'ok',
        //cancelButtonText: "Cancelar"
    });
}

function siguiente() {
    if (_idCiclo != null) {
        var _caburl = _cabecera();
        $.ajax({
            url: _caburl + "/RegistroVoucherMP/AsignacionIdCicloUnCiclo",
            type: "POST",
            data: { idCiclo: _idCiclo },
            success: function (resultado) {
                location.href = _caburl + "/" + "RegistroVoucherMP/VoucherMP";
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });

    } else {
        alertaRadio();
    }
}

function obtenervalor(idCiclo, idSede, mes, anio) {

    _idCiclo = idCiclo;
    _idSede = idSede;
    _mes = mes;
    _anio = anio;


}


