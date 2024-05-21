// Determina si el usuario quiere iniciar sesión o registrase.
var iniciarSesion = true;

// Determina si iniciar sesión o registrarse.
function procesar() {
    if(iniciarSesion) {
        ingresarUsuario();
    } else {
        registrarUsuario();
    }
}

// Almacena si el usuario quiere registrarse o iniciar sesión.
function cambiarEstado(accion) {
    iniciarSesion = accion;

    var liIniciarSesion = document.getElementById("liIniciarSesion");
    var liRegistrar = document.getElementById("liRegistrar");

    if (accion) {
        liIniciarSesion.setAttribute("class", "seleccionada");
        liRegistrar.setAttribute("class", "");
        document.getElementById("btIniciarSesion").setAttribute("style", "display: block;");
        document.getElementById("btRegistrar").setAttribute("style", "display: none;");
    } else {
        liRegistrar.setAttribute("class", "seleccionada");
        liIniciarSesion.setAttribute("class", "");
        document.getElementById("btIniciarSesion").setAttribute("style", "display: none;");
        document.getElementById("btRegistrar").setAttribute("style", "display: block;");
    }
}
