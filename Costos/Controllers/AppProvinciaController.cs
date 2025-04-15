using Costos.Attribute;
using Microsoft.AspNetCore.Mvc;
using Recaudacion.BE;
using Recaudacion.BL;

namespace Costos.Controllers
{
    [SessionTimeout]
    public class AppProvinciaController : Controller
    {
        public JsonResult Get(string id = "")
        {
            List<beProvincia> lisProvincia = new List<beProvincia>(); ;
            blProvincia objProvincia = new blProvincia();
            lisProvincia = objProvincia.ListaPorDepartamento(id);
            return Json(lisProvincia);
        }
    }
}
