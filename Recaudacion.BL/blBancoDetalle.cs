using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blBancoDetalle
    {
        List<beBancoDetalle> lisBancoDetalle;
        beBancoDetalle itmBancoDetalle;
        beReturn itmReturn;
        daBancoDetalle objBancoDetalle = new daBancoDetalle();
        blBanco objBanco = new blBanco();
        public List<beBancoDetalle> ListaPorBanco(int intIdBanco)
        {
            lisBancoDetalle = new List<beBancoDetalle>();
            lisBancoDetalle = objBancoDetalle.ListaPorBanco(intIdBanco);
            return lisBancoDetalle;
        }
        public beBancoDetalle Detalle(int intIdBancoDetalle)
        {
            itmBancoDetalle = new beBancoDetalle();
            itmBancoDetalle = objBancoDetalle.Detalle(intIdBancoDetalle);
            if (itmBancoDetalle.intIdBancoDetalle > 0)
            {
                itmBancoDetalle.itmBanco = objBanco.Detalle(itmBancoDetalle.intIdBanco);
            }
            return itmBancoDetalle;
        }
        public beReturn Insert(beBancoDetalle myitmbeBancoDetalle)
        {
            itmReturn = new beReturn();
            itmReturn = objBancoDetalle.Insert(myitmbeBancoDetalle);
            return itmReturn;
        }
        public beReturn Update(beBancoDetalle myitmbeBancoDetalle)
        {
            itmReturn = new beReturn();
            itmReturn = objBancoDetalle.Update(myitmbeBancoDetalle);
            return itmReturn;
        }
    }
}
