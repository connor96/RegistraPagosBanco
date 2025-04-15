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
    public class daSendMail
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beSendMail itmSendMail;
        beReturn itmReturn;
        public beSendMail Detalle()
        {
            itmSendMail = new beSendMail();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_SendMail", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmSendMail.idSendMail = Convert.ToInt32(dr["idSendMail"]);
                    itmSendMail.strHost = Convert.ToString(dr["strHost"]);
                    itmSendMail.intPuerto = Convert.ToInt32(dr["intPuerto"]);
                    itmSendMail.strCuenta = Convert.ToString(dr["strCuenta"]);
                    itmSendMail.strClave = Convert.ToString(dr["strClave"]);
                    itmSendMail.strTitular = Convert.ToString(dr["strTitular"]);
                    itmSendMail.strHeader = Convert.ToString(dr["strHeader"]);
                    itmSendMail.strFooter = Convert.ToString(dr["strFooter"]);
                    itmSendMail.bitActivo = Convert.ToBoolean(dr["bitActivo"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmSendMail;
        }
        public beReturn Insert(beSendMail myitmSendMail)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_SendMail_Inser", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                SqlParameter idSendMail = new SqlParameter();
                idSendMail.ParameterName = "@idSendMail";
                idSendMail.SqlDbType = SqlDbType.Int;
                idSendMail.Direction = ParameterDirection.Output;
                cmm.Parameters.Add(idSendMail).Value = myitmSendMail.idSendMail;
                cmm.Parameters.Add("@strHost", SqlDbType.VarChar, 50).Value = (myitmSendMail.strHost== null)?"": myitmSendMail.strHost;
                cmm.Parameters.Add("@intPuerto", SqlDbType.Int).Value = myitmSendMail.intPuerto;
                cmm.Parameters.Add("@strCuenta", SqlDbType.VarChar, 100).Value = (myitmSendMail.strCuenta == null) ? "" : myitmSendMail.strCuenta;
                cmm.Parameters.Add("@strClave", SqlDbType.VarChar, 50).Value = (myitmSendMail.strClave == null) ? "" : myitmSendMail.strClave;
                cmm.Parameters.Add("@strTitular", SqlDbType.VarChar, 200).Value = (myitmSendMail.strTitular == null) ? "" : myitmSendMail.strTitular;
                //cmm.Parameters.Add("@strHeader", SqlDbType.VarChar).Value = (myitmSendMail.strHeader == null) ? "" : myitmSendMail.strHeader;
                //cmm.Parameters.Add("@strFooter", SqlDbType.VarChar).Value = (myitmSendMail.strFooter == null) ? "" : myitmSendMail.strFooter;
                cmm.Parameters.Add("@bitActivo", SqlDbType.Bit).Value = myitmSendMail.bitActivo;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                //if (itmReturn.intIdReturn > 0)
                //{
                    itmReturn.strReturn = cmm.Parameters["@idSendMail"].Value.ToString();
                //}
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public beReturn Update(beSendMail myitmSendMail)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_SendMail_UpdateDatos", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@idSendMail", SqlDbType.Int).Value = myitmSendMail.idSendMail;
                cmm.Parameters.Add("@strHost", SqlDbType.VarChar, 50).Value = (myitmSendMail.strHost == null) ? "" : myitmSendMail.strHost;
                cmm.Parameters.Add("@intPuerto", SqlDbType.Int).Value = myitmSendMail.intPuerto;
                cmm.Parameters.Add("@strCuenta", SqlDbType.VarChar, 100).Value = (myitmSendMail.strCuenta == null) ? "" : myitmSendMail.strCuenta;
                cmm.Parameters.Add("@strClave", SqlDbType.VarChar, 50).Value = (myitmSendMail.strClave == null) ? "" : myitmSendMail.strClave;
                cmm.Parameters.Add("@strTitular", SqlDbType.VarChar, 200).Value = (myitmSendMail.strTitular == null) ? "" : myitmSendMail.strTitular;
                //cmm.Parameters.Add("@strHeader", SqlDbType.VarChar).Value = (myitmSendMail.strHeader == null) ? "" : myitmSendMail.strHeader;
                //cmm.Parameters.Add("@strFooter", SqlDbType.VarChar).Value = (myitmSendMail.strFooter == null) ? "" : myitmSendMail.strFooter;
                cmm.Parameters.Add("@bitActivo", SqlDbType.Bit).Value = myitmSendMail.bitActivo;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturnValue = myitmSendMail.idSendMail.ToString();
                    itmReturn.strMensaje = "Felicitaciones, los datos se guardaron satisfactoriamente.";
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public beReturn UpdateMacros(beSendMail myitmSendMail)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_SendMail_UpdateMacros", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@idSendMail", SqlDbType.Int).Value = myitmSendMail.idSendMail;
                //cmm.Parameters.Add("@strHost", SqlDbType.VarChar, 50).Value = (myitmSendMail.strHost == null) ? "" : myitmSendMail.strHost;
                //cmm.Parameters.Add("@intPuerto", SqlDbType.Int).Value = myitmSendMail.intPuerto;
                //cmm.Parameters.Add("@strCuenta", SqlDbType.VarChar, 100).Value = (myitmSendMail.strCuenta == null) ? "" : myitmSendMail.strCuenta;
                //cmm.Parameters.Add("@strClave", SqlDbType.VarChar, 50).Value = (myitmSendMail.strClave == null) ? "" : myitmSendMail.strClave;
                //cmm.Parameters.Add("@strTitular", SqlDbType.VarChar, 200).Value = (myitmSendMail.strTitular == null) ? "" : myitmSendMail.strTitular;
                cmm.Parameters.Add("@strHeader", SqlDbType.VarChar).Value = (myitmSendMail.strHeader == null) ? "" : myitmSendMail.strHeader;
                cmm.Parameters.Add("@strFooter", SqlDbType.VarChar).Value = (myitmSendMail.strFooter == null) ? "" : myitmSendMail.strFooter;
                //cmm.Parameters.Add("@bitActivo", SqlDbType.Bit).Value = myitmSendMail.bitActivo;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = myitmSendMail.idSendMail.ToString();
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public beReturn UpdateHeader(beSendMail myitmSendMail)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_SendMail_UpdateHeader", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@idSendMail", SqlDbType.Int).Value = myitmSendMail.idSendMail;
                cmm.Parameters.Add("@strHeader", SqlDbType.VarChar).Value = (myitmSendMail.strHeader == null) ? "" : myitmSendMail.strHeader;
                //cmm.Parameters.Add("@strFooter", SqlDbType.VarChar).Value = (myitmSendMail.strFooter == null) ? "" : myitmSendMail.strFooter;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturnValue = myitmSendMail.idSendMail.ToString();
                    itmReturn.strMensaje = "Felicitaciones, los datos se guardaron satisfactoriamente.";
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public beReturn UpdateFooter(beSendMail myitmSendMail)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_SendMail_UpdateFooter", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@idSendMail", SqlDbType.Int).Value = myitmSendMail.idSendMail;
                //cmm.Parameters.Add("@strHeader", SqlDbType.VarChar).Value = (myitmSendMail.strHeader == null) ? "" : myitmSendMail.strHeader;
                cmm.Parameters.Add("@strFooter", SqlDbType.VarChar).Value = (myitmSendMail.strFooter == null) ? "" : myitmSendMail.strFooter;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturnValue = myitmSendMail.idSendMail.ToString();
                    itmReturn.strMensaje = "Felicitaciones, los datos se guardaron satisfactoriamente.";
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }

      
    }
}
