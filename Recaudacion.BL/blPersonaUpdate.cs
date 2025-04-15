using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blPersonaUpdate
    {
        bePersona itmPersona;
        bePersonaUpdate itmPersonaUpdate;
        beNombreVia itmNombreVia;
        beDenominacionUrbana itmDenominacionUrbana;
        beDistrito itmDistrito;
        beReturn itmReturn;
        daPersona objPersona = new daPersona();
        daPersonaUpdate objPersonaUpdate = new daPersonaUpdate();
        daNombreVia objNombreVia = new daNombreVia();
        daDenominacionUrbana objDenominacionUrbana = new daDenominacionUrbana();
        blDistrito objDistrito = new blDistrito();
        public bePersonaUpdate Detalle(string IdPersona)
        {
            itmPersona = new bePersona();
            itmPersonaUpdate = new bePersonaUpdate();
            itmNombreVia = new beNombreVia();
            itmDenominacionUrbana = new beDenominacionUrbana();
            itmPersona = objPersona.Detalle(IdPersona);
            itmPersonaUpdate.IdPersona = itmPersona.IdPersona;
            itmPersonaUpdate.IdOcupacion = itmPersona.IdOcupacion;
            itmPersonaUpdate.CodUbigeo = itmPersona.CodUbigeo;
            itmPersonaUpdate.IdTipoVia = itmPersona.IdTipoVia;
            //itmPersonaUpdate.NombreVia = itmPersona.NombreVia;
            itmNombreVia = objNombreVia.Detalle(itmPersona.IdNombreVia);
            itmDenominacionUrbana = objDenominacionUrbana.Detalle(itmPersona.IdDenominacionUrbana);
            itmPersonaUpdate.NombreVia = itmNombreVia.DesNombreVia;
            itmPersonaUpdate.DenominacionUrbana = itmDenominacionUrbana.DesDenominacionUrbana;
            itmPersonaUpdate.IdTipoDocumento = itmPersona.IdTipoDocumento;
            itmPersonaUpdate.Nombres1 = itmPersona.Nombres1;
            itmPersonaUpdate.Nombres2 = itmPersona.Nombres2;
            itmPersonaUpdate.ApellidoPaterno = itmPersona.ApellidoPaterno;
            itmPersonaUpdate.ApellidoMaterno = itmPersona.ApellidoMaterno;
            itmPersonaUpdate.DNI = itmPersona.DNI;
            itmPersonaUpdate.FNacimiento = itmPersona.FNacimiento;
            itmPersonaUpdate.Sexo = itmPersona.Sexo;
            itmPersonaUpdate.TipoDireccion = itmPersona.TipoDireccion;
            itmPersonaUpdate.Numero = itmPersona.Numero;
            //itmPersonaUpdate.IdLocal = itmPersona.IdLocal;
            itmPersonaUpdate.IdLocal = 4;
            itmPersonaUpdate.Estado = itmPersona.Estado;
            itmPersonaUpdate.Terminal = itmPersona.TerminalRegistro;
            itmPersonaUpdate.User = itmPersona.UserRegistro;
            itmPersonaUpdate.Email = itmPersona.Email;
            itmPersonaUpdate.itmDistrito = new beDistrito();
            itmPersonaUpdate.itmDistrito = objDistrito.Detalle(itmPersonaUpdate.CodUbigeo);

            return itmPersonaUpdate;
        }

        public beReturn Update(bePersonaUpdate myitmPersonaUp)
        {
            itmReturn = new beReturn();
            itmReturn = objPersonaUpdate.Update(myitmPersonaUp);
            return itmReturn;
        }
    }
}
