using CLogica;
using Costos.Attribute;
using Microsoft.AspNetCore.Mvc;

namespace Costos.Controllers
{
    [SessionTimeout]
    public class ProgramacionController : Controller
    {
        LPagoBanco _objPagobanco;
        LHorarios _objhorarios;
        public ISession Sesion => HttpContext.Session;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult programacionNinios()
        {
            _objPagobanco= new LPagoBanco();
            string? idPersona = Sesion.GetString("idPersona");

            var cursoNivel = _objPagobanco.cursosProgramacion(idPersona);

            var listaSedes = _objPagobanco.listaSedesActivas(cursoNivel.CodCurso);


            Sesion.SetString("cursoActivo",cursoNivel.CodCurso);

            ViewBag.listaSedes=listaSedes;
            ViewBag.cursoNivel = cursoNivel;

            return View();
        }

        public JsonResult obtenerFrecuencia(string idSede)
        {
            _objhorarios= new LHorarios();
            string codCursoActivo = Sesion.GetString("cursoActivo");
            var frecuencias = _objhorarios.NE_Listas_ProgramacionFrecuencias(idSede, codCursoActivo);
            return Json(frecuencias);
        }

        public JsonResult registrarPrematricula(string idCiclo)
        {
            _objPagobanco = new LPagoBanco();
            string idPersona = Sesion.GetString("idPersona");

            string resultadoPrematricula = "";
            resultadoPrematricula = _objPagobanco.NE_RegistrarPrematricula(1, idCiclo, idPersona);
            return Json(resultadoPrematricula);
        }


    }
}
