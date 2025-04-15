using Costos.Attribute;
using Microsoft.AspNetCore.Mvc;
using Recaudacion.BE;
using Recaudacion.BL;
using System.Web.Helpers;


namespace Costos.Controllers
{

    [SessionTimeout]
    public class AppCECarreraController:Controller
    {
        List<beCECarrera> lisCECarrera;
        blCECarrera objCECarrera = new blCECarrera();
        // GET: api/AppCECarrera
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/AppCECarrera/5
        //public  List<beCECarrera> Get(int id)
        //{
        //    lisCECarrera = new List<beCECarrera>();
        //    lisCECarrera = objCECarrera.ListaPorCE(id);
        //    return lisCECarrera;
        //}


        public JsonResult Get(int id)
        {
            lisCECarrera = new List<beCECarrera>();
            lisCECarrera = objCECarrera.ListaPorCE(id);
            return Json(lisCECarrera);
        }


        // POST: api/AppCECarrera
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/AppCECarrera/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/AppCECarrera/5
        public void Delete(int id)
        {
        }
    }
}
