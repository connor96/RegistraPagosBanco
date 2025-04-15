
var today = new Date();
var dd = String(today.getDate()).padStart(2, '0');
var mm = String(today.getMonth() + 1).padStart(2, '0');
var yyyy = today.getFullYear();
today = mm + '/' + dd + '/' + yyyy;

var _url;

$('#datepicker').datepicker({
    dateFormat: "dd/mm/yyyy",
    uiLibrary: 'bootstrap4',
    setDate: today,
    value: today
});

function validarNumeros() {
    swal({
        title: "Elija un monto a partir de 40",
        //text: "Esta acción ya no se podrá deshacer, Así que piénsalo bien.",
        type: "error",
        showCancelButton: false,
        confirmButtonColor: '#ff0d00',
        //cancelButtonColor: '#d33',
        confirmButtonText: 'ok',
        //cancelButtonText: "Cancelar"
    });
}

(function () {
    'use strict';
    $('.input-file').each(function () {
        var $input = $(this),
            $label = $input.next('.js-labelFile'),
            labelVal = $label.html();
        //document.getElementById("spinner").style.display = "none";

        $input.on('change', function (element) {
            var fileName = '';
            if (element.target.value) fileName = element.target.value.split('\\').pop();
            fileName ? $label.addClass('has-file').find('.js-fileName').html(fileName) : $label.removeClass('has-file').html(labelVal);
            document.getElementById("icono-check").style.display="none";
            $("#labelbutton").css("color", "#555");
            uploadFile();
        });
    });
})();


function validaNumericos(event) {
    console.log(event);
    if (event.charCode >= 48 && event.charCode <= 57) {
        return true;
    }
    return false;
}

function validaNumericosoperacion(event) {
    $("#" + event.explicitOriginalTarget.id).removeClass("is-invalid");
    $("#" +event.explicitOriginalTarget.id).addClass("is-valid");
    
    if (event.charCode >= 48 && event.charCode <= 57) {
        return true;
    }
    return false;
}

function validarEmail(event) {
    $("#" + event.explicitOriginalTarget.id).removeClass("is-invalid");
    $("#" + event.explicitOriginalTarget.id).addClass("is-valid");
}

var firebaseConfig = {
    apiKey: "AIzaSyCQVvyMkbHHPEeuz8gVCZwa5O5-KdKIJQA",
    authDomain: "vouchersicpna4.firebaseapp.com",
    projectId: "vouchersicpna4",
    storageBucket: "vouchersicpna4.appspot.com",
    messagingSenderId: "1094764970751",
    appId: "1:1094764970751:web:84a163cc21bd014f9142ca",
    measurementId: "G-44801RDZE6"
};

firebase.initializeApp(firebaseConfig);
firebase.analytics();


function uploadFile() {

    document.getElementById("spinner").style.display = "inline-block";
    
    
    const ref = firebase.storage().ref();

    const file = document.querySelector("#file").files[0];

    new Compressor(file, {
        quality: 0.4,
        success(result) {
            var _caburl = _cabecera();
            $.ajax({
                url: _caburl + "/RegistroVoucherMP/obtenerId",
                type: "POST",
                success: function (resultado) {

                    var namefecha = new Date();
                    const name = namefecha.toJSON() + '-' + resultado;

                    const metadata = {
                        contentType: result.type
                    }
                    const task = ref.child(name).put(result, metadata);
                    task
                        .then(snapshot => snapshot.ref.getDownloadURL())
                        .then(url => {
                            document.getElementById("spinner").style.display = "none";
                            document.getElementById("icono-check").style.display = "inline-block";
                            _url = url;
                            successalert();
                        });
                },
                error: function (errormessage) {
                    console.log(errormessage);
                }
            });

            

    }, error(err){
            console.log(err.message);
    }
    });
}



function successalert(){
    swal({
        title: "Éxito",
        text: "Se ha subido la imagen correctamente",
        type: "success",
        showCancelButton: false,
        confirmButtonColor: '#004f9e',
        //cancelButtonColor: '#d33',
        confirmButtonText: 'ok',
        //cancelButtonText: "Cancelar"
    });
}

function chequeado() {

    var checkbox = $("#customCheck1").prop('checked');
    if (!checkbox) {
        $("#customCheck1").addClass("is-invalid");
    } else {
        $("#customCheck1").removeClass("is-invalid");
        $("#customCheck1").addClass("is-valid");
    }
}

