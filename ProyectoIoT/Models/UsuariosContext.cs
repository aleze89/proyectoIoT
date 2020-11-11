using Microsoft.EntityFrameworkCore;
using ProyectoIot.Models;
using System.Collections.Generic;


namespace ProyectoIoT.Models
{
    public class UsuariosContext : DbContext
    {
        public UsuariosContext(DbContextOptions<UsuariosContext> options)
            : base(options)
            { }

            public DbSet<Usuario> Usuarios { get; set; }
    }
}