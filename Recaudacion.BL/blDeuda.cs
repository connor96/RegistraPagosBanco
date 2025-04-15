using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blDeuda
    {
        beDeuda itmDeuda;
        List<beDeuda> lisDeuda;
        beReturn itmReturn;
        daDeuda objDeuda = new daDeuda();
        public List<beDeuda> listarDeuda(string idPrematricula)
        {
            lisDeuda = new List<beDeuda>();
            lisDeuda = objDeuda.listarDeuda(idPrematricula);
            return lisDeuda;
        }
        public beReturn Insert(beDeuda myitmDeuda)
        {
            itmReturn = new beReturn();
            itmReturn = objDeuda.Insert(myitmDeuda);
            return itmReturn;
        }
        public List<beDeuda> CalculaDeuda(string IdAlumno)
        {
            lisDeuda = new List<beDeuda>();
            lisDeuda = objDeuda.CalculaDeuda(IdAlumno);
            return lisDeuda;
        }

    }
}
