using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;


namespace SL.Controllers
{
    public class EstadoController : ApiController
    {
        // GET: api/Estado
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Estado/GetAll")]
        public IHttpActionResult EstadoGetAll()
        {
            ML.Result result = BL.Estado.EstadoGetAllEF();

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