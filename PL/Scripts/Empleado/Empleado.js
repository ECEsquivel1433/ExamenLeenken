$(document).ready(function () {
    GetAll();
    CategoriaGetAll();
});

function GetAll() {    
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44331/api/Empleado/GetAll',

        success: function (result)
        { //200 OK 
            $('#Empleados tbody').empty();
            $.each(result.Objects, function (i, empleado) {
                var filas =
                    '<tr>'
                        + '<td class="text-center"> '
                    + '<a href="#" onclick="GetById(' + empleado.IdEmpleado + ')">'
                                + '<img  style="height: 25px; width: 25px;" src="../img/edit.ico" />'
                            + '</a> '
                        + '</td>'
                        + "<td  id='id' class='text-center'>" + empleado.IdEmpleado + "</td>"
                        + "<td class='text-center'>" + empleado.Nombre + "</td>"
                        + "<td class='text-center'>" + empleado.Descripcion + "</ td>"
                        + "<td class='text-center'>" + empleado.Categoria.IdCategoria + "</td>"
                        //+ '<td class="text-center">  <a href="#" onclick="return Eliminar(' + empleado.IdEmpleado + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/delete.png" />' + '</a>    </td>'
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



function CategoriaGetAll() {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44331/api/Empleado/GetAll',       
        success: function (result) {
            $("#ddlCategorias").append('<option value="'+ 0 + '">' + 'Seleccione una opción' + '</option>');
            $.each(result.Objects, function (i, categoria) {
                $("#ddlCategorias").append('<option value="'
                                           + categoria.IdCategoria + '">'
                                           + categoria.Descripcion + '</option>');
            });
        }
    });
}


function Add() {

    var empleado = {
        
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
        url: 'https://localhost:44331/api/Empleado/Add',
        dataType: 'json',
        data: subcategoria,
        success: function (result) {
            $('#myModal').modal();           
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};


function GetById(IdEmpleado) {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44331/api/Empleado/GetById/'+IdEmpleado,       
        success: function (result) {
            $('#txtIdEmpleado').val(result.Object.IdEmpleado);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtDescripcion').val(result.Object.Descripcion);
            $('#txtIdCategoria').val(result.Object.Categoria.IdCategoria);
            $('#ModalUpdate').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }


    });

}


function Update() {

    var empleado = {
        IdEmpleado: $('#txtIdEmpleado').val(),
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
        data: subcategoria,
        success: function (result) {
            $('#myModal').modal();
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
            type: 'DELETE',
            url: 'https://localhost:44331/api/Empleado/Delete/'+IdEmpleado,          
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