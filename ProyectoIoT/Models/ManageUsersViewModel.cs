using System.Collections.Generic;
using ProyectoIoT.Models;

namespace ProyectoIoT.Models
{
    public class ManageUsersViewModel
    {
        public ApplicationUser[] Administrators { get; set; }
        public ApplicationUser[] Everyone { get; set;}
    }
}