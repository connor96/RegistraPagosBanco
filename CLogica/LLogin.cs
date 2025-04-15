using CEntidades;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica
{
    public class LLogin
    {
        DLogin objLogin = new DLogin();

        public string Ingresar(Login log)
        {
            string resultado;
            resultado = objLogin.Ingresar(log);
            return resultado;
        }

        public Login RetornarFullname(string idAlumno)
        {
            return objLogin.RetornaraAP(idAlumno);

        }
    }
}