//Validar correo
document.getElementById('correo').addEventListener('input', function () {
    campo = event.target;

    emailRegex = /^[-\w.%+]{1,64}@(?:[A-Z0-9-]{1,63}\.){1,125}[A-Z]{2,63}$/i;
    //Se muestra un texto a modo de ejemplo, luego va a ser un icono
    if (emailRegex.test(campo.value)) {
        $("#correo").removeClass("is-invalid");
        $("#correo").addClass("is-valid");
    } else {
        $("#correo").removeClass("is-valid");
        $("#correo").addClass("is-invalid");
    }
});

//Validar numero celular
document.getElementById('numerocelular').addEventListener('input', function () {

    campo = event.target;
    console.log(campo.value.length);

    if (campo.value.length>=9) {
        $("#numerocelular").removeClass("is-invalid");
        $("#numerocelular").addClass("is-valid");
    } else {
        $("#numerocelular").removeClass("is-valid");
        $("#numerocelular").addClass("is-invalid");
    }
});


function validarCorreoValido(event) {
    var email = $("#correo").val();
    emailRegex = /^[-\w.%+]{1,64}@(?:[A-Z0-9-]{1,63}\.){1,125}[A-Z]{2,63}$/i;
    console.log(emailRegex.test(event.explicitOriginalTarget.value));
    console.log(event.target.value);

    console.log(event);

    if (emailRegex.test(email)) {
        $("#correo").removeClass("is-invalid");
        $("#correo").addClass("is-valid");
        
    } else {
        $("#correo").removeClass("is-valid");
        $("#correo").addClass("is-invalid");
    }
}

