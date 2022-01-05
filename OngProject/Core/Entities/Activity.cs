using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Entities
{
    public class Activity : EntityBase
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(65535)]
        public string Content { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Image { get; set; }
    }
}
