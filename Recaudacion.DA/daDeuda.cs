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
    public class daDeuda
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beDeuda itmDeuda;
        List<beDeuda> lisDeuda;
        beReturn itmReturn;
        public List<beDeuda> listarDeuda(string idPrematricula)
        {
            lisDeuda = new List<beDeuda>();
            cmm = new SqlCommand("CobranzaWeb.usp_Deuda_SelectByPreMatricula", conec);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@idPrematricula", SqlDbType.UniqueIdentifier).Value = Guid.Parse((idPrematricula == null) ? "" : idPrematricula);
            ;
            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();
            }
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                itmDeuda = new beDeuda();
                itmDeuda.intIdDeudas = Convert.ToInt16(dr["intIdDeudas"]);
                itmDeuda.idPrematricula = Convert.ToString(dr["idPrematricula"]);
                itmDeuda.Deuda = Convert.ToDecimal(dr["Deuda"]);
                itmDeuda.Periodo = Convert.ToString(dr["Periodo"]);
                itmDeuda.CodAlumno = Convert.ToString(dr["CodAlumno"]);
                itmDeuda.Alumno = Convert.ToString(dr["Alumno"]);
                itmDeuda.idCurso = Convert.ToString(dr["idCurso"]);
                itmDeuda.Hora = Convert.ToString(dr["Hora"]);
                itmDeuda.idAula = Convert.ToString(dr["idAula"]);
                itmDeuda.CodIncripcion = Convert.ToString(dr["CodIncripcion"]);
                itmDeuda.Fecha = Convert.ToDateTime(dr["Fecha"]);
                lisDeuda.Add(itmDeuda);
            }
            conec.Close();
            return lisDeuda;
        }
        public beReturn Insert(beDeuda myitmDeuda)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.usp_Deuda_Insert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@idPrematricula", SqlDbType.UniqueIdentifier).Value = Guid.Parse((myitmDeuda.idPrematricula == null) ? "" : myitmDeuda.idPrematricula);
                cmm.Parameters.Add("@Deuda", SqlDbType.Decimal, 8).Value = myitmDeuda.Deuda;
                cmm.Parameters.Add("@Periodo", SqlDbType.VarChar, 10).Value = (myitmDeuda.Periodo == null) ? "" : myitmDeuda.Periodo;
                cmm.Parameters.Add("@CodAlumno", SqlDbType.VarChar, 20).Value = (myitmDeuda.CodAlumno == null) ? "" : myitmDeuda.CodAlumno;
                cmm.Parameters.Add("@Alumno", SqlDbType.VarChar, 150).Value = (myitmDeuda.Alumno == null) ? "" : myitmDeuda.Alumno;
                cmm.Parameters.Add("@idCurso", SqlDbType.VarChar, 10).Value = (myitmDeuda.idCurso == null) ? "" : myitmDeuda.idCurso; 
                cmm.Parameters.Add("@Hora", SqlDbType.VarChar, 50).Value = (myitmDeuda.Hora == null) ? "" : myitmDeuda.Hora;
                cmm.Parameters.Add("@idAula", SqlDbType.VarChar, 20).Value = (myitmDeuda.idAula == null) ? "" : myitmDeuda.idAula;
                cmm.Parameters.Add("@CodIncripcion", SqlDbType.VarChar, 15).Value = (myitmDeuda.CodIncripcion == null) ? "" : myitmDeuda.CodIncripcion;
                cmm.Parameters.Add("@Fecha", SqlDbType.Date).Value = myitmDeuda.Fecha;
                SqlParameter intIdDeuda = new SqlParameter();
                intIdDeuda.ParameterName = "@intIdDeudas";
                intIdDeuda.SqlDbType = SqlDbType.Int;
                intIdDeuda.Direction = ParameterDirection.Output;
                cmm.Parameters.Add(intIdDeuda).Value = myitmDeuda.intIdDeudas;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = cmm.Parameters["@intIdDeudas"].Value.ToString();
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public List<beDeuda> CalculaDeuda(string IdAlumno)
        {
            lisDeuda = new List<beDeuda>();
            cmm = new SqlCommand("dbo.asp_AlumnoDeudas", conec);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@IdAlumno", SqlDbType.VarChar,20).Value = (IdAlumno == null) ? "" : IdAlumno;
            ;
            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();
            }
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                itmDeuda = new beDeuda();
                itmDeuda.intIdDeudas = 0;
                itmDeuda.idPrematricula = "";
                itmDeuda.Deuda = Convert.ToDecimal(dr["Deuda"]);
                itmDeuda.Periodo = Convert.ToString(dr["Periodo"]);
                itmDeuda.CodAlumno = Convert.ToString(dr["CodAlumno"]);
                itmDeuda.Alumno = Convert.ToString(dr["Alumno"]);
                itmDeuda.idCurso = Convert.ToString(dr["idCurso"]);
                itmDeuda.Hora = Convert.ToString(dr["Hora"]);
                itmDeuda.idAula = Convert.ToString(dr["idAula"]);
                //itmDeuda.CodIncripcion = Convert.ToString(dr["CodIncripcion"]);
                itmDeuda.Fecha = Convert.ToDateTime(dr["Fecha"]);
                lisDeuda.Add(itmDeuda);
            }
            conec.Close();
            return lisDeuda;
        }

    }
}
