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

       
        public IActionResult RegistrarUsuarios()
        {
            return View(); //quiero q una vez registrados vayan al menu principal
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
            public IActionResult AgregarDispositivo(long id,string nombre,string modelo,string categoria)
            {
            Dispositivo nuevoDispositivo = new Dispositivo {
                ID = id,
                Nombre = nombre,
                Modelo = modelo,
                Categoria = categoria
            };

            db.Dispositivos.Add(nuevoDispositivo);
            db.SaveChanges();
            return RedirectToAction("menuPrincipal",nuevoDispositivo);

        }
        
        [HttpPost]
        public IActionResult AgregarUsuarioASession(string nombreUsuario, string email, string clave)
        {
            Usuario nuevoUsuario = new Usuario{
                NombreUsuario = nombreUsuario,
                Email = email,
                Clave = clave
            };


            HttpContext.Session.Set<Usuario>("UsuarioLogueado", nuevoUsuario);
            return RedirectToAction("menuPrincipal",nuevoUsuario);
        }
     
        [HttpPost]
        public IActionResult Login(string email, string nombreUsuario)
        {
            Usuario userCheck = db.Usuarios.FirstOrDefault(n => (n.Email == email));
            if(userCheck != null)
            {
                //checkear que sea el mismo usuario
                if(userCheck.Nombre == nombreUsuario)
                {
                    //Agregar el session
                    AgregarUsuarioASession(email, nombreUsuario);

                    List<Usuario> usuarios = db.Usuarios.ToList();

                    var filtrado = new List<Usuario>();
                    foreach(var usuario in usuarios){
                        if(usuario.Duenio == email)
                        {
                            filtrado.Add(usuario);
                        }
                    };
                    return View("menuPrincipal", filtrado);
                }
                else
                {
                    //No es el mismo usuario que registro ese mail
                    ViewBag.badLogin = true;
                    return View("Index");
                }
            }
            else
            {
                //crear el usuario
                Usuario nuevoUsuario = new Usuario(){
                    Email = email,
                    Nombre = nombreUsuario
                };
                db.Usuarios.Add(nuevoUsuario);
                db.SaveChanges();

                AgregarUsuarioASession(email, nombreUsuario);

                var filtrado = new List<Usuario>();

                return View("menuPrincipal", filtrado);
            }
        }

        private void AgregarUsuarioASession(string email, string nombreUsuario)
        {
            throw new NotImplementedException();
        }

        public IActionResult Index()
        {
            Usuario userCheck = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            if(userCheck != null)
            {
                List<Usuario> usuarios = db.Usuarios.ToList();
                var filtrado = new List<Usuario>();
                foreach(var usuario in usuarios){
                    if(userCheck.Duenio == usuario.Email)
                    {
                        filtrado.Add(usuario);
                    }
                };
                return View("manuPrincipal", filtrado);
            }
            else
            {
                return View();
            }
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
