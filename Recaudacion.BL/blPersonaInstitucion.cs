using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blPersonaInstitucion
    {
        bePersonaInstitucion itmPersonaInstitucion;
        beReturn itmReturn;
        daPersonaInstitucion objPersonaInstitucion = new daPersonaInstitucion();

        public bePersonaInstitucion Detalle(string IdPersona)
        {
            itmPersonaInstitucion = new bePersonaInstitucion();
            itmPersonaInstitucion = objPersonaInstitucion.Detalle(IdPersona);
            return itmPersonaInstitucion;
        }

        public beReturn Update(bePersonaInstitucion myitmPersonaInstitucion)
        {
            itmReturn = new beReturn();
            itmReturn = objPersonaInstitucion.Update(myitmPersonaInstitucion);
            return itmReturn;
        }
    }
}
