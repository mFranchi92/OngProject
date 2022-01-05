using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Entities
{
    public class Member : EntityBase
    {
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.Url)]
        [MaxLength(255)]
        public string FacebookUrl { get; set; }

        [DataType(DataType.Url)]
        [MaxLength(255)]
        public string InstagramUrl { get; set; }

        [DataType(DataType.Url)]
        [MaxLength(255)]
        public string LinkedinUrl { get; set; }

        [DataType(DataType.ImageUrl)]
        [MaxLength(255)]
        public string Image { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }
    }
}
