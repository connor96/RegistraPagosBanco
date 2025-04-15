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
    public class daActivarDatos
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        List<beActivarDatos> LisActivarDatos;
        beActivarDatos itmActivarDatos;
        beReturn itmReturn;
        public beActivarDatos Detalle(int id)
        {
            itmActivarDatos = new beActivarDatos();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_ActivarDatos_detalle", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdActivarDatos", SqlDbType.Int).Value = id;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmActivarDatos.intIdActivarDatos = Convert.ToInt16(dr["intIdActivarDatos"]);
                    itmActivarDatos.dtmInicio = Convert.ToDateTime(dr["dtmInicio"]);
                    itmActivarDatos.dtmFinal = Convert.ToDateTime(dr["dtmFinal"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmActivarDatos;
        }
        public List<beActivarDatos> Activos()
        {
            LisActivarDatos = new List<beActivarDatos>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_ActivarDatosLista", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmActivarDatos = new beActivarDatos();
                    itmActivarDatos.intIdActivarDatos = Convert.ToInt16(dr["intIdActivarDatos"]);
                    itmActivarDatos.dtmInicio = Convert.ToDateTime(dr["dtmInicio"]);
                    itmActivarDatos.dtmFinal = Convert.ToDateTime(dr["dtmFinal"]);
                    LisActivarDatos.Add(itmActivarDatos);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return LisActivarDatos;
        }
        public int ActivosInt()
        {
            int ReturnValue = 0;
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_ActivarDatos", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    ReturnValue += 1;
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ReturnValue;
        }
        public beReturn Insert(beActivarDatos myitmActivarDatos)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_ActivarDatos_Insert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                SqlParameter intIdActivarDatos = new SqlParameter();
                intIdActivarDatos.ParameterName = "@intIdActivarDatos";
                intIdActivarDatos.SqlDbType = SqlDbType.Int;
                intIdActivarDatos.Direction = ParameterDirection.Output;
                cmm.Parameters.Add(intIdActivarDatos).Value = myitmActivarDatos.intIdActivarDatos;
                cmm.Parameters.Add("@dtmInicio", SqlDbType.DateTime).Value = myitmActivarDatos.dtmInicio;
                cmm.Parameters.Add("@dtmFinal", SqlDbType.DateTime).Value = myitmActivarDatos.dtmFinal;

                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                itmReturn.intIdReturn = cmm.ExecuteNonQuery();
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturnValue = cmm.Parameters["@intIdActivarDatos"].Value.ToString();
                    itmReturn.strMensaje = beMensajes.Mensajes(enmListaErrores.Guardar_Ok);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                itmReturn.intIdReturn = 0;
                itmReturn.strMensaje = ex.Message;
                //throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public beReturn Delete(int intIdActivacion)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_ActivarDatos_Delete", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdActivarDatos", SqlDbType.Int).Value = intIdActivacion;

                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                itmReturn.intIdReturn = cmm.ExecuteNonQuery();
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturnValue = intIdActivacion.ToString();
                    itmReturn.strMensaje = beMensajes.Mensajes(enmListaErrores.Eliminar_Ok);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                itmReturn.intIdReturn = 0;
                itmReturn.strMensaje = ex.Message;
                //throw new Exception(ex.Message);
            }
            return itmReturn;
        }
    }
}