function validarDatos() {

    var _caburl = _cabecera();
   

    var tipoalumno = consultatipodealumno();
    var sedeRecojoa = document.getElementById("varsedeicpna");
    var sedeRecojo = $('#varsedeicpna').val();
    console.log(sedeRecojo);

    var email = $("#correo").val();
    var celular = $("#numerocelular").val();
    var checkbox = $("#customCheck1").prop('checked');


    
    
   

    if (tipoalumno == "NNN" || tipoalumno == "EUN") {
        var radio1 = false;
        var radio2 = false;
        var direccion = "";
        var aux = "";
        var auxiliar = true;
        var referencia = "";
        


        var rowCount = document.getElementById('mtable').rows.length;

        checkbox = $("#customCheck1").prop('checked');
        
        if ($('#exampleRadios1').is(':checked')) {
            aux = "radio1";
        }

        if ($('#exampleRadios2').is(':checked')) {
            aux = "radio2";
        }

        if (aux == "radio1") {
            referencia = $("#referencia1").val();
            if (referencia == "" || referencia==null) {
                auxiliar = false;
                
            }
        } else if (aux == "radio2") {
            direccion = $("#direccion").val();
            referencia = $("#referencia").val();
            if (direccion == "" || referencia == "" || referencia == null || direccion==null) {
                auxiliar = false;
            }

        }

        if (sedeRecojo == null|| banco == null || noperacion == "" || email == "" || celular == "" || url == null || rowCount <= 1 || checkbox == false || auxiliar == false) {

            alertadatosincompletos();
            /*if (concepto == null) {
                $("#varconcepto").addClass("is-invalid");
            }*/

            if (sedeRecojo == null) {
                $("#varsedeicpna").addClass("is-invalid");
            }


            if (banco == null) {
                $("#varbanco").addClass("is-invalid");
            }

            if (noperacion == "") {

                $("#numerooperacion").addClass("is-invalid");
            }

            if (email == "") {
                $("#correo").addClass("is-invalid");
            }

            if (celular == "") {
                $("#numerocelular").addClass("is-invalid");
            }

            if (url == null) {
                $("#labelbutton").css("color", "red");
            }

            if (!checkbox) {
                $("#customCheck1").addClass("is-invalid");
            }

            if (!auxiliar) {
                if (aux == "radio1") {
                    $("#referencia1").addClass("is-invalid");
                } else if (aux == "radio2") {
                    $("#referencia").addClass("is-invalid");
                    $("#direccion").addClass("is-invalid");
                }
            }

        } else {

            _registrarContactoEmergencia();

            if (direccion == "") {
                direccion = "no";
            }

            $.ajax({
                url: _caburl + "/RegistroVoucherMP/ValidarVoucher",
                type: "POST",
                data: { nrooperacion: noperacion },
                success: function (resultado) {
                    if (noperacion == resultado) {
                        alertaValidarVoucher();
                    } else {
                        swal({
                            title: 'Esta seguro?',
                            text: "Haga clic en el botón confirmar para registrar sus datos",
                            type: 'question',
                            showCancelButton: true,
                            confirmButtonColor: '#0a9c00',
                            cancelButtonColor: 'red',
                            confirmButtonText: 'Confirmar',
                            cancelmButtonText: 'Cancelar',
                            reverseButtons: true
                        }).then((result) => {
                            if (result.value) {
                                $.ajax({
                                    url: _caburl + "/RegistroVoucherMP/RegistrarVoucher",
                                    type: "POST",
                                    data: { nombreBanco: banco, idconcepto: 0, nrooperacion: noperacion, fechaTransaccion: ftrasnaccion, monto: 0, urlVoucher: url, correo: email, celular: celular, radio: aux, direccion: direccion, referencia: referencia, sedeRecojo:sedeRecojo },
                                    success: function (resultado) {
                                        if (resultado != "") {
                                            swal({
                                                title: "Registro correcto",
                                                text: "Sus datos se han registrado correctamente.",
                                                type: "success",
                                                confirmButtonColor: '#d33',
                                                //cancelButtonColor: '#d33',
                                                confirmButtonText: 'ok',
                                                //cancelButtonText: "Cancelar"
                                            }).then((result) => {
                                                if (result.value) {
                                                    $.ajax({
                                                        url: _caburl + "/RegistroVoucherMP/asignarTransaccion",
                                                        type: "POST",
                                                        data: { idTransaccion: resultado },
                                                        success: function (resultado) {
                                                            console.log(resultado);
                                                            location.href = _caburl + "/" + "RegistroVoucherMP/VoucherConfirmacion/";
                                                        },
                                                        error: function (errormessage) {
                                                            alert(errormessage.responseText);
                                                        }
                                                    });
                                                }
                                            });

                                        } else {
                                            swal({
                                                title: "Ha ocurrido un error",
                                                text: "Ha ocurrido un error al momento de procesar su registro, pruebe actualizando la página",
                                                type: "error",
                                                confirmButtonColor: 'red',
                                                //cancelButtonColor: '#d33',
                                                confirmButtonText: 'ok',
                                                //cancelButtonText: "Cancelar"
                                            });
                                        }

                                    },
                                    error: function (errormessage) {
                                        swal({
                                            title: "Ha ocurrido un error",
                                            text: "Ha ocurrido un error al momento de procesar su registro, pruebe actualizando la página",
                                            type: "error",
                                            confirmButtonColor: 'red',
                                            //cancelButtonColor: '#d33',
                                            confirmButtonText: 'ok',
                                            //cancelButtonText: "Cancelar"
                                        });
                                    }
                                });

                            }
                        });
                    }
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });

        }


    } else {

        var emailRegex = /^[-\w.%+]{1,64}@(?:[A-Z0-9-]{1,63}\.){1,125}[A-Z]{2,63}$/i;

        if (emailRegex.test(email)) {

            if (sedeRecojo == null || email == "" || celular == "" || checkbox == false || celular.length<9) {

                if (celular.length < 9) {
                    alertanumerosincompletos();
                    $("#correo").addClass("is-invalid");
                }

                if (email == "" || celular == "" || checkbox == false) {
                    alertadatosincompletos();
                    if (email == "") {
                        $("#correo").addClass("is-invalid");
                    }

                    

                    if (celular == "") {
                        $("#numerocelular").addClass("is-invalid");
                    }

                    if (!checkbox) {
                        $("#customCheck1").addClass("is-invalid");
                    }

                }
                if (sedeRecojo == null) {
                    $("#varsedeicpna").addClass("is-invalid");
                }



            } else {

                _registrarContactoEmergencia();

                $.ajax({
                    url: _caburl + "/RegistroVoucherMP/consultaVouchersRegistrados",
                    type: "POST",
                    success: function (resultado) {
                        if (resultado == 0) {
                            alertavoucher();
                            $("#boton-agregar-voucher").removeClass("btn-outline-primary");
                            $("#boton-agregar-voucher").addClass("btn-danger");
                        } else {

                            swal({
                                title: 'Esta seguro?',
                                text: "Haga clic en el botón confirmar para registrar sus datos",
                                type: 'question',
                                showCancelButton: true,
                                confirmButtonColor: '#0a9c00',
                                cancelButtonColor: 'red',
                                confirmButtonText: 'Confirmar',
                                cancelmButtonText: 'Cancelar',
                                reverseButtons: true
                            }).then((result) => {
                                if (result.value) {
                                    $.ajax({
                                        url: _caburl + "/RegistroVoucherMP/RegistrarPago",
                                        type: "POST",
                                        data: { correo: email, celular: celular, sedeRecojo: sedeRecojo },
                                        success: function (resultado) {
                                            if (resultado != "no") {
                                                if (resultado != "error") {
                                                    swal({
                                                        title: "Registro correcto",
                                                        text: "Sus datos se han registrado correctamente",
                                                        type: "success",
                                                        confirmButtonColor: '#d33',
                                                        //cancelButtonColor: '#d33',
                                                        confirmButtonText: 'ok',
                                                        //cancelButtonText: "Cancelar"
                                                    }).then((result) => {
                                                        if (result.value) {
                                                            $.ajax({
                                                                url: _caburl + "/RegistroVoucherMP/asignarTransaccion",
                                                                type: "POST",
                                                                data: { idTransaccion: resultado },
                                                                success: function (resultado) {
                                                                    console.log(resultado);
                                                                    location.href = _caburl + "/" + "RegistroVoucherMP/VoucherConfirmacion/";
                                                                },
                                                                error: function (errormessage) {
                                                                    swal({
                                                                        title: "Ha ocurrido un error",
                                                                        text: "Error al obtener la transacción, verifique en la opción Lista de Vouchers o comuníquese con el número 995406169. " + errormessage.responseText,
                                                                        type: "error",
                                                                        showCancelButton: false,
                                                                        confirmButtonColor: 'red',
                                                                        //cancelButtonColor: '#d33',
                                                                        confirmButtonText: 'ok',
                                                                        //cancelButtonText: "Cancelar"
                                                                    });
                                                                }
                                                            });
                                                        }
                                                    });
                                                } else {
                                                    swal({
                                                        title: "Ha ocurrido un error",
                                                        text: "Ha ocurrido un error al momento de procesar su registro, por favor verifique sus datos, si el problema persiste inicie el registro nuevamente.",
                                                        type: "error",
                                                        confirmButtonColor: 'red',
                                                        //cancelButtonColor: '#d33',
                                                        confirmButtonText: 'ok',
                                                        //cancelButtonText: "Cancelar"
                                                    });
                                                }

                                            } else {
                                                swal({
                                                    title: "Complete todos los datos",
                                                    text: "Es necesario que complete todos los datos (correo, email, voucher y al menos un concepto).",
                                                    type: "warning",
                                                    confirmButtonColor: 'red',
                                                    //cancelButtonColor: '#d33',
                                                    confirmButtonText: 'ok',
                                                    //cancelButtonText: "Cancelar"
                                                });
                                            }

                                        },
                                        error: function (jqXHR, exception) {
                                            swal({
                                                title: "Ha ocurrido un error",
                                                text: "No se ha podido completar la matrícula, intente realizar el registro nuevamente o envíe sus datos al siguiente número 995406169. No se olvide colocar su sede, nombre, ciclo, horario y voucher. Error: " + msg,
                                                type: "error",
                                                confirmButtonColor: 'red',
                                                //cancelButtonColor: '#d33',
                                                confirmButtonText: 'ok',
                                                //cancelButtonText: "Cancelar"
                                            });
                                        }
                                    });

                                }
                            });


                        }


                    },
                    error: function (errormessage) {
                        swal({
                            title: "Ha ocurrido un error",
                            text: "Debe de registrar al menos 1 voucher.",
                            type: "error",
                            showCancelButton: false,
                            confirmButtonColor: 'red',
                            //cancelButtonColor: '#d33',
                            confirmButtonText: 'ok',
                            //cancelButtonText: "Cancelar"
                        });
                    }
                });
            }

        } else {
            alertacorreoerroneo();
            $("#correo").addClass("is-invalid");
        }

        

    }

}



function _registrarContactoEmergencia(){
    var _caburl = _cabecera();

    var result = '';

    var contactoEmergencia = $("#contactoemergencia").val();
    var celularEmergencia = $("#celularemergencia").val();

   
    $.ajax({
        url: _caburl + "/RegistroVoucherMP/contactoEmergencia",
        type: "POST",
        data: { contactoEmergencia: contactoEmergencia, celularEmergencia: celularEmergencia},
        success: function (resultado) {
            result = resultado;
            console.log(result);
        },
        error: function (errormessage) {
            swal({
                title: "Ha ocurrido un error",
                text: "Ha ocurrido un error, por favor verifique los datos ingresados en su contacto de emergencia.",
                type: "error",
                showCancelButton: false,
                confirmButtonColor: 'red',
                //cancelButtonColor: '#d33',
                confirmButtonText: 'ok',
                //cancelButtonText: "Cancelar"
            });
        }
    });

    return result;
}


function consultavouchersregistrados() {

    var _caburl = _cabecera();

    var result='';

    $.ajax({
        url: _caburl + "/RegistroVoucherMP/consultaVouchersRegistrados",
        type: "POST",
        success: function (resultado) {
            result = resultado;
            console.log(result);
        },
        error: function (errormessage) {
            swal({
                title: "Ha ocurrido un error",
                text: "Ha ocurrido un error, por favor verifique los datos ingresados.",
                type: "error",
                showCancelButton: false,
                confirmButtonColor: 'red',
                //cancelButtonColor: '#d33',
                confirmButtonText: 'ok',
                //cancelButtonText: "Cancelar"
            });
        }
    });
    
    return result;
    
}

function consultatipodealumno() {
    var _caburl = _cabecera();
    var result;

    $.ajax({
        url: _caburl + "/RegistroVoucherMP/consultatipodealumno",
        type: "POST",
        success: function (resultado) {
            result = resultado;
        },
        error: function (errormessage) {
            swal({
                title: "Ha ocurrido un error",
                text: "Ha ocurrido un error, por favor actualice la página e inténtelo nuevamente",
                type: "error",
                showCancelButton: false,
                confirmButtonColor: 'red',
                //cancelButtonColor: '#d33',
                confirmButtonText: 'ok',
                //cancelButtonText: "Cancelar"
            });
        }
    });

    return result;
}


function alertavoucher() {
    swal({
        title: "No ha registrado ningun voucher",
        text: "Por favor adjunte un voucher para registrar su pago",
        type: "error",
        showCancelButton: false,
        confirmButtonColor: 'red',
        //cancelButtonColor: '#d33',
        confirmButtonText: 'ok',
        //cancelButtonText: "Cancelar"
    });
}

function alertanumerosincompletos() {
    swal({
        title: "Numero telefonico incorrecto",
        //text: "Se ha subido la imagen correctamente",
        type: "error",
        showCancelButton: false,
        confirmButtonColor: 'red',
        //cancelButtonColor: '#d33',
        confirmButtonText: 'ok',
        //cancelButtonText: "Cancelar"
    });
}

function alertaValidarVoucher() {
    swal({
        title: "El voucher ya se encuentra registrado",
        //text: "Se ha subido la imagen correctamente",
        type: "error",
        showCancelButton: false,
        confirmButtonColor: 'red',
        //cancelButtonColor: '#d33',
        confirmButtonText: 'ok',
        //cancelButtonText: "Cancelar"
    });
}

function alertadatosincompletos() {
    swal({
        title: "Complete los datos",
        text: "Falta completar algunos datos",
        type: "error",
        showCancelButton: false,
        confirmButtonColor: 'red',
        //cancelButtonColor: '#d33',
        confirmButtonText: 'ok',
        //cancelButtonText: "Cancelar"
    });
}

function alertacorreoerroneo() {
    swal({
        title: "Correo incorrecto",
        text: "Revise su correo por favor",
        type: "error",
        showCancelButton: false,
        confirmButtonColor: 'red',
        //cancelButtonColor: '#d33',
        confirmButtonText: 'ok',
        //cancelButtonText: "Cancelar"
    });
}

function retroceder() {
    swal({
        title: 'Esta seguro?',
        text: "Al retroceder se perderán los datos registrados",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#0a9c00',
        cancelButtonColor: 'red',
        confirmButtonText: 'Confirmar',
        cancelmButtonText: 'Cancelar',
        reverseButtons: true
    }).then((result) => {
        if (result.value) {
            var _caburl = _cabecera();
            location.href = _caburl + "/" + "RegistroVoucherMP/";
        }
    });
    
}


function validarDatosPV() {

    var _caburl = _cabecera();
    var rowCount = document.getElementById('mtable').rows.length;
    var periodo = $("#varperiodo").val();
    var sede = $("#varsede").val();
    var banco = $("#varbanco").val();
    var noperacion = $("#numerooperacion").val();
    //var fechatransaccion = $("#datepicker").datepicker("getDate");
    //var ftrasnaccion = $.datepicker.formatDate("dd-mm-yy", fechatransaccion);
    var fecha = $("#datepicker").val();
    fecha = new Date(fecha);
    var ftrasnaccion = fecha.toJSON();
    var monto = $("#monto").val();
    var url = _url;

    var email = $("#correopv").val();
    var celular = $("#numerocelularpv").val();

    console.log(periodo);
    console.log(sede);
    console.log(banco);

    if (periodo == null || sede == null || rowCount <= 1 || banco == null || noperacion == "" || url == null || email == "" || celular == "" ) {

        alertadatosincompletos();

        if (periodo == null) {
            $("#varperiodo").addClass("is-invalid");
        }

        if (sede == null) {
            $("#varsede").addClass("is-invalid");
        }

        if (banco == null) {
            $("#varbanco").addClass("is-invalid");
        }

        if (noperacion == "") {

            $("#numerooperacion").addClass("is-invalid");
        }

        if (url == null) {
            $("#labelbutton").css("color", "red");
        }

        if (email == "") {
            $("#correopv").addClass("is-invalid");
        }

        if (celular == "") {
            $("#numerocelularpv").addClass("is-invalid");
        }

    } else {

        $.ajax({
            url: _caburl + "/RegistroVoucherPV/ValidarVoucher",
            type: "POST",
            data: { nrooperacion: noperacion },
            success: function (resultado) {
                if (noperacion == resultado) {
                    alertaValidarVoucher();
                } else {
                    swal({
                        title: 'Esta seguro?',
                        text: "Haga clic en el botón confirmar para continuar",
                        type: 'question',
                        showCancelButton: true,
                        confirmButtonColor: '#0a9c00',
                        cancelButtonColor: 'red',
                        confirmButtonText: 'Confirmar',
                        cancelmButtonText: 'Cancelar',
                        reverseButtons: true
                    }).then((result) => {
                        if (result.value) {
                            $.ajax({
                                url: _caburl + "/RegistroVoucherPV/RegistrarVoucherPV",
                                type: "POST",
                                data: { periodomes: periodo, sede: sede, nombreBanco: banco, nrooperacion: noperacion, fechaTransaccion: ftrasnaccion, urlVoucher: url, email: email, ncelular: celular},
                                success: function (resultado) { 
                                    if (resultado != "") {
                                        swal({
                                            title: "Registro correcto",
                                            text: "Sus datos se han registrado correctamente, y se está procesando su transacción.",
                                            type: "success",
                                            confirmButtonColor: '#d33',
                                            //cancelButtonColor: '#d33',
                                            confirmButtonText: 'ok',
                                            //cancelButtonText: "Cancelar"
                                        }).then((result) => {
                                            if (result.value) {
                                                $.ajax({
                                                    url: _caburl + "/RegistroVoucherPV/asignarTransaccion",
                                                    type: "POST",
                                                    data: { idTransaccion: resultado },
                                                    success: function (resultado) {
                                                        console.log(resultado);
                                                        location.href = _caburl + "/" + "RegistroVoucherPV/VoucherConfirmacion/";
                                                    },
                                                    error: function (errormessage) {
                                                        alert(errormessage.responseText);
                                                    }
                                                });
                                            }
                                        });

                                    } else {
                                        swal({
                                            title: "Ha ocurrido un error",
                                            text: "Ha ocurrido un error al momento de procesar su registro, pruebe actualizando la página",
                                            type: "error",
                                            confirmButtonColor: 'red',
                                            //cancelButtonColor: '#d33',
                                            confirmButtonText: 'ok',
                                            //cancelButtonText: "Cancelar"
                                        });
                                    }

                                },
                                error: function (errormessage) {
                                    alert(errormessage.responseText);
                                }
                            });

                        }
                    });
                }
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }

}

function validardeuda() {
    var concepto = $("#varconcepto").val();
    console.log(concepto);

}
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
                    var url = _caburl + "/RegistroVoucherMP/TableVouchers";
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
            var url = _caburl + "/RegistroVoucherMP/TableVouchers";
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

    var url = _caburl + "/RegistroVoucherMP/TableVouchers";
    var data = { id: item, operacion: "quitar" };
    $("#tablemontos").load(url, data);
}


function agregarlibro() {
    var _caburl = _cabecera();
    var idConcepto = $("#varlibro").val();
    console.log(idConcepto);

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
                var url = _caburl + "/RegistroVoucherMP/TableVouchers";
                var data = { id: idConcepto, operacion: "libro" };
                $("#tablemontos").load(url, data);
                $('#modalLibros').modal('hide');
                $("#varconcepto").val("0");
            } else {
                $("#varconcepto").val("0");
            }
        });
    } else {
        $("#varlibro").addClass("is-invalid");

    }
 
}

