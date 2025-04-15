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
    public class daPersona
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        bePersona itmPersona;
        List<bePersona> lisPersona;
        public List<bePersona> Buscar(string strOpcion, string strBuscar)
        {
            lisPersona = new List<bePersona>();
            cmm = new SqlCommand("CobranzaWeb.wsp_Persona_Search", conec);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@Opcion", SqlDbType.VarChar).Value = strOpcion;
            cmm.Parameters.Add("@Buscar", SqlDbType.VarChar).Value = strBuscar;
            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();
            }
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                itmPersona = new bePersona();
                itmPersona.IdPersona = Convert.ToString(dr["IdPersona"]);
                itmPersona.IdOcupacion = Convert.ToInt16(dr["IdOcupacion"]);
                itmPersona.CodUbigeo = Convert.ToString(dr["CodUbigeo"]);
                itmPersona.IdTipoVia = Convert.ToByte(dr["IdTipoVia"]);
                itmPersona.IdNombreVia = Convert.ToString(dr["IdNombreVia"]);
                itmPersona.IdDenominacionUrbana = Convert.ToString(dr["IdDenominacionUrbana"]);
                itmPersona.IdTipoDocumento = Convert.ToByte(dr["IdTipoDocumento"]);
                itmPersona.Nombres1 = Convert.ToString(dr["Nombres1"]);
                itmPersona.Nombres2 = Convert.ToString(dr["Nombres2"]);
                itmPersona.ApellidoPaterno = Convert.ToString(dr["ApellidoPaterno"]);
                itmPersona.ApellidoMaterno = Convert.ToString(dr["ApellidoMaterno"]);
                itmPersona.NombreCompleto = itmPersona.ApellidoPaterno.Trim() + " " + itmPersona.ApellidoMaterno.Trim() + ", " + itmPersona.Nombres1.Trim() + " " + itmPersona.Nombres2.Trim();
                itmPersona.DNI = Convert.ToString(dr["DNI"]);
                itmPersona.FNacimiento = Convert.ToDateTime(dr["FNacimiento"]);
                itmPersona.EdadDetallada = Convert.ToString(dr["EdadDetallada"]);
                itmPersona.Sexo = Convert.ToString(dr["Sexo"]);
                itmPersona.TipoDireccion = Convert.ToString(dr["TipoDireccion"]);
                itmPersona.Numero = Convert.ToString(dr["Numero"]);
                //itmPersona.Picture = Convert.ToString(dr["Picture"]);
                itmPersona.OBS = Convert.ToString(dr["OBS"]);
                itmPersona.Estado = Convert.ToByte(dr["Estado"]);
                itmPersona.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                itmPersona.TerminalRegistro = Convert.ToString(dr["TerminalRegistro"]);
                itmPersona.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                //itmPersona.FechaActualizacion = Convert.ToDateTime(dr["FechaActualizacion"]);
                itmPersona.TerminalActualizacion = Convert.ToString(dr["TerminalActualizacion"]);
                itmPersona.UserActualizacion = Convert.ToString(dr["UserActualizacion"]);
                itmPersona.Email = Convert.ToString(dr["Email"]);
                //itmPersona.C_Codigo = Convert.ToString(dr["C_Codigo"]);
                lisPersona.Add(itmPersona);
            }
            conec.Close();
            return lisPersona;
        }
        public bePersona Detalle(string IdPersona)
        {
            itmPersona = new bePersona();
            cmm = new SqlCommand("CobranzaWeb.wsp_Persona_ByID", conec);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 20).Value = IdPersona;
            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();
            }
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                itmPersona.IdPersona = Convert.ToString(dr["IdPersona"]);
                itmPersona.IdOcupacion = Convert.ToInt16(dr["IdOcupacion"]);
                itmPersona.CodUbigeo = Convert.ToString(dr["CodUbigeo"]);
                itmPersona.IdTipoVia = Convert.ToByte(dr["IdTipoVia"]);
                itmPersona.IdNombreVia = Convert.ToString(dr["IdNombreVia"]);
                itmPersona.IdDenominacionUrbana = Convert.ToString(dr["IdDenominacionUrbana"]);
                itmPersona.IdTipoDocumento = Convert.ToByte(dr["IdTipoDocumento"]);
                itmPersona.Nombres1 = Convert.ToString(dr["Nombres1"]);
                itmPersona.Nombres2 = Convert.ToString(dr["Nombres2"]);
                itmPersona.ApellidoPaterno = Convert.ToString(dr["ApellidoPaterno"]);
                itmPersona.ApellidoMaterno = Convert.ToString(dr["ApellidoMaterno"]);
                itmPersona.NombreCompleto = itmPersona.ApellidoPaterno.Trim() + " " + itmPersona.ApellidoMaterno.Trim() + ", " + itmPersona.Nombres1.Trim() + " " + itmPersona.Nombres2.Trim();
                itmPersona.DNI = Convert.ToString(dr["DNI"]);
                itmPersona.FNacimiento = Convert.ToDateTime(dr["FNacimiento"]);
                itmPersona.EdadDetallada = Convert.ToString(dr["EdadDetallada"]);
                itmPersona.Sexo = Convert.ToString(dr["Sexo"]);
                itmPersona.TipoDireccion = Convert.ToString(dr["TipoDireccion"]);
                itmPersona.Numero = Convert.ToString(dr["Numero"]);
                //itmPersona.Picture = Convert.ToString(dr["Picture"]);
                itmPersona.OBS = Convert.ToString(dr["OBS"]);
                itmPersona.Estado = Convert.ToByte(dr["Estado"]);
                itmPersona.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                itmPersona.TerminalRegistro = Convert.ToString(dr["TerminalRegistro"]);
                itmPersona.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                //itmPersona.FechaActualizacion = Convert.ToDateTime(dr["FechaActualizacion"]);
                itmPersona.TerminalActualizacion = Convert.ToString(dr["TerminalActualizacion"]);
                itmPersona.UserActualizacion = Convert.ToString(dr["UserActualizacion"]);
                //itmPersona.C_Codigo = Convert.ToString(dr["C_Codigo"]);
                itmPersona.Email = Convert.ToString(dr["Email"]);
            }
            conec.Close();
            return itmPersona;
        }
    }
}
