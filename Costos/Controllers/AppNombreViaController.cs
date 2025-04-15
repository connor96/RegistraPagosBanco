using Costos.Attribute;
using Microsoft.AspNetCore.Mvc;
using Recaudacion.BE;
using Recaudacion.BL;

namespace Costos.Controllers
{
    public class AppNombreViaController : Controller
    {
        [SessionTimeout]
        public JsonResult Get(string id = "")
        {
            List<beNombreVia> lisNombreVia = new List<beNombreVia>(); ;
            blNombreVia objNombreVia = new blNombreVia();
            lisNombreVia = objNombreVia.Lista(id);
            return Json(lisNombreVia);
        }
    }
}
