using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blDepartamento
    {
        beDepartamento itmDepartamento;
        List<beDepartamento> lisDepartamento;
        daDepartamento objDepartamento = new daDepartamento();
        public List<beDepartamento> Lista()
        {
            lisDepartamento = new List<beDepartamento>();
            lisDepartamento = objDepartamento.Lista();
            return lisDepartamento;
        }
    }
}
