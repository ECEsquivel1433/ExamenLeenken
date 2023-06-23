using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SL.Controllers
{
    public class EmpleadoController : ApiController
    {
       

        // GET: api/Empleado
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Empleado/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Empleado.GetAllEF();

            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }

        }

        /// GET: api/Empleado/5
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Empleado/GetById/{IdEmpleado}")]
        public IHttpActionResult GetById(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.GetByIdEF(IdEmpleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }


        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Empleado/Add")]
        // POST: api/Empleado
        public IHttpActionResult Post([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.AddEF(empleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Empleado/Update")]
        // PUT: api/Empleado/5
        public IHttpActionResult Put([FromBody] ML.Empleado empleado)
        {
            var result = BL.Empleado.UpdateEF(empleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Empleado/Delete/{IdEmpleado}")]
        // GET: api/Empleado/Delete
        public IHttpActionResult Delete(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.DeleteEF(IdEmpleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }

        }

        
    }
}