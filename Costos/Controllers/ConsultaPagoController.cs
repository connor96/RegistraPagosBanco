using CEntidades;
using CLogica;
using Costos.Attribute;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Costos.Controllers
{
    [SessionTimeout]
    public class ConsultaPagoController : Controller
    {

        public ISession Sesion => HttpContext.Session;

        LLogin objLogin = new LLogin();
        LBanco objBanco = new LBanco();
        Banco _banco;

        LProgramacion objprogramacion;
        LVoucher objNE_PVoucher;

        List<EN_Conceptos> conceptos;
        List<EN_Conceptos> conceptoscargados;
        List<EN_Conceptos> montos;
        List<EN_Conceptos> smontos;

        List<EN_Ciclo_Combo> lciclos;


  
        public IActionResult Index()
        {
            Sesion.SetString("listconceptos", "");
            Sesion.SetString("listaconceptoscargados", "");

            _banco = new Banco();

            string _persona;
            _persona = Sesion.GetString("idPersona");

            _banco = objBanco.RetornarDeuda(_persona);

            objprogramacion = new LProgramacion();

            objNE_PVoucher = new LVoucher();
            string idPersona = Sesion.GetString("idPersona");
            EN_Voucher voucher = new EN_Voucher();
            voucher = objNE_PVoucher.RetornarAlumno(idPersona);

            //conceptos al combo
            conceptos = new List<EN_Conceptos>();
            conceptos = objNE_PVoucher.ObtenerConceptoCP(idPersona, _banco);
            //conceptos = validarB01(conceptos,_banco.codcurso_siguiente);

            Sesion.SetString("listconceptos", JsonConvert.SerializeObject(conceptos));

            conceptos.Clear();
            conceptos = JsonConvert.DeserializeObject<List<EN_Conceptos>>(Sesion.GetString("listconceptos"));

            //montos a la tabla(inicial)
            conceptoscargados = new List<EN_Conceptos>();
            conceptoscargados = agregarmontos(conceptos);

            Sesion.SetString("listaconceptoscargados", JsonConvert.SerializeObject(conceptoscargados));

            montos = new List<EN_Conceptos>();
            montos = conceptoscargados;

            //suma montos
            smontos = new List<EN_Conceptos>();
            smontos = conceptoscargados;

            //agregar combos ciclos
            //lciclos = new List<EN_Ciclo_Combo>();
            //lciclos = objprogramacion.RetornarCiclos();

            int total = 0;
            foreach (var item in smontos)
            {
                total = int.Parse(item.Monto) + total;
            }
            //ViewBag.ciclos = lciclos;
            ViewBag.sumatotal = total;
            ViewBag.datosMontos = montos;
            ViewBag.datosConceptos = conceptos;
            ViewBag.datosAlumnoVoucher = voucher;
            return View(_banco);
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
                            item.Activo = false;
                            conceptoscargados.Add(item);
                        }
                        break;
                    case 29:
                        if (int.Parse(item.Monto) > 0)
                        {
                            item.Activo = false;
                            conceptoscargados.Add(item);
                        }
                        break;
                    case 28:
                        if (int.Parse(item.Monto) > 0)
                        {
                            item.Activo = true;
                            conceptoscargados.Add(item);
                            //_LConceptos.Add(concepto);
                        }
                        else
                        {
                            item.Activo = true;
                            //_LConceptos.Add(concepto);
                        }

                        break;

                    case 37:
                        if (int.Parse(item.Monto) > 0)
                        {
                            item.Activo = true;
                            conceptoscargados.Add(item);
                            //_LConceptos.Add(concepto);
                        }
                        else
                        {
                            item.Activo = true;
                            //_LConceptos.Add(concepto);
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




        [SessionTimeout]
        public ActionResult TableVouchers(string id, string operacion)
        {

            objNE_PVoucher = new LVoucher();

            //int idMonto = int.Parse(Sesion.GetString("idMonto"));
            EN_Conceptos con = new EN_Conceptos();

            conceptoscargados = new List<EN_Conceptos>();
            conceptoscargados = JsonConvert.DeserializeObject<List<EN_Conceptos>>(Sesion.GetString("listaconceptoscargados"));

            if (operacion == "agregar")
            {
                con = devolverconcepto(int.Parse(id));
                conceptoscargados.Clear();
                conceptoscargados = agregarconceptos(con);
                Sesion.SetString("listaconceptoscargados", "");
                Sesion.SetString("listaconceptoscargados", JsonConvert.SerializeObject(conceptoscargados));
            }
            else if (operacion == "quitar")
            {
                conceptoscargados = quitarconceptos(int.Parse(id));
                Sesion.SetString("listaconceptoscargados", "");
                Sesion.SetString("listaconceptoscargados", JsonConvert.SerializeObject(conceptoscargados));
            }
            else
            {
                con = objNE_PVoucher.ConceptoLibro(id);
                conceptoscargados = agregarconceptos(con);
                Sesion.SetString("listaconceptoscargados", "");
                Sesion.SetString("listaconceptoscargados", JsonConvert.SerializeObject(conceptoscargados));
            }

            conceptoscargados.Clear();
            conceptoscargados = JsonConvert.DeserializeObject<List<EN_Conceptos>>(Sesion.GetString("listaconceptoscargados"));

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
            conceptos = JsonConvert.DeserializeObject<List<EN_Conceptos>>(Sesion.GetString("listconceptos"));

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
            conceptoscargados = JsonConvert.DeserializeObject<List<EN_Conceptos>>(Sesion.GetString("listaconceptoscargados"));

            conceptoscargados.Add(concep);

            return conceptoscargados;
        }

        public List<EN_Conceptos> quitarconceptos(int id)
        {
            conceptoscargados = new List<EN_Conceptos>();
            conceptoscargados = JsonConvert.DeserializeObject<List<EN_Conceptos>>(Sesion.GetString("listaconceptoscargados"));

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

        [SessionTimeout]
        public ActionResult Salir()
        {
            Sesion.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
