using System.Data;
using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoIoT.Models;
using System.Text;
using ProyectoIot.Models;

namespace ProyectoIoT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UsuariosContext db;

        public HomeController(UsuariosContext context)
        {
            this.db = context;
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CrearUsuario()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CrearUsuario(Usuario user)
        {
            if (ModelState.IsValid)
            {
                bool correcta = "Clave".Any(char.IsDigit) && "Clave".Any(char.IsLower) && "Clave".Any(char.IsUpper);
            }
            ViewBag.registroCompleto= "Su registro a sido exitos";
            return View();
        }

        public string AgregarUsuario(string nombreUsuario,string email,string clave)
        {
            Usuario nuevoUsuario = new Usuario(){
                NombreUsuario = nombreUsuario,
                EmailAddress = email,
                Clave = clave
            };

            object p = db.Usuarios.Add(nuevoUsuario);
            db.SaveChanges();

            return "Ok!!!";

        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
