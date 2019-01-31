using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Data;


namespace AppCorreo.Controllers
{
    public class CorreoController : Controller
    {
        // GET: Correo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EnviarCorreo()
        {
            return View();
        }
        public JsonResult SentCorreo(string nombre, string correo, string fecha_nacimiento, string tema, string comentario)
        {

            bool resultado = true;
            IPHostEntry host;
            string localIP = "";

            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)

            {

                if (ip.AddressFamily.ToString() == "InterNetwork")

                {

                    localIP = ip.ToString();

                }

            }
            StringBuilder sb = new StringBuilder();
            sb.Append("<table border =2><thead><tr>");
            sb.Append("<td colspan=2>Datos</td>");
            sb.Append("</tr></thead><tbody><tr><td scope=\"row\"><strong>Nombre</strong>");
            sb.Append("</td><td>");
            sb.Append(nombre);
            sb.Append("</td></tr><tr> <td scope=\"row\"><strong>Correo</strong>");
            sb.Append(" </td><td>");
            sb.Append(correo);
            sb.Append("</td></tr><tr><td scope=\"row\"><strong>Fecha Nacimiento</strong>");
            sb.Append("</td><td>");
            sb.Append(fecha_nacimiento);
            sb.Append("</td></tr><tr><td scope=\"row\"><strong>Tema</strong>");
            sb.Append(" </td><td>");
            sb.Append(tema);
            sb.Append("</td></tr><tr><td scope=\"row\"><strong>Comentario</strong>");
            sb.Append("</td><td>");
            sb.Append(comentario);
            sb.Append("</td></tr> </tbody></table><br><br>");
            sb.Append("<p>Tu ip es: <b>"+localIP+"</b></p>");
            sb.Append("<p> Este mensaje fue enviado a la Fecha y Hora: <u>"+ DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + "</u></p>");
            Console.WriteLine(comentario);
            string laTabla = sb.ToString();


            var email = new MailMessage();
            var smtp = new SmtpClient();


            email.To.Add(new MailAddress("flaria@ectotec.com"));
            email.From=new MailAddress("corre@example.com"); // correo remitente 
    
            email.Subject = "Correo de Aplicacion Back";
            email.SubjectEncoding = Encoding.UTF8;
            email.Body = laTabla;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            smtp.Host = "smtp-mail.example.com"; // dominio del servidor - remitente
            smtp.Port = 25; //puerto del servidor - remitente
            smtp.EnableSsl = true;
            smtp.Timeout = 50;
            
            smtp.Credentials=new System.Net.NetworkCredential
            {
                UserName = "corre@example.com",//Nombre de usuario de correo
                Password = "password"//password
            };
            try
            {
                smtp.Send(email);

                resultado = true;
            }
            catch(Exception ex)
            {
                resultado = false;

            }
            


            return Json(new
            {
                resultado
            }, "application/json", JsonRequestBehavior.DenyGet);
        }
    }
}