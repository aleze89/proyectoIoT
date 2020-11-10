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
        
        private readonly ILogger<HomeController> logger;
        private readonly UsuariosContext db;

        public HomeController(ILogger<HomeController> logger,
        UsuariosContext contexto)
        {
            this.logger = logger;
            this.db = contexto;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

            public string AgregarUsuario(string nombreUsuario,string email,string clave)
        {
            Usuario nuevoUsuario = new Usuario{
                NombreUsuario = nombreUsuario,
                Email = email,
                Clave = clave
            };

            db.Usuarios.Add(nuevoUsuario);
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
