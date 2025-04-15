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
    public class DVoucher
    {
        DBanco _banco = new DBanco();
        DProgramacion _programacion = new DProgramacion();

        List<EN_Conceptos> concep;
        List<EN_Conceptos> _conceptos;
        List<EN_Voucher> listavoucher;
        List<EN_Voucher_Pago> listavoucherpagos;
        List<EN_Curso> cursosmatriculados;

        EN_Voucher voucher;
        coneccion con = new coneccion();
        SqlCommand cmm;

        public EN_Voucher RetornarDatos(string idUsuario)
        {
            cmm = new SqlCommand("NetCore.sp_obtener_actualizar_alumno", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "obtenerdatos";
            cmm.Parameters.Add("@idPersona", SqlDbType.VarChar, 15).Value = idUsuario;
            cmm.Parameters.Add("@correo", SqlDbType.VarChar, 50).Value = DBNull.Value;
            cmm.Parameters.Add("@celular", SqlDbType.VarChar, 30).Value = DBNull.Value;
            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            voucher = new EN_Voucher();

            if (dr.Read())
            {
                voucher.Email = dr["Email"].ToString();
                voucher.Celular = dr["Telefono"].ToString();
                if (voucher.Celular == null)
                {
                    voucher.Celular = "0";
                }
                if (voucher.Email == null)
                {
                    voucher.Email = "0";
                }
            }
            con.con.Close();
            return voucher;
        }

        public string ValidarVoucher(string NroOperacion)
        {
            cmm = new SqlCommand("NetCore.sp_otrasoperaciones", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "voperacion";
            cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 15).Value = DBNull.Value;
            cmm.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = NroOperacion;
            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            string numero = "";

            if (dr.Read())
            {
                numero = dr["NroOperacion"].ToString();
            }
            con.con.Close();
            return numero;
        }

        public string RegistrarVoucher(EN_Voucher voucher)
        {
            try
            {
                cmm = new SqlCommand("NetCore.sp_registrarvoucher", con.con);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "regvoucher";
                cmm.Parameters.Add("@Periodo", SqlDbType.VarChar, 4).Value = voucher.Periodo;
                cmm.Parameters.Add("@IdSede", SqlDbType.TinyInt).Value = voucher.IdSede;
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 15).Value = voucher.IdPersona;
                cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 11).Value = voucher.IdCiclo;
                cmm.Parameters.Add("@NombreBanco", SqlDbType.VarChar, 30).Value = voucher.NomBanco;
                cmm.Parameters.Add("@IdConcepto", SqlDbType.SmallInt).Value = voucher.IdConcepto;
                cmm.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 20).Value = voucher.NroOperacion;
                cmm.Parameters.Add("@FechaTransaccion", SqlDbType.Date).Value = voucher.FechaTransaccion;
                cmm.Parameters.Add("@Monto", SqlDbType.Int).Value = voucher.Monto;
                cmm.Parameters.Add("@urlVoucher", SqlDbType.NVarChar, 500).Value = voucher.Urlvoucher;
                cmm.Parameters.Add("@correo", SqlDbType.VarChar, 50).Value = voucher.Email;
                cmm.Parameters.Add("@celular", SqlDbType.VarChar, 30).Value = voucher.Celular;
                cmm.Parameters.Add("@cursoexaubicacion", SqlDbType.NVarChar, 15).Value = DBNull.Value;
                cmm.Parameters.Add("@terminalRegistro", SqlDbType.VarChar, 50).Value = "";


                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmm.ExecuteReader();

                string numero = "";

                if (dr.Read())
                {
                    numero = dr["resultado"].ToString();
                }
                con.con.Close();
                return numero;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string RegistrarPago(EN_Voucher_Pagado voucher)
        {
            string numero = "";
            string exaubicacion = "";
            try
            {
                cmm = new SqlCommand("NetCore.sp_registrarvoucher", con.con);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "regvoucher";
                cmm.Parameters.Add("@Periodo", SqlDbType.VarChar, 4).Value = voucher.periodo;
                cmm.Parameters.Add("@IdSede", SqlDbType.TinyInt).Value = voucher.IdSede;
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 15).Value = voucher.IdPersona;
                cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 11).Value = DBNull.Value;
                cmm.Parameters.Add("@NombreBanco", SqlDbType.VarChar, 30).Value = DBNull.Value;
                cmm.Parameters.Add("@IdConcepto", SqlDbType.SmallInt).Value = DBNull.Value;
                cmm.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 20).Value = DBNull.Value;
                cmm.Parameters.Add("@FechaTransaccion", SqlDbType.Date).Value = DBNull.Value;
                cmm.Parameters.Add("@Monto", SqlDbType.Int).Value = voucher.monto;
                cmm.Parameters.Add("@urlVoucher", SqlDbType.NVarChar, 500).Value = DBNull.Value;
                cmm.Parameters.Add("@correo", SqlDbType.VarChar, 50).Value = voucher.email;
                cmm.Parameters.Add("@celular", SqlDbType.VarChar, 30).Value = voucher.celular;
                cmm.Parameters.Add("@terminalRegistro", SqlDbType.VarChar, 50).Value = voucher.terminalRegistro;

                //Valida exámen de ubicación
                exaubicacion = _banco.ConsultaExamen(voucher.IdPersona);
                if (exaubicacion != "")
                {
                    cmm.Parameters.Add("@cursoexaubicacion", SqlDbType.NVarChar, 15).Value = exaubicacion;
                }
                else
                {
                    cmm.Parameters.Add("@cursoexaubicacion", SqlDbType.NVarChar, 15).Value = DBNull.Value;
                }

                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmm.ExecuteReader();
                if (dr.Read())
                {
                    numero = dr["resultado"].ToString();
                }
                con.con.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return numero;
        }


        public string RegistrarVoucherPV(EN_Voucher voucher)
        {
            cmm = new SqlCommand("NetCore.sp_registrarvoucher", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "regvoucherpv";
            cmm.Parameters.Add("@Periodo", SqlDbType.VarChar, 4).Value = voucher.Periodo;
            cmm.Parameters.Add("@IdSede", SqlDbType.TinyInt).Value = voucher.IdSede;
            cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 15).Value = voucher.IdPersona;
            cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 11).Value = DBNull.Value;
            cmm.Parameters.Add("@NombreBanco", SqlDbType.VarChar, 30).Value = voucher.NomBanco;
            cmm.Parameters.Add("@IdConcepto", SqlDbType.SmallInt).Value = voucher.IdConcepto;
            cmm.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 20).Value = voucher.NroOperacion;
            cmm.Parameters.Add("@FechaTransaccion", SqlDbType.Date).Value = voucher.FechaTransaccion;
            cmm.Parameters.Add("@Monto", SqlDbType.Int).Value = voucher.Monto;
            cmm.Parameters.Add("@urlVoucher", SqlDbType.NVarChar, 500).Value = voucher.Urlvoucher;
            cmm.Parameters.Add("@correo", SqlDbType.VarChar, 50).Value = DBNull.Value;
            cmm.Parameters.Add("@celular", SqlDbType.VarChar, 30).Value = DBNull.Value;
            cmm.Parameters.Add("@cursoexaubicacion", SqlDbType.NVarChar, 15).Value = DBNull.Value;
            cmm.Parameters.Add("@terminalRegistro", SqlDbType.VarChar, 50).Value = "";

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            string numero = "";

            if (dr.Read())
            {
                numero = dr["resultado"].ToString();
            }
            con.con.Close();
            return numero;
        }

        public string RegistrarPagoPV(EN_Voucher_Pagado voucher)
        {
            try
            {
                cmm = new SqlCommand("NetCore.sp_registrarvoucher", con.con);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "regvoucherpv";
                cmm.Parameters.Add("@Periodo", SqlDbType.VarChar, 4).Value = voucher.periodo;
                cmm.Parameters.Add("@IdSede", SqlDbType.TinyInt).Value = voucher.IdSede;
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 15).Value = voucher.IdPersona;
                cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 11).Value = DBNull.Value;
                cmm.Parameters.Add("@NombreBanco", SqlDbType.VarChar, 30).Value = DBNull.Value;
                cmm.Parameters.Add("@IdConcepto", SqlDbType.SmallInt).Value = DBNull.Value;
                cmm.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 20).Value = DBNull.Value;
                cmm.Parameters.Add("@FechaTransaccion", SqlDbType.Date).Value = DBNull.Value;
                cmm.Parameters.Add("@Monto", SqlDbType.Int).Value = voucher.monto;
                cmm.Parameters.Add("@urlVoucher", SqlDbType.NVarChar, 500).Value = DBNull.Value;
                cmm.Parameters.Add("@correo", SqlDbType.VarChar, 50).Value = voucher.email;
                cmm.Parameters.Add("@celular", SqlDbType.VarChar, 30).Value = voucher.celular;
                cmm.Parameters.Add("@cursoexaubicacion", SqlDbType.NVarChar, 15).Value = DBNull.Value;
                cmm.Parameters.Add("@terminalRegistro", SqlDbType.VarChar, 50).Value = "";

                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmm.ExecuteReader();

                string numero = "";

                if (dr.Read())
                {
                    numero = dr["resultado"].ToString();
                }
                con.con.Close();
                return numero;
            }
            catch (Exception)
            {

                throw;
            }

        }



        public string RegistrarVoucherMPDetalle(EN_Conceptos concepto, int IdTransaccion, string sedeRecojo)
        {
            string numero = "";
            if (concepto.IdCiclo == null)
            {
                //try catch (crear procedimiento registrar excepcion(registrar todo el elemento como string)).
                //concepto, transaccion, usuario, sesion.
                //Guardae excepcion el sql
                //

                try
                {
                    cmm = new SqlCommand("NetCore.sp_registrarvoucher_detalle", con.con);
                    cmm.CommandType = CommandType.StoredProcedure;
                    cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "regvoucher";
                    cmm.Parameters.Add("@IdTransaccion", SqlDbType.Int).Value = IdTransaccion;
                    cmm.Parameters.Add("@IdConcepto", SqlDbType.Int).Value = concepto.IdConcepto;
                    cmm.Parameters.Add("@IdProducto", SqlDbType.Int).Value = concepto.IdProducto;
                    cmm.Parameters.Add("@DesConcepto", SqlDbType.VarChar, 100).Value = concepto.DesConcepto;
                    cmm.Parameters.Add("@MontoDetalle", SqlDbType.Int).Value = int.Parse(concepto.Monto);
                    cmm.Parameters.Add("@dciclo", SqlDbType.VarChar, 15).Value = DBNull.Value;
                    if (sedeRecojo is null)
                    {
                        cmm.Parameters.Add("@sedeRecojo", SqlDbType.VarChar, 4).Value = DBNull.Value;
                    }
                    else
                    {
                        cmm.Parameters.Add("@sedeRecojo", SqlDbType.VarChar, 4).Value = sedeRecojo;
                    }


                    SqlDataReader dr;
                    if (ConnectionState.Closed == con.con.State)
                    {
                        con.con.Open();
                    }
                    dr = cmm.ExecuteReader();

                    if (dr.Read())
                    {
                        numero = dr["resultado"].ToString();
                    }
                    con.con.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                try
                {
                    cmm = new SqlCommand("NetCore.sp_registrarvoucher_detalle2", con.con);
                    cmm.CommandType = CommandType.StoredProcedure;
                    cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "regvoucher";
                    cmm.Parameters.Add("@IdTransaccion", SqlDbType.Int).Value = IdTransaccion;
                    cmm.Parameters.Add("@IdConcepto", SqlDbType.Int).Value = concepto.IdConcepto;
                    cmm.Parameters.Add("@IdProducto", SqlDbType.Int).Value = concepto.IdProducto;
                    cmm.Parameters.Add("@DesConcepto", SqlDbType.VarChar, 100).Value = concepto.DesConcepto;
                    cmm.Parameters.Add("@MontoDetalle", SqlDbType.Int).Value = int.Parse(concepto.Monto);
                    cmm.Parameters.Add("@dciclo", SqlDbType.VarChar, 15).Value = concepto.IdCiclo;
                    if (sedeRecojo is null)
                    {
                        cmm.Parameters.Add("@sedeRecojo", SqlDbType.VarChar, 4).Value = DBNull.Value;
                    }
                    else
                    {
                        cmm.Parameters.Add("@sedeRecojo", SqlDbType.VarChar, 4).Value = sedeRecojo;
                    }

                    SqlDataReader dr;
                    if (ConnectionState.Closed == con.con.State)
                    {
                        con.con.Open();
                    }
                    dr = cmm.ExecuteReader();
                    if (dr.Read())
                    {
                        numero = dr["resultado"].ToString();
                    }
                    con.con.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return numero;
        }

        public string RegistrarVoucherMPDetalleCiclo(EN_Conceptos curso, int IdTransaccion)
        {

            if (curso.IdCiclo == null)
            {
                return "0";
            }
            else
            {
                try
                {
                    cmm = new SqlCommand("NetCore.sp_registrarvoucher_detalle_ciclo", con.con);
                    cmm.CommandType = CommandType.StoredProcedure;
                    cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "regciclo";
                    cmm.Parameters.Add("@IdTransaccion", SqlDbType.Int).Value = IdTransaccion;
                    cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 11).Value = curso.IdCiclo;

                    SqlDataReader dr;
                    if (ConnectionState.Closed == con.con.State)
                    {
                        con.con.Open();
                    }
                    dr = cmm.ExecuteReader();

                    string numero = "";

                    if (dr.Read())
                    {
                        numero = dr["resultado"].ToString();
                    }
                    con.con.Close();
                    return numero;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public string RegistrarVoucherMPDetalleVoucher(EN_Voucher_Pago voucher, int IdTransaccion)
        {
            string numero = "";
            try
            {
                cmm = new SqlCommand("NetCore.sp_registrarvoucher_detalle_voucher", con.con);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "regvoucher";
                cmm.Parameters.Add("@IdTransaccion", SqlDbType.Int).Value = IdTransaccion;
                cmm.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 30).Value = voucher.nrooperacion;
                cmm.Parameters.Add("@Banco", SqlDbType.VarChar, 30).Value = voucher.banco;
                cmm.Parameters.Add("@FechaVoucher", SqlDbType.Date).Value = voucher.fecha;
                cmm.Parameters.Add("@urlVoucher", SqlDbType.NVarChar, 500).Value = voucher.url;

                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmm.ExecuteReader();
                if (dr.Read())
                {
                    numero = dr["resultado"].ToString();
                }
                con.con.Close();

            }
            catch (Exception)
            {
                throw;
            }
            return numero;
        }

        public string RegistrarDireccion(EN_Alumno alumno)
        {
            try
            {
                cmm = new SqlCommand("NetCore.sp_registrar_direccion", con.con);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "regdir";
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 15).Value = alumno.IdAlumno;
                cmm.Parameters.Add("@Tipo", SqlDbType.Bit).Value = alumno.TipoActualizacion;
                cmm.Parameters.Add("@Direccion", SqlDbType.VarChar, 500).Value = alumno.Direccion;
                cmm.Parameters.Add("@Referencia", SqlDbType.VarChar, 500).Value = alumno.Referencia;
                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmm.ExecuteReader();

                string numero = "";

                if (dr.Read())
                {
                    numero = dr["resultado"].ToString();
                }
                con.con.Close();
                return numero;
            }
            catch (Exception)
            {

                throw;
            }


        }


        public EN_Voucher ObtenerVoucher(string NroOperacion)
        {
            cmm = new SqlCommand("NetCore.sp_otrasoperaciones", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "reporte";
            cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 11).Value = DBNull.Value;
            cmm.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 20).Value = NroOperacion;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            EN_Voucher voucher = new EN_Voucher();

            if (dr.Read())
            {
                voucher.IdTransaccion = dr["IdTransaccion"].ToString();
                voucher.IdPersona = dr["IdPersona"].ToString();
                voucher.DNI = dr["DNI"].ToString();
                voucher.Fullname = dr["fullname"].ToString();
                voucher.Email = dr["Email"].ToString();
                voucher.Celular = dr["Telefono"].ToString();
                voucher.Descurso = dr["DesCurso"].ToString();
                voucher.Horario = dr["horario"].ToString();
                voucher.NomBanco = dr["NombreBanco"].ToString();
                voucher.NroOperacion = dr["NroOperacion"].ToString();
                voucher.Desconcepto = dr["DesConcepto"].ToString();
                voucher.Desconcepto = ValidarConceptop(voucher.Desconcepto);
                voucher.Monto = int.Parse(dr["Monto"].ToString());
                voucher.RegistradoC34 = bool.Parse(dr["RegistradoC34"].ToString());
                voucher.FechaRegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
            }
            con.con.Close();
            return voucher;
        }


        public EN_Voucher_Pagado ObtenerVoucherPagado(string NroOperacion)
        {
            cmm = new SqlCommand("NetCore.sp_otrasoperaciones", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "reporteg";
            cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 11).Value = DBNull.Value;
            cmm.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 20).Value = NroOperacion;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            EN_Voucher_Pagado voucher = new EN_Voucher_Pagado();

            if (dr.Read())
            {
                voucher.IdTransaccion = dr["IdTransaccion"].ToString();
                voucher.IdPersona = dr["IdPersona"].ToString();
                voucher.DNI = dr["DNI"].ToString();
                voucher.Fullname = dr["fullname"].ToString();
                voucher.email = dr["Email"].ToString();
                voucher.celular = dr["Telefono"].ToString();
                voucher.monto = int.Parse(dr["Monto"].ToString());

            }
            con.con.Close();
            return voucher;
        }


        public List<EN_Curso> ObtenerCursos(int IdTransaccion)
        {

            cursosmatriculados = new List<EN_Curso>();

            cmm = new SqlCommand("NetCore.sp_registrarvoucher_detalle_ciclo2", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "obtciclo";
            cmm.Parameters.Add("@IdTransaccion", SqlDbType.Int).Value = IdTransaccion;
            cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 11).Value = DBNull.Value;


            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            while (dr.Read())
            {
                EN_Curso curso = new EN_Curso();

                curso.IdSede = dr["IdSede"].ToString();
                curso.IdCiclo = dr["IdCiclo"].ToString();
                curso.DesCurso = dr["DesCurso"].ToString();
                curso.CodNivel = dr["codnivel"].ToString();
                curso.Horario = dr["horario"].ToString();
                curso.Docente = dr["docente"].ToString();
                curso.ModalidadEsp = dr["modalidad_esp"].ToString();
                curso.mes = dr["Mes"].ToString();
                curso.anio = dr["anio"].ToString();
                curso.aula = dr["aula"].ToString();
                cursosmatriculados.Add(curso);
            }
            con.con.Close();
            return cursosmatriculados;
        }


        public List<EN_Voucher_Pago> ObtenerVouchers(int IdTransaccion)
        {

            listavoucherpagos = new List<EN_Voucher_Pago>();

            cmm = new SqlCommand("NetCore.sp_registrarvoucher_detalle_voucher", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "obtvoucher";
            cmm.Parameters.Add("@IdTransaccion", SqlDbType.Int).Value = IdTransaccion;
            cmm.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 30).Value = DBNull.Value;
            cmm.Parameters.Add("@Banco", SqlDbType.VarChar, 30).Value = DBNull.Value;
            cmm.Parameters.Add("@FechaVoucher", SqlDbType.Date).Value = DBNull.Value;
            cmm.Parameters.Add("@urlVoucher", SqlDbType.NVarChar, 500).Value = DBNull.Value;


            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            while (dr.Read())
            {
                EN_Voucher_Pago vpago = new EN_Voucher_Pago();

                vpago.nrooperacion = dr["NroOperacion"].ToString();
                vpago.banco = dr["Banco"].ToString();
                vpago.fecha = DateTime.Parse(dr["FechaVoucher"].ToString());
                vpago.url = dr["urlVoucher"].ToString();
                listavoucherpagos.Add(vpago);
            }
            con.con.Close();
            return listavoucherpagos;
        }

        public List<EN_Conceptos> ObtenerVoucherDetalle(string NroOperacion)
        {
            _conceptos = new List<EN_Conceptos>();
            cmm = new SqlCommand("NetCore.sp_obtenervoucher_detalle", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "obtenerv";
            cmm.Parameters.Add("@IdTransaccion", SqlDbType.Int).Value = int.Parse(NroOperacion);

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            EN_Voucher voucher = new EN_Voucher();

            while (dr.Read())
            {
                EN_Conceptos concept = new EN_Conceptos();
                concept.IdConcepto = int.Parse(dr["IdConcepto"].ToString());
                concept.IdProducto = int.Parse(dr["IdProducto"].ToString());
                concept.DesConcepto = dr["DesConcepto"].ToString();
                concept.Monto = dr["MontoDetalle"].ToString();
                _conceptos.Add(concept);
            }
            con.con.Close();
            return _conceptos;
        }


        public EN_Voucher ObtenerVoucherPV(string NroOperacion)
        {
            cmm = new SqlCommand("NetCore.sp_otrasoperaciones", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "reportepv";
            cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 11).Value = DBNull.Value;
            cmm.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 20).Value = NroOperacion;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            EN_Voucher voucher = new EN_Voucher();

            if (dr.Read())
            {
                voucher.IdTransaccion = dr["IdTransaccion"].ToString();
                voucher.IdPersona = dr["IdPersona"].ToString();
                voucher.DNI = dr["DNI"].ToString();
                voucher.Fullname = dr["fullname"].ToString();
                voucher.Email = dr["Email"].ToString();
                voucher.Celular = dr["Telefono"].ToString();
                voucher.NomBanco = dr["NombreBanco"].ToString();
                voucher.NroOperacion = dr["NroOperacion"].ToString();
                voucher.Desconcepto = dr["DesConcepto"].ToString();
                voucher.Desconcepto = ValidarConceptop(voucher.Desconcepto);
                voucher.Monto = int.Parse(dr["Monto"].ToString());
                voucher.RegistradoC34 = bool.Parse(dr["RegistradoC34"].ToString());
                voucher.FechaRegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
            }
            con.con.Close();
            return voucher;
        }


        public string RegistrarContactoEmergencia(string IdPersona,string contactoEmergencia, string celularEmergencia)
        {
            string resultado = "";
            cmm = new SqlCommand("Contacto.Registrar_Contacto_Emergencia", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 10).Value = "1";
            cmm.Parameters.Add("@Idpersona", SqlDbType.VarChar, 20).Value = IdPersona;
            cmm.Parameters.Add("@ContactoDescripcion", SqlDbType.VarChar, 200).Value = contactoEmergencia;
            cmm.Parameters.Add("@TelefonoContacto", SqlDbType.VarChar, 20).Value = celularEmergencia;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

          
            if (dr.Read())
            {
                resultado = dr[0].ToString();
            }
            con.con.Close();
            return resultado;
        }


        public List<EN_Conceptos> ObtenerConcepto()
        {
            concep = new List<EN_Conceptos>();

            cmm = new SqlCommand("NetCore.sp_otrasoperaciones", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "conceptos";
            cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 11).Value = DBNull.Value;
            cmm.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 20).Value = DBNull.Value;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                EN_Conceptos concepto = new EN_Conceptos();
                concepto.IdConcepto = int.Parse(dr["IdConcepto"].ToString());
                concepto.DesConcepto = dr["DesConcepto"].ToString();
                concep.Add(concepto);
            }
            con.con.Close();
            return concep;
        }

        public List<EN_Conceptos> ObtenerConceptoPM()
        {
            concep = new List<EN_Conceptos>();

            cmm = new SqlCommand("NetCore.sp_conceptos_pagos", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "oconceptopm";
            cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 11).Value = DBNull.Value;
            cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 15).Value = DBNull.Value;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                EN_Conceptos concepto = new EN_Conceptos();
                concepto.IdConcepto = int.Parse(dr["IdConcepto"].ToString());
                concepto.DesConcepto = ValidarConceptop(dr["DesConcepto"].ToString());
                concepto.Monto = agregarmontos(concepto.IdConcepto).ToString();
                concep.Add(concepto);
            }
            con.con.Close();
            return concep;
        }

        public List<EN_Conceptos> ObtenerConceptoPV()
        {
            concep = new List<EN_Conceptos>();

            cmm = new SqlCommand("NetCore.sp_conceptos_pagos", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "oconceptopv";
            cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 11).Value = DBNull.Value;
            cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 15).Value = DBNull.Value;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                EN_Conceptos concepto = new EN_Conceptos();
                concepto.IdConcepto = int.Parse(dr["IdConcepto"].ToString());
                concepto.IdProducto = 0;
                concepto.DesConcepto = dr["DesConcepto"].ToString();
                concepto.Monto = agregarmontos(concepto.IdConcepto).ToString();
                concep.Add(concepto);
            }
            con.con.Close();
            return concep;
        }

        public EN_Libro ObtenerLibro(string CodCurso)
        {

            concep = new List<EN_Conceptos>();

            cmm = new SqlCommand("NetCore.sp_conceptos_pagos", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "clibrocod";
            cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 11).Value = CodCurso;
            cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 15).Value = DBNull.Value;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();
            EN_Libro libro = new EN_Libro();

            if (dr.Read())
            {
                libro.IdProducto = int.Parse(dr["IdProducto"].ToString());
                libro.DesProducto = "LIBRO: " + dr["DesProducto"].ToString();
                libro.Curso = dr["Curso"].ToString();
            }

            con.con.Close();
            return libro;
        }

        public EN_CEmergencia ObtenerContactoEmergencia(string idPersona)
        {

            EN_CEmergencia emergencia= new EN_CEmergencia();

            cmm = new SqlCommand("NetCore.sp_contacto_emergencia", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "oemergencia";
            cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 11).Value = idPersona;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();
            

            if (dr.Read())
            {
                emergencia.idContactoEmergencia = dr["ContactoDescripcion"].ToString();
                emergencia.numeroEmergencia = dr["TelefonoContacto"].ToString();
               
            }

            con.con.Close();
            return emergencia;
        }


        public List<EN_Voucher> ListaVouchers(string IdPersona)
        {
            listavoucher = new List<EN_Voucher>();



            cmm = new SqlCommand("NetCore.sp_listar_voucher", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "lvpagado";
            cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 15).Value = IdPersona;



            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                EN_Voucher voucher = new EN_Voucher();
                voucher.IdTransaccion = dr["IdTransaccion"].ToString();
                //voucher.IdCiclo= dr["IdCiclo"].ToString();
                //voucher.Tipo = RetornarTipoConcepto(voucher.IdCiclo);
                //voucher.NroOperacion = dr["NroOperacion"].ToString();
                voucher.Monto = int.Parse(dr["Monto"].ToString());
                voucher.FechaRegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
                voucher.FechaTexto = voucher.FechaRegistro.ToString("MM/dd/yyyy");
                voucher.RegistradoC34 = bool.Parse(dr["RegistradoC34"].ToString());
                voucher.Motivo = dr["MotivoAnulado"].ToString();
                voucher.Eliminado = bool.Parse(dr["Eliminado"].ToString());
                voucher.Periodo = dr["Periodo"].ToString();
                voucher.Hora = voucher.FechaRegistro.ToString("HH:mm:ss");
                voucher.PeriodoString = _programacion.obtenerdescripcion(voucher.Periodo);
                listavoucher.Add(voucher);
            }
            con.con.Close();
            return listavoucher;
        }

        public string ValidarConceptop(string desconcepto)
        {
            if (desconcepto == "COSTO PENSIÓN")
            {
                desconcepto = "PENSIÓN REGULAR";
            }
            if (desconcepto == "BECA")
            {
                desconcepto = "PENSIÓN BECADO";
            }
            return desconcepto;

        }

        public int RetornarTipoConcepto(string desconcepto)
        {

            if (desconcepto == "")
            {
                return 0;
            }

            return 1;

        }

        public int agregarmontos(int IdConcepto)
        {
            switch (IdConcepto)
            {
                case 18:
                    return 40;
                case 28:
                    return 60;
                case 39:
                    return 130;
                case 91:
                    return 50;
                default:
                    return 0;

            }
        }

        public string RegistrarVoucherPrematricula(string idCiclo, string idPersona)
        {
            string numero = "";
            try
            {
                cmm = new SqlCommand("NetCore.usp_PreMatricula_Insert", con.con);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@opcion", SqlDbType.TinyInt).Value = 0;
                cmm.Parameters.Add("@IdAlumno", SqlDbType.VarChar, 20).Value = idPersona;
                cmm.Parameters.Add("@IdCiclo", SqlDbType.Char, 11).Value = idCiclo;

                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmm.ExecuteReader();
                if (dr.Read())
                {
                    numero = dr["resultado"].ToString();
                }
                con.con.Close();

            }
            catch (Exception)
            {
                throw;
            }
            return numero;
        }


        public string RegistrarVoucherInscripcion(string idCiclo, string idPersona)
        {
            string numero = "";
            try
            {
                cmm = new SqlCommand("Matricula.usp_PreInscripcion_Insert", con.con);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdAlumno", SqlDbType.VarChar,20).Value = idPersona;
                cmm.Parameters.Add("@IdCiclo", SqlDbType.Char, 11).Value = idCiclo;
                cmm.Parameters.Add("@TerminalRegistro", SqlDbType.VarChar, 50).Value = "SERVIDOR-WEB";
                cmm.Parameters.Add("@UserRegistro", SqlDbType.VarChar, 20).Value = idPersona;

                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmm.ExecuteReader();
                if (dr.Read())
                {
                    numero = dr["resultado"].ToString();
                }
                con.con.Close();

            }
            catch (Exception)
            {
                throw;
            }
            return numero;
        }
    }
}
