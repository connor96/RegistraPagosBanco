using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blRegistro
    {
        beRegistro itmRegistro;
        daRegistro objRegistro = new daRegistro();
        public string Registro(beRegistro myitmRegistro) {
            itmRegistro = new beRegistro();
            return objRegistro.Registro(myitmRegistro);
        }
    }
}
