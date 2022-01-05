using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Entities
{
    public class Contact : EntityBase
    {

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [StringLength(20)]
        public string Phone { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [StringLength(65535)]
        public string Message { get; set; }

    }
}