function agregarvoucher() {
    var _caburl = _cabecera();

    var banco = $("#varbanco").val();
    var noperacion = $("#numerooperacion").val();
    var fecha = $("#datepicker").val();
    fecha = new Date(fecha);
    var ftrasnaccion = fecha.toJSON();
    var urlimagen = _url;

    if (banco == null || noperacion == "" || urlimagen == null) {

        alertadatosincompletos();

        if (banco == null) {
            $("#varbanco").addClass("is-invalid");
        }

        if (noperacion == "") {

            $("#numerooperacion").addClass("is-invalid");
        }

        if (urlimagen == null) {
            $("#labelbutton").css("color", "red");
        }

    } else {

        var url = _caburl + "/RegistroVoucherMP/TableVoucher";
        var data = { operacion: "agregar", banco: banco, nrooperacion: noperacion, fecha: ftrasnaccion, url: urlimagen};
        $("#voucheragregado").load(url, data);
        $('#modalVoucher').modal('hide');
        limpiarmodalvoucher();
        $("#boton-agregar-voucher").removeClass("btn-danger");
        $("#boton-agregar-voucher").addClass("btn-outline-primary");
    }
}

function limpiarmodalvoucher() {
    $("#varbanco").val("0");
    $("#varbanco").removeClass('is-valid');
    $("#numerooperacion").val('');
    $("#numerooperacion").removeClass('is-valid');
    $('#datepicker').datepicker({
        dateFormat: "dd/mm/yyyy",
        uiLibrary: 'bootstrap4',
        setDate: today,
        value: today
    });
    
    $('.input-file').each(function () {
        var $input = $(this),
            $label = $input.next('.js-labelFile'),
            labelVal = $label.html();

        var fileName = 'Seleccione una imagen';
        $label.removeClass('has-file').find('.js-fileName').html(fileName);
        document.getElementById("icono-check").style.display = "inline-block";
    });
}

