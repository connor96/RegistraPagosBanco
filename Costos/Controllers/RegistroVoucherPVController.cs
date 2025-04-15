using CEntidades;
using CLogica;
using Costos.Attribute;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Costos.Controllers
{
    [SessionTimeout]
    public class RegistroVoucherPVController : Controller
    {

        EN_Voucher _voucher;
        List<EN_PHoraria> ListaPHoraria;
        List<EN_Conceptos> conceptos;
        List<EN_Conceptos> montos;
        List<EN_Conceptos> conceptoscargados;
        List<EN_Voucher_Pago> lpagos;

        List<EN_Ciclo_Combo> lciclos;

        List<EN_Programacion> lprogramacion;
        LVoucher objVoucher;
        LProgramacion objprogramacion;
        LHorarios objNE_PHoraria;

        LVoucher objNE_PVoucher;

        EN_Voucher voucher;

        public ISession Sesion => HttpContext.Session;
        
        public IActionResult Index()
        {
            //Inicializar variables de sesion (listas)
            Sesion.SetString("listconceptospv", "");
            Sesion.SetString("listaconceptoscargadospv", "");

            objprogramacion = new LProgramacion();

            string idPersona = Sesion.GetString("idPersona");


            voucher = new EN_Voucher();
            objNE_PVoucher = new LVoucher();
            voucher = objNE_PVoucher.RetornarAlumno(idPersona);

            //Lista de conceptos
            objVoucher = new LVoucher();
            conceptos = new List<EN_Conceptos>();
            conceptos = objVoucher.ObtenerConcepto(idPersona);

            Sesion.SetString("listconceptospv", JsonConvert.SerializeObject(conceptos));

            //montos a la tabla(inicial)
            montos = new List<EN_Conceptos>();
            montos = agregarmontos(conceptos);
            Sesion.SetString("listaconceptoscargadospv", JsonConvert.SerializeObject(montos));


            //Lista de periodos
            objprogramacion = new LProgramacion();
            lprogramacion = new List<EN_Programacion>();
            lprogramacion = objprogramacion.RetornarCodProgramacion();

            //Lista de sedes
            ListaPHoraria = new List<EN_PHoraria>();
            objNE_PHoraria = new LHorarios();
            ListaPHoraria = objNE_PHoraria.NE_Listas_PHoraria("sede", "", "", "", "", "", "", "", "");

            //agregar combos ciclos (libros)
            lciclos = new List<EN_Ciclo_Combo>();
            lciclos = objprogramacion.RetornarCiclos();

            //total
            int total = 0;
            foreach (var item in montos)
            {
                total = int.Parse(item.Monto) + total;
            }


            //Lanzar todo a la interfaz mediante ViewBag
            ViewBag.lprog = lprogramacion;
            ViewBag.concep = conceptos;
            ViewBag.sedes = ListaPHoraria;
            ViewBag.ciclos = lciclos;
            ViewBag.totales = total;
            ViewBag.montoscargados = montos;
            ViewBag.datosAlumnoVoucher = voucher;
            return View();
        }


        public List<EN_Conceptos> agregarmontos(List<EN_Conceptos> concepto)
        {
            conceptoscargados = new List<EN_Conceptos>();

            foreach (var item in concepto)
            {
                switch (item.IdConcepto)
                {
                    case 6:
                        if (int.Parse(item.Monto) > 0)
                        {
                            item.Activo = true;
                            conceptoscargados.Add(item);
                        }
                        break;
                    case 29:
                        if (int.Parse(item.Monto) > 0)
                        {
                            item.Activo = true;
                            conceptoscargados.Add(item);
                        }
                        break;

                    default:
                        item.Activo = true;
                        //_LConceptos.Add(concepto);
                        break;
                }
            }

            return conceptoscargados;


        }

        public JsonResult RegistrarVoucherPV(string periodomes, string sede, string nombreBanco, string nrooperacion, string fechaTransaccion, string urlVoucher, string email, string ncelular)
        {
            objNE_PVoucher = new LVoucher();

            EN_Voucher_Pagado vpagado = new EN_Voucher_Pagado();

            //Agregar conceptos
            conceptos = new List<EN_Conceptos>();
            conceptos = JsonConvert.DeserializeObject<List<EN_Conceptos>>(Sesion.GetString("listaconceptoscargadospv"));

            vpagado.conceptos = conceptos;
            vpagado.IdPersona = Sesion.GetString("idPersona");
            vpagado.periodo = periodomes;
            vpagado.IdSede = sede;

            vpagado.celular = ncelular;
            vpagado.email = email;

            //Asignar total
            int total = 0;
            foreach (var item in conceptos)
            {
                total = int.Parse(item.Monto) + total;
            }
            vpagado.monto = total;

            //Nuevo voucher registro
            lpagos = new List<EN_Voucher_Pago>();
            EN_Voucher_Pago vpago = new EN_Voucher_Pago();
            vpago.banco = nombreBanco;
            vpago.fecha = Convert.ToDateTime(fechaTransaccion);
            vpago.nrooperacion = nrooperacion;
            vpago.url = urlVoucher;
            lpagos.Add(vpago);

            vpagado.vouchersregistrados = lpagos;

            string resultado = objNE_PVoucher.RegistrarPagoPV(vpagado);

            Sesion.SetString("listconceptospv", "");
            Sesion.SetString("listaconceptoscargadospv", "");
            return Json(resultado);
        }


        public JsonResult asignarTransaccion(string idTransaccion)
        {
            Sesion.SetString("idTransaccion", idTransaccion);
            return Json("exito");
        }

        public JsonResult ValidarVoucher(string nrooperacion)
        {
            objNE_PVoucher = new LVoucher();
            string operacion = objNE_PVoucher.ValidarVoucher(nrooperacion);
            return Json(operacion);
        }

        public ActionResult TableVouchers(string id, string operacion)
        {

            objNE_PVoucher = new LVoucher();

            //int idMonto = int.Parse(Sesion.GetString("idMonto"));
            EN_Conceptos con = new EN_Conceptos();

            conceptoscargados = new List<EN_Conceptos>();
            conceptoscargados = JsonConvert.DeserializeObject<List<EN_Conceptos>>(Sesion.GetString("listaconceptoscargadospv"));

            if (operacion == "agregar")
            {
                con = devolverconcepto(int.Parse(id));
                if (conceptoscargados != null)
                {
                    conceptoscargados.Clear();
                    conceptoscargados = agregarconceptos(con);
                }
                else
                {
                    conceptoscargados = agregarconceptos(con);
                }
                Sesion.SetString("listaconceptoscargadospv", "");
                Sesion.SetString("listaconceptoscargadospv", JsonConvert.SerializeObject(conceptoscargados));
            }
            else if (operacion == "quitar")
            {
                conceptoscargados = quitarconceptos(int.Parse(id));
                Sesion.SetString("listaconceptoscargadospv", "");
                Sesion.SetString("listaconceptoscargadospv", JsonConvert.SerializeObject(conceptoscargados));

            }
            else
            {
                con = objNE_PVoucher.ConceptoLibro(id);
                conceptoscargados = agregarconceptos(con);
                Sesion.SetString("listaconceptoscargadospv", "");
                Sesion.SetString("listaconceptoscargadospv", JsonConvert.SerializeObject(conceptoscargados));
            }

            conceptoscargados.Clear();
            conceptoscargados = JsonConvert.DeserializeObject<List<EN_Conceptos>>(Sesion.GetString("listaconceptoscargadospv"));

            int total = 0;
            foreach (var item in conceptoscargados)
            {
                total = int.Parse(item.Monto) + total;
            }

            ViewBag.montoscargados = conceptoscargados;
            ViewBag.totales = total;
            return View();

        }

        public EN_Conceptos devolverconcepto(int id)
        {
            EN_Conceptos conceptodevuelto = new EN_Conceptos();
            conceptos = new List<EN_Conceptos>();
            conceptos = JsonConvert.DeserializeObject<List<EN_Conceptos>>(Sesion.GetString("listconceptospv"));

            foreach (var item in conceptos)
            {
                if (item.IdConcepto == id)
                {
                    conceptodevuelto = item;
                }
            }
            return conceptodevuelto;
        }

        public List<EN_Conceptos> agregarconceptos(EN_Conceptos concep)
        {
            conceptoscargados = new List<EN_Conceptos>();
            conceptoscargados = JsonConvert.DeserializeObject<List<EN_Conceptos>>(Sesion.GetString("listaconceptoscargadospv"));

            if (conceptoscargados == null)
            {
                conceptos = new List<EN_Conceptos>();
                conceptos.Add(concep);
                return conceptos;
            }
            else
            {
                conceptoscargados.Add(concep);
                return conceptoscargados;
            }


        }

        public List<EN_Conceptos> quitarconceptos(int id)
        {
            conceptoscargados = new List<EN_Conceptos>();
            conceptoscargados = JsonConvert.DeserializeObject<List<EN_Conceptos>>(Sesion.GetString("listaconceptoscargadospv"));

            conceptos = new List<EN_Conceptos>();
            foreach (var item in conceptoscargados)
            {
                if (item.IdConcepto != id)
                {
                    conceptos.Add(item);
                }
            }

            return conceptos;

        }


        public ActionResult VoucherConfirmacion()
        {
            EN_Voucher_Pagado voucher = new EN_Voucher_Pagado();

            objNE_PVoucher = new LVoucher();
            string idTransaccion = Sesion.GetString("idTransaccion");
            voucher = objNE_PVoucher.ObtenerVoucherPV(idTransaccion);

            ViewBag.voucherTransaccion = voucher;

            return View();
        }



    }
}
