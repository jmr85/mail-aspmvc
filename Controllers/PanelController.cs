using PracticaMailMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PracticaMailMVC.Controllers
{
    public class PanelController : Controller
    {
        // GET: Panel
        public ActionResult Index()
        {
            return View("/Views/Panel/Index.cshtml");
        }
        
        public ActionResult Formulario()
        {
            return View("/Views/Panel/Formulario.cshtml");//hace submit a Enviar()
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Enviar(EmailFormModel model)
        {
            var mensaje = "";
            if (ModelState.IsValid)
            {
                var message = new MailMessage();
                message.To.Add(new MailAddress(model.FromEmail)); // Mail destinatario
                message.Subject = model.FromSubject; // Asunto
                message.Body = model.Message; // mensaje
                message.IsBodyHtml = true;

                try
                {
                    var smtp = new SmtpClient();
                    smtp.Send(message);
                    
                    mensaje = "Email has been sent successfully.";
                }       
                catch (Exception ex)
                {
                    mensaje = "ERROR: " + ex.Message;
                } 
            }

            ViewBag.mensaje = mensaje;
            return View("/Views/Panel/Mensaje.cshtml");
        }
    }
}