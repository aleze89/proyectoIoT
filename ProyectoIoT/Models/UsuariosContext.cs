using Microsoft.EntityFrameworkCore;
using ProyectoIot.Models;
using System.Collections.Generic;


namespace ProyectoIoT.Models
{
    public class UsuariosContext : DbContext
    {
        private DbSet<Usuario> usuarios;

        public UsuariosContext(DbContextOptions<UsuariosContext> options)
: base(options)
        { }

        public object Usuarios { get; internal set; }

        public DbSet<Usuario> GetUsuarios()
        {
            return usuarios;
        }

        public void SetUsuarios(DbSet<Usuario> value)
        {
            usuarios = value;
        }
    }

}