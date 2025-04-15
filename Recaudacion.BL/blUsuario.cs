using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blUsuario
    {
        beReturn itmReturn;
        beUsuario itmUsuario;
        daUsuario objUsuario = new daUsuario();
        public beUsuario Detalle(string IdUser)
        {
            itmUsuario = new beUsuario();
            itmUsuario = objUsuario.Detalle(IdUser);
            return itmUsuario;
        }
        public beReturn Insert(beUsuario myitmUsuario)
        {
            itmReturn = new beReturn();
            itmReturn = objUsuario.Insert(myitmUsuario);
            return itmReturn;
        }
        public beReturn Inactivar(string IdUser)
        {
            itmReturn = new beReturn();
            itmReturn = objUsuario.Inactivar(IdUser);
            return itmReturn;
        }
        public beReturn RestaurarClave(string IdUser)
        {
            itmReturn = new beReturn();
            itmReturn = objUsuario.RestaurarClave(IdUser);
            return itmReturn;
        }
        public beReturn CambiarClave(string IdUser, string Clave)
        {
            itmReturn = new beReturn();
            itmReturn = objUsuario.CambiarClave(IdUser, Clave);
            return itmReturn;
        }

    }
}
