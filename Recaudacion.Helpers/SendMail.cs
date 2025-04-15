using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using Recaudacion.BE;
using Recaudacion.BL;
using Recaudacion.DA;

namespace Recaudacion.Helpers
{
    public class SendMail
    {
        static bool mailSent = false;
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
            mailSent = true;
        }

        public beError Send(string strDestinatario, string strAsunto, string strMensaje) //Main(string[] args)
        {
            beError itmError = new beError();
            beSendMail itmSendMail = new beSendMail();
            daSendMail objSendMail = new daSendMail();
            itmSendMail = objSendMail.Detalle();
            string[] _mail;
            if (itmSendMail.idSendMail > 0)
            {
                try
                {
                    string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
                    MailMessage msg = new MailMessage();
                    msg.To.Add(strDestinatario);
                    msg.From = new MailAddress(itmSendMail.strCuenta, itmSendMail.strTitular, System.Text.Encoding.UTF8);
                    msg.Subject = strAsunto;
                    msg.SubjectEncoding = System.Text.Encoding.UTF8;
                    msg.Body += itmSendMail.strHeader;
                    msg.Body += Environment.NewLine + strMensaje;
                    //msg.Body += Environment.NewLine + someArrows;
                    msg.Body += Environment.NewLine + itmSendMail.strFooter;
                    msg.BodyEncoding = System.Text.Encoding.UTF8;
                    msg.IsBodyHtml = true;

                    //Aquí es donde se hace lo especial
                    SmtpClient client = new SmtpClient();
                    // Cambir contraseña con de la cuenta de correo
                    client.Credentials = new NetworkCredential(itmSendMail.strCuenta, itmSendMail.strClave);
                    // habilitar los puertos TCP 465, 857 y 995
                    client.Port = itmSendMail.intPuerto;
                    //client.Host = "smtp.live.com"; //Hotmail
                    //client.Host = "smtp.gmail.com"; //Gmail
                    client.Host = itmSendMail.strHost;
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                    string userState = "test message1";

                    client.Send(msg);
                    //client.SendAsync(message, userState);
                    //client.SendAsyncCancel();
                    msg.Dispose();
                    _mail = strDestinatario.Split('@');
                    itmError.intIdError = 1;
                    itmError.strError = "El correo se envio correctamente, por favor revise su cuenta " + _mail[0].Substring(0,4)+new string('*',_mail[0].Length-4)+"@"+ _mail[1];
                }
                catch (Exception ex)
                {
                    itmError.intIdError = 0;
                    itmError.strError = "Ocurrio un error al enviar los datos: "+ ex.Message;
                    //throw new Exception(ex.Message);
                }
            }
            else
            {
                itmError.intIdError = 0;
                itmError.strError = "Ocurrio un error al enviar los datos: no se encontro datos de la cuenta HOST";
            }
            return itmError;
        }
    }
}