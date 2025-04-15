using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blActivarDatos
    {
        beActivarDatos itmActivarDatos;
        List<beActivarDatos> lisActivarDatos;
        daActivarDatos objActivarDatos = new daActivarDatos();
        beReturn itmReturn;
        public beActivarDatos Detalle(int id)
        {
            itmActivarDatos = new beActivarDatos();
            itmActivarDatos = objActivarDatos.Detalle(id);
            return itmActivarDatos;
        }
        public List<beActivarDatos> Activos()
        {
            lisActivarDatos = new List<beActivarDatos>();
            lisActivarDatos = objActivarDatos.Activos();
            return lisActivarDatos;
        }
        public int ActivosInt()
        {
            return objActivarDatos.ActivosInt();
        }
        public beReturn Insert(beActivarDatos myitmActivarDatos)
        {
            itmReturn = new beReturn();
            itmReturn = objActivarDatos.Insert(myitmActivarDatos);
            return itmReturn;
        }
        public beReturn Delete(int intIdActivarDatos)
        {
            itmReturn = new beReturn();
            itmReturn = objActivarDatos.Delete(intIdActivarDatos);
            return itmReturn;
        }
    }
}
