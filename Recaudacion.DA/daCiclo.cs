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
    public class daCiclo
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beCiclo itmCiclo;
        List<beCiclo> lisCiclo;
        public List<beCiclo> ListaCicloByLocalCursoCiclo(int IdLocal, string codCurso, string idPeriodo)
        {
            lisCiclo = new List<beCiclo>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_CicloByLocalCursoPeriodo", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdLocal", SqlDbType.TinyInt).Value = IdLocal;
                cmm.Parameters.Add("@codCurso", SqlDbType.VarChar).Value = (codCurso == null) ? "" : codCurso;
                cmm.Parameters.Add("@IdPeriodo", SqlDbType.VarChar).Value = (idPeriodo == null) ? "" : idPeriodo;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmCiclo = new beCiclo();
                    itmCiclo.IdPeriodo = Convert.ToString(dr["IdPeriodo"]);
                    itmCiclo.IdSede = Convert.ToByte(dr["IdSede"]);
                    itmCiclo.IdLocal = Convert.ToByte(dr["IdLocal"]);
                    itmCiclo.Local = Convert.ToString(dr["Local"]);
                    itmCiclo.IdCiclo = Convert.ToString(dr["IdCiclo"]);
                    itmCiclo.CodCurso = Convert.ToString(dr["CodCurso"]);
                    itmCiclo.IdAula = Convert.ToByte(dr["IdAula"]);
                    itmCiclo.DesAula = Convert.ToString(dr["DesAula"]);
                    itmCiclo.DesCurso = Convert.ToString(dr["DesCurso"]);
                    itmCiclo.DesMallaCurricular = Convert.ToString(dr["DesMallaCurricular"]);
                    itmCiclo.PreRequisito = Convert.ToString(dr["PreRequisito"]);
                    itmCiclo.DesTurno = Convert.ToString(dr["DesTurno"]);
                    itmCiclo.IdHoras = Convert.ToByte(dr["IdHoras"]);
                    itmCiclo.Inicio = Convert.ToString(dr["Inicio"]);
                    itmCiclo.Final = Convert.ToString(dr["Final"]);
                    itmCiclo.Capacidad = Convert.ToInt16(dr["Capacidad"]);
                    itmCiclo.Matriculado = Convert.ToInt16(dr["Matriculado"]);
                    itmCiclo.Vacante = Convert.ToInt16(dr["Vacante"]);
                    itmCiclo.Prematriculado = Convert.ToInt16(dr["Prematriculado"]);
                    lisCiclo.Add(itmCiclo);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisCiclo;
        }
        public List<beCiclo> ListaCicloByCurso(string idPersona, string codCurso, string idPeriodo)
        {
            lisCiclo = new List<beCiclo>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_Institucion_Ciclo_Get", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar).Value = (idPersona == null) ? "" : idPersona;
                cmm.Parameters.Add("@codCurso", SqlDbType.VarChar).Value = (codCurso == null) ? "" : codCurso;
                cmm.Parameters.Add("@IdPeriodo", SqlDbType.VarChar).Value = (idPeriodo == null) ? "" : idPeriodo;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmCiclo = new beCiclo();
                    itmCiclo.IdPeriodo = Convert.ToString(dr["IdPeriodo"]);
                    itmCiclo.IdSede = Convert.ToByte(dr["IdSede"]);
                    itmCiclo.IdLocal = Convert.ToByte(dr["IdLocal"]);
                    itmCiclo.Local = Convert.ToString(dr["Local"]);
                    itmCiclo.IdCiclo = Convert.ToString(dr["IdCiclo"]);
                    itmCiclo.CodCurso = Convert.ToString(dr["CodCurso"]);
                    itmCiclo.IdAula = Convert.ToByte(dr["IdAula"]);
                    itmCiclo.DesAula = Convert.ToString(dr["DesAula"]);
                    itmCiclo.DesCurso = Convert.ToString(dr["DesCurso"]);
                    itmCiclo.DesMallaCurricular = Convert.ToString(dr["DesMallaCurricular"]);
                    itmCiclo.PreRequisito = Convert.ToString(dr["PreRequisito"]);
                    itmCiclo.DesTurno = Convert.ToString(dr["DesTurno"]);
                    itmCiclo.IdHoras = Convert.ToByte(dr["IdHoras"]);
                    itmCiclo.Inicio = Convert.ToString(dr["Inicio"]);
                    itmCiclo.Final = Convert.ToString(dr["Final"]);
                    itmCiclo.Capacidad = Convert.ToInt16(dr["Capacidad"]);
                    itmCiclo.Matriculado = Convert.ToInt16(dr["Matriculado"]);
                    itmCiclo.Vacante = Convert.ToInt16(dr["Vacante"]);
                    itmCiclo.Prematriculado = Convert.ToInt16(dr["Prematriculado"]);
                    lisCiclo.Add(itmCiclo);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisCiclo;
        }
        public List<beCiclo> ListaCicloByUsuario(string idPersona, int idSede, string codCurso, string idPeriodo)
        {
            lisCiclo = new List<beCiclo>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_Institucion_CicloLocal", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar).Value = idPersona;
                cmm.Parameters.Add("@IdSede", SqlDbType.TinyInt).Value = idSede;
                cmm.Parameters.Add("@codCurso", SqlDbType.VarChar).Value = codCurso;
                cmm.Parameters.Add("@IdPeriodo", SqlDbType.VarChar).Value = idPeriodo;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmCiclo = new beCiclo();
                    itmCiclo.IdPeriodo = Convert.ToString(dr["IdPeriodo"]);
                    itmCiclo.IdSede = Convert.ToByte(dr["IdSede"]);
                    itmCiclo.IdLocal = Convert.ToByte(dr["IdLocal"]);
                    itmCiclo.Local = Convert.ToString(dr["Local"]);
                    itmCiclo.IdCiclo = Convert.ToString(dr["IdCiclo"]);
                    itmCiclo.CodCurso = Convert.ToString(dr["CodCurso"]);
                    itmCiclo.IdAula = Convert.ToByte(dr["IdAula"]);
                    itmCiclo.DesAula = Convert.ToString(dr["DesAula"]);
                    itmCiclo.DesCurso = Convert.ToString(dr["DesCurso"]);
                    itmCiclo.DesMallaCurricular = Convert.ToString(dr["DesMallaCurricular"]);
                    itmCiclo.PreRequisito = Convert.ToString(dr["PreRequisito"]);
                    itmCiclo.DesTurno = Convert.ToString(dr["DesTurno"]);
                    itmCiclo.IdHoras = Convert.ToByte(dr["IdHoras"]);
                    itmCiclo.Inicio = Convert.ToString(dr["Inicio"]);
                    itmCiclo.Final = Convert.ToString(dr["Final"]);
                    itmCiclo.Capacidad = Convert.ToInt16(dr["Capacidad"]);
                    itmCiclo.Matriculado = Convert.ToInt16(dr["Matriculado"]);
                    itmCiclo.Vacante = Convert.ToInt16(dr["Vacante"]);
                    itmCiclo.Prematriculado = Convert.ToInt16(dr["Prematriculado"]);
                    lisCiclo.Add(itmCiclo);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisCiclo;
        }
        public beCiclo detalle(string IdCiclo)
        {
            itmCiclo = new beCiclo();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_Ciclo_Detalle", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar).Value = IdCiclo;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmCiclo.IdCiclo = Convert.ToString(dr["IdCiclo"]);
                    itmCiclo.IdLocal = Convert.ToByte(dr["IdLocal"]);
                    itmCiclo.IdProgramacion = Convert.ToString(dr["IdProgramacion"]);
                    itmCiclo.IdSede = Convert.ToByte(dr["IdSede"]);
                    itmCiclo.CodCurso = Convert.ToString(dr["CodCurso"]);
                    itmCiclo.IdAula = Convert.ToInt16(dr["IdAula"]);
                    itmCiclo.IdDocente = Convert.ToString(dr["IdDocente"]);
                    itmCiclo.IdTurnoSede = Convert.ToInt16(dr["IdTurnoSede"]);
                    itmCiclo.Obs = Convert.ToString(dr["Obs"]);
                    //itmCiclo.rowguid = Convert.ToString(dr["rowguid"]);
                    itmCiclo.Estado = Convert.ToByte(dr["Estado"]);
                    //itmCiclo.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    itmCiclo.TerminalRegistro = Convert.ToString(dr["TerminalRegistro"]);
                    itmCiclo.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                    //itmCiclo.FechaActualizacion = Convert.ToString(dr["FechaActualizacion"]);
                    itmCiclo.TerminalActualizacion = Convert.ToString(dr["TerminalActualizacion"]);
                    itmCiclo.UserActualizacion = Convert.ToString(dr["UserActualizacion"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmCiclo;
        }
    }
}
