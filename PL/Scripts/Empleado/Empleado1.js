$(document).ready(function () {
    GetAll();
    EstadoGetAll();
});
function ModalOpen() {
    $('#ModalForm').modal('show');
}
function ModalClose() {
    $('#ModalForm').modal('close');
}
function Enviar() {
    Validate();
    Clear();
}
function Cancelar() {
    ModalClose();
    Clear();
}
function Validate(IdEmpleado) {
    var empleado = {
        IdEmpleado: $('#txtIdEmpleado').val(),
    }
    if(empleado.IdEmpleado == ""){
        Add();
    }
    else {
        Update();
    }
}
function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44331/api/Empleado/GetAll',

        success: function (result) { //200 OK 
            $('#Empleados tbody').empty();
            $.each(result.Objects, function (i, empleado) {
                var filas =
                    '<tr>'
                    + '<td class="text-center"> '
                    + '<a class="glyphicon glyphicon-edit" href="#" onclick="GetById(' + empleado.IdEmpleado + ')">'
                    + '</a> '
                    + '</td>'
                    + "<td  id='id' class='text-center'>" + empleado.IdEmpleado + "</td>"
                    + "<td class='text-center'>" + empleado.Nombre + "</td>"
                    + "<td class='text-center'>" + empleado.ApellidoPaterno + "</ td>"
                    + "<td class='text-center'>" + empleado.ApellidoMaterno + "</ td>"
                    + "<td class='text-center'>" + empleado.NumeroNomina + "</ td>"
                    + "<td class='text-center'>" + empleado.Estado.Nombre + "</td>"
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + empleado.IdEmpleado + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#Empleados tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};
function EstadoGetAll() {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44331/api/Estado/GetAll',
        success: function (result) {
            $("#ddlEstados").append('<option value="' + 0 + '">' + 'Seleccione una opción' + '</option>');
            $.each(result.Objects, function (i, estado) {
                $("#ddlEstados").append('<option value="'
                    + estado.IdEstado + '">'
                    + estado.Nombre + '</option>');
            });
        }
    });
}
function Add() {

    var empleado = {
        IdEmpleado: 0,
        NumeroNomina: $('#txtNumeroNomina').val(),
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApellidoPaterno').val(),
        ApellidoMaterno: $('#txtApellidoMaterno').val(),
        Estado: {
            IdEstado: $('#ddlEstados').val()

        }
    }
    $.ajax({
        type: 'POST',
        url: 'https://localhost:44331/api/Empleado/Add',
        dataType: 'json',
        data: empleado,
        success: function (result) {
            $('#myModal').modal('show');
            $('#ModalForm').modal('show');
            GetAll();
            Console(respond);
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
    Clear();
};
function GetById(IdEmpleado) {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44331/api/Empleado/GetById/' + IdEmpleado,
        success: function (result) {
            $('#txtIdEmpleado').val(result.Object.IdEmpleado);
            $('#txtNumeroNomina').val(result.Object.NumeroNomina);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtApellidoPaterno').val(result.Object.ApellidoPaterno);
            $('#txtApellidoMaterno').val(result.Object.ApellidoMaterno);
            $('#ddlEstados').val(result.Object.Estado.IdEstado);
            $('#ModalForm').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
}
function Update() {

    var empleado = {
        IdEmpleado: $('#txtIdEmpleado').val(),
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApellidoPaterno').val(),
        ApellidoMaterno: $('#txtApellidoMaterno').val(),
        NumeroNomina: $('#txtNumeroNomina').val(),
        Estado: {
            IdEstado: $('#ddlEstados').val()
        }

    }

    $.ajax({
        type: 'POST',
        url: 'https://localhost:44331/api/Empleado/Update',
        datatype: 'json',
        data: empleado,
        success: function (result) {
            $('#myModal').modal('show');
            $('#Modal').modal('show');
            GetAll();
            Console(respond);
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });

};
function Eliminar(IdEmpleado) {

    if (confirm("¿Estas seguro de eliminar al Empleado seleccionada?")) {
        $.ajax({
            type: 'POST',
            url: 'https://localhost:44331/api/Empleado/Delete/' + IdEmpleado,
            success: function (result) {
                $('#myModal').modal();
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });

    };
};
function Clear() {
    $('#txtIdEmpleado').val("");
        $('#txtNombre').val("");
        $('#txtApellidoPaterno').val("");
        $('#txtApellidoMaterno').val("");
    $('#txtNumeroNomina').val("");
    $('#ddlEstados').val(0)
}