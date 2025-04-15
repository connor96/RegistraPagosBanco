using CEntidades;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica
{
    public class LHorarios
    {
        List<EN_PHoraria> Lista_PHoraria;
        List<EN_Frecuencia> Lista_Frecuencia;
        List<EN_Inicio> Lista_Inicio;
        DHorarios objDA = new DHorarios();

        public List<EN_PHoraria> NE_Listas_PHoraria(string opcion, string idsede, string anio, string mes, string codnivel, string modalidad, string curso, string frecuencia, string estado)
        {
            Lista_PHoraria = new List<EN_PHoraria>();

            if (estado == "NNN" || estado == "EUN")
            {
                Lista_PHoraria = objDA.Listas_PH_ninios(opcion, idsede, anio, mes, codnivel, modalidad, curso, frecuencia);
                return Lista_PHoraria;
            }
            else
            {
                Lista_PHoraria = objDA.Listas_PH(opcion, idsede, anio, mes, codnivel, modalidad, curso, frecuencia);
                return Lista_PHoraria;
            }
        }


        public List<EN_PHoraria> NE_Listas_ProgramacionHoraria(string curso)
        {
            Lista_PHoraria = new List<EN_PHoraria>();
            Lista_PHoraria = objDA.ListaSedes(curso);

            return Lista_PHoraria;
        }

        public List<EN_PHoraria> NE_Listas_ProgramacionFrecuencias(string sede,string curso)
        {
            Lista_PHoraria = new List<EN_PHoraria>();
            Lista_PHoraria = objDA.ListaFrecuencias(sede,curso);

            return Lista_PHoraria;
        }

        public List<EN_Frecuencia> NE_Listas_FHoraria(string opcion, string idsede, string anio, string mes, string codnivel, string modalidad, string curso, string frecuencia)
        {
            Lista_Frecuencia = new List<EN_Frecuencia>();
            Lista_Frecuencia = objDA.ListarFrecuencias(opcion, idsede, anio, mes, codnivel, modalidad, curso, frecuencia);
            return Lista_Frecuencia;
        }
        public List<EN_Inicio> NE_Listas_IHoraria(string mes, string anio)
        {
            Lista_Inicio = new List<EN_Inicio>();
            Lista_Inicio = objDA.Listar_Inicio(mes, anio);
            return Lista_Inicio;
        }

        
    }
}
