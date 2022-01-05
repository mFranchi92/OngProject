using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs
{
    public class CommentUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
