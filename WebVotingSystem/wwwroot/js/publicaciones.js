function publicarArticulo() {
	var opTitulo = document.getElementById("iTitulo");
	var opContenido = document.getElementById("iContenido");

	if(opTitulo.value.length == 0 || opContenido.value.length == 0){ 
		document.getElementById("publiMensaje").innerHTML = "El artículo necesita título y contenido.";
		document.getElementById("publiMensaje").setAttribute("class","mensajeError");
	} else {
		swal({
			title: "¿Está seguro?",
			text: "Una vez publicado, no será posible editarlo ni borrarlo.",
			icon: "warning",
			buttons: true,
			dangerMode: true
		}).then((result) => {
			if (result) {
				document.getElementById("formPublicar").submit();
			}
		});
	}
}

$(document).ready(function () {
	$.noConflict();
	$('#tblTodasOpiniones').DataTable();
	$('#tblMisOpiniones').DataTable();
});

function Borrar(url) {
	swal({
		title: "¿Está seguro?",
		text: "Una vez borrado, no será posible recuperarlo.",
		icon: "warning",
		buttons: true,
		dangerMode: true
	}).then((result) => {
		if (result) {
			$.ajax({
				url: url,
				type: "DELETE",
				success: function (data) {
					if (data.success) {
						toastr.success(data.message);
						dataTable.ajax.reload();
					}
					else {
						toastr.error(data.message);
					}
				}
			});
		}
	});
}
