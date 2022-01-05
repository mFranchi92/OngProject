using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs
{
    public class ActivityInsertDto
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(65535)]
        public string Content { get; set; }

        [Required]
        public IFormFile Image { get; set; }
    }
}
