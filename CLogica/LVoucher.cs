using CEntidades;
using CEstaticos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CLogica
{
    public class LVoucher
    {
        EN_Voucher voucher;
        EN_Voucher_Pagado vpagado;
        DVoucher objVoucher = new DVoucher();
        DAlumno objAlumno;
        EN_Alumno alumno;
        EN_Alumno alIngreso;

        List<EN_Conceptos> conceptos;
        List<EN_Conceptos> conceptopensiones;
        List<EN_Conceptos> conceptosexportar;
        List<EN_Programacion> lprogramacion;
        List<EN_Conceptos> _conceptos;

        List<EN_Curso> _pensiones;
        List<EN_Voucher_Pagado> lpagados;

        public EN_Voucher RetornarAlumno(string idPersona)
        {
            voucher = new EN_Voucher();
            voucher = objVoucher.RetornarDatos(idPersona);
            return voucher;
        }

        public string ValidarVoucher(string NroOperacion)
        {
            string operacion = "";
            operacion = objVoucher.ValidarVoucher(NroOperacion);
            return operacion;
        }

        public string RegistrarVoucher(EN_Voucher voucher)
        {
            _conceptos = new List<EN_Conceptos>();
            string operacion = "";
            int op;
            string aux = "";
            string auxdir = "";
            operacion = objVoucher.RegistrarVoucher(voucher);
            op = int.Parse(operacion);
            _conceptos = voucher.conceptos;
            auxdir = objVoucher.RegistrarDireccion(voucher.alumno);
            foreach (var item in _conceptos)
            {
                aux = objVoucher.RegistrarVoucherMPDetalle(item, op, "");
            }
            return operacion;
        }


        public string RegistrarPago(EN_Voucher_Pagado voucher, string sedeRecojo)
        {
            string operacion = "";
            try
            {
                using (var scope = new TransactionScope())
                {

                    string aux = "";
                    string auxopcional = "";
                    int op;

                   

                    operacion = objVoucher.RegistrarPago(voucher);
                    op = int.Parse(operacion);
                    foreach (var item in voucher.vouchersregistrados)
                    {
                        aux = objVoucher.RegistrarVoucherMPDetalleVoucher(item, op);
                    }
                    foreach (var item2 in voucher.conceptos)
                    {
                        if (item2.IdCiclo != null)
                        {
                            aux = objVoucher.RegistrarVoucherMPDetalle(item2, op, sedeRecojo);

                            auxopcional = objVoucher.RegistrarVoucherPrematricula(item2.IdCiclo, voucher.IdPersona);

                            auxopcional = objVoucher.RegistrarVoucherInscripcion(item2.IdCiclo, voucher.IdPersona);
                            
                        }
                        else
                        {
                            aux = objVoucher.RegistrarVoucherMPDetalle(item2, op, "");
                        }

                    }
                    scope.Complete();
                    return operacion;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public string RegistrarEmergencia(string IdPersona,string contactoEmergencia, string celularEmergencia)
        {
            string operacion = "";
            operacion = objVoucher.RegistrarContactoEmergencia(IdPersona,contactoEmergencia,celularEmergencia);

            return operacion;

        }

        public string RegistrarPagoNinios(EN_Voucher_Pagado voucher, string sedeRecojo)
        {
            string operacion = "";
            try
            {
                using (var scope = new TransactionScope())
                {

                    string aux = "";
                    int op;
                    operacion = objVoucher.RegistrarPago(voucher);
                    op = int.Parse(operacion);
                    foreach (var item in voucher.vouchersregistrados)
                    {
                        aux = objVoucher.RegistrarVoucherMPDetalleVoucher(item, op);
                    }
                    foreach (var item2 in voucher.conceptos)
                    {
                        aux = objVoucher.RegistrarVoucherMPDetalle(item2, op, sedeRecojo);
                    }
                    aux = objVoucher.RegistrarDireccion(voucher.alumno);
                    scope.Complete();
                    return operacion;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        

        //public string Registrar_Voucher(EN_Voucher_Pago pago,int transaccion)
        //{
        //    string operacion = "";
        //    try
        //    {
        //        operacion = objVoucher.RegistrarVoucherMPDetalleVoucher(pago,transaccion);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return operacion;

        //}

        //public string Registrar_Concepto(EN_Conceptos concepto,int transaccion)
        //{
        //    string operacion = "";
        //    try
        //    {
        //        operacion= objVoucher.RegistrarVoucherMPDetalle(concepto, transaccion);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return operacion;
        //}

        public string RegistrarVoucherPV(EN_Voucher voucher)
        {
            string operacion = "";
            int op;
            string aux = "";
            operacion = objVoucher.RegistrarVoucherPV(voucher);
            op = int.Parse(operacion);
            _conceptos = voucher.conceptos;
            foreach (var item in _conceptos)
            {
                aux = objVoucher.RegistrarVoucherMPDetalle(item, op, "");
            }

            return operacion;
        }

        public string RegistrarPagoPV(EN_Voucher_Pagado voucher)
        {
            string operacion = "";
            int op = 0;
            string aux = "";

            try
            {
                using (var scope = new TransactionScope())
                {
                    operacion = objVoucher.RegistrarPagoPV(voucher);
                    op = int.Parse(operacion);

                    foreach (var item in voucher.conceptos)
                    {
                        aux = objVoucher.RegistrarVoucherMPDetalle(item, op, "");
                    }

                    foreach (var item in voucher.vouchersregistrados)
                    {
                        aux = objVoucher.RegistrarVoucherMPDetalleVoucher(item, op);
                    }
                    scope.Complete();
                    return operacion;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public EN_Voucher ObtenerVoucher(string NroTransaccion)
        {
            voucher = new EN_Voucher();
            voucher = objVoucher.ObtenerVoucher(NroTransaccion);
            voucher.conceptos = objVoucher.ObtenerVoucherDetalle(NroTransaccion);
            return voucher;
        }

        public EN_Voucher_Pagado ObtenerVoucherPagado(string NroTransaccion)
        {
            int transaccion = int.Parse(NroTransaccion);
            vpagado = new EN_Voucher_Pagado();
            vpagado = objVoucher.ObtenerVoucherPagado(NroTransaccion);
            vpagado.cursosregistrados = objVoucher.ObtenerCursos(transaccion);
            vpagado.vouchersregistrados = objVoucher.ObtenerVouchers(transaccion);
            vpagado.conceptos = objVoucher.ObtenerVoucherDetalle(NroTransaccion);

            return vpagado;
        }

        public EN_Voucher_Pagado ObtenerVoucherPV(string NroTransaccion)
        {
            int transaccion = int.Parse(NroTransaccion);
            vpagado = new EN_Voucher_Pagado();
            vpagado = objVoucher.ObtenerVoucherPagado(NroTransaccion);
            vpagado.vouchersregistrados = objVoucher.ObtenerVouchers(transaccion);
            vpagado.conceptos = objVoucher.ObtenerVoucherDetalle(NroTransaccion);
            return vpagado;
        }

        public List<EN_Conceptos> ObtenerConcepto(string IdPersona)
        {
            LProgramacion objprogramacion = new LProgramacion();
            objAlumno = new DAlumno();
            //asignacion valores certificados
            alIngreso = new EN_Alumno();
            alumno = new EN_Alumno();
            alIngreso.IdAlumno = IdPersona;
            alumno = objAlumno.ObtenerUltimoCiclo(alIngreso);
            string costocertificado;
            costocertificado = retornarcostos(alumno);

            conceptos = new List<EN_Conceptos>();
            conceptos = objVoucher.ObtenerConceptoPV();

            //Objeto banco
            DBanco objBanco = new DBanco();

            //deuda, mora, pension, matricula
            Banco deuda = new Banco();
            deuda = objBanco.RetornarDeuda(IdPersona);

            string Deuda = deuda.costo_deuda;
            string Mora = deuda.costo_mora;

            //asignacion de valores a variables
            foreach (var item in conceptos)
            {
                if (item.IdConcepto == 6)
                {
                    item.Monto = Deuda;
                    item.Activo = true;
                }
                if (item.IdConcepto == 29)
                {
                    item.Monto = Mora;
                    item.Activo = true;
                }
                if (item.IdConcepto == 9)
                {
                    item.Monto = costocertificado;
                    item.Activo = true;
                }
                if (item.IdConcepto == 10)
                {
                    item.Monto = costocertificado;
                    item.Activo = true;
                }
                if (item.IdConcepto == 11)
                {
                    item.Monto = costocertificado;
                    item.Activo = true;
                }
                if (item.IdConcepto == 12)
                {
                    item.Monto = "40";
                    item.Activo = true;
                }
                if (item.IdConcepto == 13)
                {
                    item.Monto = "245";
                    item.Activo = true;
                }
                if (item.IdConcepto == 18)
                {
                    item.DesConcepto = "EXAMEN DE UBICACIÓN NORMAL";
                    item.Monto = "40";
                    item.Activo = true;
                }
                if (item.IdConcepto == 4)
                {
                    item.Monto = "40";
                    item.Activo = true;
                }
                if (item.IdConcepto == 111)
                {
                    item.Monto = "40";
                    item.Activo = true;
                }
                if (item.IdConcepto == 48)
                {
                    item.Monto = "60";
                    item.Activo = true;
                }
                if (item.IdConcepto == 33)
                {
                    item.Monto = "110";
                    item.Activo = true;
                }

                if (item.IdConcepto == 91)
                {
                    item.Activo = true;
                }
                if (item.IdConcepto == 211)
                {
                    item.Monto = "240";
                    item.Activo = true;
                }
            }



            //EN_Conceptos con = new EN_Conceptos();
            //con.IdConcepto = 17;
            //con.DesConcepto = "EXAMEN DE UBICACIÓN EXTEMPORÁNEO";
            //con.Activo = true;
            //con.Monto = "40";
            conceptos.Add(_agregarConceptosVarios(17, "EXAMEN DE UBICACIÓN EXTEMPORÁNEO", "40"));
            conceptos.Add(_agregarConceptosVarios(165, "EXAMEN TOEFL ITP REMOTO", "160"));
            conceptos.Add(_agregarConceptosVarios(704, "POSTERGACION ADULTOS REGULAR/FDS", "110"));
            conceptos.Add(_agregarConceptosVarios(705, "POSTERGACION NIÑOS SABATINO", "60"));
            conceptos.Add(_agregarConceptosVarios(706, "POSTERGACION ADULTOS E. ESCRITO / E. FINAL", "50"));
            conceptos.Add(_agregarConceptosVarios(707, "POSTERGACION ADULTOS E. ESCRITO MEDIO CICLO", "30"));
            conceptos.Add(_agregarConceptosVarios(708, "POSTERGACION ADULTOS E. ORAL", "30"));
            conceptos.Add(_agregarConceptosVarios(709, "POSTERGACION ADULTOS PROYECTO", "30"));
            conceptos.Add(_agregarConceptosVarios(710, "POSTERGACION NIÑOS E. ESCRITO", "35"));
            conceptos.Add(_agregarConceptosVarios(711, "POSTERGACION NIÑOS E. ORAL", "20"));
            conceptos.Add(_agregarConceptosVarios(712, "CONSTANCIA CON NOTAS", "50"));
            conceptos.Add(_agregarConceptosVarios(713, "CARNET DE LECTOR", "25"));


            //EN_Conceptos con2 = new EN_Conceptos();
            //con2.IdConcepto = 165;
            //con2.DesConcepto = "EXAMEN TOEFL ITP REMOTO";
            //con2.Activo = true;
            //con2.Monto = "150";


            return conceptos;
        }

        private EN_Conceptos _agregarConceptosVarios(int idConcepto, string desConcepto, string monto)
        {
            EN_Conceptos concepto = new EN_Conceptos();
            concepto.IdConcepto = idConcepto;
            concepto.DesConcepto = desConcepto;
            concepto.Activo = true;
            concepto.Monto = monto;
            return concepto;
        }

        public EN_Conceptos ConceptoLibro(string CodCurso)
        {

            //Obtenciòn del libro
            EN_Libro libro = new EN_Libro();
            if (CodCurso == "A10")
            {
                CodCurso = "A10 - A12";
            }
            libro = objVoucher.ObtenerLibro(CodCurso);

            //Generaciòn de nuevo concepto a partir del libro
            EN_Conceptos concepto = new EN_Conceptos();
            concepto = asignarmontolibro(libro);
            return concepto;
        }

        public List<EN_Conceptos> ObtenerConceptoPM(List<EN_Curso> lcursos, string IdPersona)
        {
            LProgramacion objprogramacion = new LProgramacion();

            objAlumno = new DAlumno();

            DBanco objBanco = new DBanco();

            //deuda, mora, pension, matricula
            Banco deuda = new Banco();
            deuda = objBanco.RetornarDeuda(IdPersona);

            _pensiones = new List<EN_Curso>();

            //Obtener curso y ciclo
            //string Pensionbeca=calculopensionbeca(lcursos[0].CodNivel).ToString();
            string Deuda = deuda.costo_deuda;
            string Mora = deuda.costo_mora;
            string Matricula = deuda.costo_matricula;

            if (Matricula == "50")
            {
                Matricula = "60";
            }

            //asignacion valores certificados
            alIngreso = new EN_Alumno();
            alumno = new EN_Alumno();
            alIngreso.IdAlumno = IdPersona;
            alumno = objAlumno.ObtenerUltimoCiclo(alIngreso);
            string costocertificado;
            costocertificado = retornarcostos(alumno);

            //conceptos pensiones agregados
            conceptopensiones = new List<EN_Conceptos>();
            conceptopensiones = obtenerconceptosciclos(lcursos);

            //agregar pensiones becados
            conceptos = new List<EN_Conceptos>();
            //foreach (var item in lcursos)
            //{
            //    EN_Curso cur = new EN_Curso();
            //    cur.PensionRegular = calculopension(item.CodNivel, deuda.codcurso_siguiente).ToString();
            //    _pensiones.Add(cur);
            //}

            //agregar pensiones regulares
            //foreach (var item in _pensiones)
            //{
            //    EN_Conceptos concepto = new EN_Conceptos();
            //    concepto.IdConcepto = 37;
            //    concepto.IdProducto = 0;
            //    concepto.DesConcepto = "COSTO PENSIÓN";
            //    concepto.Monto = item.PensionRegular;
            //    conceptos.Add(concepto);
            //}

            //agregar conceptos
            conceptosexportar = new List<EN_Conceptos>();
            conceptosexportar = objVoucher.ObtenerConceptoPM();

            foreach (var item in conceptosexportar)
            {
                conceptos.Add(item);
            }

            foreach (var item in conceptopensiones)
            {
                conceptos.Add(item);
            }

            //asignacion de valores a variables
            foreach (var item in conceptos)
            {

                if (item.IdConcepto == 6)
                {
                    item.Monto = Deuda;
                    item.Activo = false;
                }
                if (item.IdConcepto == 28)
                {
                    item.Monto = Matricula;
                    item.Activo = true;
                }
                if (item.IdConcepto == 29)
                {
                    item.Monto = Mora;
                    item.Activo = false;
                }
                if (item.IdConcepto == 9)
                {
                    item.Monto = costocertificado;
                    item.Activo = true;
                }
                if (item.IdConcepto == 10)
                {
                    item.Monto = costocertificado;
                    item.Activo = true;
                }
                if (item.IdConcepto == 11)
                {
                    item.Monto = costocertificado;
                    item.Activo = true;
                }
                if (item.IdConcepto == 18)
                {
                    item.DesConcepto = "EXAMEN DE UBICACIÓN NORMAL";
                    item.Activo = true;
                }
                if (item.IdConcepto == 28)
                {
                    item.Activo = true;
                }
                if (item.IdConcepto == 39)
                {
                    item.Activo = true;
                }
                if (item.IdConcepto == 91)
                {
                    item.Monto = "50";
                    item.Activo = true;
                }
                if (item.IdConcepto == 37)
                {
                    item.cursoActual = deuda.codcurso_siguiente;
                }
            }
            EN_Conceptos con = new EN_Conceptos();
            con.IdConcepto = 17;
            con.DesConcepto = "EXAMEN DE UBICACIÓN EXTEMPORÁNEO";
            con.Activo = true;
            con.Monto = "40";
            conceptos.Add(con);

            EN_Conceptos con2 = new EN_Conceptos();
            con2.IdConcepto = 731;
            con2.DesConcepto = "DESCUENTO POR CONVENIO";
            con2.Activo = true;
            con2.Monto = "-25";
            conceptos.Add(con2);

            EN_Conceptos con3 = new EN_Conceptos();
            con3.IdConcepto = 732;
            con3.DesConcepto = "CARNE DE LECTOR";
            con3.Activo = true;
            con3.Monto = "25";
            conceptos.Add(con3);

            return conceptos;
        }

        public List<EN_Conceptos> obtenerconceptosciclos(List<EN_Curso> lcursos)
        {

            conceptosexportar = new List<EN_Conceptos>();
            foreach (var item in lcursos)
            {
                EN_Conceptos concepto = new EN_Conceptos();
                concepto.IdConcepto = 37;
                concepto.IdProducto = 0;
                concepto.DesConcepto = "COSTO PENSIÓN REGULAR " + item.DesCurso;
                concepto.Monto = validarpension("", item.CodNivel, item.CodCurso).ToString();
                concepto.IdCiclo = item.IdCiclo;
                concepto.Activo = true;
                conceptosexportar.Add(concepto);
            }
            foreach (var item in lcursos)
            {
                EN_Conceptos concepto = new EN_Conceptos();
                concepto.IdConcepto = 225;
                concepto.IdProducto = 0;
                concepto.DesConcepto = "COSTO PENSIÓN ACELERADO " + item.DesCurso;
                concepto.Monto = validarpension("", item.CodNivel, item.CodCurso).ToString();
                concepto.IdCiclo = item.IdCiclo;
                concepto.Activo = true;
                conceptosexportar.Add(concepto);
            }

            foreach (var item in lcursos)
            {
                EN_Conceptos concepto = new EN_Conceptos();
                concepto.IdConcepto = 42;
                concepto.IdProducto = 0;
                concepto.DesConcepto = "COSTO PENSIÓN BECA " + item.DesNivelCurso;
                concepto.Monto = calculopensionbeca(item.CodNivel, item.CodCurso).ToString();
                concepto.IdCiclo = item.IdCiclo;
                concepto.Activo = true;
                conceptosexportar.Add(concepto);
            }

            foreach (var item in lcursos)
            {
                EN_Conceptos concepto = new EN_Conceptos();
                concepto.IdConcepto = 39;
                concepto.IdProducto = 0;
                concepto.DesConcepto = "PAGO A CUENTA " + item.DesCurso;
                concepto.Monto = "130";
                concepto.IdCiclo = item.IdCiclo;
                concepto.Activo = true;
                conceptosexportar.Add(concepto);
            }

            //foreach (var item in lcursos)
            //{
            //    EN_Conceptos concepto = new EN_Conceptos();
            //    concepto.IdConcepto = 39;
            //    concepto.IdProducto = 0;
            //    concepto.DesConcepto = "PAGO A CUENTA " + item.DesNivelCurso;
            //    concepto.Monto = calculopensionbeca(item.CodCurso).ToString();
            //    concepto.IdCiclo = item.IdCiclo;
            //    concepto.Activo = true;
            //    conceptosexportar.Add(concepto);
            //}
            return conceptosexportar;

        }

        public List<EN_Conceptos> ObtenerConceptoCP(string IdPersona, Banco _deuda)
        {
            LProgramacion objprogramacion = new LProgramacion();

            objAlumno = new DAlumno();

            DBanco objBanco = new DBanco();

            //deuda, mora, pension, matricula
            Banco deuda = new Banco();
            deuda = _deuda;

            //Obtener curso y ciclo
            EN_Programacion prog = new EN_Programacion();
            prog = objprogramacion.RetornarCodNivel(deuda.codcurso_siguiente);

            //valores de algunas variables
            string Pensionregular;
            if (deuda.codcurso_siguiente == "B01")
            {
                //Pensionregular = deuda.costo_pension;
                Pensionregular = "180";
            }
            else
            {
                Pensionregular = deuda.costo_pension;
                Pensionregular = validarpension(Pensionregular, prog.codnivel, prog.curso).ToString();
            }
            string Pensionbeca = calculopensionbeca(prog.codnivel, "").ToString();
            string Deuda = deuda.costo_deuda;
            string Mora = deuda.costo_mora;
            string Matricula = "0";

            Matricula = deuda.costo_matricula;
            if (Matricula == "50")
            {
                Matricula = "60";
            }


            //asignacion valores certificados
            alIngreso = new EN_Alumno();
            alumno = new EN_Alumno();
            alIngreso.IdAlumno = IdPersona;
            alumno = objAlumno.ObtenerUltimoCiclo(alIngreso);
            string costocertificado;
            costocertificado = retornarcostos(alumno);


            conceptos = new List<EN_Conceptos>();
            conceptos = objVoucher.ObtenerConceptoPM();

            //Agregar Matrícula
            EN_Conceptos pmatricula = new EN_Conceptos();
            pmatricula.IdConcepto = 37;
            pmatricula.IdProducto = 0;
            pmatricula.DesConcepto = "COSTO PENSIÓN REGULAR ";
            pmatricula.Monto = Pensionregular;
            pmatricula.Activo = true;
            conceptos.Add(pmatricula);

            //Agregar beca
            EN_Conceptos pbeca = new EN_Conceptos();
            pbeca.IdConcepto = 42;
            pbeca.IdProducto = 0;
            pbeca.DesConcepto = "COSTO PENSIÓN BECA ";
            pbeca.Monto = Pensionbeca;
            pbeca.Activo = true;
            conceptos.Add(pbeca);

            //asignacion de valores a variables
            foreach (var item in conceptos)
            {

                if (item.IdConcepto == 6)
                {
                    item.Monto = Deuda;
                    item.Activo = false;
                }
                if (item.IdConcepto == 28)
                {
                    item.Monto = Matricula;
                    item.Activo = true;
                }
                if (item.IdConcepto == 29)
                {
                    item.Monto = Mora;
                    item.Activo = false;
                }
                if (item.IdConcepto == 9)
                {
                    item.Monto = costocertificado;
                    item.Activo = true;
                }
                if (item.IdConcepto == 10)
                {
                    item.Monto = costocertificado;
                    item.Activo = true;
                }
                if (item.IdConcepto == 11)
                {
                    item.Monto = costocertificado;
                    item.Activo = true;
                }
                if (item.IdConcepto == 18)
                {
                    item.DesConcepto = "EXAMEN DE UBICACIÓN NORMAL";
                    item.Activo = true;
                }
                if (item.IdConcepto == 28)
                {
                    item.Activo = true;
                }
                if (item.IdConcepto == 39)
                {
                    item.Activo = true;
                }

            }

            EN_Conceptos con = new EN_Conceptos();
            con.IdConcepto = 17;
            con.DesConcepto = "EXAMEN DE UBICACIÓN EXTEMPORÁNEO";
            con.Activo = true;
            con.Monto = "40";
            conceptos.Add(con);

            return conceptos;
        }

        public List<EN_Conceptos> ValidarMatricula(List<EN_Conceptos> conceptos)
        {

            foreach (var item in conceptos)
            {
                if (item.IdConcepto == 28)
                {
                    item.Monto = "60";

                }

            }
            return conceptos;
        }

        public List<EN_Conceptos> ObtenerConceptoPV()
        {
            return objVoucher.ObtenerConceptoPV();
        }

        public List<EN_Voucher> listaVoucher(string IdPersona)
        {
            return objVoucher.ListaVouchers(IdPersona);
        }

        public int calculopension(string codCurso, string curso)
        {
            if (curso == "B01")
            {
                return 180;
            }
            else
            {
                switch (codCurso)
                {
                    case "KSS":
                        return 165;
                    case "PKES":
                        return 200;
                    case "KES":
                        return 200;
                    case "KS":
                        return 190;
                    case "CS":
                        return 190;
                    case "YS":
                        return 190;
                    case "JRS":
                        return 190;
                    case "PTS":
                        return 190;
                    case "TES":
                        return 190;
                    case "B":
                        return 225;
                    case "I":
                        return 230;
                    case "A":
                        return 240;
                    case "MET":
                        return 290;
                    default:
                        return 0;
                }
            }
        }


        public int calculopensionregular(string codCurso)
        {
            switch (codCurso)
            {
                case "KSS":
                    return 165;
                case "PKES":
                    return 200;
                case "KES":
                    return 200;
                case "KS":
                    return 190;
                case "CS":
                    return 190;
                case "YS":
                    return 190;
                case "JRS":
                    return 190;
                case "PTS":
                    return 190;
                case "TES":
                    return 190;
                case "B01":
                    return 190;
                case "B02":
                case "B03":
                case "B04":
                case "B05":
                case "B06":
                case "B07":
                case "B08":
                case "B09":
                case "B10":
                case "B11":
                case "B12":
                    return 225;
                case "BA02":
                case "BA04":
                case "BA06":
                    return 225;
                case "I01":
                case "I02":
                case "I03":
                case "I04":
                case "I05":
                case "I06":
                case "I07":
                case "I08":
                case "I09":
                case "I10":
                case "I11":
                case "I12":
                    return 230;
                case "A01":
                case "A02":
                case "A03":
                case "A04":
                case "A05":
                case "A06":
                case "A07":
                case "A08":
                case "A09":
                case "A10":
                case "A11":
                case "A12":
                case "A10 - A12":
                    return 240;
                case "MET1":
                case "MET2":
                case "MET3":
                case "MET4":
                case "MET5":
                case "MET6":
                    return 290;
                default:
                    return 0;
            }

        }

        public int calculopensionbeca(string codnivel, string codCurso)
        {
            switch (codnivel)
            {
                case "KSS":
                    switch (codCurso)
                    {
                        case "KS01S":
                            return 210;
                        default:
                            return 145;
                    }
                case "PKES":
                    return 70;
                case "KES":
                    return 70;
                case "KS":
                    return 60;
                case "CS":
                    return 60;
                case "YS":
                    return 60;
                case "JRS":
                    return 60;
                case "PTS":
                    return 60;
                case "TES":
                    return 60;
                case "B":
                    return 80;
                case "B01":
                case "B02":
                case "B03":
                case "B04":
                case "B05":
                case "B06":
                case "B07":
                case "B08":
                case "B09":
                case "B10":
                case "B11":
                case "B12":
                    return 80;
                case "I":
                    return 85;
                case "I01":
                case "I02":
                case "I03":
                case "I04":
                case "I05":
                case "I06":
                case "I07":
                case "I08":
                case "I09":
                case "I10":
                case "I11":
                case "I12":
                    return 85;
                case "A":
                    return 90;
                case "A01":
                case "A02":
                case "A03":
                case "A04":
                case "A05":
                case "A06":
                case "A07":
                case "A08":
                case "A09":
                case "A10":
                case "A11":
                case "A12":
                case "A10 - A12":
                    return 90;
                case "MET1":
                case "MET2":
                case "MET3":
                case "MET4":
                case "MET5":
                case "MET6":
                    return 270;
                case "MET":
                    return 270;
                default:
                    return 0;
            }

        }

        public EN_Conceptos asignarmontolibro(EN_Libro libro)
        {
            EN_Conceptos concepto = new EN_Conceptos();
            concepto.IdConcepto = 31;
            concepto.IdProducto = libro.IdProducto;
            concepto.DesConcepto = libro.DesProducto;
            concepto.Monto = asignarcosto(libro.Curso);
            concepto.Activo = true;
            return concepto;

        }

        public string asignarcosto(string codcurso)
        {
            switch (codcurso)
            {
                case "A10 - A12":
                    return "150";
                case "A11":
                    return "0";
                case "A12":
                    return "0";
                default:
                    return "60";
            }

        }

        public void anadirconceptos(List<EN_Conceptos> con)
        {

            foreach (var item in con)
            {
                if (item.IdConcepto == 37 || item.IdConcepto == 42 || item.IdConcepto == 28)
                {
                    EConceptos.AddValue(item);
                }
            }
            foreach (var item in con)
            {
                if (item.IdConcepto == 37 || item.IdConcepto == 42 || item.IdConcepto == 28)
                {
                }
                else
                {
                    EConceptos.AddValue(item);
                }
            }

        }

        public int validarpension(string pension, string nivel, string codcurso)
        {
            switch (nivel)
            {
                case "O":
                    return 190;
                case "KSS":
                    switch (codcurso)
                    {
                        case "KS01S":
                            return 230;
                        default:
                            return 165;
                    }
                case "PKES":
                    return 200;
                case "KES":
                    return 200;
                case "KS":
                    return 190;
                case "KD":
                    return 240;
                case "CS":
                    return 190;
                case "YS":
                    return 190;
                case "JRS":
                    return 190;
                case "JRD":
                    return 240;
                case "PTS":
                    return 190;
                case "TES":
                    return 190;
                case "B":
                    switch (codcurso)
                    {
                        case "B01":
                            return 190;
                        case "B02":
                        case "B03":
                        case "B04":
                        case "B05":
                        case "B06":
                        case "B07":
                        case "B08":
                        case "B09":
                        case "B10":
                        case "B11":
                        case "B12":
                            return 225;
                        case "BA02":
                        case "BA04":
                        case "BA05":
                            return 440;
                        default:
                            return 0;
                    }

                case "I":
                    //case "I02":
                    //case "I03":
                    //case "I04":
                    //case "I05":
                    //case "I06":
                    //case "I07":
                    //case "I08":
                    //case "I09":
                    //case "I10":
                    //case "I11":
                    //case "I12":
                    return 230;
                case "A":
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
                    //case "A10 - A12":
                    return 240;
                case "MET":
                    //case "MET2":
                    //case "MET3":
                    //case "MET4":
                    //case "MET5":
                    //case "MET6":
                    return 290;
                default:
                    return 0;
            }
        }

        public string retornarcostos(EN_Alumno alumno)
        {

            return "60";

        }


        public EN_Alumno ObtenerDireccion(EN_Alumno alumno)
        {
            return objAlumno.ObtenerDireccion(alumno);
        }

        public EN_CEmergencia ObtenerContactoEmergencia(string idPersona)
        {
            return objVoucher.ObtenerContactoEmergencia(idPersona);

        }

    }
}
