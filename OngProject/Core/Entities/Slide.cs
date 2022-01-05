using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Entities
{
    public class Slide : EntityBase
    {
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string ImageUrl { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Text { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

    }
}
