using System;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
    }
}