var _idCiclo;
var _idSede;
var _periodo;
var _mes;
var _anio;

//$('#ddlsedes').change(function () {
//    var n = $("#ddlsedes").val();
//    //-----------------------------
//    var today = new Date();
//    var a = today.getFullYear();
//    //---------------------------------
//    var m = today.getMonth() + 1;
//    //-----------------------------
//    CargarNivel(n, a, m);
//});


$('#ddlsedes2').change(function () {
    var n = $("#ddlsedes2").val();
    //-----------------------------
    var today = new Date();
    var a = today.getFullYear();
    //---------------------------------
    var m = today.getMonth() + 1;
    //-----------------------------
    CargarNivel2(n, a, m);
});


function CargarNivel2(idsede, anio, mes) {
    cleanddl("ddlniveles2");
    cleanddl("ddlfrecuencia2");
    cleanddl("ddlcursos2");
    var _caburl = _cabecera();

    $.ajax({
        url: _caburl + "/RegistroVoucherMP/ListarNiveles",
        type: "POST",
        data: { idsede: idsede, anio: anio, mes: mes },
        success: function (resultado) {
            $.each(resultado, function (key, item) {
                $("#ddlniveles2").append('<option value="' + item.codnivel + '">' + item.nivel + '</option>');
            });
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}



//Funciones agregadas
$('#ddlsedes').change(function () {
    var n = $("#ddlsedes").val();
    //-----------------------------
    var today = new Date();
    var a = today.getFullYear();
    //---------------------------------
    var m = today.getMonth() + 1;
    //-----------------------------
    CargarNivelFrecuencia(n);
});


function CargarNivelFrecuencia(idsede) {
    
    cleanddl("ddlfrecuencia");
    
    var _caburl = _cabecera();

    $.ajax({
        url: _caburl + "/RegistroVoucherMP/IntranetBuscarSede",
        type: "POST",
        data: { sede: idsede },
        success: function (resultado) {
            $.each(resultado, function (key, item) {
                $("#ddlfrecuencia").append('<option value="' + item.idmodalidad + '">' + item.modalidad_esp + '</option>');
            });
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//Fin de Funciones agregadas

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


$('#ddlniveles2').change(function () {
    var idsede = $("#ddlsedes2").val();
    //---------------------------------
    var today = new Date();
    var anio = today.getFullYear();
    //---------------------------------
    var mes = today.getMonth() + 1;
    var codnivel = $("#ddlniveles2").val();
    CargarFrecuencia2(idsede, anio, mes, codnivel);

});


function CargarFrecuencia2(idsede, anio, mes, codnivel) {
    cleanddl("ddlfrecuencia2");
    cleanddl("ddlcursos2");
    var _caburl = _cabecera();
    $.ajax({
        url: _caburl + "/RegistroVoucherMP/ListarFrecuencia",
        type: "POST",
        data: { idsede: idsede, anio: anio, mes: mes, codnivel: codnivel },
        success: function (resultado) {
            $.each(resultado, function (key, item) {
                $("#ddlfrecuencia2").append('<option value="' + item.idmodalidad + '">' + item.modalidad_esp + '</option>');
            });
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


//Funciones agregadas
$('#ddlfrecuencia').change(function () {
    var n = $("#ddlsedes").val();
    //---------------------------------
    var today = new Date();
    var anio = today.getFullYear();
    //---------------------------------
    var mes = today.getMonth() + 1;
    //var codnivel = $("#ddlniveles").val();
    var modalidad = $("#ddlfrecuencia").val();

   
});



function activarbuttonBusqueda() {

    if ($('#ddlsedes').val() == null || $('#ddlfrecuencia').val() == null ) {
        alerta();
    } else {
        $("#loading").addClass("version").addClass("text-center");
        console.log("Entro a listar frecuencia");
        //---------------------------------
        var today = new Date();
        var a = today.getFullYear();
        //---------------------------------
        var m = today.getMonth() + 2;
        var sede = $("#ddlsedes").val();
        var mod = $("#ddlfrecuencia").val();
        //---------------------------------
        var url = _obtenerurl();
        var data = { idsede: sede, modalidad: mod };
        $("#tablaalumnos").load(url, data);
    }
}



//Fin de Funciones agregadas

//$('#ddlfrecuencia').change(function () {
//    var n = $("#ddlsedes").val();
//    //---------------------------------
//    var today = new Date();
//    var anio = today.getFullYear();
//    //---------------------------------
//    var mes = today.getMonth() + 1;
//    var codnivel = $("#ddlniveles").val();
//    var modalidad = $("#ddlfrecuencia").val();

//    CargarCursos(n, anio, mes, codnivel, modalidad);
//});


$('#ddlfrecuencia2').change(function () {
    var n = $("#ddlsedes2").val();
    //---------------------------------
    var today = new Date();
    var anio = today.getFullYear();
    //---------------------------------
    var mes = today.getMonth() + 1;
    var codnivel = $("#ddlniveles2").val();
    var modalidad = $("#ddlfrecuencia2").val();

    CargarCursos2(n, anio, mes, codnivel, modalidad);
});


function CargarCursos2(idsede, anio, mes, codnivel, modalidad) {
    cleanddl("ddlcursos2");
    var _caburl = _cabecera();
    $.ajax({
        url: _caburl + "/RegistroVoucherMP/ListarCursos",
        type: "POST",
        data: { idsede: idsede, anio: anio, mes: mes, codnivel: codnivel, modalidad: modalidad },
        success: function (resultado) {
            $.each(resultado, function (key, item) {
                $("#ddlcursos2").append('<option value="' + item.curso + '">' + item.curso + '</option>');
            });
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}



$('#ddlcursos').change(function () {
    $("#btnbuscar").show();
});

function CargarNivel(idsede, anio, mes) {
    cleanddl("ddlniveles");
    cleanddl("ddlfrecuencia");
    cleanddl("ddlcursos");
    var _caburl = _cabecera();

    $.ajax({
        url: _caburl+"/RegistroVoucherMP/ListarNiveles",
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
        url: _caburl+"/RegistroVoucherMP/ListarFrecuencia",
        type: "POST",
        data: { idsede: idsede, anio: anio, mes: mes, codnivel: codnivel },
        success: function (resultado) {
            $.each(resultado, function (key, item) {
                $("#ddlfrecuencia").append('<option value="' + item.idmodalidad + '">' + item.modalidad_esp + '</option>');
            });
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function CargarCursos(idsede, anio, mes, codnivel, modalidad) {
    cleanddl("ddlcursos");
    var _caburl = _cabecera();
    $.ajax({
        url: _caburl+"/RegistroVoucherMP/ListarCursos",
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

function cleanddl(objeto) {
    $("#" + objeto)
        .empty()
        .append("<option disabled selected>Selecciona una opción</option>");
}

function obtenerfrecuencias() {

    if ($('#ddlsedes').val() == null || $('#ddlniveles').val() == null || $('#ddlfrecuencia').val() == null || $('#ddlcursos').val() == null) {
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
        var data = { idsede: s, anio: a, mes: m, codnivel: cn, modalidad: mod, curso: cur };
        $("#tablaalumnos").load(url, data);
    }
}


function obtenerfrecuencias2() {

    if ($('#ddlsedes2').val() == null || $('#ddlniveles2').val() == null || $('#ddlfrecuencia2').val() == null || $('#ddlcursos2').val() == null) {
        alerta();
    } else {
        $("#loading").addClass("version").addClass("text-center");
        console.log("Entro a listar frecuencia");
        //---------------------------------
        var today = new Date();
        var a = today.getFullYear();
        //---------------------------------
        var m = today.getMonth() + 2;
        var s = $("#ddlsedes2").val();
        var cn = $("#ddlniveles2").val();
        var mod = $("#ddlfrecuencia2").val();
        var cur = $("#ddlcursos2").val();
        //---------------------------------
        var url = _obtenerurl();
        var data = { idsede: s, anio: a, mes: m, codnivel: cn, modalidad: mod, curso: cur };
        $("#tablaalumnos").load(url, data);
    }
}


function activarbutton() {

    if ($('#ddlsedes').val() == null || $('#ddlniveles').val() == null || $('#ddlfrecuencia').val() == null || $('#ddlcursos').val() == null) {
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
        var data = { idsede: s, anio: a, mes: m, codnivel: cn, modalidad: mod, curso: cur };
        $("#tablaalumnos").load(url, data);
    }
}

function siguiente() {
    if (_idCiclo != null) {
        var _caburl = _cabecera();
        $.ajax({
            url: _caburl + "/RegistroVoucherMP/AsignacionIdCicloUnCiclo",
            type: "POST",
            data: { idCiclo: _idCiclo},
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

function siguientepagina() {

        var _caburl = _cabecera();
        $.ajax({
            url: _caburl + "/RegistroVoucherMP/AsignacionIdCiclo",
            type: "POST",
            success: function (resultado) {
                if (resultado == "vacio") {
                    alertaRadio();
                } else {
                    location.href = _caburl + "/" + "RegistroVoucherMP/VoucherMP";
                }
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
}

function obtenervalor(idCiclo,idSede,mes,anio) {
  
    _idCiclo = idCiclo;
    _idSede = idSede;
    _mes = mes;
    _anio = anio;


}

function alertaRadio() {
    swal({
        title: "Agregue un ciclo",
        //text: "Esta acción ya no se podrá deshacer, Así que piénsalo bien.",
        type: "error",
        showCancelButton: false,
        confirmButtonColor: '#ff0d00',
        //cancelButtonColor: '#d33',
        confirmButtonText: 'ok',
        //cancelButtonText: "Cancelar"
    });
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

function alertacargadatos(error) {
    swal({
        title: "Ha currido un error",
        text: error,
        type: "error",
        showCancelButton: false,
        confirmButtonColor: '#ff0d00',
        //cancelButtonColor: '#d33',
        confirmButtonText: 'ok',
        //cancelButtonText: "Cancelar"
    });
}


function DevuelveDetalles(idsede, anio, mes, codnivel, modalidad, curso) {
    $.ajax({
        url: "/Horarios/Detalles",
        type: "POST",
        data: { idsede: idsede, anio: anio, mes: mes, codnivel: codnivel, modalidad: modalidad, curso: curso },
        success: function (resultado) {
            $.each(resultado, function (key, item) {
                txtcurso.innerText = item.curso;
                txtfrecuencia.innerText = item.modalidad_esp;
            });
        },
    });
}

$(document).on('click', '#btnbuscar', function () {

    //---------------------------------
    var s = $("#ddlsedes").val();
    //---------------------------------
    var today = new Date();
    var a = today.getFullYear();
    //---------------------------------
    var m = today.getMonth() + 2;
    var cn = $("#ddlniveles").val();
    var mod = $("#ddlfrecuencia").val();
    var cur = $("#ddlcursos").val();

    DevuelveDetalles(s, a, m, cn, mod, cur);
    BuscarFrecuencias(s, a, m, cn, mod, cur);

    //$("#turno3").empty();
    //$("#turno2").empty();
    //$("#turno1").empty();
    $("#padre").empty();
});

function _lanzaralerta(estados, codcursiguiente) {
    switch (estados) {
        case 0:
            console.log('normal');
            break;
        case 1:
            alertaninios("Kiddies 1");
            break;
        case 2:
            alertaninios("Prekinder 1");
            break;
        case 3:
            alertaninios("Kinder 1");
            break;
        case 4:
            alertaninios("Kids1");
            break;
        case 5:
            alertaninios("Junior 1");
            break;
        default:
            console.log("Valor no admitido");
            break;
    }

}

function alertaninios(texto_alt) {
    swal({
        title: "Aviso Importante",
        text: "El alumno podría de pasar al ciclo " + texto_alt + " por su edad. Si usted lo desea comuníquese con el siguiente numero 954459616",
        type: "warning",
        showCancelButton: false,
        confirmButtonColor: '#ff0d00',
        //cancelButtonColor: '#d33',
        confirmButtonText: 'ok',
        //cancelButtonText: "Cancelar"
    });
}

function agregarciclo() {

    var ciclo = _idCiclo;
    if (ciclo == null) {
        alertanull();
    } else {
        var _caburl = _cabecera();
        var url = _caburl + "/RegistroVoucherMP/TableCiclos";
        var data = { idciclo: ciclo, operacion: "agregar" };
        $("#tablemontos").load(url, data);
        $('#exampleModalCenter').modal('hide');
        $("#varconcepto").val("0");
        borrardatos();
    }

}

function alertanull() {
    swal({
        title: "Error",
        text: "Debe marcar un horario",
        type: "error",
        showCancelButton: false,
        confirmButtonColor: '#ff0d00',
        //cancelButtonColor: '#d33',
        confirmButtonText: 'ok',
        //cancelButtonText: "Cancelar"
    });
}

function quitarciclo(item) {
    var _caburl = _cabecera();
    var url = _caburl + "/RegistroVoucherMP/TableCiclos";
    var data = { idciclo: item, operacion: "quitar" };
    $("#tablemontos").load(url, data);
}

function borrardatos() {
    $("#tableciclos").remove();
    $("#ddlsedes").val("0");
    cleanddl("ddlniveles");
    cleanddl("ddlfrecuencia");
    cleanddl("ddlcursos");
    
}
