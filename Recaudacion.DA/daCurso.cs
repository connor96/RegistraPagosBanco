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
    public class daCurso
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beCurso itmCurso;
        List<beCurso> lisCurso;
        public beCurso CursoByUsuario(string idPersona, int Sede, string PreRequisito, bool PorEdad)
        {
            itmCurso = new beCurso();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_Institucion_Cursos_Get", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar).Value = idPersona;
                cmm.Parameters.Add("@Sede", SqlDbType.TinyInt).Value = Sede;
                cmm.Parameters.Add("@PreRequisito", SqlDbType.VarChar).Value = (PreRequisito == null) ? "" : PreRequisito;
                cmm.Parameters.Add("@PorEdad", SqlDbType.Bit).Value = PorEdad;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmCurso.CodCurso = Convert.ToString(dr["CodCurso"]);
                    itmCurso.IdCurso = Convert.ToInt16(dr["IdCurso"]);
                    itmCurso.CodNivelCurso = Convert.ToString(dr["CodNivelCurso"]);
                    itmCurso.CodMYELT = Convert.ToString(dr["CodMYELT"]);
                    itmCurso.DesCurso = Convert.ToString(dr["DesCurso"]);
                    itmCurso.Orden = Convert.ToInt16(dr["Orden"]);
                    itmCurso.PreRequisito = Convert.ToString(dr["PreRequisito"]);
                    itmCurso.EdadMi = Convert.ToString(dr["EdadMi"]);
                    itmCurso.EdadMa = Convert.ToString(dr["EdadMa"]);
                    itmCurso.Disponible = Convert.ToByte(dr["Disponible"]);
                    //itmCurso.rowguid = Convert.tog(dr["IdSede"]);
                    itmCurso.Estado = Convert.ToByte(dr["Estado"]);
                    //itmCurso.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    itmCurso.TerminalRegistro = Convert.ToString(dr["TerminalRegistro"]);
                    itmCurso.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                    //itmCurso.FechaActualizacion = Convert.ToDateTime(dr["FechaActualizacion"]);
                    itmCurso.TerminalActualizacion = Convert.ToString(dr["TerminalActualizacion"]);
                    itmCurso.UserActualizacion = Convert.ToString(dr["UserActualizacion"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmCurso;
        }
        public List<beCurso> ListaCursoByUsuario(string idPersona, int Sede)
        {
            lisCurso = new List<beCurso>();
            try
            {
                cmm = new SqlCommand("[CobranzaWeb].[wsp_Institucion_CursoByEdad]", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar).Value = idPersona;
                cmm.Parameters.Add("@Sede", SqlDbType.TinyInt).Value = Sede;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmCurso = new beCurso();
                    itmCurso.CodCurso = Convert.ToString(dr["CodCurso"]);
                    itmCurso.IdCurso = Convert.ToInt16(dr["IdCurso"]);
                    itmCurso.CodNivelCurso = Convert.ToString(dr["CodNivelCurso"]);
                    itmCurso.CodMYELT = Convert.ToString(dr["CodMYELT"]);
                    itmCurso.DesCurso = Convert.ToString(dr["DesCurso"]);
                    itmCurso.Orden = Convert.ToInt16(dr["Orden"]);
                    itmCurso.PreRequisito = Convert.ToString(dr["PreRequisito"]);
                    itmCurso.EdadMi = Convert.ToString(dr["EdadMi"]);
                    itmCurso.EdadMa = Convert.ToString(dr["EdadMa"]);
                    itmCurso.Disponible = Convert.ToByte(dr["Disponible"]);
                    //itmCurso.rowguid = Convert.tog(dr["IdSede"]);
                    itmCurso.Estado = Convert.ToByte(dr["Estado"]);
                    //itmCurso.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    itmCurso.TerminalRegistro = Convert.ToString(dr["TerminalRegistro"]);
                    itmCurso.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                    //itmCurso.FechaActualizacion = Convert.ToDateTime(dr["FechaActualizacion"]);
                    itmCurso.TerminalActualizacion = Convert.ToString(dr["TerminalActualizacion"]);
                    itmCurso.UserActualizacion = Convert.ToString(dr["UserActualizacion"]);
                    lisCurso.Add(itmCurso);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisCurso;
        }
        public beCurso Detalle(string IdCurso)
        {
            itmCurso = new beCurso();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_CursoByID", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@CodCurso", SqlDbType.VarChar, 15).Value = IdCurso;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmCurso.CodCurso = Convert.ToString(dr["CodCurso"]);
                    itmCurso.IdCurso = Convert.ToInt16(dr["IdCurso"]);
                    itmCurso.CodNivelCurso = Convert.ToString(dr["CodNivelCurso"]);
                    itmCurso.CodMYELT = Convert.ToString(dr["CodMYELT"]);
                    itmCurso.DesCurso = Convert.ToString(dr["DesCurso"]);
                    itmCurso.Orden = Convert.ToInt16(dr["Orden"]);
                    itmCurso.PreRequisito = Convert.ToString(dr["PreRequisito"]);
                    itmCurso.EdadMi = Convert.ToString(dr["EdadMi"]);
                    itmCurso.EdadMa = Convert.ToString(dr["EdadMa"]);
                    itmCurso.Disponible = Convert.ToByte(dr["Disponible"]);
                    //itmCurso.rowguid = Convert.tog(dr["IdSede"]);
                    itmCurso.Estado = Convert.ToByte(dr["Estado"]);
                    //itmCurso.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    itmCurso.TerminalRegistro = Convert.ToString(dr["TerminalRegistro"]);
                    itmCurso.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                    //itmCurso.FechaActualizacion = Convert.ToDateTime(dr["FechaActualizacion"]);
                    itmCurso.TerminalActualizacion = Convert.ToString(dr["TerminalActualizacion"]);
                    itmCurso.UserActualizacion = Convert.ToString(dr["UserActualizacion"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmCurso;
        }
        public List<beCurso> ListaPorPersona(string idPersona, string PreRequisito)
        {
            lisCurso = new List<beCurso>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_CursoByPerona", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@PreRequisito", SqlDbType.VarChar).Value = (PreRequisito == null)?"": PreRequisito;
                cmm.Parameters.Add("@idPersona", SqlDbType.VarChar).Value = idPersona;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmCurso = new beCurso();
                    itmCurso.CodCurso = Convert.ToString(dr["CodCurso"]);
                    itmCurso.IdCurso = Convert.ToInt16(dr["IdCurso"]);
                    itmCurso.CodNivelCurso = Convert.ToString(dr["CodNivelCurso"]);
                    itmCurso.DesCurso = Convert.ToString(dr["DesCurso"]);
                    itmCurso.PreRequisito = Convert.ToString(dr["PreRequisito"]);
                    itmCurso.EdadMi = Convert.ToString(dr["EdadMi"]);
                    itmCurso.EdadMa = Convert.ToString(dr["EdadMa"]);
                    lisCurso.Add(itmCurso);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisCurso;
        }
    }
}
