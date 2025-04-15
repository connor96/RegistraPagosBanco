using Costos.Attribute;
using Microsoft.AspNetCore.Mvc;
using Recaudacion.BE;
using Recaudacion.BL;

namespace Costos.Controllers
{
    [SessionTimeout]
    public class AppDistritoController : Controller
    {
        public JsonResult Get(string idDep = "", string idProv = "")
        {
            List<beDistrito> lisDistrito = new List<beDistrito>(); ;
            blDistrito objDistrito = new blDistrito();
            lisDistrito = objDistrito.ListaPorProvincia(idDep, idProv);
            return Json(lisDistrito);
        }
    }
}
