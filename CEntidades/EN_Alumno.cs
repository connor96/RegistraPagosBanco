using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades
{
    public class EN_Alumno
    {
        public string IdAlumno { get; set; }
        public string DNI { get; set; }
        public DateTime fNacimiento { get; set; }
        public int edad { get; set; }
        public string fullname { get; set; }
        public string UltimoCiclo { get; set; }
        public string Direccion { get; set; }
        public string Referencia { get; set; }
        public int TipoActualizacion { get; set; }
    }
}
