using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades
{
    public class EN_Frecuencia
    {
        public string idTurno { get; set; }
        public List<EN_PHoraria> Programacion { get; set; }
    }
}
