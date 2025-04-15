


function validar(elemento) {

    if (elemento.value == '') {
        elemento.className = 'form-control is-invalid';
    } else {
        elemento.className = 'form-control is-valid';
    }
    
}


function loguearse() {
    var usuario;
    var password;

    usuario = $("#inputusuario").val();
    password = $("#inputPassword").val();

    if (usuario == '' || password == '') {
        alertaIncompletos();
    } else {
        var data = { usuario: usuario, password: password };

        var _caburl = _cabecera();

        $.ajax({
            url: _caburl+"/"+"Login/Loguearse",
            type: "GET",
            data: data,
            success: function (resultado) {
                console.log(resultado);    
                if (resultado == 'incorrect') {
                    alerta();
                    //limpiardatos();
                } else {
                    location.href = _caburl + "/" +"Dashboard/";
                }
            },
            error: function (errormessage) {
                alert(errormessage);
                console.log(resultado);
            }
        });
    }


}

function redireccionar() {
    location.href = "https://www.icpnarc.edu.pe/prematriculas/Registro";
}

function alerta() {
    swal({
        title: "Login incorrecto",
        //text: "Esta acción ya no se podrá deshacer, Así que piénsalo bien.",
        type: "error",
        showCancelButton: false,
        confirmButtonColor: '#ff0d00',
        //cancelButtonColor: '#d33',
        confirmButtonText: 'ok',
        //cancelButtonText: "Cancelar"
    });
}

function alertaIncompletos() {
    swal({
        title: "Complete los datos",
        //text: "Esta acción ya no se podrá deshacer, Así que piénsalo bien.",
        type: "error",
        showCancelButton: false,
        confirmButtonColor: '#ff0d00',
        //cancelButtonColor: '#d33',
        confirmButtonText: 'ok',
        //cancelButtonText: "Cancelar"
    });
}

function limpiardatos() {
    $("#inputusuario").val('');
    $("#inputPassword").val('');

}

function salir() {
    var _caburl = _cabecera();
    location.href = _caburl + "/" +"Login/Salir/";
}

function descargar() {
    var _caburl = _cabecera();
    location.href = _caburl + "/" +"Login/GeneratePdf";
}
