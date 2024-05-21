function votar(){
    var idCandidato = document.getElementById("iIdCandidato");

    swal({
        title: "¿Está seguro?",
        text: "Una vez realizado el voto, no será posible revertirlo.",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((result) => {
        if (result) {
            var tarjetaPostal = new XMLHttpRequest();
            tarjetaPostal.open("POST", "Votaciones/Upsert", true);
            tarjetaPostal.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            tarjetaPostal.send("candidatoId=" + idCandidato.value);

            tarjetaPostal.onreadystatechange = function () {
                if (tarjetaPostal.readyState == 4 && tarjetaPostal.status == 200) {
                    desactivarVotacion();
                    cargarResultadoVotacion();
                    toastr.success("Voto registrado correctamente");
                } else if (tarjetaPostal.readyState == 4 && tarjetaPostal.status != 200) {
                    toastr.error("Fallo al registrar el voto");
                }
            }
        }
    });    
}

function registrarVotacion(id){
    document.getElementById("iIdCandidato").value = id;

    votar();
}

function desactivarVotacion(){
    var botones = document.getElementsByClassName("btn-votar");

    while (!botones.length == 0){
        botones[0].remove();
    }
}

function cargarResultadoVotacion() {
    var tarjetaPostal = new XMLHttpRequest();
    tarjetaPostal.open("POST", "/Votaciones/CargarResultados", true);
    tarjetaPostal.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    tarjetaPostal.send(null);

    tarjetaPostal.onreadystatechange = function(){
        if(tarjetaPostal.readyState == 4 && tarjetaPostal.status == 200){
            var resp = tarjetaPostal.responseText; 
            var resultados = JSON.parse(resp);
            
            for (var resultado in resultados) {
                var pResultado = document.getElementById("resultadoCandidato" + resultados[resultado].idCandidato);

                pResultado.innerHTML = "Cantidad de votos: " + resultados[resultado].resultado;
            }
    }
  }
}

function cantidadVotos() {
    var tarjetaPostal = new XMLHttpRequest();
    tarjetaPostal.open("POST", "/Votaciones/Listar", true);
    tarjetaPostal.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    tarjetaPostal.send(null);

    tarjetaPostal.onreadystatechange = function(){
        if(tarjetaPostal.readyState == 4 && tarjetaPostal.status == 200){
            var resp = tarjetaPostal.responseText; 
            var resultados = JSON.parse(resp);
            var h1Votos = document.getElementById("votos-totales");

            h1Votos.innerHTML = resultados.data;
    }
  }
}