function quitarvoucher(item) {

    swal({
        title: 'Desea eliminar el voucher seleccionado?',
        //text: "El costo del libro físico se ha incrementado por gastos de importación y traslados debido a la situación por la que pasa el país.",
        type: 'question',
        showCancelButton: true,
        confirmButtonColor: '#0a9c00',
        cancelButtonColor: 'red',
        confirmButtonText: 'Eliminar',
        cancelmButtonText: 'Cancelar',
        reverseButtons: true
    }).then((result) => {
        if (result.value) {
            var _caburl = _cabecera();
            var banco = '';
            var ftrasnaccion = '';
            var url = '';
            var url = _caburl + "/RegistroVoucherMP/TableVoucher";
            var data = { operacion: "quitar", banco: banco, nrooperacion: item, fecha: ftrasnaccion, url: url };
            $("#voucheragregado").load(url, data);
        }

     });

}

function vervoucher(item) {
    var _caburl = _cabecera();
    var url = _caburl + "/RegistroVoucherMP/VerVoucher";
    var data = { nrooperacion: item};
    $("#vervoucherdetalle").load(url, data);
    $("#modaldetallevoucher").modal('show');
}


function agregarpagovarios() {

    var idConcepto = $("#varconcepto").val();
    console.log(idConcepto);

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
                var url = _caburl + "/RegistroVoucherPV/TableVouchers";
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
        var url = _caburl + "/RegistroVoucherPV/TableVouchers";
        var data = { id: idConcepto, operacion: "agregar" };
        $("#tablemontos").load(url, data);
        $('#exampleModalCenter').modal('hide');
        $("#varconcepto").val("0");
    }

}

