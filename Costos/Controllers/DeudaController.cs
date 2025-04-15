using CEntidades;
using CLogica;
using Costos.Attribute;
using Microsoft.AspNetCore.Mvc;

namespace Costos.Controllers
{
    [SessionTimeout]
    public class DeudaController : Controller
    {
        LDeudaBanco objDeuda = new LDeudaBanco();

        EN_ObtenerDeudaCabecera cabeceraDeuda;
        List<EN_ObtenerDeudaDeuda> listaDeudas;
        public ISession Sesion => HttpContext.Session;
        public IActionResult Index()
        {
            cabeceraDeuda= new EN_ObtenerDeudaCabecera();
            listaDeudas = new List<EN_ObtenerDeudaDeuda>();
            string idPersona = Sesion.GetString("idPersona");

            string resultado = "";

            cabeceraDeuda = objDeuda.cabeceraDeuda(idPersona);
            listaDeudas=objDeuda.listaDeudas(idPersona);
            resultado=objDeuda.registrarDeudaTmp(idPersona);


            ViewBag.cabeceraDeuda=cabeceraDeuda;
            ViewBag.listaDeudas = listaDeudas;
            ViewBag.resultado = resultado;

            return View();

        }

        public JsonResult RegistroDeuda()
        {
            string idPersona = Sesion.GetString("idPersona");
            string idTransacion = "";
            idTransacion = objDeuda.registrarDeudaTransacciones(idPersona);
            return Json(idTransacion);
        }
       


    }
}
