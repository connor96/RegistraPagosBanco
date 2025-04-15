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
    public class daProgramacion
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beProgramacion itmProgramacion;
        List<beProgramacion> lisProgramacion;
        public List<beProgramacion> ListarProgramacionByUsuario(string IdPersona,int IdSede)
        {
            lisProgramacion = new List<beProgramacion>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_Institucion_PeriodoByEdad", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar,20).Value = IdPersona;
                cmm.Parameters.Add("@Sede", SqlDbType.TinyInt).Value = IdSede;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmProgramacion = new beProgramacion();
                    itmProgramacion.IdSede = Convert.ToByte(dr["IdSede"]);
                    itmProgramacion.IdInstitucion = Convert.ToByte(dr["IdInstitucion"]);
                    itmProgramacion.IdMallaCurricular = Convert.ToInt16(dr["IdMallaCurricular"]);
                    itmProgramacion.strMes = Convert.ToString(dr["strMes"]);
                    itmProgramacion.Mes = Convert.ToByte(dr["Mes"]);
                    itmProgramacion.Yea = Convert.ToString(dr["Yea"]);
                    itmProgramacion.IdPeriodo = Convert.ToString(dr["IdPeriodo"]);
                    //itmProgramacion.DesMallaCurricular = Convert.ToString(dr["DesMallaCurricular"]);
                    lisProgramacion.Add(itmProgramacion);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisProgramacion;
        }
        public List<beProgramacion> ListarProgramacionByCurso(string IdPersona, string CodCurso)
        {
            lisProgramacion = new List<beProgramacion>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_Institucion_Periodo_Get", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 20).Value = IdPersona;
                //cmm.Parameters.Add("@Sede", SqlDbType.TinyInt).Value = IdSede;
                cmm.Parameters.Add("@CodCurso", SqlDbType.VarChar, 10).Value = (CodCurso==null)?"": CodCurso;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmProgramacion = new beProgramacion();
                    itmProgramacion.IdSede = Convert.ToByte(dr["IdSede"]);
                    itmProgramacion.IdInstitucion = Convert.ToByte(dr["IdInstitucion"]);
                    itmProgramacion.IdMallaCurricular = Convert.ToInt16(dr["IdMallaCurricular"]);
                    itmProgramacion.strMes = Convert.ToString(dr["strMes"]);
                    itmProgramacion.Mes = Convert.ToByte(dr["Mes"]);
                    itmProgramacion.Yea = Convert.ToString(dr["Yea"]);
                    itmProgramacion.IdPeriodo = Convert.ToString(dr["IdPeriodo"]);
                    //itmProgramacion.DesMallaCurricular = Convert.ToString(dr["DesMallaCurricular"]);
                    lisProgramacion.Add(itmProgramacion);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisProgramacion;
        }
        public List<beProgramacion> ListarProgramacionPorLocalCurso(int idlocal, string CodCurso)
        {
            lisProgramacion = new List<beProgramacion>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_Periodo_Local_Curso", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@idlocal", SqlDbType.TinyInt).Value = idlocal;
                cmm.Parameters.Add("@CodCurso", SqlDbType.VarChar, 10).Value = (CodCurso == null) ? "" : CodCurso;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmProgramacion = new beProgramacion();
                    //itmProgramacion.IdSede = Convert.ToByte(dr["IdSede"]);
                    itmProgramacion.IdInstitucion = Convert.ToByte(dr["IdInstitucion"]);
                    itmProgramacion.IdMallaCurricular = Convert.ToInt16(dr["IdMallaCurricular"]);
                    itmProgramacion.strMes = Convert.ToString(dr["strMes"]);
                    itmProgramacion.Mes = Convert.ToByte(dr["Mes"]);
                    itmProgramacion.Yea = Convert.ToString(dr["Yea"]);
                    itmProgramacion.IdPeriodo = Convert.ToString(dr["IdPeriodo"]);
                    //itmProgramacion.DesMallaCurricular = Convert.ToString(dr["DesMallaCurricular"]);
                    lisProgramacion.Add(itmProgramacion);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisProgramacion;
        }
    }
}