function quitarelementopv(item) {

    var _caburl = _cabecera();

    var url = _caburl + "/RegistroVoucherPV/TableVouchers";
    var data = { id: item, operacion: "quitar" };
    $("#tablemontos").load(url, data);
}

function agregarlibropv() {
    var _caburl = _cabecera();
    var idConcepto = $("#varlibro").val();
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
            var url = _caburl + "/RegistroVoucherPV/TableVouchers";
            var data = { id: idConcepto, operacion: "libro" };
            $("#tablemontos").load(url, data);
            $('#modalLibros').modal('hide');
            $("#varconcepto").val("0");
        } else {
            $("#varconcepto").val("0");
        }
    });
}


function validalibro() {
    $("#varlibro").removeClass("is-invalid");
    $("#varlibro").addClass("is-valid");
}

function validaconcepto() {
    $("#varconcepto").removeClass("is-invalid");
    $("#varconcepto").addClass("is-valid");
}

function deshabilitarinput() {
    $("#referencia1").removeClass("is-inactive");
    $("#referencia1").addClass("is-active");

    $("#direccion").removeClass("is-active");
    $("#direccion").addClass("is-inactive");
    $("#referencia").removeClass("is-active");
    $("#referencia").addClass("is-inactive");
}

function actualizardireccion() {
    $("#direccion").removeClass("is-inactive");
    $("#direccion").addClass("is-active");
    $("#referencia").removeClass("is-inactive");
    $("#referencia").addClass("is-active");

    $("#referencia1").removeClass("is-active");
    $("#referencia1").addClass("is-inactive");
}

