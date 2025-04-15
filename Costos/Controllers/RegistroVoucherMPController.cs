using CEntidades;
using CLogica;
using Costos.Attribute;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Costos.Controllers
{
    [SessionTimeout]
    public class RegistroVoucherMPController : Controller
    {
        #region Declaracion de Variables

        public ISession Sesion => HttpContext.Session;

        List<EN_PHoraria> ListaPHoraria;
        List<EN_Frecuencia> ListaPFrecuencuencia;
        List<EN_Conceptos> conceptos;
        List<EN_Conceptos> montos;
        List<EN_Conceptos> smontos;
        List<EN_Conceptos> conceptoscargados;
        List<EN_Curso> cursoscargados;
        List<EN_Curso> listacursos;
        List<EN_Curso> listacursosvalidado;
        List<EN_Curso> _ciclos_matriculados;
        List<EN_Voucher_Pago> listavoucherpago;
        List<EN_Voucher_Pago> listavoucherpagocargado;
        List<EN_Voucher_Pago> listavoucherninios;
        List<EN_Ciclo_Combo> lciclos;
        List<EN_PHoraria> _phoraria;

        LHorarios objNE_PHoraria;
        LVoucher objNE_PVoucher;
        LProgramacion objprogramacion;
        LAlumno objalumno;
        LCurso objCurso;

        LPagoBanco objBanco;

        EN_Frecuencia ListaFrecuenciaManana;
        EN_Frecuencia ListaFrecuenciaTarde;
        EN_Frecuencia ListaFrecuenciaNoche;
        EN_Curso detalle_curso;
        EN_Alumno alumno;
        EN_Alumno alumno2;
        EN_Voucher _voucher;
        EN_Voucher_Pagado vpagado;
        EN_Voucher voucher;
        EN_Voucher_Pago voucherninios;

        string _mes;
        string _anio;

        string _mesninios;
        string _anioninios;

        #endregion

        public IActionResult Index()
        {
            objBanco = new LPagoBanco();
            objalumno = new LAlumno();
            alumno = new EN_Alumno();
            _ciclos_matriculados = new List<EN_Curso>();
            //_phoraria = new List<EN_PHoraria>();

            string idPersona = Sesion.GetString("idPersona");

            alumno.IdAlumno = idPersona;
            string notafinal = Sesion.GetString("notafinalciclo");

            string codCursoglobal = Sesion.GetString("codCursoglobal");

            string vdoblecurso;
            vdoblecurso = validardoblecurso(notafinal, codCursoglobal);

            //_phoraria = objalumno.ObtenerRegistros(alumno);
            _ciclos_matriculados = objalumno.ObtenerCiclosMatriculados(alumno);

            ViewBag.ciclomat = _ciclos_matriculados;
            ViewBag.vdcurso = vdoblecurso;

            string resultado = objBanco.pagosBanco(idPersona);

            if (resultado == "4")
            {
                return RedirectToAction("Index", "Deuda");
            }
            else if (resultado == "5")
            {
                return RedirectToAction("Index", "Banco");
            }
            else if (resultado == "14")
            {
                return RedirectToAction("Index", "Banco");
            }
            else
            {
                return View();
            }

            //return View();

        }


        public string validardoblecurso(string nota, string codcursofinal)
        {
            switch (nota)
            {
                case "SN":
                case "INC":
                case "NS":
                    return "no";
                case "EXAMEN DE UBICACION":
                case "BASICO 1":
                    return "si";
                default:
                    int not = 0;
                    not = int.Parse(nota);
                    if (not < 80)
                    {
                        return "no";
                    }
                    else
                    {
                        switch (codcursofinal)
                        {
                            //case "A01":
                            //case "A02":
                            //case "A03":
                            //case "A04":
                            //case "A05":
                            //case "A06":
                            //case "A07":
                            //case "A08":
                            //case "A09":
                            //case "A10":
                            //case "A11":
                            //case "A12":
                            case "MET1":
                            case "MET2":
                            case "MET3":
                            case "MET4":
                            case "MET5":
                            case "MET6":
                                return "no";
                            default:
                                return "si";
                        }
                    }
            }

        }


        #region Horarios y cursos


        public JsonResult ListarSedes()
        {
            objNE_PHoraria = new LHorarios();
            return Json(objNE_PHoraria.NE_Listas_PHoraria("sede", "", "", "", "", "", "", "", ""));
        }

        public JsonResult ListarNiveles(string idsede, string anio, string mes)
        {
            obtenermes();
            objNE_PHoraria = new LHorarios();
            string estado = Sesion.GetString("tipoAlumno");
            return Json(objNE_PHoraria.NE_Listas_PHoraria("nivel", idsede, _anio, _mes, "", "", "", "", estado));
        }

        public JsonResult ListarNivelesNinios(string idsede, string anio, string mes)
        {
            obtenermesninios();
            objNE_PHoraria = new LHorarios();
            string estado = Sesion.GetString("tipoAlumno");
            return Json(objNE_PHoraria.NE_Listas_PHoraria("nivel", idsede, _anioninios, _mesninios, "", "", "", "", estado));
        }

        public ActionResult ListarFrecuenciaAccion(string idsede, string anio, string mes, string codnivel, string modalidad, string curso)
        {
            obtenermes();
            objNE_PHoraria = new LHorarios();
            ListaPFrecuencuencia = new List<EN_Frecuencia>();
            ListaPFrecuencuencia = objNE_PHoraria.NE_Listas_FHoraria("frecuencia", idsede, _anio, _mes, codnivel, modalidad, curso, "");
            ViewBag.ListaFrecuencia = ListaPFrecuencuencia;

            ListaFrecuenciaManana = new EN_Frecuencia();
            ListaFrecuenciaTarde = new EN_Frecuencia();
            ListaFrecuenciaNoche = new EN_Frecuencia();

            foreach (var item in ListaPFrecuencuencia)
            {
                if (item.idTurno == "turno1")
                {
                    ListaFrecuenciaManana = item;
                }
                if (item.idTurno == "turno2")
                {
                    ListaFrecuenciaTarde = item;
                }
                if (item.idTurno == "turno3")
                {
                    ListaFrecuenciaNoche = item;
                }
            }
            ViewBag.FrecuenciaManana = ListaFrecuenciaManana;
            ViewBag.FrecuenciaTarde = ListaFrecuenciaTarde;
            ViewBag.FrecuenciaNoche = ListaFrecuenciaNoche;

            ListaPHoraria = new List<EN_PHoraria>();
            ListaPHoraria = objNE_PHoraria.NE_Listas_PHoraria("detalles", idsede, _anio, _mes, codnivel, modalidad, curso, "", "");
            ViewBag.ListaHoraria = ListaPHoraria;

            return View();
        }


        public ActionResult ListarFrecuenciaAccion2(string idsede, string modalidad)
        {

            string curso = Sesion.GetString("codCursoglobal");
            string codnivel = "";

            obtenermes();
            objNE_PHoraria = new LHorarios();
            ListaPFrecuencuencia = new List<EN_Frecuencia>();
            ListaPFrecuencuencia = objNE_PHoraria.NE_Listas_FHoraria("frecuencia2", idsede, _anio, _mes, codnivel, modalidad, curso, "");
            ViewBag.ListaFrecuencia = ListaPFrecuencuencia;

            ListaFrecuenciaManana = new EN_Frecuencia();
            ListaFrecuenciaTarde = new EN_Frecuencia();
            ListaFrecuenciaNoche = new EN_Frecuencia();

            foreach (var item in ListaPFrecuencuencia)
            {
                if (item.idTurno == "turno1")
                {
                    ListaFrecuenciaManana = item;
                }
                if (item.idTurno == "turno2")
                {
                    ListaFrecuenciaTarde = item;
                }
                if (item.idTurno == "turno3")
                {
                    ListaFrecuenciaNoche = item;
                }
            }
            ViewBag.FrecuenciaManana = ListaFrecuenciaManana;
            ViewBag.FrecuenciaTarde = ListaFrecuenciaTarde;
            ViewBag.FrecuenciaNoche = ListaFrecuenciaNoche;

            ListaPHoraria = new List<EN_PHoraria>();
            ListaPHoraria = objNE_PHoraria.NE_Listas_PHoraria("detalles2", idsede, _anio, _mes, codnivel, modalidad, curso, "", "");
            ViewBag.ListaHoraria = ListaPHoraria;

            return View();
        }




        public ActionResult ListarFrecuenciaAccionTabla(string idsede, string modalidad)
        {

            string curso = Sesion.GetString("codCursoglobal");
            string codnivel = "";

            obtenermes();
            objNE_PHoraria = new LHorarios();
            ListaPFrecuencuencia = new List<EN_Frecuencia>();
            ListaPFrecuencuencia = objNE_PHoraria.NE_Listas_FHoraria("frecuencia2", idsede, _anio, _mes, codnivel, modalidad, curso, "");
            ViewBag.ListaFrecuencia = ListaPFrecuencuencia;

            ListaFrecuenciaManana = new EN_Frecuencia();
            ListaFrecuenciaTarde = new EN_Frecuencia();
            ListaFrecuenciaNoche = new EN_Frecuencia();

            foreach (var item in ListaPFrecuencuencia)
            {
                if (item.idTurno == "turno1")
                {
                    ListaFrecuenciaManana = item;
                }
                if (item.idTurno == "turno2")
                {
                    ListaFrecuenciaTarde = item;
                }
                if (item.idTurno == "turno3")
                {
                    ListaFrecuenciaNoche = item;
                }
            }
            ViewBag.FrecuenciaManana = ListaFrecuenciaManana;
            ViewBag.FrecuenciaTarde = ListaFrecuenciaTarde;
            ViewBag.FrecuenciaNoche = ListaFrecuenciaNoche;

            ListaPHoraria = new List<EN_PHoraria>();
            ListaPHoraria = objNE_PHoraria.NE_Listas_PHoraria("detalles2", idsede, _anio, _mes, codnivel, modalidad, curso, "", "");
            ViewBag.ListaHoraria = ListaPHoraria;

            return View();
        }


        public JsonResult ObtenerFrecuenciaNinios(string idsede, string anio, string mes)
        {
            obtenermesninios();
            objNE_PHoraria = new LHorarios();
            string codcursosiguiente = Sesion.GetString("codCursoglobal");
            LProgramacion objprogramacion = new LProgramacion();
            EN_Programacion prog = new EN_Programacion();
            prog = objprogramacion.RetornarCodNivel(codcursosiguiente);

            return Json(objNE_PHoraria.NE_Listas_PHoraria("modalidad", idsede, _anioninios, _mesninios, prog.codnivel, "", "", "", ""));
        }





        public ActionResult ListarFrecuenciaNinios(string idsede, string nivel, string modalidad, string curso)
        {

            obtenermesninios();

            string codcursosiguiente = Sesion.GetString("codCursoglobal");

            objNE_PHoraria = new LHorarios();
            ListaPFrecuencuencia = new List<EN_Frecuencia>();
            ListaPFrecuencuencia = objNE_PHoraria.NE_Listas_FHoraria("frecuencia", idsede, _anioninios, _mesninios, nivel, modalidad, curso, "");
            ViewBag.ListaFrecuencia = ListaPFrecuencuencia;

            ListaFrecuenciaManana = new EN_Frecuencia();
            ListaFrecuenciaTarde = new EN_Frecuencia();
            ListaFrecuenciaNoche = new EN_Frecuencia();

            foreach (var item in ListaPFrecuencuencia)
            {
                if (item.idTurno == "turno1")
                {
                    ListaFrecuenciaManana = item;
                }
                if (item.idTurno == "turno2")
                {
                    ListaFrecuenciaTarde = item;
                }
                if (item.idTurno == "turno3")
                {
                    ListaFrecuenciaNoche = item;
                }
            }
            ViewBag.FrecuenciaManana = ListaFrecuenciaManana;
            ViewBag.FrecuenciaTarde = ListaFrecuenciaTarde;
            ViewBag.FrecuenciaNoche = ListaFrecuenciaNoche;

            ListaPHoraria = new List<EN_PHoraria>();
            ListaPHoraria = objNE_PHoraria.NE_Listas_PHoraria("detalles", idsede, _anioninios, _mesninios, nivel, modalidad, curso, "", "");
            ViewBag.ListaHoraria = ListaPHoraria;

            return View();
        }


        public ActionResult ListarFrecuenciaAccionCiclo(string idsede, string anio, string mes, string codnivel, string modalidad, string curso)
        {
            obtenermes();
            objNE_PHoraria = new LHorarios();
            ListaPFrecuencuencia = new List<EN_Frecuencia>();
            ListaPFrecuencuencia = objNE_PHoraria.NE_Listas_FHoraria("frecuencia", idsede, _anio, _mes, codnivel, modalidad, curso, "");
            ViewBag.ListaFrecuencia = ListaPFrecuencuencia;

            ListaFrecuenciaManana = new EN_Frecuencia();
            ListaFrecuenciaTarde = new EN_Frecuencia();
            ListaFrecuenciaNoche = new EN_Frecuencia();

            foreach (var item in ListaPFrecuencuencia)
            {
                if (item.idTurno == "turno1")
                {
                    ListaFrecuenciaManana = item;
                }
                if (item.idTurno == "turno2")
                {
                    ListaFrecuenciaTarde = item;
                }
                if (item.idTurno == "turno3")
                {
                    ListaFrecuenciaNoche = item;
                }
            }
            ViewBag.FrecuenciaManana = ListaFrecuenciaManana;
            ViewBag.FrecuenciaTarde = ListaFrecuenciaTarde;
            ViewBag.FrecuenciaNoche = ListaFrecuenciaNoche;

            ListaPHoraria = new List<EN_PHoraria>();
            ListaPHoraria = objNE_PHoraria.NE_Listas_PHoraria("detalles", idsede, _anio, _mes, codnivel, modalidad, curso, "", "");
            ViewBag.ListaHoraria = ListaPHoraria;

            return View();
        }
        public JsonResult AsignacionIdCicloUnCiclo(string idCiclo)
        {
            objCurso = new LCurso();
            EN_Curso curso = new EN_Curso();
            curso = devolvercurso(idCiclo);
            cursoscargados = agregarcursos(curso);
            Sesion.SetString("listacursoscargados", "");
            Sesion.SetString("listacursoscargados", JsonConvert.SerializeObject(cursoscargados));

            return Json("Agregado");
        }

        public JsonResult ListarFrecuencia(string idsede, string anio, string mes, string codnivel)
        {
            obtenermes();
            objNE_PHoraria = new LHorarios();
            return Json(objNE_PHoraria.NE_Listas_PHoraria("modalidad", idsede, _anio, _mes, codnivel, "", "", "", ""));
        }

        public JsonResult ListarFrecuenciaNinio(string idsede, string anio, string mes, string codnivel)
        {
            obtenermesninios();
            string estado = Sesion.GetString("tipoAlumno");
            objNE_PHoraria = new LHorarios();
            return Json(objNE_PHoraria.NE_Listas_PHoraria("modalidad", idsede, _anioninios, _mesninios, codnivel, "", "", "", estado));
        }

        public JsonResult ListarCursos(string idsede, string anio, string mes, string codnivel, string modalidad)
        {
            obtenermes();
            objNE_PHoraria = new LHorarios();
            return Json(objNE_PHoraria.NE_Listas_PHoraria("cursos", idsede, _anio, _mes, codnivel, modalidad, "", "", ""));
        }

        public JsonResult ListarCursosNinios(string idsede, string anio, string mes, string codnivel, string modalidad)
        {
            obtenermesninios();
            objNE_PHoraria = new LHorarios();
            return Json(objNE_PHoraria.NE_Listas_PHoraria("cursos", idsede, _anioninios, _mesninios, codnivel, modalidad, "", "", ""));
        }

        public JsonResult ListarFrecuencias(string idsede, string anio, string mes, string codnivel, string modalidad, string curso)
        {
            obtenermes();
            objNE_PHoraria = new LHorarios();
            return Json(objNE_PHoraria.NE_Listas_PHoraria("frecuencia", idsede, _anio, _mes, codnivel, modalidad, curso, "", ""));
            //return Json(objNE_PHoraria.NE_BuscarFrecuencia("frecuencia", idsede, anio, mes, codnivel, modalidad, curso));
        }

        public JsonResult Programacion(string idsede, string anio, string mes, string codnivel, string modalidad, string curso, string frecuencia)
        {
            obtenermes();
            objNE_PHoraria = new LHorarios();
            return Json(objNE_PHoraria.NE_Listas_PHoraria("programacion", idsede, _anio, _mes, codnivel, modalidad, curso, frecuencia, ""));
        }

        public JsonResult Detalles(string idsede, string anio, string mes, string codnivel, string modalidad, string curso, string frecuencia)
        {
            obtenermes();
            objNE_PHoraria = new LHorarios();
            return Json(objNE_PHoraria.NE_Listas_PHoraria("detalles", idsede, _anio, _mes, codnivel, modalidad, curso, "", ""));
        }


        private void obtenermes()
        {
            _anio = "2025";
            _mes = "4";
        }

        private void obtenermesninios()
        {
            _anioninios = "2025";
            _mesninios = "4";

        }


        public EN_Curso devolvercurso(string idCiclo)
        {
            objCurso = new LCurso();
            EN_Curso curso = new EN_Curso();
            curso = objCurso.RetornarCursoTabla(idCiclo);
            return curso;
        }


        public List<EN_Curso> agregarcursos(EN_Curso cur)
        {
            listacursos = new List<EN_Curso>();
            listacursos = JsonConvert.DeserializeObject<List<EN_Curso>>(Sesion.GetString("listacursoscargados"));
            if (listacursos == null)
            {
                cursoscargados = new List<EN_Curso>();
                cursoscargados.Add(cur);
                listacursos = cursoscargados;
                return listacursos;
            }
            else
            {
                listacursosvalidado = new List<EN_Curso>();

                foreach (var item in listacursos)
                {
                    listacursosvalidado.Add(item);
                    if (item.IdCiclo != cur.IdCiclo)
                    {
                        listacursosvalidado.Add(cur);
                    }
                }
                return listacursosvalidado;
            }

        }


        #endregion


        #region Seleccionar cursos

        public ActionResult ListarCiclo()
        {
            Sesion.SetString("listacursoscargados", "");
            detalle_curso = new EN_Curso();
            objCurso = new LCurso();

            string idPersona = Sesion.GetString("idPersona");
            string curso = Sesion.GetString("codCursoglobal");
            detalle_curso = objCurso.RetornarDetalleCurso(curso);


            ListaPHoraria = new List<EN_PHoraria>();
            objNE_PHoraria = new LHorarios();
            ListaPHoraria = objNE_PHoraria.NE_Listas_PHoraria("sede", "", "", "", "", "", "", "", "");

            ViewBag.detalles = detalle_curso;

            return View(ListaPHoraria);
        }

        public ActionResult RegistroCiclo()
        {
            Sesion.SetString("listacursoscargados", "");
            detalle_curso = new EN_Curso();
            objCurso = new LCurso();

            string idPersona = Sesion.GetString("idPersona");
            string curso = Sesion.GetString("codCursoglobal");
            detalle_curso = objCurso.RetornarDetalleCurso(curso);

            ListaPHoraria = new List<EN_PHoraria>();
            objNE_PHoraria = new LHorarios();
            //ListaPHoraria = objNE_PHoraria.NE_Listas_PHoraria("sede", "", "", "", "", "", "", "", "");
            ListaPHoraria = objNE_PHoraria.NE_Listas_ProgramacionHoraria(curso);
            ViewBag.detalles = detalle_curso;

            return View(ListaPHoraria);
        }


        public  JsonResult IntranetBuscarSede(string sede)
        {
            string curso = Sesion.GetString("codCursoglobal");
            objNE_PHoraria = new LHorarios();
            return Json(objNE_PHoraria.NE_Listas_ProgramacionFrecuencias(sede,curso));
        }


        public ActionResult RegistroNinios()
        {

            alumno = new EN_Alumno();
            objalumno = new LAlumno();
            _ciclos_matriculados = new List<EN_Curso>();

            Sesion.SetString("listacursoscargados", "");
            detalle_curso = new EN_Curso();
            objCurso = new LCurso();

            string idPersona = Sesion.GetString("idPersona");

            alumno.IdAlumno = idPersona;
            string curso = Sesion.GetString("codCursoglobal");
            detalle_curso = objCurso.RetornarDetalleCurso(curso);

            ListaPHoraria = new List<EN_PHoraria>();
            objNE_PHoraria = new LHorarios();
            ListaPHoraria = objNE_PHoraria.NE_Listas_PHoraria("sede", "", "", "", "", "", "", "", "");
            ViewBag.detalles = detalle_curso;

            _ciclos_matriculados = objalumno.ObtenerCiclosMatriculados(alumno);
            ViewBag.ciclomat = _ciclos_matriculados;

            return View(ListaPHoraria);
        }

        #endregion



        public JsonResult AsignacionIdCiclo()
        {

            cursoscargados = new List<EN_Curso>();
            cursoscargados = JsonConvert.DeserializeObject<List<EN_Curso>>(Sesion.GetString("listacursoscargados"));

            if (cursoscargados == null)
            {
                return Json("vacio");
            }
            else
            {
                return Json("lleno");
            }

        }


        public ActionResult VoucherMP()
        {
            EN_CEmergencia emergencia = new EN_CEmergencia();

            string idPersona = Sesion.GetString("idPersona");

            Sesion.SetString("listavoucherscargados", "");
            Sesion.SetString("listconceptos", "");
            Sesion.SetString("listaconceptoscargados", "");

            objprogramacion = new LProgramacion();

            objNE_PVoucher = new LVoucher();
            voucher = new EN_Voucher();
            voucher = objNE_PVoucher.RetornarAlumno(idPersona);

            //conceptos al combo
            conceptos = new List<EN_Conceptos>();

            //ciclos seleccionados
            listacursos = new List<EN_Curso>();
            listacursos = JsonConvert.DeserializeObject<List<EN_Curso>>(Sesion.GetString("listacursoscargados"));

            conceptos = objNE_PVoucher.ObtenerConceptoPM(listacursos, idPersona);
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
            lciclos = new List<EN_Ciclo_Combo>();
            lciclos = objprogramacion.RetornarCiclos();

            //obtener direccion
            alumno = new EN_Alumno();
            alumno.IdAlumno = idPersona;
            alumno2 = new EN_Alumno();
            alumno2 = objNE_PVoucher.ObtenerDireccion(alumno);

            //validar concepto matricula
            conceptos = objNE_PVoucher.ValidarMatricula(conceptos);

            int total = 0;
            foreach (var item in smontos)
            {
                total = int.Parse(item.Monto) + total;
            }

            string cursoactual = "";
            foreach (var item in conceptos)
            {
                if (item.IdConcepto == 37)
                {
                    cursoactual = item.cursoActual;
                }
            }

            ListaPHoraria = new List<EN_PHoraria>();
            objNE_PHoraria = new LHorarios();
            ListaPHoraria = objNE_PHoraria.NE_Listas_PHoraria("sede", "", "", "", "", "", "", "", "");

            emergencia = objNE_PVoucher.ObtenerContactoEmergencia(idPersona);

            List<string> _listaContactos=new List<string>();
            _listaContactos = contactosEmergencia();

            ViewBag.sedes = ListaPHoraria;
            ViewBag.cursoactual = cursoactual;
            ViewBag.alumno = alumno2;
            ViewBag.ciclos = lciclos;
            ViewBag.sumatotal = total;
            ViewBag.datosMontos = montos;
            ViewBag.datosConceptos = conceptos;
            ViewBag.datosAlumnoVoucher = voucher;
            ViewBag.datosEmergencia = emergencia;
            ViewBag.listaContactos = _listaContactos;

            return View();
        }


         
        public List<string> contactosEmergencia()
        {

            List<string> contactos = new List<string>();
            contactos.Add("padre");
            contactos.Add("madre");
            contactos.Add("apoderado");
            contactos.Add("otro");

            return contactos;

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
                if (item.IdConcepto == 28)
                {
                    item.Monto = "60";

                }

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


        public ActionResult TableCiclos(string idciclo, string operacion)
        {

            objCurso = new LCurso();
            EN_Curso curso = new EN_Curso();

            cursoscargados = new List<EN_Curso>();
            if (operacion == "agregar")
            {
                curso = devolvercurso(idciclo);
                cursoscargados = agregarcursos(curso);
                Sesion.SetString("listacursoscargados", "");
                Sesion.SetString("listacursoscargados", JsonConvert.SerializeObject(cursoscargados));
            }
            else if (operacion == "quitar")
            {
                cursoscargados = quitarcurso(idciclo);
                Sesion.SetString("listacursoscargados", "");
                Sesion.SetString("listacursoscargados", JsonConvert.SerializeObject(cursoscargados));
            }

            cursoscargados.Clear();
            cursoscargados = JsonConvert.DeserializeObject<List<EN_Curso>>(Sesion.GetString("listacursoscargados"));

            ViewBag.ccargados = cursoscargados;
            return View();

        }

        public List<EN_Curso> quitarcurso(string idciclo)
        {
            cursoscargados = new List<EN_Curso>();
            cursoscargados = JsonConvert.DeserializeObject<List<EN_Curso>>(Sesion.GetString("listacursoscargados"));

            listacursos = new List<EN_Curso>();
            foreach (var item in cursoscargados)
            {
                if (item.IdCiclo != idciclo)
                {
                    listacursos.Add(item);
                }
            }
            return listacursos;
        }



        public ActionResult TableVoucher(string operacion, string banco, string nrooperacion, string fecha, string url)
        {

            EN_Voucher_Pago vpago = new EN_Voucher_Pago();

            listavoucherpago = new List<EN_Voucher_Pago>();
            if (operacion == "agregar")
            {
                vpago.banco = banco;
                vpago.nrooperacion = nrooperacion;
                vpago.fecha = Convert.ToDateTime(fecha);
                vpago.url = url;

                listavoucherpago = agregarvoucher(vpago);
                Sesion.SetString("listavoucherscargados", "");
                Sesion.SetString("listavoucherscargados", JsonConvert.SerializeObject(listavoucherpago));
            }
            else if (operacion == "quitar")
            {
                listavoucherpago = quitarvoucher(nrooperacion);
                Sesion.SetString("listavoucherscargados", "");
                Sesion.SetString("listavoucherscargados", JsonConvert.SerializeObject(listavoucherpago));
            }

            listavoucherpago.Clear();
            listavoucherpago = JsonConvert.DeserializeObject<List<EN_Voucher_Pago>>(Sesion.GetString("listavoucherscargados"));

            ViewBag.vcargados = listavoucherpago;
            return View();

        }

        public List<EN_Voucher_Pago> agregarvoucher(EN_Voucher_Pago vp)
        {
            listavoucherpagocargado = new List<EN_Voucher_Pago>();
            listavoucherpagocargado = JsonConvert.DeserializeObject<List<EN_Voucher_Pago>>(Sesion.GetString("listavoucherscargados"));
            if (listavoucherpagocargado == null)
            {
                listavoucherpago = new List<EN_Voucher_Pago>();
                listavoucherpago.Add(vp);
                listavoucherpagocargado = listavoucherpago;
            }
            else
            {
                listavoucherpagocargado.Add(vp);
            }

            return listavoucherpagocargado;
        }

        public List<EN_Voucher_Pago> quitarvoucher(string nroperacion)
        {
            listavoucherpagocargado = new List<EN_Voucher_Pago>();
            listavoucherpagocargado = JsonConvert.DeserializeObject<List<EN_Voucher_Pago>>(Sesion.GetString("listavoucherscargados"));

            listavoucherpago = new List<EN_Voucher_Pago>();
            foreach (var item in listavoucherpagocargado)
            {
                if (item.nrooperacion != nroperacion)
                {
                    listavoucherpago.Add(item);
                }
            }
            return listavoucherpago;
        }


        public ActionResult VoucherConfirmacion()
        {
            string tipoalumno = "";
            EN_Voucher voucher = new EN_Voucher();
            EN_Voucher_Pagado vpagado = new EN_Voucher_Pagado();
            tipoalumno = Sesion.GetString("tipoAlumno");
            if (tipoalumno == "NNN" || tipoalumno == "EUN")
            {

                objNE_PVoucher = new LVoucher();
                string idTransaccion = Sesion.GetString("idTransaccion");
                vpagado = objNE_PVoucher.ObtenerVoucherPagado(idTransaccion);

            }
            else
            {
                objNE_PVoucher = new LVoucher();
                string idTransaccion = Sesion.GetString("idTransaccion");
                vpagado = objNE_PVoucher.ObtenerVoucherPagado(idTransaccion);
            }

            ViewBag.voucherPagado = vpagado;
            ViewBag.voucherTransaccion = voucher;
            return View();
        }


        public ActionResult VoucherConfirmacionNinios()
        {
            string tipoalumno = "";
            EN_Voucher voucher = new EN_Voucher();
            EN_Voucher_Pagado vpagado = new EN_Voucher_Pagado();
            tipoalumno = Sesion.GetString("tipoAlumno");

            objNE_PVoucher = new LVoucher();
            string idTransaccion = Sesion.GetString("idTransaccion");
            vpagado = objNE_PVoucher.ObtenerVoucherPagado(idTransaccion);

            ViewBag.voucherPagado = vpagado;
            ViewBag.voucherTransaccion = voucher;
            return View();
        }

        public JsonResult obtenerId()
        {
            string idPersona = Sesion.GetString("idPersona");
            return Json(idPersona);
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

        public int validattipo(string tipo)
        {
            if (tipo == "radio1")
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public JsonResult RegistrarVoucher(string nombreBanco, int idconcepto, string nrooperacion, string fechaTransaccion, int monto, string urlVoucher, string correo, string celular, string direccion, string sedeRecojo)
        {

            try
            {
    
                vpagado = new EN_Voucher_Pagado();
                vpagado.IdPersona = Sesion.GetString("idPersona");
                vpagado.cursosregistrados = JsonConvert.DeserializeObject<List<EN_Curso>>(Sesion.GetString("listacursoscargados"));
                vpagado.vouchersregistrados = JsonConvert.DeserializeObject<List<EN_Voucher_Pago>>(Sesion.GetString("listavoucherscargados"));
                //vpagado.vouchersregistrados = listavoucherninios;

                string _mes = "";
                string _anio = "";
                string _idSede = "";

                foreach (var item in vpagado.cursosregistrados)
                {
                    _idSede = item.IdSede;
                    _mes = item.mes;
                    _anio = item.anio;
                }

                if (_mes.Length == 1)
                {
                    vpagado.periodo = _anio.Substring(2, 2) + "0" + _mes;
                }
                else
                {
                    vpagado.periodo = _anio.Substring(2, 2) + _mes;
                }
                vpagado.IdSede = _idSede;
                vpagado.email = correo;
                vpagado.celular = celular;

                conceptos = new List<EN_Conceptos>();
                conceptos = JsonConvert.DeserializeObject<List<EN_Conceptos>>(Sesion.GetString("listaconceptoscargados"));
                vpagado.conceptos = conceptos;
                int _total = 0;
                foreach (var item in conceptos)
                {
                    _total = int.Parse(item.Monto) + _total;
                }
                vpagado.monto = _total;

                EN_Alumno _alumno = new EN_Alumno();
                _alumno.IdAlumno = Sesion.GetString("idPersona");
                _alumno.Direccion = direccion;
                _alumno.Referencia = "no";
                _alumno.TipoActualizacion = validattipo("radio1");

                vpagado.alumno = _alumno;

                string? localIP;

                localIP = HttpContext.Connection.RemoteIpAddress?.MapToIPv4()?.ToString();

                vpagado.terminalRegistro = localIP;

                string result = "si";
                //Validación final
                if (vpagado.conceptos.Count() > 0)
                {
                    if (vpagado.vouchersregistrados != null)
                    {
                        if (vpagado.vouchersregistrados.Count() > 0)
                        {
                            objNE_PVoucher = new LVoucher();
                            string _resultado = objNE_PVoucher.RegistrarPagoNinios(vpagado, sedeRecojo);
                            result = _resultado;
                        }
                        else
                        {
                            result = "no";
                        }
                    }
                    else
                    {
                        result = "no";
                    }
                }
                else
                {
                    result = "no";
                }
                Sesion.SetString("listconceptos", "");
                Sesion.SetString("listaconceptoscargados", "");
                return Json(result);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public JsonResult contactoEmergencia(string contactoEmergencia,string celularEmergencia)
        {
            objNE_PVoucher = new LVoucher();
            string resultado = "";
            try
            {
                string idPersona= Sesion.GetString("idPersona");
                resultado = objNE_PVoucher.RegistrarEmergencia(idPersona, contactoEmergencia, celularEmergencia);
                return Json(resultado);

            }
            catch (Exception)
            {

                throw;
            }
        }


        public JsonResult RegistrarPago(string correo, string celular, string sedeRecojo)
        {
            try
            {
                vpagado = new EN_Voucher_Pagado();

                vpagado.IdPersona = Sesion.GetString("idPersona");
                vpagado.cursosregistrados = JsonConvert.DeserializeObject<List<EN_Curso>>(Sesion.GetString("listacursoscargados"));
                vpagado.vouchersregistrados = JsonConvert.DeserializeObject<List<EN_Voucher_Pago>>(Sesion.GetString("listavoucherscargados"));

                string mes = "";
                string anio = "";
                string idSede = "";

                foreach (var item in vpagado.cursosregistrados)
                {
                    idSede = item.IdSede;
                    mes = item.mes;
                    anio = item.anio;
                }

                if (mes.Length == 1)
                {
                    vpagado.periodo = anio.Substring(2, 2) + "0" + mes;
                }
                else
                {
                    vpagado.periodo = anio.Substring(2, 2) + mes;
                }
                vpagado.IdSede = idSede;
                vpagado.email = correo;
                vpagado.celular = celular;
                

                string localIP="";

                //IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());// objeto para guardar la ip
                //foreach (IPAddress ip in host.AddressList)
                //{
                //    if (ip.AddressFamily.ToString() == "InterNetwork")
                //    {
                //        localIP = ip.ToString();// esta es nuestra ip
                //    }
                //}

                localIP=HttpContext.Connection.RemoteIpAddress?.MapToIPv4()?.ToString();



                vpagado.terminalRegistro = localIP;

                conceptos = new List<EN_Conceptos>();
                conceptos = JsonConvert.DeserializeObject<List<EN_Conceptos>>(Sesion.GetString("listaconceptoscargados"));
                vpagado.conceptos = conceptos;
                int total = 0;
                foreach (var item in conceptos)
                {
                    total = int.Parse(item.Monto) + total;
                }
                vpagado.monto = total;

                string result = "si";
                //Validación final
                if (vpagado.conceptos.Count() > 0)
                {
                    if (vpagado.vouchersregistrados != null)
                    {
                        if (vpagado.vouchersregistrados.Count() > 0)
                        {
                            objNE_PVoucher = new LVoucher();
                            string resultado = objNE_PVoucher.RegistrarPago(vpagado, sedeRecojo);
                            result = resultado;
                        }
                        else
                        {
                            result = "no";
                        }
                    }
                    else
                    {
                        result = "no";
                    }
                }
                else
                {
                    result = "no";
                }
                Sesion.SetString("listconceptos", "");
                Sesion.SetString("listaconceptoscargados", "");
                return Json(result);
            }
            catch (Exception)
            {

                throw;
            }

        }


        public ActionResult VerVoucher(string nrooperacion)
        {
            listavoucherpagocargado = new List<EN_Voucher_Pago>();
            listavoucherpagocargado = JsonConvert.DeserializeObject<List<EN_Voucher_Pago>>(Sesion.GetString("listavoucherscargados"));

            EN_Voucher_Pago vp = new EN_Voucher_Pago();
            foreach (var item in listavoucherpagocargado)
            {
                if (item.nrooperacion == nrooperacion)
                {
                    vp = item;
                }
            }
            ViewBag.dvoucher = vp;
            return View();
        }


        public JsonResult consultatipodealumno()
        {
            string tipoalumno = "";
            tipoalumno = Sesion.GetString("tipoAlumno");

            return Json(tipoalumno);

        }

        public JsonResult consultaVouchersRegistrados()
        {
            listavoucherpago = new List<EN_Voucher_Pago>();
            listavoucherpago = JsonConvert.DeserializeObject<List<EN_Voucher_Pago>>(Sesion.GetString("listavoucherscargados"));

            if (listavoucherpago == null)
            {
                return Json(0);
            }
            else
            {
                return Json(listavoucherpago.Count());
            }
        }

    }
}
