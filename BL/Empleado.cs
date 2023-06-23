using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result AddEF(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ExamenLeenkenEntities context = new DL.ExamenLeenkenEntities())
                {
                    int queryEF = context.EmpleadoAdd(empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.NumeroNomina, empleado.Estado.IdEstado);
                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el empleado" + ex;
            }
            return result;
        }
        public static ML.Result UpdateEF(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ExamenLeenkenEntities context = new DL.ExamenLeenkenEntities())
                {
                    int queryEF = context.EmpleadoUpdate(empleado.IdEmpleado, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno,empleado.NumeroNomina,empleado.Estado.IdEstado);
                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el empleado" + ex;
            }
            return result;
        }
        public static ML.Result DeleteEF(int IdEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ExamenLeenkenEntities context = new DL.ExamenLeenkenEntities())
                {
                    int queryEF = context.EmpleadoDelete(IdEmpleado);
                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el empleado" + ex;
            }
            return result;
        }
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenLeenkenEntities context = new DL.ExamenLeenkenEntities())
                {
                    var queryEF = context.EmpleadoGetAll().ToList();
                    result.Objects = new List<object>();
                    if (queryEF != null)
                    {
                        foreach (var obj in queryEF)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.Estado = new ML.Estado();
                            empleado.IdEmpleado = obj.IdEmpleado;
                            empleado.Nombre = obj.Nombre;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;
                            empleado.NumeroNomina= obj.NumeroNomina;
                            empleado.Estado.IdEstado = obj.IdEstado;
                            empleado.Estado.Nombre = obj.Estado;
                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el empleado" + ex;
            }
            return result;
        }
        public static ML.Result GetByIdEF(int idEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenLeenkenEntities context = new DL.ExamenLeenkenEntities())
                {
                    var queryEF = context.EmpleadoGetById(idEmpleado).FirstOrDefault();
                    if (queryEF != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();
                        empleado.Estado = new ML.Estado();

                        empleado.IdEmpleado = queryEF.IdEmpleado;
                        empleado.Nombre = queryEF.Nombre;
                        empleado.ApellidoPaterno = queryEF.ApellidoPaterno;
                        empleado.ApellidoMaterno = queryEF.ApellidoMaterno;
                        empleado.NumeroNomina = queryEF.NumeroNomina;
                        empleado.Estado.IdEstado = queryEF.IdEstado;
                        empleado.Estado.Nombre = queryEF.Estado;

                        result.Object = empleado;

                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el empleado" + ex;
            }
            return result;
        }
    }
}
