var dataTable;

$(document).ready(function () { /* esta funcion lo que hace es cuando esta cargada toda la pagina  ejecuta a un funcion en este caso cargarDataTable()*/
    cargarDataTable();
});

function cargarDataTable() {
    dataTable = $("#tblCategorias").DataTable({
        "ajax": {
            "url": "/admin/categorias/GetCategorias",
            "type": "GET",
            "dataType": "json"
        },
        "columns": [
            { "data": "idCategoria", "width": "5%" },
            { "data": "nombre", "width": "40%" },
            { "data": "fechaCreacion", "width": "20%" },
            {
                "data": "idCategoria",
                "render": function (data) {

                    return `<div class="text-center">
    <a href="/admin/categorias/editar/${data}" class="btn btn-success text-white bi bi-pencil-square" style="cursor:pointer; width:100px;">Editar</a>
    &nbsp;
    <a toastr.options.onclick=Borrar("/admin/categorias/BorrarCategoria/${data}") class="btn btn-danger text-white bi bi-x-square" style="cursor:pointer; width:100px;">Borrar</a>
</div>`;

                }
            }
        ]
    });
}



function Borrar(url) {
    swal({
        title: "¿Está seguro de borrar?",
        text: "Este contenido no se puede recuperar.",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Sí, Borrar!",
        closeOnConfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                } else {
                    toastr.error(data.message);
                }
            }
        });
    });
}

