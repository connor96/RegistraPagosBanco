using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades
{
    public class EN_Voucher
    {
        public string IdTransaccion { get; set; }
        public int IdSede { get; set; }
        public string IdPersona { get; set; }
        public string DNI { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string IdCiclo { get; set; }
        public string Descurso { get; set; }
        public string Horario { get; set; }
        public string NomBanco { get; set; }
        public int IdConcepto { get; set; }
        public string Desconcepto { get; set; }
        public bool RegistradoC34 { get; set; }
        public string NroOperacion { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string FechaTexto { get; set; }
        public int Monto { get; set; }
        public string Urlvoucher { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Tipo { get; set; }
        public List<EN_Conceptos> conceptos { get; set; }
        public string Periodo { get; set; }
        public string radio { get; set; }
        public EN_Alumno alumno { get; set; }
        public bool Eliminado { get; set; }
        public string Motivo { get; set; }
        public string PeriodoString { get; set; }
        public string Hora { get; set; }
        public string terminalRegistro { get; set; }
    }
}