//ninios
function registrarninios() {

    var _caburl = _cabecera();
    var sedeRecojo = $('#varsedeicpna').val();

    var email = $("#correo").val();
    var celular = $("#numerocelular").val();
    //var checkbox = $("#customCheck1").prop('checked');
    var checkbox = true;

    console.log(checkbox);


        var radio1 = false;
        var radio2 = false;
        var direccion = "";
        var aux = "";
        var auxiliar = true;
        var referencia = "";

        direccion = $("#direccion").val();
        var rowCount = document.getElementById('mtable').rows.length;

        //if ($('#exampleRadios1').is(':checked')) {
        //    aux = "radio1";
        //}

        //if ($('#exampleRadios2').is(':checked')) {
        //    aux = "radio2";
        //}

        //if (aux == "radio1") {
        //    referencia = $("#referencia1").val();
        //    if (referencia == "") {
        //        auxiliar = false;
        //        console.log(auxiliar);
        //    }
        //} else if (aux == "radio2") {
        //    direccion = $("#direccion").val();
        //    referencia = $("#referencia").val();
        //    if (direccion == "" || referencia == "") {
        //        auxiliar = false;
        //    }

        //}


    if (sedeRecojo==null || email == "" || celular == "" || rowCount <= 1 || checkbox == false || direccion == "") {

            alertadatosincompletos();
            /*if (concepto == null) {
                $("#varconcepto").addClass("is-invalid");
            }*/

            if (email == "") {
                $("#correo").addClass("is-invalid");
            }

            if (celular == "") {
                $("#numerocelular").addClass("is-invalid");
            }

            
            //if (!checkbox) {
            //    $("#customCheck1").addClass("is-invalid");
            //}

            if (direccion == "" || direccion == null) {
                $("#direccion").addClass("is-invalid");
            }

            //if (!auxiliar) {
            //    if (aux == "radio1") {
            //        $("#referencia1").addClass("is-invalid");
            //    } else if (aux == "radio2") {
            //        $("#referencia").addClass("is-invalid");
            //        $("#direccion").addClass("is-invalid");
            //    }
            //}

            if (sedeRecojo == null) {
                $("#varsedeicpna").addClass("is-invalid");
            }

        } else {

            if (direccion == "" || direccion==null) {
                direccion = "no";
            }
                swal({
                    title: 'Esta seguro?',
                    text: "Haga clic en el botón confirmar para registrar sus datos",
                    type: 'question',
                    showCancelButton: true,
                    confirmButtonColor: '#0a9c00',
                    cancelButtonColor: 'red',
                    confirmButtonText: 'Confirmar',
                    cancelmButtonText: 'Cancelar',
                    reverseButtons: true
                }).then((result) => {
                    if (result.value) {
                        $.ajax({
                            url: _caburl + "/RegistroVoucherMP/RegistrarVoucher",
                            type: "POST",
                            data: { nombreBanco: '', idconcepto: 0, nrooperacion: '', fechaTransaccion: '', monto: 0, urlVoucher: '', correo: email, celular: celular, direccion: direccion, sedeRecojo: sedeRecojo },
                            success: function (resultado) {
                                if (resultado != "") {
                                    swal({
                                        title: "Registro correcto",
                                        text: "Sus datos se han registrado correctamente.",
                                        type: "success",
                                        confirmButtonColor: '#d33',
                                        //cancelButtonColor: '#d33',
                                        confirmButtonText: 'ok',
                                        //cancelButtonText: "Cancelar"
                                    }).then((result) => {
                                        if (result.value) {
                                            $.ajax({
                                                url: _caburl + "/RegistroVoucherMP/asignarTransaccion",
                                                type: "POST",
                                                data: { idTransaccion: resultado },
                                                success: function (resultado) {
                                                    console.log(resultado);
                                                    location.href = _caburl + "/" + "RegistroVoucherMP/VoucherConfirmacionNinios/";
                                                },
                                                error: function (errormessage) {
                                                    alert(errormessage.responseText);
                                                }
                                            });
                                        }
                                    });

                                } else {
                                    swal({
                                        title: "Ha ocurrido un error",
                                        text: "Ha ocurrido un error al momento de procesar su registro, pruebe actualizando la página",
                                        type: "error",
                                        confirmButtonColor: 'red',
                                        //cancelButtonColor: '#d33',
                                        confirmButtonText: 'ok',
                                        //cancelButtonText: "Cancelar"
                                    });
                                }

                            },
                            error: function (errormessage) {
                                swal({
                                    title: "Ha ocurrido un error",
                                    text: "Ha ocurrido un error al momento de procesar su registro, pruebe actualizando la página",
                                    type: "error",
                                    confirmButtonColor: 'red',
                                    //cancelButtonColor: '#d33',
                                    confirmButtonText: 'ok',
                                    //cancelButtonText: "Cancelar"
                                });
                            }
                        });

                    }
                });

        }




}



