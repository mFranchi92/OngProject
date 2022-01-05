using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs
{
    public class UserUpdateDto
    {
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string LastName { get; set; }
        public IFormFile Photo { get; set; }
    }
}
