using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.DTOs
{
    public class TestimonialDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
