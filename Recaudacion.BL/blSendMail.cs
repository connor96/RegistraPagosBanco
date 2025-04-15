using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blSendMail
    {
        beSendMail itmSendMail;
        beReturn itmReturn;
        daSendMail objSendMail = new daSendMail();
        public beSendMail Detalle()
        {
            itmSendMail = new beSendMail();
            itmSendMail = objSendMail.Detalle();
            return itmSendMail;
        }
        public beReturn Insert(beSendMail myitmSendMail)
        {
            itmReturn = new beReturn();
            itmReturn = objSendMail.Insert(myitmSendMail);
            return itmReturn;
        }
        public beReturn Update(beSendMail myitmSendMail)
        {
            itmReturn = new beReturn();
            itmReturn = objSendMail.Update(myitmSendMail);
            return itmReturn;
        }
        public beReturn UpdateMacros(beSendMail myitmSendMail)
        {
            itmReturn = new beReturn();
            itmReturn = objSendMail.UpdateMacros(myitmSendMail);
            return itmReturn;
        }
        public beReturn UpdateHeader(beSendMail myitmSendMail)
        {
            itmReturn = new beReturn();
            itmReturn = objSendMail.UpdateHeader(myitmSendMail);
            return itmReturn;
        }
        public beReturn UpdateFooter(beSendMail myitmSendMail)
        {
            itmReturn = new beReturn();
            itmReturn = objSendMail.UpdateFooter(myitmSendMail);
            return itmReturn;
        }
    }
}
