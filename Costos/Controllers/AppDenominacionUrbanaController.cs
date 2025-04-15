using Costos.Attribute;
using Microsoft.AspNetCore.Mvc;
using Recaudacion.BE;
using Recaudacion.BL;

namespace Costos.Controllers
{
    [SessionTimeout]
    public class AppDenominacionUrbanaController : Controller
    {
        public JsonResult Get(string id = "")
        {
            List<beDenominacionUrbana> lisDenominacionUrbana = new List<beDenominacionUrbana>(); ;
            blDenominacionUrbana objDenominacionUrbana = new blDenominacionUrbana();
            lisDenominacionUrbana = objDenominacionUrbana.Lista(id);
            return Json(lisDenominacionUrbana);
        }
    }
}
