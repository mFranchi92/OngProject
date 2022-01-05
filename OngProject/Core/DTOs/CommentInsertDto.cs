using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs
{
    public class CommentInsertDto
    {
        [Required]
        public string Body { get; set; }

        [Required]
        public int NewsId { get; set; }
    }
}
