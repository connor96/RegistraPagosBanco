using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blTipoDocumento
    {
        daTipoDocumento objTipoDocumento = new daTipoDocumento();
        public List<beTipoDocumento> ListaTipoDocumento()
        {
            return objTipoDocumento.ListaTipoDocumento();
        }
    }
}
