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
    public class daCicloUltimo
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beCicloUltimo itmCicloUltimo;
        beGradeCard itmGradeCard;
        public beCicloUltimo ListaCicloUltimoByUsuario(string idPersona)
        {
            itmCicloUltimo = new beCicloUltimo();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.usp_CicloUltimo", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar).Value = idPersona;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmCicloUltimo.IdMatricula = Convert.ToString(dr["IdMatricula"]);
                    itmCicloUltimo.IdComprobante = Convert.ToString(dr["IdComprobante"]);
                    itmCicloUltimo.IdAlumno = Convert.ToString(dr["IdAlumno"]);
                    itmCicloUltimo.FechaMatricula = Convert.ToDateTime(dr["FechaMatricula"]);
                    itmCicloUltimo.IdCiclo = Convert.ToString(dr["IdCiclo"]);
                    itmCicloUltimo.IdSede = Convert.ToByte(dr["IdSede"]);
                    itmCicloUltimo.IdAula = Convert.ToByte(dr["IdAula"]);
                    itmCicloUltimo.CodCurso = Convert.ToString(dr["CodCurso"]);
                    itmCicloUltimo.PreRequisito = Convert.ToString(dr["PreRequisito"]);
                    itmCicloUltimo.Mes = Convert.ToByte(dr["Mes"]);
                    itmCicloUltimo.Yea = Convert.ToString(dr["Yea"]);
                    itmCicloUltimo.Inicio = Convert.ToDateTime(dr["Inicio"]);
                    itmCicloUltimo.Final = Convert.ToDateTime(dr["Final"]);
                    itmCicloUltimo.NotaFinal = Convert.ToInt16(dr["NotaFinal"]);
                    itmCicloUltimo.FechaActual = Convert.ToDateTime(dr["FechaActual"]);
                    itmCicloUltimo.Meses = Convert.ToInt16(dr["Meses"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmCicloUltimo;
        }

        public beGradeCard GradeCard(string idPersona)
        {
            itmGradeCard = new beGradeCard();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.usp_GradeCard", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar).Value = idPersona;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmGradeCard.IdMatricula = Convert.ToString(dr["IdMatricula"]);
                    itmGradeCard.IdComprobante = Convert.ToString(dr["IdComprobante"]);
                    itmGradeCard.IdAlumno = Convert.ToString(dr["IdAlumno"]);
                    itmGradeCard.NombreCompleto = Convert.ToString(dr["NombreCompleto"]);
                    itmGradeCard.FechaMatricula = Convert.ToDateTime(dr["FechaMatricula"]);
                    itmGradeCard.IdCiclo = Convert.ToString(dr["IdCiclo"]);
                    itmGradeCard.IdSede = Convert.ToByte(dr["IdSede"]);
                    itmGradeCard.IdAula = Convert.ToByte(dr["IdAula"]);
                    itmGradeCard.DesAula = Convert.ToString(dr["DesAula"]);
                    itmGradeCard.DesTurno = Convert.ToString(dr["DesTurno"]);
                    itmGradeCard.HoraInicio = Convert.ToString(dr["HoraInicio"]);
                    itmGradeCard.HoraFinal = Convert.ToString(dr["HoraFinal"]);
                    itmGradeCard.CodCurso = Convert.ToString(dr["CodCurso"]);
                    itmGradeCard.DesCurso = Convert.ToString(dr["DesCurso"]);
                    itmGradeCard.DesNivelCurso = Convert.ToString(dr["DesNivelCurso"]);
                    itmGradeCard.PreRequisito = Convert.ToString(dr["PreRequisito"]);
                    itmGradeCard.strMes = Convert.ToString(dr["strMes"]);
                    itmGradeCard.Mes = Convert.ToByte(dr["Mes"]);
                    itmGradeCard.Yea = Convert.ToString(dr["Yea"]);
                    itmGradeCard.Inicio = Convert.ToDateTime(dr["Inicio"]);
                    itmGradeCard.Final = Convert.ToDateTime(dr["Final"]);
                    itmGradeCard.NotaFinal = Convert.ToInt16(dr["NotaFinal"]);
                    itmGradeCard.FechaActual = Convert.ToDateTime(dr["FechaActual"]);
                    itmGradeCard.Meses = Convert.ToInt16(dr["Meses"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmGradeCard;
        }
    }
}
