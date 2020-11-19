using System.ComponentModel.DataAnnotations;
using System.Net.Http;
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
        public IActionResult RegistrarUsuarios()
        {
            return View();
        }
        
        public IActionResult menuPrincipal()
        {
            return View(db.Usuarios.ToList());
        }
        

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
            public JsonResult AgregarUsuario(string nombreUsuario,string email,string clave)
        {
            Usuario nuevoUsuario = new Usuario{
                NombreUsuario = nombreUsuario,
                Email = email,
                Clave = clave
            };

            db.Usuarios.Add(nuevoUsuario);
            db.SaveChanges();

            return Json(nuevoUsuario);

        }
        
        public JsonResult AgregarUsuarioASession(string nombreUsuario, string email, string clave)
        {
            Usuario nuevoUsuario = new Usuario{
                NombreUsuario = nombreUsuario,
                Email= email,
                Clave = clave
            };
            HttpContext.Session.Set<Usuario>("UsuarioLogueado", nuevoUsuario);
            return Json(nuevoUsuario);
        }
     
        public JsonResult ConsultarUsuario()
        {
            var usuario = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            if(usuario != null)
            {
                return Json(usuario);
            }
            else
            {
                return Json("No está loqueado");
            }

        }

        public string EliminarUsuarioDeSession()
        {
            HttpContext.Session.Remove("UsuarioLogueado");
            return "Usuario eliminado";
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
