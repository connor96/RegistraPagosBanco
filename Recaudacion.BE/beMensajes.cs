using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beMensajes
    {
        public static string Mensajes(enmListaErrores Opcion)
        {

        string strReturn = "";
            switch ((int)Opcion)
            {
                case 1:
                    strReturn = "Felicitaciones, los datos se guardaron correctamente";
                    break;
                case 2:
                    strReturn = "Lo sentimos, los datos NO se guardaron.";
                    break;
                case 3:
                    strReturn = "Felicitaciones, los datos se eliminaron correctamente";
                    break;
                case 4:
                    strReturn = "Lo sentimos, los datos NO se eliminaron.";
                    break;
                default:
                    break;
            }
            return strReturn;
        }
    }
    public enum enmListaErrores
    {
        Guardar_Ok = 1,
        Guardar_Error = 2,
        Eliminar_Ok = 3,
        Eliminar_Error = 4
    }
}
