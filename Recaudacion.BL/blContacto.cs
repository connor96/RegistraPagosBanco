using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blContacto
    {
        List<beContacto> lisContacto;
        beContacto itmContacto;
        beReturn itmReturn;

        daContacto objContacto = new daContacto();
        public List<beContacto> Lista(string strIdPersona)
        {
            lisContacto = new List<beContacto>();
            lisContacto = objContacto.Lista(strIdPersona);
            return lisContacto;
        }
        public beReturn Insert(beContacto myitmContacto)
        {
            itmReturn = new beReturn();
            itmReturn = objContacto.Insert(myitmContacto);
            return itmReturn;
        }
        public beReturn Delete(Guid guiRowguid)
        {
            itmReturn = new beReturn();
            itmReturn = objContacto.Delete(guiRowguid);
            return itmReturn;
        }
    }
}
