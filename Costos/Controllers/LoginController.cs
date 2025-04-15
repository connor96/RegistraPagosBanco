using CLogica;
using CEntidades;
using Microsoft.AspNetCore.Mvc;
using Costos.Attribute;
using System.Xml.Linq;
using iText;

namespace Costos.Controllers
{
    public class LoginController : Controller
    {

        public ISession Sesion => HttpContext.Session;
        LLogin objLogin = new LLogin();
        LBanco objBanco = new LBanco();
        Banco _banco;
        string IdAlumno = "";
        public IActionResult Index()
        {

            return View();
        }

        public JsonResult Loguearse(string usuario, string password)
        {


            string hostname=System.Net.Dns.GetHostName();

            Console.Write(hostname);

            _banco = new Banco();
            Sesion.SetString("listconceptos", "");

            Login log = new Login();
            log.usuario = usuario;
            log.password = password;
            string resultado;
            resultado = objLogin.Ingresar(log);
            IdAlumno = resultado;
            if (resultado != "")
            {
                _banco = objBanco.RetornarDeudaAcademico(resultado);
                //Id Persona
                Sesion.SetString("idPersona", resultado);
                //Cod curso que le toca
                Sesion.SetString("codCursoglobal", _banco.codcurso_siguiente);
                //Puntaje objtenido al final del ciclo
                Sesion.SetString("notafinalciclo", _banco.nota_final);
                //Tipo de alumno
                Sesion.SetString("tipoAlumno", _banco.estado);
                //Codigo del curso que le toca al ciclo siguiente
                Sesion.SetString("codCursoallevarmessiguiente", _banco.codcurso_siguiente);
                if (_banco.estado == "NNN")
                {
                    //Ninio estado ver archivo js
                    Sesion.SetString("estadoNinios", _banco.estado_ninios);
                }
                else
                {
                    //Estado normal
                    Sesion.SetString("estadoNinios", "0");
                }
                return Json(resultado);
            }
            else
            {
                return Json("incorrect");
            }
        }

        [SessionTimeout]
        public ActionResult Salir()
        {
            Sesion.Clear();
            return RedirectToAction("Index", "Login");
        }


    }


    //class HeaderFooter : PdfPageEventHelper
    //{
    //    string PathImage = null;
    //    public HeaderFooter(string LogoPath)
    //    {
    //        PathImage = LogoPath;
    //    }

    //    public override void OnEndPage(PdfWriter writer, Document document)
    //    {
    //        PdfPTable tbHeader = new PdfPTable(3);
    //        tbHeader.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
    //        tbHeader.DefaultCell.Border = 0;

    //        tbHeader.AddCell(new Paragraph());

    //        PdfPCell _cell = new PdfPCell(new Paragraph("ICPNA Región Centro - donde sí se aprende inglés"));
    //        _cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //        _cell.Border = 0;

    //        tbHeader.AddCell(_cell);
    //        tbHeader.AddCell(new Paragraph());

    //        tbHeader.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetTop(document.TopMargin) + 40, writer.DirectContent);



    //        PdfPTable tbfooter = new PdfPTable(3);
    //        tbfooter.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
    //        tbfooter.DefaultCell.Border = 0;

    //        tbfooter.AddCell(new Paragraph());

    //        _cell = new PdfPCell(new Paragraph("ICPNA Región Centro - donde sí se aprende inglés"));
    //        _cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //        _cell.Border = 0;

    //        tbfooter.AddCell(_cell);

    //        _cell = new PdfPCell(new Paragraph("Pagina" + writer.PageNumber));
    //        _cell.HorizontalAlignment = Element.ALIGN_RIGHT;
    //        _cell.Border = 0;

    //        tbfooter.AddCell(_cell);
    //        tbfooter.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetBottom(document.BottomMargin) - 5, writer.DirectContent);


    //        Image logo = Image.GetInstance(PathImage);
    //        logo.SetAbsolutePosition(document.LeftMargin, writer.PageSize.GetTop(document.TopMargin));
    //        logo.ScaleAbsolute(80f, 40f);
    //        document.Add(logo);


    //    }


    //}


}
