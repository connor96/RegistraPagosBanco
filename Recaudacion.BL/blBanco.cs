using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blBanco
    {
        List<beBanco> lisBanco;
        beBanco itmBanco;
        beReturn itmReturn;
        daBanco objBanco = new daBanco();

        public List<beBanco> Lista()
        {
            lisBanco = new List<beBanco>();
            lisBanco = objBanco.Lista();
            return lisBanco;
        }
        public beBanco Detalle(int intIdBanco)
        {
            itmBanco = new beBanco();
            itmBanco = objBanco.Detalle(intIdBanco);
            return itmBanco;
        }
        public beReturn Insert(beBanco myitmBanco)
        {
            itmReturn = new beReturn();
            itmReturn = objBanco.Insert(myitmBanco);
            return itmReturn;
        }
        public beReturn Update(beBanco myitmBanco)
        {
            itmReturn = new beReturn();
            itmReturn = objBanco.Update(myitmBanco);
            return itmReturn;
        }
    }
}
