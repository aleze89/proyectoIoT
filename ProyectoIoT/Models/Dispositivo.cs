using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIot.Models
{
    public class Dispositivo
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID {get; set; }

        [Required(ErrorMessage = "Debe introducir un nombre de dispositivo")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "Debe introducir numero de serie o marca en caso de poseerlo")]
        public string Modelo { get; set; }

        public string Categoria { get; set; }

        public bool Estado { get; set; }

        public bool CambiarEstado { get; set; }

        public float Temporizar { get; set; }
       
        public int Temperatura { get; set; }
        
        public int Potencia { get; set; }

        public Usuario Duenio { get; set; }

    }
}
        
    