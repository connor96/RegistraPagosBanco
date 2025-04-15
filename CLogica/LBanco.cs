using CEntidades;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica
{
    public class LBanco
    {
        DBanco objBanco = new DBanco();
        Banco _banco;

        public Banco RetornarDeuda(string idAlumno)
        {
            _banco = new Banco();
            _banco = objBanco.RetornarDeuda(idAlumno);

            LProgramacion objprogramacion = new LProgramacion();
            EN_Programacion prog = new EN_Programacion();
            prog = objprogramacion.RetornarCodNivel(_banco.codcurso_siguiente);

            string Pensionregular;
            if (_banco.codcurso_siguiente == "B01")
            {
                Pensionregular = _banco.costo_pension;
            }
            else
            {
                Pensionregular = _banco.costo_pension;
                Pensionregular = validarpension(Pensionregular, prog.codnivel, prog.curso).ToString();
            }
            _banco.costo_pension = Pensionregular;
            _banco.total_pagar = validarsuma(_banco);

            return _banco;
        }


        public Banco RetornarDeudaAcademico(string idAlumno)
        {
            _banco = new Banco();
            _banco = objBanco.RetornarDeudaAcademico(idAlumno);

            LProgramacion objprogramacion = new LProgramacion();
            EN_Programacion prog = new EN_Programacion();
            prog = objprogramacion.RetornarCodNivel(_banco.codcurso_siguiente);

            string Pensionregular;
            if (_banco.codcurso_siguiente == "B01")
            {
                Pensionregular = _banco.costo_pension;
            }
            else
            {
                Pensionregular = _banco.costo_pension;
                Pensionregular = validarpension(Pensionregular, prog.codnivel, prog.curso).ToString();
            }
            _banco.costo_pension = Pensionregular;
            _banco.total_pagar = validarsuma(_banco);

            return _banco;
        }


        private int validarsuma(Banco banco)
        {
            return banco.total_pagar = int.Parse(banco.costo_matricula) + int.Parse(banco.costo_pension) + int.Parse(banco.costo_deuda) + int.Parse(banco.costo_mora);
        }

        private object validarpension(string pension, string nivel, string codcurso)
        {
            switch (nivel)
            {
                case "O":
                    return "190";
                case "KSS":
                    switch (codcurso)
                    {
                        case "KSS1S":
                            return 220;
                        default:
                            return 165;
                    }

                case "PKES":
                    return 200;
                case "KES":
                    return 200;
                case "KD":
                    return 240;
                case "KS":
                    switch (codcurso)
                    {
                        case "K01S":
                            return 190;
                        default:
                            return 190;
                    }
                case "CS":
                    switch (codcurso)
                    {
                        case "C01S":
                            return 190;
                        default:
                            return 190;
                    }
                case "YS":
                    return 190;
                case "JRS":
                    return 190;
                case "JRD":
                    return 240;
                case "PTS":
                    return 190;
                case "TES":
                    return 190;
                case "B":
                    switch (codcurso)
                    {
                        case "B01":
                            return 190;
                        case "B02":
                        case "B03":
                        case "B04":
                        case "B05":
                        case "B06":
                        case "B07":
                        case "B08":
                        case "B09":
                        case "B10":
                        case "B11":
                        case "B12":
                            return 225;
                        default:
                            return 0;
                    }

                case "I":
                    //case "I02":
                    //case "I03":
                    //case "I04":
                    //case "I05":
                    //case "I06":
                    //case "I07":
                    //case "I08":
                    //case "I09":
                    //case "I10":
                    //case "I11":
                    //case "I12":
                    return 230;
                case "A":
                    //case "A02":
                    //case "A03":
                    //case "A04":
                    //case "A05":
                    //case "A06":
                    //case "A07":
                    //case "A08":
                    //case "A09":
                    //case "A10":
                    //case "A11":
                    //case "A12":
                    //case "A10 - A12":
                    return 240;
                case "MET":
                    //case "MET2":
                    //case "MET3":
                    //case "MET4":
                    //case "MET5":
                    //case "MET6":
                    return 290;
                default:
                    return 0;
            }
        }
        /*public Banco RetornarDeudaAntiguo(string idAlumno)
{
   return objBanco.RetornarDeudaAntiguo(idAlumno);
}*/
    }
}
