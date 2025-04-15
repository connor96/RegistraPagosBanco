using CEntidades;
using CLogica;
using Costos.Attribute;
using Datos;
using Microsoft.AspNetCore.Mvc;

namespace Costos.Controllers
{
    [SessionTimeout]
    public class BancoController : Controller
    {
        LVoucher objNE_PVoucher;
        LPagoBanco objPagoBanco;
        EN_Voucher voucher;

        List<string> _listaIdCiclo;

        List<EN_BancoTablaPensiones> en_BancoTablaPensiones;
        public ISession Sesion => HttpContext.Session;
        public IActionResult Index()
        {
            objPagoBanco= new LPagoBanco();
            
            string idPersona = Sesion.GetString("idPersona");

            string resultado = "";
            resultado= objPagoBanco.pagosBanco(idPersona);

            if (resultado == "5")
            {
                return RedirectToAction("AlumnoPrematricula", "Banco");
            }
            else if (resultado == "14")
            {

                return RedirectToAction("AlumnoDeuda", "Banco");

            }
            else 
            {
                ViewBag.resultado = resultado;
                return View();
            }

            
        }


        public IActionResult AlumnoPrematricula()
        {
            objPagoBanco = new LPagoBanco();
            string idPersona = Sesion.GetString("idPersona");

            List<EN_PagoMatriculaA> _PagoMatriculaA = new List<EN_PagoMatriculaA>();
            _PagoMatriculaA = objPagoBanco.PagoMatriculaA(idPersona);

            EN_PagoMatriculaB _PagoMatriculaB=new EN_PagoMatriculaB();
            _PagoMatriculaB=objPagoBanco.PagoMatriculaB(idPersona);

            ViewBag.matriculaA = _PagoMatriculaA;
            ViewBag.matriculaB= _PagoMatriculaB;

            return View();
        }

        public IActionResult AlumnoDeuda()
        {
            objPagoBanco = new LPagoBanco();
            string idPersona = Sesion.GetString("idPersona");

            List<EN_PagoMatriculaA> _PagoMatriculaA = new List<EN_PagoMatriculaA>();
            _PagoMatriculaA = objPagoBanco.PagoDeuda(idPersona);

           
            ViewBag.matriculaA = _PagoMatriculaA;
          

            return View();
        }

        public IActionResult TablaPagosPensiones()
        {
            objPagoBanco = new LPagoBanco();
            en_BancoTablaPensiones = new List<EN_BancoTablaPensiones>();
            string idPersona = Sesion.GetString("idPersona");

            objNE_PVoucher = new LVoucher();
            voucher = new EN_Voucher();
            voucher = objNE_PVoucher.RetornarAlumno(idPersona);

            _listaIdCiclo = new List<string>();

            _listaIdCiclo = objPagoBanco.ListaIdCiclo(idPersona);

            string resultado="";

            foreach (var item in _listaIdCiclo)
            {
                resultado = objPagoBanco.CalcularTransaccionesTmp(idPersona, item);
            }

            en_BancoTablaPensiones = objPagoBanco.ListaTablaPensiones(idPersona);

            ViewBag.listaTablaPensiones = en_BancoTablaPensiones;
            ViewBag.datosAlumno = voucher;

            return View();
        }


        public JsonResult registrarTransaccion(string correo, string telefono)
        {
            string idPersona = Sesion.GetString("idPersona");
            objPagoBanco = new LPagoBanco();

            string confirmacion = objPagoBanco.RegistrarPago(idPersona, correo, telefono);

            objPagoBanco.actualizarDatos(idPersona, correo, telefono);

            return Json(confirmacion);
                                                                                                                                                                                                                                                                                                                                                                                               
        }

    }
}
 