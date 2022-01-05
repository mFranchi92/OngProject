using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs
{
    public class ContactDto
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Message { get; set; }
    }
}
