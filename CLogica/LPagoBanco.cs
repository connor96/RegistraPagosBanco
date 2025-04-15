using CEntidades;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica
{
    public class LPagoBanco
    {
        DPagoProgramacion _objProgramacion;
        DPagoBanco _objPagos;
        public string pagosBanco(string idPersona)
        {
            _objPagos= new DPagoBanco();
            return _objPagos.opcionMatricula(idPersona);
        }

        public EN_BencoCursoCabecera cursosProgramacion(string idPersona)
        {
            _objProgramacion= new DPagoProgramacion();

            return _objProgramacion.opcionMatricula(idPersona);

        }

        public List<EN_BancoSede> listaSedesActivas(string codCurso)
        {
            _objProgramacion = new DPagoProgramacion();
            return _objProgramacion.listaSedesActivas(codCurso);
        }

        public string NE_RegistrarPrematricula(int v, string idCiclo, string? idPersona)
        {
            _objProgramacion = new DPagoProgramacion();

            return _objProgramacion.registrarPrematricula(v, idCiclo, idPersona);

        }

        public List<EN_BancoTablaPensiones> ListaTablaPensiones(string idPersona)
        {
            _objPagos = new DPagoBanco();
            return _objPagos.tablaPensiones(idPersona);
        }

        public List<string> ListaIdCiclo(string idPersona)
        {
            _objPagos = new DPagoBanco();
            return _objPagos.listaIdCiclos(idPersona);
        }

        public string CalcularTransaccionesTmp(string idPersona, string idCiclo)
        {
            _objPagos = new DPagoBanco();
            return _objPagos.CalcularTransaccionesTmp(idPersona, idCiclo);
        }

        public string RegistrarPago(string? idPersona, string correo, string telefono)
        {
            _objPagos = new DPagoBanco();

            return _objPagos.RegistrarPago(idPersona, correo, telefono);

        }

        public List<EN_PagoMatriculaA> PagoMatriculaA(string idPersona)
        {
            _objPagos= new DPagoBanco();
            return _objPagos.MatriculaPagoA(idPersona);
        }

        public EN_PagoMatriculaB PagoMatriculaB(string idPersona)
        {
            _objPagos = new DPagoBanco();
            return _objPagos.MatriculaPagoB(idPersona);
        }

        public List<EN_PagoMatriculaA> PagoDeuda(string idPersona)
        {
            _objPagos = new DPagoBanco();
            return _objPagos.PagoDeuda(idPersona);
        }

        public void actualizarDatos(string? idPersona, string correo, string telefono)
        {
            _objPagos = new DPagoBanco();
            _objPagos.actualizarDatos(idPersona, correo, telefono);
        }


    }
}
