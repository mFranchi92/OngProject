﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Entities
{
    public class News : EntityBase
    {
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Content { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Image { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
