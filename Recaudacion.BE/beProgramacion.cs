using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beProgramacion
    {
        public byte IdSede { get; set; }
        public byte IdInstitucion { get; set; }
        public short IdMallaCurricular { get; set; }
        public string strMes { get; set; }
        public Nullable<byte> Mes { get; set; }
        public string Yea { get; set; }
        public string IdPeriodo { get; set; }
        public string DesMallaCurricular { get; set; }
    }
}
