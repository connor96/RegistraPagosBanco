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
    public class daConceptoPago
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beConceptoPago itmConceptoPago;
        List<beConceptoPago> lisConceptoPago;
        beReturn itmReturn;
        public List<beConceptoPago> listarConceptoPagos(string idPrematricula)
        {
            lisConceptoPago = new List<beConceptoPago>();
            cmm = new SqlCommand("CobranzaWeb.usp_ConceptoPago_SelectByPreMatricula", conec);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@idPrematricula", SqlDbType.UniqueIdentifier).Value = Guid.Parse((idPrematricula == null) ? "" : idPrematricula);
            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();
            }
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                itmConceptoPago = new beConceptoPago();
                itmConceptoPago.intIdConceptoPago = Convert.ToInt16(dr["intIdConceptoPago"]);
                itmConceptoPago.idPrematricula = Convert.ToString(dr["idPrematricula"]);
                itmConceptoPago.idConceptoSede = Convert.ToInt16(dr["idConceptoSede"]);
                itmConceptoPago.Monto = Convert.ToDecimal(dr["Monto"]);
                itmConceptoPago.Pagar = Convert.ToDecimal(dr["Pagar"]);
                itmConceptoPago.Dscto = Convert.ToDecimal(dr["Dscto"]);
                itmConceptoPago.Stock = Convert.ToString(dr["Stock"]);
                itmConceptoPago.TipoMatricula = Convert.ToBoolean(dr["TipoMatricula"]);
                itmConceptoPago.IdSituacionMatricula = Convert.ToInt16(dr["IdSituacionMatricula"]);
                itmConceptoPago.PMatricula = Convert.ToBoolean(dr["PMatricula"]);
                itmConceptoPago.IdMatricula = Convert.ToString(dr["IdMatricula"]);
                lisConceptoPago.Add(itmConceptoPago);
            }
            conec.Close();
            return lisConceptoPago;
        }
        public beReturn Insert(beConceptoPago myitmConceptoPago)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.usp_ConceptoPago_Insert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@idGrupoConcepto", SqlDbType.SmallInt).Value = myitmConceptoPago.idGrupoConcepto;
                cmm.Parameters.Add("@CodCurso", SqlDbType.VarChar,15).Value = (myitmConceptoPago.CodCurso == null) ? "" : myitmConceptoPago.CodCurso;
                cmm.Parameters.Add("@idPrematricula", SqlDbType.UniqueIdentifier).Value = Guid.Parse((myitmConceptoPago.idPrematricula == null) ? "" : myitmConceptoPago.idPrematricula);
                cmm.Parameters.Add("@idConceptoSede", SqlDbType.SmallInt).Value = myitmConceptoPago.idConceptoSede;
                cmm.Parameters.Add("@Tipo", SqlDbType.Char,1).Value = (myitmConceptoPago.Tipo == null) ? "" : myitmConceptoPago.Tipo;
                cmm.Parameters.Add("@IdSede", SqlDbType.TinyInt).Value = myitmConceptoPago.IdSede;
                cmm.Parameters.Add("@Concepto", SqlDbType.VarChar,101).Value = (myitmConceptoPago.Concepto == null) ? "" : myitmConceptoPago.Concepto;
                cmm.Parameters.Add("@Monto", SqlDbType.Decimal, 10).Value = myitmConceptoPago.Monto;
                cmm.Parameters.Add("@Pagar", SqlDbType.Decimal, 20).Value = myitmConceptoPago.Pagar;
                cmm.Parameters.Add("@Dscto", SqlDbType.Decimal, 20).Value = myitmConceptoPago.Dscto;
                cmm.Parameters.Add("@Stock", SqlDbType.VarChar, 10).Value = (myitmConceptoPago.Stock == null) ? "" : myitmConceptoPago.Stock;
                cmm.Parameters.Add("@TipoMatricula", SqlDbType.Bit).Value = myitmConceptoPago.TipoMatricula;
                cmm.Parameters.Add("@IdSituacionMatricula", SqlDbType.TinyInt).Value = myitmConceptoPago.IdSituacionMatricula;
                cmm.Parameters.Add("@PMatricula", SqlDbType.Bit).Value = myitmConceptoPago.PMatricula;
                cmm.Parameters.Add("@IdMatricula", SqlDbType.Char, 12).Value = (myitmConceptoPago.Stock == null) ? "" : myitmConceptoPago.IdMatricula;
                SqlParameter intIdDeuda = new SqlParameter();
                intIdDeuda.ParameterName = "@intIdConceptoPago";
                intIdDeuda.SqlDbType = SqlDbType.Int;
                intIdDeuda.Direction = ParameterDirection.Output;
                cmm.Parameters.Add(intIdDeuda).Value = myitmConceptoPago.intIdConceptoPago;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = cmm.Parameters["@intIdConceptoPago"].Value.ToString();
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public beReturn InsertByCiclo(string IdCiclo, string idPrematricula)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.usp_ConceptoPago_InsertByCiclo", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdCiclo", SqlDbType.Char, 11).Value = (IdCiclo == null) ? "" : IdCiclo;
                cmm.Parameters.Add("@idPrematricula", SqlDbType.UniqueIdentifier).Value = Guid.Parse((idPrematricula == null) ? Guid.NewGuid().ToString() : idPrematricula);

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.intIdReturn = 1;
                    itmReturn.strReturn = "";
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                itmReturn.intIdReturn = 0;
                itmReturn.strReturn = ex.Message;
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        //public beConceptoPago PagosPorCurso(int IdSede, string CodCurso, string IdCiclo)
        public beConceptoPago PagosPorCurso(string IdCiclo)
        {
            itmConceptoPago = new beConceptoPago();
            cmm = new SqlCommand("CobranzaWeb.wsp_Combo_Get", conec);
            cmm.CommandType = CommandType.StoredProcedure;
            //cmm.Parameters.Add("@IdSede", SqlDbType.TinyInt).Value = IdSede;
            //cmm.Parameters.Add("@CodCurso", SqlDbType.VarChar, 20).Value = (CodCurso == null) ? "" : CodCurso;
            cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 20).Value = (IdCiclo == null) ? "" : IdCiclo;
            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();
            }
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                itmConceptoPago.intIdConceptoPago = 0;
                itmConceptoPago.idGrupoConcepto = Convert.ToInt16(dr["idGrupoConcepto"]);
                itmConceptoPago.CodCurso = Convert.ToString(dr["CodCurso"]);
                itmConceptoPago.idConceptoSede = Convert.ToInt16(dr["idConceptoSede"]);
                itmConceptoPago.Tipo = Convert.ToString(dr["Tipo"]);
                itmConceptoPago.Concepto = Convert.ToString(dr["Concepto"]);
                itmConceptoPago.Monto = Convert.ToDecimal(dr["Monto"]);
                itmConceptoPago.IdSede = Convert.ToInt16(dr["IdSede"]);
                itmConceptoPago.Stock = Convert.ToString(dr["Stock"]);
                itmConceptoPago.idPrematricula = "";
                itmConceptoPago.Pagar = 0;
                itmConceptoPago.Dscto = 0;
                //itmConceptoPago.TipoMatricula = Convert.ToBoolean(dr["TipoMatricula"]);
                //itmConceptoPago.IdSituacionMatricula = Convert.ToInt16(dr["IdSituacionMatricula"]);
                //itmConceptoPago.PMatricula = Convert.ToBoolean(dr["PMatricula"]);
                //itmConceptoPago.IdMatricula = Convert.ToString(dr["IdMatricula"]);
            }
            conec.Close();
            return itmConceptoPago;
        }
        public List<beConceptoPago> PagosPorCiclo(string IdCiclo)
        {
            lisConceptoPago = new List<beConceptoPago>();
            cmm = new SqlCommand("CobranzaWeb.wsp_ComboByCiclo", conec);
            cmm.CommandType = CommandType.StoredProcedure;
            //cmm.Parameters.Add("@IdSede", SqlDbType.TinyInt).Value = IdSede;
            //cmm.Parameters.Add("@CodCurso", SqlDbType.VarChar, 20).Value = (CodCurso == null) ? "" : CodCurso;
            cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 20).Value = (IdCiclo == null) ? "" : IdCiclo;
            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();
            }
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                itmConceptoPago = new beConceptoPago();
                itmConceptoPago.intIdConceptoPago = 0;
                itmConceptoPago.idGrupoConcepto = Convert.ToInt16(dr["idGrupoConcepto"]);
                itmConceptoPago.CodCurso = Convert.ToString(dr["CodCurso"]);
                itmConceptoPago.idConceptoSede = Convert.ToInt16(dr["idConceptoSede"]);
                itmConceptoPago.Tipo = Convert.ToString(dr["Tipo"]);
                itmConceptoPago.Concepto = Convert.ToString(dr["Concepto"]);
                itmConceptoPago.Monto = Convert.ToDecimal(dr["Monto"]);
                itmConceptoPago.IdSede = Convert.ToInt16(dr["IdSede"]);
                itmConceptoPago.Stock = Convert.ToString(dr["Stock"]);
                itmConceptoPago.idPrematricula = "";
                itmConceptoPago.Pagar = 0;
                itmConceptoPago.Dscto = 0;
                itmConceptoPago.TipoMatricula = Convert.ToBoolean(dr["TipoMatricula"]);
                itmConceptoPago.IdSituacionMatricula = Convert.ToInt16(dr["IdSituacionMatricula"]);
                itmConceptoPago.PMatricula = Convert.ToBoolean(dr["PMatricula"]);
                itmConceptoPago.IdMatricula = Convert.ToString(dr["IdMatricula"]);
                lisConceptoPago.Add(itmConceptoPago);
            }
            conec.Close();
            return lisConceptoPago;
        }
        public beConceptoPago PagoMatricula(int IdSede, int IdInstitucion =1)
        {
            itmConceptoPago = new beConceptoPago();
            cmm = new SqlCommand("CobranzaWeb.usp_ConceptoSede_Buscar", conec);
            cmm.CommandType = CommandType.StoredProcedure;
            //cmm.Parameters.Add("@Tipo", SqlDbType.TinyInt).Value = 0;
            cmm.Parameters.Add("@Descripcion", SqlDbType.VarChar,50).Value = "MATRICULA";
            cmm.Parameters.Add("@IdSede", SqlDbType.TinyInt).Value = IdSede;
            //cmm.Parameters.Add("@IdInstitucion", SqlDbType.TinyInt).Value = IdInstitucion;
            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();
            }
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                itmConceptoPago.intIdConceptoPago = Convert.ToInt16(dr["IdConcepto"]);
                itmConceptoPago.idConceptoSede = Convert.ToInt16(dr["IdConceptoSede"]);
                itmConceptoPago.idGrupoConcepto = Convert.ToInt16(dr["IdConceptoSede"]);
                itmConceptoPago.Tipo = Convert.ToString(dr["Tipo"]);
                itmConceptoPago.Concepto = Convert.ToString(dr["Concepto"]);
                itmConceptoPago.IdSede = Convert.ToInt16(dr["IdSede"]);
                itmConceptoPago.Monto = Convert.ToDecimal(dr["Monto"]);
                itmConceptoPago.Pagar = Convert.ToDecimal(dr["Pagar"]); 
                itmConceptoPago.Dscto = Convert.ToDecimal(dr["Dscto"]); 
                itmConceptoPago.Stock = Convert.ToString(dr["Stock"]); ;
                itmConceptoPago.CodCurso = "";
                itmConceptoPago.idPrematricula = "";
                //itmConceptoPago.TipoMatricula = Convert.ToBoolean(dr["TipoMatricula"]);
                //itmConceptoPago.IdSituacionMatricula = Convert.ToInt16(dr["IdSituacionMatricula"]);
                //itmConceptoPago.PMatricula = Convert.ToBoolean(dr["PMatricula"]);
                //itmConceptoPago.IdMatricula = Convert.ToString(dr["IdMatricula"]);
            }
            conec.Close();
            return itmConceptoPago;
        }
    }
}
