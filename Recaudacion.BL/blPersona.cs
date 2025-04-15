using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blPersona
    {
        bePersona itmPersona;
        //List<bePersona> lisPersona;
        daPersona objPersona = new daPersona();
        public List<bePersona> Buscar(string strOpcion, string strBuscar)
        {
            return objPersona.Buscar(strOpcion, strBuscar);
        }
        public bePersona Detalle(string IdPersona)
        {
            itmPersona = new bePersona();
            itmPersona = objPersona.Detalle(IdPersona);
            return itmPersona;
        }
    }
}
