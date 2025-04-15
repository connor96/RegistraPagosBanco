using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades
{
    public class EN_PHoraria
    {
        public string idCiclo { get; set; }
        public string idsede { get; set; }
        public string sede { get; set; }
        public string desmallacurricular { get; set; }
        public string idmodalidad { get; set; }
        public string modalidad_eng { get; set; }
        public string modalidad_esp { get; set; }
        public string codnivel { get; set; }
        public string orden { get; set; }
        public string nivel { get; set; }
        public string curso { get; set; }
        public string frecuencia { get; set; }
        public string inicio { get; set; }
        public string final { get; set; }
        public string mes { get; set; }
        public string anio { get; set; }
        public string periodo { get; set; }
        public string codturno { get; set; }
        public string turno { get; set; }
        public string aula { get; set; }
        public string fullhora { get; set; }
        public string idturno { get; set; }
        public string Apellidos { get; set; }
        public string CodDocente { get; set; }
        public List<EN_Contacto> Contacto { get; set; }
        public List<EN_PHoraria> Programacion { get; set; }
        public bool presencial { get; set; }
        public int Vacantes { get; set; }
        public bool Visible { get; set; }
    }
}
