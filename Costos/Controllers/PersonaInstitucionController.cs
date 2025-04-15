using Costos.Attribute;
using Microsoft.AspNetCore.Mvc;
using Recaudacion.BE;
using Recaudacion.BL;

namespace Costos.Controllers
{
    [SessionTimeout]
    public class PersonaInstitucionController : Controller
    {
        List<beOcupacion> lisOcupacion;
        List<beCE> lisCE;
        List<beCECarrera> lisCECarrera;
        bePersonaInstitucion itmPersonaInstitucion;
        beReturn itmReturn;
        blPersonaInstitucion objPersonaInstitucion = new blPersonaInstitucion();
        blOcupacion objOcupacion = new blOcupacion();
        blCE objCE = new blCE();
        blCECarrera objCECarrera = new blCECarrera();

        public ISession Sesion => HttpContext.Session;


        // GET: PersonaInstitucion
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: PersonaInstitucion/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: PersonaInstitucion/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: PersonaInstitucion/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: PersonaInstitucion/Edit/5
        public ActionResult Edit()
        {
            string idPersona = Sesion.GetString("idPersona");
            lisOcupacion = new List<beOcupacion>();
            lisCE = new List<beCE>();
            lisCECarrera = new List<beCECarrera>();
            itmPersonaInstitucion = new bePersonaInstitucion();
            itmPersonaInstitucion = objPersonaInstitucion.Detalle(idPersona);
            lisOcupacion = objOcupacion.Lista();
            lisCE = objCE.ListaPorOcupacion(itmPersonaInstitucion.IdOcupacion);
            lisCECarrera = objCECarrera.ListaPorCE(itmPersonaInstitucion.IdCE);
            ViewBag.lisOcupacion = lisOcupacion;
            ViewBag.lisCE = lisCE;
            ViewBag.lisCECarrera = lisCECarrera;
            return PartialView(itmPersonaInstitucion);
        }

        // POST: PersonaInstitucion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(bePersonaInstitucion myitemPersonaInstitucion)
        {
            string idPersona = Sesion.GetString("idPersona");
            itmReturn = new beReturn();
            myitemPersonaInstitucion.IdPersona = idPersona;
            myitemPersonaInstitucion.IdSede = 1;
            itmReturn = objPersonaInstitucion.Update(myitemPersonaInstitucion);
            return Json(itmReturn);
        }

        // GET: PersonaInstitucion/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: PersonaInstitucion/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
