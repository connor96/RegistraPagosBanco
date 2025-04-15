using Costos.Attribute;
using Microsoft.AspNetCore.Mvc;
using Recaudacion.BE;
using Recaudacion.BL;

namespace Costos.Controllers
{
    [SessionTimeout]
    public class ContactoController : Controller
    {
        List<beContacto> lisContacto;
        List<beTipoContacto> lisTipoContacto;
        beContacto itmContacto;
        beReturn itmReturn;

        blContacto objContacto = new blContacto();
        blTipoContacto objTipoContacto = new blTipoContacto();

        public ISession Sesion => HttpContext.Session;
        // GET: Contacto
        public ActionResult Index()
        {
            string idPersona = Sesion.GetString("idPersona");
            lisContacto = new List<beContacto>();
            lisContacto = objContacto.Lista(idPersona);
            return PartialView(lisContacto);
        }

        // GET: Contacto/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Contacto/Create
        public ActionResult Create()
        {
            lisTipoContacto = new List<beTipoContacto>();
            lisTipoContacto = objTipoContacto.Lista();
            ViewBag.lisTipoContacto = lisTipoContacto;
            return View();
        }

        // POST: Contacto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beContacto myitmContacto)
        {
            string idPersona = Sesion.GetString("idPersona");
            itmReturn = new beReturn();
            myitmContacto.IdPersona = idPersona;
            myitmContacto.UserRegistro = "0000000000";
            itmReturn = objContacto.Insert(myitmContacto);
            return Json(itmReturn);
        }

        // GET: Contacto/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: Contacto/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Contacto/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Contacto/Delete/5
        [HttpPost]
        public JsonResult Delete(Guid id, FormCollection collection)
        {
            itmReturn = new beReturn();
            itmReturn = objContacto.Delete(id);
            return Json(itmReturn);
        }
    }
}
