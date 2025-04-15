using CEntidades;
using CLogica;
using Costos.Attribute;
using Microsoft.AspNetCore.Mvc;

namespace Costos.Controllers
{

    [SessionTimeout]
    public class ListaVoucherController : Controller
    {

        public ISession Sesion => HttpContext.Session;

        LVoucher obj_Voucher = new LVoucher();
        List<EN_Voucher> _listavoucher;
        LCurso obj_Curso = new LCurso();
        EN_Curso_Libro cursolibro;
        LLogin objLLogin;

        public IActionResult Index()
        {
            objLLogin = new LLogin();
            Login log = new Login();
            string IdPersona = Sesion.GetString("idPersona");
            log = objLLogin.RetornarFullname(IdPersona);
            _listavoucher = new List<EN_Voucher>();
            _listavoucher = obj_Voucher.listaVoucher(IdPersona);
            ViewBag.listavoucher = _listavoucher;
            ViewBag.login = log;
            return View();
        }


        public ActionResult ModalCurso(string idCiclo)
        {
            cursolibro = new EN_Curso_Libro();
            cursolibro = obj_Curso.RetornarCursoLibro(idCiclo);
            ViewBag.clibro = cursolibro;
            return View();
        }

        public ActionResult DetalleMP(string idTransaccion)
        {
            EN_Voucher voucher = new EN_Voucher();
            //string idTransaccion = Sesion.GetString("idTransaccion");
            voucher = obj_Voucher.ObtenerVoucher(idTransaccion);

            ViewBag.voucherTransaccion = voucher;
            return View();
        }

        public ActionResult DetalleVoucher(string Idtransaccion)
        {

            EN_Voucher_Pagado vpagado = new EN_Voucher_Pagado();
            vpagado = obj_Voucher.ObtenerVoucherPagado(Idtransaccion);

            ViewBag.voucher = vpagado;
            return View();
        }

        public JsonResult DetalleMPjson(string idTransaccion)
        {
            Sesion.SetString("idTrans", idTransaccion);
            return Json("exito");
        }
    }
}
