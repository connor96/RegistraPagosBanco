using Costos.Attribute;
using Microsoft.AspNetCore.Mvc;
using Recaudacion.BE;
using Recaudacion.BL;

namespace Costos.Controllers
{
    [SessionTimeout]
    public class AppCEController : Controller
    {
        List<beCE> lisCE;
        blCE objCE = new blCE();
        // GET: api/AppCE
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/AppCE/5
        public JsonResult Get(int id)
        {
            lisCE = new List<beCE>();
            lisCE = objCE.ListaPorOcupacion(id);
            return Json(lisCE);
        }

        // POST: api/AppCE
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/AppCE/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/AppCE/5
        public void Delete(int id)
        {
        }
    }
}
