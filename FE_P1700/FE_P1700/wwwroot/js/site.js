function ValidarCaracteres(cadena) {
    // Expresión regular para buscar caracteres problemáticos
    var patron = /['";=*%`><(){}]/;

    return patron.test(cadena);
}

function ValidarCadenaVacia(cadena) {

    if (cadena == "" || cadena == null)
        return true;
    else
        return false;

}


function AbrirModal(datos) {
    // Iterar sobre los datos recibidos y asignarlos a los campos correspondientes
    Object.keys(datos).forEach(key => {
        $(`#txt${key.charAt(0).toUpperCase() + key.slice(1)}`).val(datos[key]);
    });

    // Mostrar el modal
    $("#Modal").modal('show');

    // Validar si el modal está presente en el contenedor y agregarlo si es necesario
    if ($('#DivParaModals').children().length === 0) {
        $('#DivParaModals').append($('#Modal'));
    }
}


function LlamarTabla(tabla, url, columns, columnDefs, scrollX) {

    tabla.DataTable({
        language: {
            info: 'Mostrando página _PAGE_ de _PAGES_',
            infoEmpty: 'Ningún registro disponible',
            lengthMenu: 'Mostrar _MENU_ registros por página',
            zeroRecords: 'No se encontraron registros',
            search: 'Búsqueda'
        },
        responsive: true,
        scrollX: scrollX,
        ajax: {
            url: url,
            type: 'GET',
            dataType: 'json',
            error: function (xhr, error, thrown) {

                // Obtener información del error
                let errorMessage = "Se ha producido un error.";
                if (xhr.status === 0) {
                    errorMessage = "No se puede conectar al servidor. Verifica tu conexión a Internet.";
                } else if (xhr.status === 404) {
                    errorMessage = "La URL solicitada no se encontró.";
                } else if (xhr.status === 500) {
                    errorMessage = "Error interno del servidor.";
                } else if (error === "parsererror") {
                    errorMessage = "Error al analizar la respuesta JSON.";
                } else if (error === "timeout") {
                    errorMessage = "La solicitud ha excedido el tiempo de espera.";
                } else if (error === "abort") {
                    errorMessage = "La solicitud fue abortada.";
                }


                console.log('Se produjo un error:', error);

                const Toast = Swal.mixin({
                    toast: true,
                    position: "top-end",
                    showConfirmButton: false,
                    timer: 10000,
                    timerProgressBar: true,
                    didOpen: (toast) => {
                        toast.onmouseenter = Swal.stopTimer;
                        toast.onmouseleave = Swal.resumeTimer;
                    }
                });
                Toast.fire({
                    icon: "error",
                    iconColor: '#0C4A6E',
                    title: errorMessage
                });
            }
        },
        autoWidth: false,
        columns: columns,
        columnDefs: columnDefs,
        destroy: true
    });

}



function GuardarRegistro(url, modelo, id) {

    fetch(url, {
        method: id === "0" ? "POST" : "PUT",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(modelo)
    })
        .then(response => {

            if (!response.ok) {
                return response.json().then(errors => {

                    console.log('Validation errors:', errors);

                    var errorMessage = "";

                    Object.keys(errors).forEach(key => {
                        errorMessage += errors[key].join('\n') + '\n';
                    });

                    const Toast = Swal.mixin({
                        toast: true,
                        position: "center",
                        showConfirmButton: true,
                        confirmButtonColor: '#0C4A6E',
                        timer: 0,
                        timerProgressBar: false,
                        didOpen: toast => {
                            toast.onmouseenter = Swal.stopTimer;
                            toast.onmouseleave = Swal.resumeTimer;
                        }
                    });
                    Toast.fire({
                        icon: "error",
                        iconColor: '#0C4A6E',
                        title: errorMessage
                    });

                    throw new Error('Validation errors occurred');
                });
            }

            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(dataJson => {
            const exitoMensaje = modelo.proveedorId === "0" ? "Se registró correctamente!" : "Se actualizó correctamente!";
            const Toast = Swal.mixin({
                toast: true,
                position: "top-end",
                showConfirmButton: false,
                timer: 3000,
                timerProgressBar: true,
                didOpen: toast => {
                    toast.onmouseenter = Swal.stopTimer;
                    toast.onmouseleave = Swal.resumeTimer;
                }
            });
            Toast.fire({
                icon: "success",
                iconColor: '#0C4A6E',
                title: exitoMensaje
            });

            $('.modal').modal('hide');
            CargarTabla();
        })
}



function EliminarRegistro(registroID) {

    Swal.fire({
        title: "¿Desea eliminar el registro?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Eliminar",
        cancelButtonText: "Cancelar",
        confirmButtonColor: '#0C4A6E',
        iconColor: '#0C4A6E'
    }).then((result) => {
        if (result.isConfirmed) {
            fetch("Delete", {
                method: "DELETE",
                headers: {
                    'Content-Type': 'application/json;charset=utf-8'
                },
                body: JSON.stringify(registroID)
            })
                .then(response => {
                    return response.ok ? response.json() : Promise.reject(response);
                })
                .then(dataJson => {
                    const exitoMensaje = "Registro eliminado correctamente!";
                    const Toast = Swal.mixin({
                        toast: true,
                        position: 'top-end',
                        showConfirmButton: false,
                        timer: 4000,
                        width: '400px',
                        timerProgressBar: true,
                        didOpen: toast => {
                            toast.addEventListener('mouseenter', Swal.stopTimer);
                            toast.addEventListener('mouseleave', Swal.resumeTimer);
                        }
                    });
                    Toast.fire({
                        icon: 'success',
                        title: exitoMensaje
                    });

                    CargarTabla();
                })
                .catch(error => {
                    console.log('Se produjo un error:', error);

                    const Toast = Swal.mixin({
                        toast: true,
                        position: "top-end",
                        showConfirmButton: false,
                        timer: 10000,
                        timerProgressBar: true,
                        didOpen: toast => {
                            toast.onmouseenter = Swal.stopTimer;
                            toast.onmouseleave = Swal.resumeTimer;
                        }
                    });
                    Toast.fire({
                        icon: "error",
                        iconColor: '#0C4A6E',
                        title: 'Se ha producido un error.'
                    });
                });
        }
    });
}

function FormatearFecha(sqlDateString) {
    if (!sqlDateString) {
        return '';
    }

    // Divide fecha sql en año mes y día
    const [year, month, day] = sqlDateString.split('-');

    // Crea un nuevo objeto con los valores
    const dateObj = new Date(parseInt(year), parseInt(month) - 1, parseInt(day));

    // Formatea la fecha YYYY-MM-DD
    const formattedDate = dateObj.toISOString().slice(0, 10);

    return formattedDate;
}
