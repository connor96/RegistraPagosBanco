using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blNombreVia
    {
        beNombreVia itmNombreVia;
        List<beNombreVia> lisNombreVia;
        daNombreVia objNombreVia = new daNombreVia();
        public beNombreVia Detalle(string IdNombreVia)
        {
            itmNombreVia = new beNombreVia();
            itmNombreVia = objNombreVia.Detalle(IdNombreVia);
            return itmNombreVia;
        }
        public List<beNombreVia> Lista(string DesNombreVia)
        {
            lisNombreVia = new List<beNombreVia>();
            lisNombreVia = objNombreVia.Lista(DesNombreVia);
            return lisNombreVia;
        }
    }
}
