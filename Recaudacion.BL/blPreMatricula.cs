using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blPreMatricula
    {
        bePreMatricula itmPreMatricula;
        daPreMatricula objPrematricula = new daPreMatricula();
        blPersona objPersona = new blPersona();
        beReturn itmReturn;
        List<bePreMatricula> lisPreMatricula;
        blCiclo objCiclo = new blCiclo();
        beCiclo itmCiclo;
        public beReturn Registrar(bePreMatricula myitmPreMatricula)
        {
            itmReturn = new beReturn();
            itmReturn = objPrematricula.Registrar(myitmPreMatricula);
            return itmReturn;
        }
        public bool Registro(int Opcion, bePreMatricula myitmPreMatricula)
        {
            return objPrematricula.Registro(Opcion, myitmPreMatricula);
        }
        public bePreMatricula Detalle(Guid IdPreMatricula)
        {
            itmPreMatricula = new bePreMatricula();
            itmPreMatricula = objPrematricula.Detalle(IdPreMatricula);
            itmPreMatricula.itmPersona = objPersona.Detalle(itmPreMatricula.IdAlumno);
            itmPreMatricula.itmCiclo = objCiclo.detalle(itmPreMatricula.IdCiclo);
            return itmPreMatricula;
        }
        public List<bePreMatricula> ListarPorUsuario(string idPersona)
        {
            lisPreMatricula = new List<bePreMatricula>();
            lisPreMatricula = objPrematricula.ListarPorUsuario(idPersona);
            //foreach (var item in lisPreMatricula)
            //{
            //    itmCiclo = new beCiclo();
            //    //itmPreMatricula.itmCiclo = new beCiclo();
            //    itmCiclo = objCiclo.detalle(item.IdCiclo);
            //    //itmPreMatricula.itmCiclo = itmCiclo;
            //}
            return lisPreMatricula;
        }
        public List<bePreMatricula> ListarPorFecha(DateTime fecha)
        {
            lisPreMatricula = new List<bePreMatricula>();
            lisPreMatricula = objPrematricula.ListarPorFecha(fecha);
            return lisPreMatricula;
        }
        public List<bePreMatricula> ListarParaTransmision()
        {
            lisPreMatricula = new List<bePreMatricula>();
            lisPreMatricula = objPrematricula.ListarParaTransmision();
            return lisPreMatricula;
        }
    }
}
