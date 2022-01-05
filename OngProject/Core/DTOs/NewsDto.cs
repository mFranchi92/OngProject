using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs
{
    public class NewsDto
    {
        [Required]

        [MaxLength(255)]

        public string Name { get; set; }

        public IFormFile Image { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }
    }
}
