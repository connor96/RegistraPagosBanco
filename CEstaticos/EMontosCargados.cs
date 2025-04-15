using CEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEstaticos
{
    public class EMontosCargados
    {

        static List<EN_Conceptos> _LConceptosCargados;
        static List<EN_Conceptos> _Cargados;

        static EMontosCargados()
        {
            _LConceptosCargados = new List<EN_Conceptos>();
        }

        public static void AddMontos(EN_Conceptos concepto)
        {
            _LConceptosCargados.Add(concepto);
        }

        public static void QuitarMonto(string id)
        {
            _Cargados = new List<EN_Conceptos>();
            foreach (var item in _LConceptosCargados)
            {
                if (item.IdConcepto != int.Parse(id))
                {
                    _Cargados.Add(item);
                }
            }

            _LConceptosCargados.Clear();

            foreach (var item in _Cargados)
            {
                _LConceptosCargados.Add(item);
            }
        }


        public static List<EN_Conceptos> ListarConceptos()
        {
            return _LConceptosCargados;
        }

        public static void ClearMontos()
        {
            _LConceptosCargados.Clear();
        }

    }
}
