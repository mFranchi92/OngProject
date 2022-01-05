using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs
{
    public class SlideCreateDto
    {
        [Required]
        public string ImageBase64 { get; set; }

        [Required]
        public string Text { get; set; }

        public int? Order { get; set; }

        [Required]
        public int OrganizationId { get; set; }
      
    }
}
