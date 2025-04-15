using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Recaudacion.BE;

namespace Recaudacion.DA
{
    public class daPreMatricula
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        bePreMatricula itmPreMatricula;
        beReturn itmReturn;
        List<bePreMatricula> lisPreMatricula;
        daCiclo objCiclo = new daCiclo();
        public beReturn Registrar(bePreMatricula myitmPreMatricula)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_PreMatricula_Inser", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdAlumno", SqlDbType.VarChar,20).Value = (myitmPreMatricula.IdAlumno == null)?"": myitmPreMatricula.IdAlumno;
                cmm.Parameters.Add("@IdCiclo", SqlDbType.Char, 11).Value = (myitmPreMatricula.IdCiclo == null)?"": myitmPreMatricula.IdCiclo;
                cmm.Parameters.Add("@DeudaMatricula", SqlDbType.Decimal, 18).Value = myitmPreMatricula.DeudaMatricula;
                cmm.Parameters.Add("@DeudaAnterior", SqlDbType.Decimal, 18).Value = myitmPreMatricula.DeudaAnterior;
                cmm.Parameters.Add("@DeudaPreinscripcion", SqlDbType.Decimal, 18).Value = myitmPreMatricula.DeudaPreinscripcion;
                SqlParameter IdPreMatricula = new SqlParameter();
                IdPreMatricula.ParameterName = "@IdPreMatricula";
                IdPreMatricula.SqlDbType = SqlDbType.UniqueIdentifier;
                IdPreMatricula.Size = 20;
                IdPreMatricula.Direction = ParameterDirection.Output;
                cmm.Parameters.Add(IdPreMatricula).Value = myitmPreMatricula.IdPreMatricula;
                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    //ReturnValue = Guid.Parse(cmm.Parameters["@IdPersona"].Value.ToString());
                    itmReturn.strReturn = cmm.Parameters["@IdPreMatricula"].Value.ToString();
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public bool Registro(int Opcion, bePreMatricula myitmPreMatricula)
        {
            bool ReturnValue = false;
            try
            {
                cmm = new SqlCommand("[Matricula].[usp_PreMatricula_Insert]", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@Opcion", SqlDbType.TinyInt).Value = Opcion;
                cmm.Parameters.Add("@IdAlumno", SqlDbType.VarChar, 20).Value = myitmPreMatricula.IdAlumno;
                cmm.Parameters.Add("@IdCiclo", SqlDbType.Char, 11).Value = myitmPreMatricula.IdCiclo;
                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                if (sqlRows > 0)
                {
                    ReturnValue = true;
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ReturnValue;
        }
        public bePreMatricula Detalle(Guid IdPreMatricula)
        {
            itmPreMatricula = new bePreMatricula();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_PreMatricula_SelectById", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdPreMatricula", SqlDbType.UniqueIdentifier).Value = IdPreMatricula;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmPreMatricula.IdPreMatricula = Guid.Parse(Convert.ToString(dr["IdPreMatricula"]));
                    itmPreMatricula.IdAlumno = Convert.ToString(dr["IdAlumno"]);
                    itmPreMatricula.IdCiclo = Convert.ToString(dr["IdCiclo"]);
                    itmPreMatricula.rowguid = Convert.ToString(dr["rowguid"]);
                    itmPreMatricula.DeudaMatricula = Convert.ToDecimal(dr["DeudaMatricula"]);
                    itmPreMatricula.DeudaAnterior = Convert.ToDecimal(dr["DeudaAnterior"]);
                    itmPreMatricula.DeudaPreinscripcion = Convert.ToDecimal(dr["DeudaPreinscripcion"]);
                    itmPreMatricula.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    itmPreMatricula.FechaCaducar = Convert.ToDateTime(dr["FechaCaducar"]);
                    itmPreMatricula.EsCaducado = Convert.ToBoolean(dr["EsCaducado"]);
                    itmPreMatricula.EsMatriculado = Convert.ToString(dr["EsMatriculado"]);
                    itmPreMatricula.bitEleiminar = Convert.ToBoolean(dr["bitEleiminar"]);
                    //itmPreMatricula.itmCiclo = new beCiclo();
                    itmPreMatricula.itmCiclo = objCiclo.detalle(itmPreMatricula.IdCiclo);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmPreMatricula;
        }
        public List<bePreMatricula> ListarPorUsuario(string idPersona)
        {
            lisPreMatricula = new List<bePreMatricula>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_PreMatricula_SelectByAlumno", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 20).Value = idPersona;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmPreMatricula = new bePreMatricula();
                    itmPreMatricula.IdPreMatricula = Guid.Parse(Convert.ToString(dr["IdPreMatricula"]));
                    itmPreMatricula.IdAlumno = Convert.ToString(dr["IdAlumno"]);
                    itmPreMatricula.IdCiclo = Convert.ToString(dr["IdCiclo"]);
                    itmPreMatricula.rowguid = Convert.ToString(dr["rowguid"]);
                    itmPreMatricula.DeudaMatricula = Convert.ToDecimal(dr["DeudaMatricula"]);
                    itmPreMatricula.DeudaAnterior = Convert.ToDecimal(dr["DeudaAnterior"]);
                    itmPreMatricula.DeudaPreinscripcion = Convert.ToDecimal(dr["DeudaPreinscripcion"]);
                    itmPreMatricula.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    itmPreMatricula.FechaCaducar = Convert.ToDateTime(dr["FechaCaducar"]);
                    itmPreMatricula.EsCaducado = Convert.ToBoolean(dr["EsCaducado"]);
                    itmPreMatricula.EsMatriculado = Convert.ToString(dr["EsMatriculado"]);
                    itmPreMatricula.bitEleiminar = Convert.ToBoolean(dr["bitEleiminar"]);
                    //itmPreMatricula.itmCiclo = new beCiclo();
                    itmPreMatricula.itmCiclo = objCiclo.detalle(itmPreMatricula.IdCiclo);
                    lisPreMatricula.Add(itmPreMatricula);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisPreMatricula;
        }
        public List<bePreMatricula> ListarPorFecha(DateTime fecha)
        {
            lisPreMatricula = new List<bePreMatricula>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_PreMatricula_SearchByDate", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@date", SqlDbType.Date).Value = fecha;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmPreMatricula = new bePreMatricula();
                    itmPreMatricula.IdPreMatricula = Guid.Parse(Convert.ToString(dr["IdPreMatricula"]));
                    itmPreMatricula.IdAlumno = Convert.ToString(dr["IdAlumno"]);
                    itmPreMatricula.IdCiclo = Convert.ToString(dr["IdCiclo"]);
                    itmPreMatricula.rowguid = Convert.ToString(dr["rowguid"]);
                    itmPreMatricula.DeudaMatricula = Convert.ToDecimal(dr["DeudaMatricula"]);
                    itmPreMatricula.DeudaAnterior = Convert.ToDecimal(dr["DeudaAnterior"]);
                    itmPreMatricula.DeudaPreinscripcion = Convert.ToDecimal(dr["DeudaPreinscripcion"]);
                    itmPreMatricula.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    itmPreMatricula.FechaCaducar = Convert.ToDateTime(dr["FechaCaducar"]);
                    itmPreMatricula.EsCaducado = Convert.ToBoolean(dr["EsCaducado"]);
                    itmPreMatricula.EsMatriculado = Convert.ToString(dr["EsMatriculado"]);
                    itmPreMatricula.bitEleiminar = Convert.ToBoolean(dr["bitEleiminar"]);
                    //itmPreMatricula.itmCiclo = new beCiclo();
                    itmPreMatricula.itmCiclo = objCiclo.detalle(itmPreMatricula.IdCiclo);
                    lisPreMatricula.Add(itmPreMatricula);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisPreMatricula;
        }
        public List<bePreMatricula> ListarParaTransmision()
        {
            lisPreMatricula = new List<bePreMatricula>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_TransmisionLista_Transmision", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmPreMatricula = new bePreMatricula();
                    itmPreMatricula.IdPreMatricula = Guid.Parse(Convert.ToString(dr["IdPreMatricula"]));
                    itmPreMatricula.IdAlumno = Convert.ToString(dr["IdAlumno"]);
                    itmPreMatricula.itmPersona = new bePersona();
                    itmPreMatricula.itmPersona.DNI = Convert.ToString(dr["DNI"]);
                    itmPreMatricula.itmPersona.Nombres1 = Convert.ToString(dr["Nombres1"]);
                    itmPreMatricula.itmPersona.Nombres2 = Convert.ToString(dr["Nombres2"]);
                    itmPreMatricula.itmPersona.ApellidoPaterno = Convert.ToString(dr["ApellidoPaterno"]);
                    itmPreMatricula.itmPersona.ApellidoMaterno = Convert.ToString(dr["ApellidoMaterno"]);
                    itmPreMatricula.IdCiclo = Convert.ToString(dr["IdCiclo"]);
                    itmPreMatricula.rowguid = Convert.ToString(dr["IdPreMatricula"]);
                    itmPreMatricula.DeudaMatricula = Convert.ToDecimal(dr["DeudaMatricula"]);
                    itmPreMatricula.DeudaAnterior = Convert.ToDecimal(dr["DeudaAnterior"]);
                    itmPreMatricula.DeudaPreinscripcion = Convert.ToDecimal(dr["DeudaPreinscripcion"]);
                    itmPreMatricula.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    itmPreMatricula.FechaCaducar = Convert.ToDateTime(dr["FechaCaducar"]);
                    itmPreMatricula.EsCaducado = Convert.ToBoolean(dr["EsCaducado"]);
                    itmPreMatricula.EsMatriculado = Convert.ToString(dr["EsMatriculado"]);
                    itmPreMatricula.itmCiclo = new beCiclo();
                    itmPreMatricula.itmCiclo.itmProgramacion = new beProgramacion();
                    itmPreMatricula.itmCiclo.itmProgramacion.Yea = Convert.ToString(dr["Yea"]);
                    itmPreMatricula.itmCiclo.itmProgramacion.Mes = Convert.ToByte(dr["Mes"]);
                    itmPreMatricula.itmCiclo.itmProgramacion.strMes = Convert.ToString(dr["strMes"]);
                    itmPreMatricula.itmCiclo.IdSede = Convert.ToByte(dr["IdSede"]);
                    itmPreMatricula.itmCiclo.IdLocal = Convert.ToByte(dr["IdLocal"]);
                    itmPreMatricula.itmCiclo.CodCurso = Convert.ToString(dr["CodCurso"]);
                    //itmPreMatricula.bitEleiminar = Convert.ToBoolean(dr["bitEleiminar"]);
                    //itmPreMatricula.itmCiclo = objCiclo.detalle(itmPreMatricula.IdCiclo);
                    lisPreMatricula.Add(itmPreMatricula);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisPreMatricula;
        }
    }
}
