using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProyectoIot.Models;

namespace ProyectoIoT.Models
{
    public class UsuariosContext : DbContext
    {
        public UsuariosContext(DbContextOptions<UsuariosContext> options)
            : base(options)
            { }

            public DbSet<Usuario> Usuarios { get; set; }

            public DbSet<Dispositivo> Dispositivos { get; set; }
    }
}