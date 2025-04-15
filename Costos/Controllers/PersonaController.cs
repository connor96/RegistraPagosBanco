using Costos.Attribute;
using Microsoft.AspNetCore.Mvc;
using Recaudacion.BE;
using Recaudacion.BL;

namespace Costos.Controllers
{
    [SessionTimeout]
    public class PersonaController : Controller
    {
        bePersonaUpdate itmPersonaUp;
        beDepartamento itmDepartamento;
        beProvincia itmProvincia;
        beDistrito itmDistrito;
        beTipoVia itmTipoVia;
        beOcupacion itmOcupacion;
        beReturn itmReturn;
        List<beDepartamento> lisDepartamento;
        List<beProvincia> lisProvincia;
        List<beDistrito> lisDistrito;
        List<beTipoVia> lisTipoVia;
        List<beTipoDireccion> lisTipoDireccion;
        blPersonaUpdate objPresonaUp = new blPersonaUpdate();
        blDepartamento objDepartamento = new blDepartamento();
        blProvincia objProvincia = new blProvincia();
        blDistrito objDistrito = new blDistrito();
        blTipoVia objTipoVia = new blTipoVia();
        blTipoDireccion objTipoDireccion = new blTipoDireccion();

        public ISession Sesion => HttpContext.Session;




        // GET: Persona
        public ActionResult Editar()
        {
            itmPersonaUp = new bePersonaUpdate();
            lisDepartamento = new List<beDepartamento>();
            lisProvincia = new List<beProvincia>();
            lisDistrito = new List<beDistrito>();
            lisTipoVia = new List<beTipoVia>();
            lisTipoDireccion = new List<beTipoDireccion>();


            string idPersona = Sesion.GetString("idPersona");

            itmPersonaUp = objPresonaUp.Detalle(idPersona);

            lisDepartamento = objDepartamento.Lista();
            lisProvincia = objProvincia.ListaPorDepartamento(itmPersonaUp.itmDistrito.CodDepartamento);
            lisDistrito = objDistrito.ListaPorProvincia(itmPersonaUp.itmDistrito.CodDepartamento, itmPersonaUp.itmDistrito.CodProvincia);
            lisTipoVia = objTipoVia.Lista();
            lisTipoDireccion = objTipoDireccion.Lista();

            ViewBag.lisDepartamento = lisDepartamento;
            ViewBag.lisProvincia = lisProvincia;
            ViewBag.lisDistrito = lisDistrito;
            ViewBag.lisTipoVia = lisTipoVia;
            ViewBag.lisTipoDireccion = lisTipoDireccion;
            return View(itmPersonaUp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Editar(bePersonaUpdate myitmPersonaUp)
        {


            string idPersona = Sesion.GetString("idPersona");
            itmReturn = new beReturn();
            myitmPersonaUp.IdPersona = idPersona;
            myitmPersonaUp.IdLocal = 4;
            myitmPersonaUp.Terminal = Environment.MachineName;
            myitmPersonaUp.User = "0000000000";
            itmReturn = objPresonaUp.Update(myitmPersonaUp);
            return Json(itmReturn);
        }
    }
}
