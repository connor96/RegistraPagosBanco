using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blDistrito
    {
        beDistrito itmDistrito;
        List<beDistrito> lisDistrito;
        daDistrito objDistrito = new daDistrito();
        public beDistrito Detalle(string CodUbigeo)
        {
            itmDistrito = new beDistrito();
            itmDistrito = objDistrito.Detalle(CodUbigeo);
            return itmDistrito;
        }
        public List<beDistrito> ListaPorProvincia(string CodDepartamento, string CodProvincia)
        {
            lisDistrito = new List<beDistrito>();
            lisDistrito = objDistrito.ListaPorProvincia(CodDepartamento, CodProvincia);
            return lisDistrito;
        }
    }
}
