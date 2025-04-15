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
    public class daAlumno
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        public beAlumno Detalle(string idPersona)
        {
            beAlumno itmAlumno = new beAlumno();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.usp_AlumnoDetalle", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar).Value = idPersona;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmAlumno.IdAlumno = Convert.ToString(dr["IdAlumno"]);
                    itmAlumno.IdLocal = Convert.ToByte(dr["IdLocal"]);
                    itmAlumno.Clave = Convert.ToString(dr["Clave"]);
                    itmAlumno.rowguid = Guid.Parse(Convert.ToString(dr["rowguid"]));
                    itmAlumno.Estado = Convert.ToByte(dr["Estado"]);
                    itmAlumno.NroVeces = Convert.ToByte(dr["NroVeces"]);
                    itmAlumno.Obs = Convert.ToString(dr["Obs"]);
                    itmAlumno.TerminalRegistro = Convert.ToString(dr["TerminalRegistro"]);
                    itmAlumno.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                    itmAlumno.TerminalActualizacion = Convert.ToString(dr["TerminalActualizacion"]);
                    itmAlumno.UserActualizacion = Convert.ToString(dr["UserActualizacion"]);
                    //itmAlumno.IdSede = Convert.ToString(dr["IdSede"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmAlumno;
        }
        public int Sede(string idPersona)
        {
            int ReturnValue = 0;
            try
            {
                cmm = new SqlCommand("CobranzaWeb.usp_AlumnoDetalle", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar).Value = idPersona;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    ReturnValue = Convert.ToInt16(dr["IdSede"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ReturnValue;
        }
    }
}
