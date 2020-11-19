using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoIot.Models
{
    public class Dispositivo
    {
        [key]
        public string Estado { get; set; }

        public string Encender { get; set; }

        public string Apagar { get; set; }

        public string Temporizar { get; set; }

        public List<Usuario> Usuarios { get; set; }
    }
    
}