using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OngProject.Core.Entities
{ 
    public class Testimonial : EntityBase
    {

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Image { get; set; }
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

    }
}
