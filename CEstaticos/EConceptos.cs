using CEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEstaticos
{
    public static class EConceptos
    {

        static List<EN_Conceptos> _LConceptos;
        static EConceptos()
        {
            _LConceptos = new List<EN_Conceptos>();
        }

        public static void AddValue(EN_Conceptos concepto)
        {

            switch (concepto.IdConcepto)
            {
                case 6:
                    if (int.Parse(concepto.Monto) > 0)
                    {
                        concepto.Activo = false;
                        EMontosCargados.AddMontos(concepto);
                    }
                    break;
                case 29:
                    if (int.Parse(concepto.Monto) > 0)
                    {
                        concepto.Activo = false;
                        EMontosCargados.AddMontos(concepto);
                    }
                    break;
                case 28:
                    if (int.Parse(concepto.Monto) > 0)
                    {
                        concepto.Activo = true;
                        EMontosCargados.AddMontos(concepto);
                        _LConceptos.Add(concepto);
                    }
                    else
                    {
                        concepto.Activo = true;
                        _LConceptos.Add(concepto);
                    }

                    break;

                case 37:
                    if (int.Parse(concepto.Monto) > 0)
                    {
                        concepto.Activo = true;
                        EMontosCargados.AddMontos(concepto);
                        _LConceptos.Add(concepto);
                    }
                    else
                    {
                        concepto.Activo = true;
                        _LConceptos.Add(concepto);
                    }

                    break;

                default:
                    concepto.Activo = true;
                    _LConceptos.Add(concepto);
                    break;
            }

        }

        public static void UpdateValue(EN_Conceptos concepto)
        {
            foreach (var item in _LConceptos)
            {
                if (concepto.IdConcepto == item.IdConcepto)
                {
                    item.DesConcepto = concepto.DesConcepto;
                    item.Monto = concepto.Monto;
                }
            }
        }

        public static EN_Conceptos DevolverDatos(int id)
        {
            EN_Conceptos concepto = new EN_Conceptos();
            foreach (var item in _LConceptos)
            {
                if (id == item.IdConcepto)
                {
                    concepto = item;
                }
            }
            return concepto;
        }

        public static List<EN_Conceptos> RetornarDatos()
        {
            return _LConceptos;
        }

        public static void LimpiarLista()
        {
            _LConceptos.Clear();
        }


    }
}
