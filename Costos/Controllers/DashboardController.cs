using CEntidades;
using CLogica;
using Costos.Attribute;
using Microsoft.AspNetCore.Mvc;

namespace Costos.Controllers
{
    [SessionTimeout]
    public class DashboardController : Controller
    {
        public ISession Sesion => HttpContext.Session;
        LLogin objLLogin;

        // GET: Dashboard
        public ActionResult Index()
        {
            Login log = new Login();
            objLLogin = new LLogin();
            string idPersona = Sesion.GetString("idPersona");
            string estado = Sesion.GetString("tipoAlumno");
            log = objLLogin.RetornarFullname(idPersona);
            Sesion.SetString("fullname", log.fullname);
            ViewBag.login = log;
            ViewBag.iPersona = idPersona;
            ViewBag.tipoAlumno = estado;
            return View();
        }
    }
}
