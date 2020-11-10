using System;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ProyectoIot.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID {get; set; }
        
        [Required(ErrorMessage = "Debe introducir un nombre de usuario")]
        public string NombreUsuario {get; set; }

        [Required(ErrorMessage = "Debe ingresar un email")]
        
        public string Email {get; set; }

        [Required(ErrorMessage = "Debe ingresar clave")]
        [StringLength(6, ErrorMessage = "La clave debe contener entre 1 y 6 cararteres", MinimumLength = 1)]
        [DataType(DataType.Password)]
        public string Clave {get; set; }

        
    }
    
}