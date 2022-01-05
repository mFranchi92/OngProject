using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs
{
    public class MemberEditDto
    {
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string FacebookUrl { get; set; }

        [MaxLength(255)]
        public string InstagramUrl { get; set; }

        [MaxLength(255)]
        public string LinkedinUrl { get; set; }
        public IFormFile Image { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }
    }
}
