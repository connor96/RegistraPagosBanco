using CEntidades;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica
{
    public class LDeudaBanco
    {
        DDeuda objDeuda=new DDeuda();

        public EN_ObtenerDeudaCabecera cabeceraDeuda(string idPersona)
        {
            return objDeuda.ObtenerDeudaCabecera(idPersona);
        }

        public List<EN_ObtenerDeudaDeuda> listaDeudas(string idPersona)
        {
            return objDeuda.ObtenerDeudaContenido(idPersona);
        }

        public string registrarDeudaTmp(string idPersona)
        {
            return objDeuda.RegistrarDeudaTmp(idPersona);
        }

        public string registrarDeudaTransacciones(string idPersona)
        {
            return objDeuda.RegistrarDeudaTransacciones(idPersona);
        }

    }
}
