using Castle.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Form()
        {
            return View(new ML.Empleado());
        }


        //[HttpGet]
        //public ActionResult GetAll()
        //{

        //    ML.Empleado empleado = new ML.Empleado();
        //    empleado.Empleados = new List<object>();

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44331/api/");

        //        var responseTask = client.GetAsync("Empleado/GetAll");
        //        responseTask.Wait(); //esperar a que se resuelva la llamada al servicio

        //        var result = responseTask.Result;


        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<ML.Result>();
        //            readTask.Wait();

        //            foreach (var resultItem in readTask.Result.Objects)
        //            {
        //                ML.Empleado resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Empleado>(resultItem.ToString());
        //                empleado.Empleados.Add(resultItemList);
        //            }
        //        }
        //    }
        //    return View(empleado);
        //}


        //[HttpGet]
        //public ActionResult Form(int? idEmpleado)
        //{
        //    //ML.Result resultProveedores = BL.Proveedor.GetAll();
        //    //ML.Result resultAreas = BL.Area.GetAll();
        //    //ML.Result resultDepartamentos = BL.Departamento.GetAll();

        //    ML.Empleado empleado = new ML.Empleado();
        //    //empleado.Proveedor = new ML.Proveedor();
        //    //empleado.Departamento = new ML.Departamento();
        //    //empleado.Area = new ML.Area();

        //    //empleado.Departamento.Departamentos = resultDepartamentos.Objects;
        //    //empleado.Proveedor.Proveedores = resultProveedores.Objects;
        //    //empleado.Area.Areas = resultAreas.Objects;

        //    //add
        //    if (idEmpleado == null)
        //    {
        //        return View(empleado);
        //    }
        //    else //BetById para Update
        //    {
        //        //Se omite llamada a al y unboxing para WebAPI
        //        //ML.Result result = BL.Empleado.GetById(idEmpleado.Value);
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri("https://localhost:44331/api/");

        //            var postTask = client.PostAsJsonAsync<int>("Empleado/GetById", idEmpleado.Value);
        //            postTask.Wait();

        //            var result = postTask.Result;


        //            if (result.IsSuccessStatusCode)
        //            {
        //                var readTask = result.Content.ReadAsAsync<ML.Empleado>();
        //                readTask.Wait();
        //                empleado = readTask.Result;
        //            }
        //        }


        //        //empleado = (ML.Empleado)result.Object;
        //        //ML.Result resultDepartamentos = BL.Departamento.GetByIdArea(empleado.Area.IdArea);


        //        //empleado.Departamento.Departamentos = resultDepartamentos.Objects;
        //        //empleado.Proveedor.Proveedores = resultProveedores.Objects;
        //        //empleado.Area.Areas = resultAreas.Objects;

        //        return View(empleado);
        //    }
        //}


        //[HttpPost]
        //public ActionResult Form(ML.Empleado empleado)
        //{

        //    ML.Result result = new ML.Result();
        //    if (empleado.IdEmpleado == 0)
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri("https://localhost:44331/api/");

        //            //HTTP POST
        //            var postTask = client.PostAsJsonAsync<ML.Empleado>("Empleado/Add", empleado);
        //            postTask.Wait();

        //            var empleadoresult = postTask.Result;
        //            if (empleadoresult.IsSuccessStatusCode)
        //            {
        //                ViewBag.Message = "Se agrego correctamente el usuario";
        //            }
        //            else
        //            {
        //                ViewBag.Message = "Ocurrio un error al agregar el usuario";
        //            }
        //        }
        //        return PartialView("Modal");
        //    }
        //    else
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri("https://localhost:44331/api/");

        //            //HTTP POST
        //            var putTask = client.PutAsJsonAsync<ML.Empleado>("Empleado/Update", empleado);
        //            putTask.Wait();

        //            var empleadoresult = putTask.Result;
        //            if (empleadoresult.IsSuccessStatusCode)
        //            {
        //                ViewBag.Message = "Se actualizo correctamente el usuario";
        //            }
        //            else
        //            {
        //                ViewBag.Message = "Ocurrio un error al actualizar el usuario";
        //            }
        //        }
        //        return PartialView("Modal");
        //    }

        //    //return PartialView("Modal");
        //}

        //public ActionResult Delete(int IdEmpleado)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44331/api/");

        //        //HTTP POST
        //        var postTask = client.PostAsJsonAsync<int>("Empleado/Delete", IdEmpleado);
        //        postTask.Wait();

        //        var empleadoresult = postTask.Result;
        //        if (empleadoresult.IsSuccessStatusCode)
        //        {
        //            ViewBag.Message = "Se elimino correctamente el usuario";
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Ocurrio un error al eliminar el usuario";
        //        }
        //    }
        //    return PartialView("Modal");
        //}

    }
}