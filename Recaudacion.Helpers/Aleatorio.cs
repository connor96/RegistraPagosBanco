using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.Helpers
{
    public class Aleatorio
    {
        public string Clave(int Longitud)
        {
            Random obj = new Random();
            string posibles = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int longitudcadena = posibles.Length;
            char lerta;
            string nuevacadena = "";
            for (int i = 0; i < Longitud; i++)
            {
                lerta = posibles[obj.Next(longitudcadena)];
                nuevacadena += lerta.ToString();
            }
            return nuevacadena;
        }
    }
}
