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
    public class daInserComprobanteDetalle
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;

        beInserComprobanteDetalle itmInserComprobanteDetalle;
        beReturn itmReturn;
        List<beInserComprobanteDetalle> lisInserComprobanteDetalle;
        public List<beInserComprobanteDetalle> SearchByInsert(int intIdRecepcionDetalle, string IdComprobante, string User, string terminal)
        {
            lisInserComprobanteDetalle = new List<beInserComprobanteDetalle>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_ComprobanteDetalle_ParaNuevo", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdRecepcionDetalle", SqlDbType.Int).Value = intIdRecepcionDetalle;
                cmm.Parameters.Add("@User", SqlDbType.VarChar, 50).Value = (User == null) ? "0000000000" : User;
                cmm.Parameters.Add("@terminal", SqlDbType.VarChar, 20).Value = (terminal == null) ? Environment.MachineName : terminal;
                cmm.Parameters.Add("@IdComprobante", SqlDbType.Char, 10).Value = IdComprobante;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmInserComprobanteDetalle = new beInserComprobanteDetalle();
                    itmInserComprobanteDetalle.TipoMatricula = Convert.ToBoolean(dr["TipoMatricula"]);
                    itmInserComprobanteDetalle.IdItem = Convert.ToInt32(dr["IdItem"]);
                    itmInserComprobanteDetalle.TipoItem = Convert.ToString(dr["TipoItem"]);
                    itmInserComprobanteDetalle.IdGrupoConcepto = Convert.ToInt32(dr["IdGrupoConcepto"]);
                    itmInserComprobanteDetalle.IdDescuentoSede = Convert.ToInt32(dr["IdDescuentoSede"]);
                    itmInserComprobanteDetalle.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                    itmInserComprobanteDetalle.Importe = Convert.ToDecimal(dr["Importe"]);
                    itmInserComprobanteDetalle.Dscto = Convert.ToDecimal(dr["Dscto"]);
                    itmInserComprobanteDetalle.TotalPagar = Convert.ToDecimal(dr["TotalPagar"]);
                    itmInserComprobanteDetalle.IdAlumno = Convert.ToString(dr["IdAlumno"]);
                    itmInserComprobanteDetalle.IdCiclo = Convert.ToString(dr["IdCiclo"]);
                    itmInserComprobanteDetalle.IdSituacionMatricula = Convert.ToInt32(dr["IdSituacionMatricula"]);
                    itmInserComprobanteDetalle.User = Convert.ToString(dr["User"]);
                    itmInserComprobanteDetalle.Terminal = Convert.ToString(dr["Terminal"]);
                    itmInserComprobanteDetalle.IdComprobante = Convert.ToString(dr["IdComprobante"]);
                    lisInserComprobanteDetalle.Add(itmInserComprobanteDetalle);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisInserComprobanteDetalle;
        }

        public beReturn Insert(beInserComprobanteDetalle itmInserComprobanteDetalle)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("Caja.usp_DetalleComprobante_Insert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                SqlParameter IdComprobante = new SqlParameter();
                cmm.Parameters.Add("@TipoMatricula", SqlDbType.Bit).Value = itmInserComprobanteDetalle.TipoMatricula;
                cmm.Parameters.Add("@IdItem", SqlDbType.Int).Value = itmInserComprobanteDetalle.IdItem;
                cmm.Parameters.Add("@TipoItem", SqlDbType.Char, 1).Value = (itmInserComprobanteDetalle.TipoItem == null) ? "" : itmInserComprobanteDetalle.TipoItem;
                cmm.Parameters.Add("@IdGrupoConcepto", SqlDbType.Int).Value = itmInserComprobanteDetalle.IdGrupoConcepto;
                cmm.Parameters.Add("@IdDescuentoSede", SqlDbType.Int).Value = itmInserComprobanteDetalle.IdDescuentoSede;
                cmm.Parameters.Add("@Cantidad", SqlDbType.Int).Value = itmInserComprobanteDetalle.Cantidad;
                cmm.Parameters.Add("@Importe", SqlDbType.Decimal).Value = itmInserComprobanteDetalle.Importe;
                cmm.Parameters.Add("@Dscto", SqlDbType.Decimal).Value = itmInserComprobanteDetalle.Dscto;
                cmm.Parameters.Add("@TotalPagar", SqlDbType.Decimal).Value = itmInserComprobanteDetalle.TotalPagar;
                cmm.Parameters.Add("@IdAlumno", SqlDbType.VarChar, 20).Value = (itmInserComprobanteDetalle.IdAlumno == null) ? "" : itmInserComprobanteDetalle.IdAlumno;
                cmm.Parameters.Add("@IdCiclo", SqlDbType.Char, 11).Value = (itmInserComprobanteDetalle.IdCiclo == null) ? "" : itmInserComprobanteDetalle.IdCiclo;
                cmm.Parameters.Add("@IdSituacionMatricula", SqlDbType.Int).Value = itmInserComprobanteDetalle.IdSituacionMatricula;
                cmm.Parameters.Add("@Terminal", SqlDbType.VarChar, 20).Value = (itmInserComprobanteDetalle.Terminal == null) ? "" : itmInserComprobanteDetalle.Terminal;
                cmm.Parameters.Add("@User", SqlDbType.VarChar, 50).Value = (itmInserComprobanteDetalle.User == null) ? "" : itmInserComprobanteDetalle.User;
                cmm.Parameters.Add("@IdComprobante", SqlDbType.Char, 10).Value = (itmInserComprobanteDetalle.IdComprobante == null) ? "" : itmInserComprobanteDetalle.IdComprobante;
                cmm.Parameters.Add("@Ultimo", SqlDbType.Bit).Value = itmInserComprobanteDetalle.Ultimo;
                cmm.Parameters.Add("@PMatricula", SqlDbType.Bit).Value = itmInserComprobanteDetalle.PMatricula;
                cmm.Parameters.Add("@PDeuda", SqlDbType.Int).Value = itmInserComprobanteDetalle.PDeuda;
                cmm.Parameters.Add("@IdMatricula", SqlDbType.Char, 12).Value = (itmInserComprobanteDetalle.IdMatricula == null) ? "0" : itmInserComprobanteDetalle.IdMatricula;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = "OK";
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
