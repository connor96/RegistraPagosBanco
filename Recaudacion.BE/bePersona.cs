using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Recaudacion.BE
{
    public class bePersona
    {
        public string IdPersona { get; set; }
        public short IdOcupacion { get; set; }
        public string CodUbigeo { get; set; }
        public byte IdTipoVia { get; set; }
        public string IdNombreVia { get; set; }
        public string IdDenominacionUrbana { get; set; }
        public byte IdTipoDocumento { get; set; }
        public string Nombres1 { get; set; }
        public string Nombres2 { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreCompleto { get; set; }
        public string DNI { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FNacimiento { get; set; }
        public string EdadDetallada { get; set; }
        public string Sexo { get; set; }
        public string TipoDireccion { get; set; }
        public string Numero { get; set; }
        public byte[] Picture { get; set; }
        public string OBS { get; set; }
        public System.Guid rowguid { get; set; }
        public byte Estado { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaRegistro { get; set; }
        public string TerminalRegistro { get; set; }
        public string UserRegistro { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaActualizacion { get; set; }
        public string TerminalActualizacion { get; set; }
        public string UserActualizacion { get; set; }
        public string C_Codigo { get; set; }
        public string Email { get; set; }
        public virtual beAlumno itmAlumno { get; set; }
        public virtual bePersonaInstitucion itmPersonaInstitucion { get; set; }
        //public virtual Docente Docente { get; set; }
        //public virtual Ocupacion Ocupacion { get; set; }
        //public virtual DenominacionUrbana DenominacionUrbana { get; set; }
        //public virtual Distrito Distrito { get; set; }
        //public virtual NombreVia NombreVia { get; set; }
        //public virtual TipoDocumento TipoDocumento { get; set; }
        //public virtual TipoVia TipoVia { get; set; }
    }
}
