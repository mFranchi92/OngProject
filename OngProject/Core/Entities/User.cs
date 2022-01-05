using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]        
        public string LastName { get; set; }

        [MaxLength(255)]
        public string Photo { get; set; }
        public bool IsDeleted { get; set; }
    }
}
