using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blConceptoPago
    {
        beConceptoPago itmConceptoPago;
        List<beConceptoPago> lisConceptoPago;
        beReturn itmReturn;
        daConceptoPago objConceptoPago = new daConceptoPago();
        public List<beConceptoPago> listarConceptoPagos(string idPrematricula)
        {
            lisConceptoPago = new List<beConceptoPago>();
            lisConceptoPago = objConceptoPago.listarConceptoPagos(idPrematricula);
            return lisConceptoPago;
        }
        public beReturn Insert(beConceptoPago myitmConceptoPago)
        {
            itmReturn = new beReturn();
            itmReturn = objConceptoPago.Insert(myitmConceptoPago);
            return itmReturn;
        }

        public beReturn InsertByCiclo(string IdCiclo, string idPrematricula)
        {
            itmReturn = new beReturn();
            itmReturn = objConceptoPago.InsertByCiclo(IdCiclo, idPrematricula);
            return itmReturn;
        }
        //public beConceptoPago PagosPorCurso(int IdSede, string CodCurso, string IdCiclo)
        public beConceptoPago PagosPorCurso(string IdCiclo)
        {
            itmConceptoPago = new beConceptoPago();
            //itmConceptoPago = objConceptoPago.PagosPorCurso(IdSede, CodCurso, IdCiclo);
            itmConceptoPago = objConceptoPago.PagosPorCurso(IdCiclo);
            return itmConceptoPago;
        }
        public List<beConceptoPago> PagosPorCiclo(string IdCiclo)
        {
            lisConceptoPago = new List<beConceptoPago>();
            //itmConceptoPago = objConceptoPago.PagosPorCurso(IdSede, CodCurso, IdCiclo);
            lisConceptoPago = objConceptoPago.PagosPorCiclo(IdCiclo);
            return lisConceptoPago;
        }
        public beConceptoPago PagoMatricula(int IdSede, int IdInstitucion =1)
        {
            itmConceptoPago = new beConceptoPago();
            itmConceptoPago = objConceptoPago.PagoMatricula(IdSede, IdInstitucion);
            return itmConceptoPago;
        }
    }
}
