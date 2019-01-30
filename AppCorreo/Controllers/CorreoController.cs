using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}