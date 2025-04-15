using CEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DBanco
    {
        Banco banco;
        coneccion con = new coneccion();
        SqlCommand cmm;

        public Banco RetornarDeuda(string idUsuario)
        {
            cmm = new SqlCommand("NetCore.sp_ConsultaPago", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@codalumno", SqlDbType.VarChar, 15).Value = idUsuario;
            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            banco = new Banco();

            if (dr.Read())
            {
                banco.codalumno = dr["codalumno"].ToString();
                banco.dni = dr["dni"].ToString();
                banco.fullname = dr["fullname"].ToString();
                banco.codcurso_actual = dr["codcurso_actual"].ToString();
                banco.codcurso_siguiente = dr["codcurso_siguiente"].ToString();
                banco.nota_final = dr["nota_final"].ToString();
                banco.costo_matricula = validar_montos(dr["matricula"].ToString());
                banco.costo_pension = validar_montos(dr["pension"].ToString());
                banco.costo_deuda = validar_montos(dr["deuda"].ToString());
                banco.costo_mora = validar_montos(dr["mora"].ToString());
                banco.periodostring = dr["periodostring"].ToString();
                banco.estado = dr["estado"].ToString();
                banco.fechainscripcion = DateTime.Parse(dr["fechainscripcion"].ToString());

            }
            con.con.Close();

            if (banco.codcurso_siguiente == "B01")
            {
                banco.estado = "AAN";
            }

            if (banco.codcurso_actual == "A12")
            {
                banco = RetornarValidacionMet(idUsuario);
            }

            banco = validaralumno(banco, idUsuario);
            banco = validaralumnomet(banco, idUsuario);

            banco = validarexamenubicacion(banco, idUsuario);

            banco = validarpromocionciclob01(banco, idUsuario);

            banco = _validarMora(banco, idUsuario);

            if (banco.estado == "NNN")
            {
                banco.total_pagar = int.Parse(banco.costo_matricula) + int.Parse(banco.costo_pension) + int.Parse(banco.costo_deuda) + int.Parse(banco.costo_mora);
                banco.estado_ninios = ValidarYSP(idUsuario, banco.codcurso_siguiente);
            }
            else
            {
                banco.total_pagar = int.Parse(banco.costo_matricula) + int.Parse(banco.costo_pension) + int.Parse(banco.costo_deuda) + int.Parse(banco.costo_mora);
            }

            return banco;
        }


        public Banco RetornarDeudaAcademico(string idUsuario)
        {
            cmm = new SqlCommand("NetCore.sp_ConsultaPagoAcademico", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@codalumno", SqlDbType.VarChar, 15).Value = idUsuario;
            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            banco = new Banco();

            if (dr.Read())
            {
                banco.codalumno = dr["codalumno"].ToString();
                banco.dni = dr["dni"].ToString();
                banco.fullname = dr["fullname"].ToString();
                banco.codcurso_actual = dr["codcurso_actual"].ToString();
                banco.codcurso_siguiente = dr["codcurso_siguiente"].ToString();
                banco.nota_final = dr["nota_final"].ToString();
                banco.costo_matricula = validar_montos(dr["matricula"].ToString());
                banco.costo_pension = validar_montos(dr["pension"].ToString());
                banco.costo_deuda = validar_montos(dr["deuda"].ToString());
                banco.costo_mora = validar_montos(dr["mora"].ToString());
                banco.periodostring = dr["periodostring"].ToString();
                banco.estado = dr["estado"].ToString();
                banco.fechainscripcion = DateTime.Parse(dr["fechainscripcion"].ToString());

            }
            con.con.Close();

            if (banco.codcurso_siguiente == "B01")
            {
                banco.estado = "AAN";
            }

            if (banco.codcurso_actual == "A12")
            {
                banco = RetornarValidacionMet(idUsuario);
            }

            banco = validaralumno(banco, idUsuario);
            banco = validaralumnomet(banco, idUsuario);

            banco = validarexamenubicacion(banco, idUsuario);

            banco = validarpromocionciclob01(banco, idUsuario);

            //banco = _validarMora(banco, idUsuario);

            if (banco.estado == "NNN")
            {
                banco.total_pagar = int.Parse(banco.costo_matricula) + int.Parse(banco.costo_pension) + int.Parse(banco.costo_deuda) + int.Parse(banco.costo_mora);
                banco.estado_ninios = ValidarYSP(idUsuario, banco.codcurso_siguiente);
            }
            else
            {
                banco.total_pagar = int.Parse(banco.costo_matricula) + int.Parse(banco.costo_pension) + int.Parse(banco.costo_deuda) + int.Parse(banco.costo_mora);
            }

            return banco;
        }



        private Banco _validarMora(Banco banco, string idUsuario)
        {
            bool procedimiento = _validarVerificarDeudaProc(idUsuario);
            bool deuda = _validarVerificarDeudaMonto(idUsuario);
            if (procedimiento && deuda)
            {
                banco.costo_mora = "10";
            }
            else
            {
                banco.costo_mora = "0";
            }
            return banco;

        }

        private bool _validarVerificarDeudaMonto(string idUsuario)
        {
            string deuda = "";
            bool res = false;
            cmm = new SqlCommand("Caja.usp_Deudas_Get", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@IdAlumno", SqlDbType.BigInt).Value = idUsuario;
            cmm.Parameters.Add("@Tipo", SqlDbType.VarChar, 1).Value = idUsuario;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();


            if (dr.Read())
            {
                deuda = dr["Deuda"].ToString();
            }

            con.con.Close();

            //if (res)
            //{
            //    banco.costo_mora = "10";
            //}
            //else
            //{
            //    banco.costo_mora = "0";
            //}

            if (deuda != "")
            {
                res = true;
            }

            return res;
        }

        private bool _validarVerificarDeudaProc(string idUsuario)
        {
            bool res = false;
            cmm = new SqlCommand("Caja.usp_VerificarDeuda_Get", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@IdAlumno", SqlDbType.VarChar, 20).Value = idUsuario;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();


            if (dr.Read())
            {
                res = bool.Parse(dr[0].ToString());
            }

            con.con.Close();

            //if (res)
            //{
            //    banco.costo_mora = "10";
            //}
            //else
            //{
            //    banco.costo_mora = "0";
            //}

            return res;
        }



        public Banco RetornarValidacionMet(string idUsuario)
        {
            cmm = new SqlCommand("NetCore.sp_ConsultaPago_MET", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@codalumno", SqlDbType.VarChar, 15).Value = idUsuario;
            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            banco = new Banco();

            if (dr.Read())
            {
                banco.codalumno = dr["codalumno"].ToString();
                banco.dni = dr["dni"].ToString();
                banco.fullname = dr["fullname"].ToString();
                banco.codcurso_actual = dr["codcurso_actual"].ToString();
                banco.codcurso_siguiente = dr["codcurso_siguiente"].ToString();
                banco.nota_final = dr["nota_final"].ToString();
                banco.costo_matricula = validarMatricula(validar_montos(dr["matricula"].ToString()));
                banco.costo_pension = validar_montos(dr["pension"].ToString());
                banco.costo_deuda = validar_montos(dr["deuda"].ToString());
                banco.costo_mora = validar_montos(dr["mora"].ToString());
                banco.periodostring = dr["periodostring"].ToString();
                banco.estado = dr["estado"].ToString();
                banco.fechainscripcion = DateTime.Parse(dr["fechainscripcion"].ToString());

            }
            con.con.Close();

            return banco;
        }

        private string validarMatricula(string v)
        {
            if (v=="50")
            {
                return "60";
            }
            else
            {
                return v;
            }

               
        }

        private Banco validarpromocionciclob01(Banco bnk, string idUsuario)
        {
            string curso_promovido = "";
            curso_promovido = ConsultaAutorizacionB01(idUsuario);

            if (curso_promovido != "")
            {
                if (curso_promovido != bnk.codcurso_siguiente)
                {
                    bnk.codcurso_siguiente = curso_promovido;
                    bnk.estado = obtenertipo(curso_promovido);
                    bnk.nota_final = "BASICO 1";
                    bnk.costo_matricula = obtenermatricula(curso_promovido, bnk.costo_matricula);
                    return bnk;
                }
                else
                {
                    if (curso_promovido == "MET1")
                    {
                        bnk.estado = "AMD";
                    }
                    return bnk;
                }
            }
            else
            {
                return bnk;
            }


        }

        private string ConsultaAutorizacionB01(string idUsuario)
        {
            try
            {
                string cursopromovido = "";
                cmm = new SqlCommand("NetCore.sp_obtenerpromocionedad", con.con);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "opromocione";
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 15).Value = idUsuario;

                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmm.ExecuteReader();

                if (dr.Read())
                {
                    cursopromovido = dr["CodCurso"].ToString();

                }
                con.con.Close();
                return cursopromovido;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Banco validaralumno(Banco bank, string idUsuario)
        {

            Banco banco = new Banco();
            if (bank.codalumno != null)
            {
                return bank;
            }
            else
            {
                EN_Alumno alumn = new EN_Alumno();
                alumn = ObtenerDatos(idUsuario);

                if (alumn.edad <= 3)
                {
                    banco.codalumno = alumn.IdAlumno;
                    banco.dni = alumn.DNI;
                    banco.fullname = alumn.fullname;
                    banco.codcurso_actual = "KS01S";
                    banco.codcurso_siguiente = "KS01S";
                    banco.nota_final = "100";
                    banco.costo_matricula = validar_montos("0");
                    banco.costo_pension = validar_montos("220");
                    banco.costo_deuda = validar_montos("0");
                    banco.costo_mora = validar_montos("0");
                    banco.periodostring = "Abril";
                    banco.estado = "NNN";
                }
                else if (alumn.edad == 4)
                {
                    banco.codalumno = alumn.IdAlumno;
                    banco.dni = alumn.DNI;
                    banco.fullname = alumn.fullname;
                    banco.codcurso_actual = "PKN01S";
                    banco.codcurso_siguiente = "PKN01S";
                    banco.nota_final = "100";
                    banco.costo_matricula = validar_montos("0");
                    banco.costo_pension = validar_montos("190");
                    banco.costo_deuda = validar_montos("0");
                    banco.costo_mora = validar_montos("0");
                    banco.periodostring = "Abril";
                    banco.estado = "NNN";
                }
                else if (alumn.edad == 5)
                {
                    banco.codalumno = alumn.IdAlumno;
                    banco.dni = alumn.DNI;
                    banco.fullname = alumn.fullname;
                    banco.codcurso_actual = "KN0AS";
                    banco.codcurso_siguiente = "KN0AS";
                    banco.nota_final = "100";
                    banco.costo_matricula = validar_montos("0");
                    banco.costo_pension = validar_montos("190");
                    banco.costo_deuda = validar_montos("0");
                    banco.costo_mora = validar_montos("0");
                    banco.periodostring = "Abril";
                    banco.estado = "NNN";
                }
                else if (alumn.edad > 5 && alumn.edad < 9)
                {
                    banco.codalumno = alumn.IdAlumno;
                    banco.dni = alumn.DNI;
                    banco.fullname = alumn.fullname;
                    banco.codcurso_actual = "K01S";
                    banco.codcurso_siguiente = "K01S";
                    banco.nota_final = "100";
                    banco.costo_matricula = validar_montos("0");
                    banco.costo_pension = validar_montos("180");
                    banco.costo_deuda = validar_montos("0");
                    banco.costo_mora = validar_montos("0");
                    banco.periodostring = "Abril";
                    banco.estado = "NNN";
                }
                else if (alumn.edad > 8 && alumn.edad < 13)
                {
                    banco.codalumno = alumn.IdAlumno;
                    banco.dni = alumn.DNI;
                    banco.fullname = alumn.fullname;
                    banco.codcurso_actual = "JR01S";
                    banco.codcurso_siguiente = "JR01S";
                    banco.nota_final = "100";
                    banco.costo_matricula = validar_montos("0");
                    banco.costo_pension = validar_montos("180");
                    banco.costo_deuda = validar_montos("0");
                    banco.costo_mora = validar_montos("0");
                    banco.periodostring = "Abril";
                    banco.estado = "NNN";
                }
                else
                {
                    banco.codalumno = alumn.IdAlumno;
                    banco.dni = alumn.DNI;
                    banco.fullname = alumn.fullname;
                    banco.codcurso_actual = "B01";
                    banco.codcurso_siguiente = "B01";
                    banco.nota_final = "100";
                    banco.costo_matricula = validar_montos("60");
                    banco.costo_pension = validar_montos("180");
                    banco.costo_deuda = validar_montos("0");
                    banco.costo_mora = validar_montos("0");
                    banco.periodostring = "Abril";
                    banco.estado = "AAN";
                }

                return banco;
            }
        }

        public Banco validaralumnomet(Banco bank, string idUsuario)
        {
            Banco banco = new Banco();
            if (bank.codcurso_actual == "MET6")
            {

                bank.codcurso_siguiente = "MET6";
                bank.costo_pension = "0";

                return bank;
            }
            else
            {

                return bank;

            }
        }

        public Banco validarexamenubicacion(Banco bnk, string idusuario)
        {
            string curso_promovido = "";
            curso_promovido = ConsultaExamen(idusuario);

            if (curso_promovido != "")
            {
                if (curso_promovido != bnk.codcurso_siguiente)
                {
                    bnk.codcurso_siguiente = curso_promovido;
                    bnk.estado = obtenertipo(curso_promovido);
                    bnk.nota_final = "EXAMEN DE UBICACION";
                    bnk.costo_matricula = obtenermatricula(curso_promovido, bnk.costo_matricula);
                    return bnk;
                }
                else
                {
                    return bnk;
                }
            }
            else
            {
                return bnk;
            }


        }

        public string obtenermatricula(string curso, string matricula)
        {
            switch (curso)
            {
                case "KS01S":
                case "KS02S":
                case "KS03S":
                case "KS04S":
                case "KS05S":
                case "KS06S":
                case "PKN01S":
                case "PKN02S":
                case "PKN03S":
                case "PKN04S":
                case "PKN05S":
                case "PKN06S":
                case "KN01S":
                case "KN02S":
                case "KN03S":
                case "KN04S":
                case "KN05S":
                case "KN06S":
                case "KN0AS":
                case "KN0BS":
                case "KN0CS":
                case "KN0DS":
                case "K01-2D":
                case "K03-4D":
                case "K01S":
                case "K02S":
                case "K03S":
                case "K04S":
                case "K05S":
                case "K06S":
                case "C01S":
                case "C02S":
                case "C03S":
                case "C04S":
                case "C05S":
                case "C06S":
                case "Y01S":
                case "Y02S":
                case "Y03S":
                case "Y04S":
                case "Y05S":
                case "Y06S":
                case "JR01-02D":
                case "JR03-04D":
                case "JR01S":
                case "JR02S":
                case "JR03S":
                case "JR04S":
                case "JR05S":
                case "JR06S":
                case "JR07S":
                case "JR08S":
                case "PT01S":
                case "PT02S":
                case "PT03S":
                case "PT04S":
                case "PT05S":
                case "PT06S":
                case "PT07S":
                case "PT08S":
                case "T01S":
                case "T02S":
                case "T03S":
                case "T04S":
                case "T05S":
                case "T06S":
                case "T07S":
                case "T08S":
                    return "0";
                default:
                    return matricula;
            }
        }

        public string obtenertipo(string curso)
        {
            switch (curso)
            {
                case "KS01S":
                case "KS02S":
                case "KS03S":
                case "KS04S":
                case "KS05S":
                case "KS06S":
                case "PKN01S":
                case "PKN02S":
                case "PKN03S":
                case "PKN04S":
                case "PKN05S":
                case "PKN06S":
                case "KN01S":
                case "KN02S":
                case "KN03S":
                case "KN04S":
                case "KN05S":
                case "KN06S":
                case "KN0AS":
                case "KN0BS":
                case "KN0CS":
                case "KN0DS":
                case "K01-2D":
                case "K03-4D":
                case "K01S":
                case "K02S":
                case "K03S":
                case "K04S":
                case "K05S":
                case "K06S":
                case "C01S":
                case "C02S":
                case "C03S":
                case "C04S":
                case "C05S":
                case "C06S":
                case "Y01S":
                case "Y02S":
                case "Y03S":
                case "Y04S":
                case "Y05S":
                case "Y06S":
                case "JR01-02D":
                case "JR03-04D":
                case "JR01S":
                case "JR02S":
                case "JR03S":
                case "JR04S":
                case "JR05S":
                case "JR06S":
                case "JR07S":
                case "JR08S":
                case "PT01S":
                case "PT02S":
                case "PT03S":
                case "PT04S":
                case "PT05S":
                case "PT06S":
                case "PT07S":
                case "PT08S":
                case "T01S":
                case "T02S":
                case "T03S":
                case "T04S":
                case "T05S":
                case "T06S":
                case "T07S":
                case "T08S":
                    return "NNN";
                default:
                    return "ANN";
            }
        }



        public string ConsultaExamen(string idUsuario)
        {

            string cursopromovido = "";
            cmm = new SqlCommand("NetCore.sp_validar_examen_ubicacion", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "obtenerexa";
            cmm.Parameters.Add("@idAlumno", SqlDbType.VarChar, 15).Value = idUsuario;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            if (dr.Read())
            {
                cursopromovido = dr["CursoPromovido"].ToString();

            }
            con.con.Close();
            return cursopromovido;
        }


        public EN_Alumno ObtenerDatos(string idUsuario)
        {
            cmm = new SqlCommand("NetCore.sp_obtener_alumno", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@idAlumno", SqlDbType.VarChar, 15).Value = idUsuario;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            EN_Alumno alumno = new EN_Alumno();

            if (dr.Read())
            {
                alumno.IdAlumno = dr["IdPersona"].ToString();
                alumno.DNI = dr["DNI"].ToString();
                alumno.fullname = dr["fullname"].ToString();
                alumno.fNacimiento = DateTime.Parse(dr["fNacimiento"].ToString());
                alumno.edad = CalculateAge(alumno.fNacimiento);
            }
            con.con.Close();
            return alumno;
        }


        public int CalculateAge(DateTime data)
        {
            DateTime dateNow = DateTime.Now;

            //obtengo la fecha en años, meses y dias
            int year = dateNow.Year - data.Year;
            int month = dateNow.Month - data.Month;
            int day = dateNow.Day - data.Day;

            //hago la comparación
            if (month < 0)
            {
                //devuelvo la edad en años teniendo en cuenta la diferencia de meses
                return year - 1;
            }

            else if (month == 0)
            {
                //devuelvo la edad en años teniendo en cuenta la diferencia de días
                return day <= 0 ? year : year - 1;
            }

            else
            {
                return year;
            }
        }

        public string ValidarYSP(string idUsuario, string codSiguiente)
        {
            cmm = new SqlCommand("NetCore.sp_validar_ysp", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@codalumno", SqlDbType.VarChar, 15).Value = idUsuario;
            cmm.Parameters.Add("@ciclo_sgt", SqlDbType.VarChar, 10).Value = codSiguiente;
            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            string estado_ninios = "";

            if (dr.Read())
            {
                estado_ninios = dr["estado"].ToString();
            }
            con.con.Close();
            return estado_ninios;
        }


        public string ValidarCursoYSP(string estado_ninio, string cod_curso)
        {
            switch (estado_ninio)
            {
                case "0":
                    return cod_curso;
                case "1":
                    return "KS01S";
                case "2":
                    return "PKN01S";
                case "3":
                    return "KN01S";
                case "4":
                    return "K01S";
                case "5":
                    return "JR01S";
                default:
                    return "JR01S";
            }
        }

        /*public Banco RetornarDeudaAntiguo(string idUsuario)
        {
            cmm = new SqlCommand("NetCore.sp_AlumnoAntiguo", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@codalumno", SqlDbType.VarChar, 15).Value = idUsuario;
            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            banco = new Banco();

            if (dr.Read())
            {

                banco.codalumno = dr["codalumno"].ToString();
                banco.fullname = dr["fullname"].ToString();
                banco.dni = dr["dni"].ToString();
                banco.codcurso_actual = dr["codcurso_actual"].ToString();

                banco.nota_final = dr["nota_final"].ToString();

                banco.periodostring= dr["periodostring"].ToString();
                banco.periodo= dr["periodo"].ToString();

                banco.costo_matricula = dr["matricula"].ToString();
                banco.costo_matricula = validar_montos(banco.costo_matricula);
                banco.costo_deuda = dr["deuda"].ToString();
                banco.costo_deuda = validar_montos(banco.costo_deuda);
                banco.costo_mora = dr["mora"].ToString();
                banco.costo_mora = validar_montos(banco.costo_mora);
                banco.total_pagar = int.Parse(banco.costo_matricula) +  int.Parse(banco.costo_deuda) + int.Parse(banco.costo_mora);



                banco.exa_ubicacion = examen_ubicacion(banco.nota_final);

            }

            con.con.Close();
            return banco;
        }

        public string examen_ubicacion(string nota)
        {
            if (nota=="")
            {
                return "No";
            }
            else
            {
                return "Si";
            }
        }*/

        public string validar_montos(string valor)
        {
            if (valor == null)
            {
                return "0";
            }
            else
            {
                return valor;
            }

        }
    }
}
