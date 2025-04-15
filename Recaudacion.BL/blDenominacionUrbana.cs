using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blDenominacionUrbana
    {
        beDenominacionUrbana itmDenominacionUrbana;
        List<beDenominacionUrbana> lisDenominacionUrbana;
        daDenominacionUrbana objDenominacionUrbana = new daDenominacionUrbana();
        public beDenominacionUrbana Detalle(string IdDenominacionUrbana)
        {
            itmDenominacionUrbana = new beDenominacionUrbana();
            itmDenominacionUrbana = objDenominacionUrbana.Detalle(IdDenominacionUrbana);
            return itmDenominacionUrbana;
        }
        public List<beDenominacionUrbana> Lista(string DesDenominacionUrbana)
        {
            lisDenominacionUrbana = new List<beDenominacionUrbana>();
            lisDenominacionUrbana = objDenominacionUrbana.Lista(DesDenominacionUrbana);
            return lisDenominacionUrbana;
        }
    }
}
