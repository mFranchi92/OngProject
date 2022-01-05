using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Entities
{
    public class Rol : IdentityRole
    {
        
        [StringLength(255)]
        public string Description { get; set; }
    }
}