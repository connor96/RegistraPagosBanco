using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blUsuarioDatos
    {
        beUsuarioDatos itmUsuarioDatos;
        List<beUsuarioDatos> lisUsuarioDatos;

        daUsuarioDatos objUsuarioDatos = new daUsuarioDatos();
        public beUsuarioDatos Detalle(string IdUser)
        {
            itmUsuarioDatos = new beUsuarioDatos();
            itmUsuarioDatos = objUsuarioDatos.Detalle(IdUser);
            return itmUsuarioDatos;
        }
        public List<beUsuarioDatos> BuscaExistentes()
        {
            lisUsuarioDatos = new List<beUsuarioDatos>();
            lisUsuarioDatos = objUsuarioDatos.BuscaExistentes();
            return lisUsuarioDatos;
        }
        public List<beUsuarioDatos> BuscaNuevos(string IdUser = "")
        {
            lisUsuarioDatos = new List<beUsuarioDatos>();
            lisUsuarioDatos = objUsuarioDatos.BuscaNuevos(IdUser);
            return lisUsuarioDatos;
        }
    }
}
