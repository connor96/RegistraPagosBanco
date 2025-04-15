using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blCredencial
    {
        beCredencial itmCredencial;
        daCredencial objCredencial = new daCredencial();
        public beCredencial Credencial(string strIdPersona, string strClave)
        {
            return objCredencial.Credencial(strIdPersona, strClave);
        }
        public beUsuario CredencialAdministrativo(string IdUser, string strClave)
        {
            return objCredencial.CredencialAdministrativo(IdUser, strClave);
        }
    }
}
