using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Entities
{
    public class Category : EntityBase
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [StringLength(255)]
        public string Description { get; set; }
        
        [StringLength(255)]
        public string Image { get; set; }
        
    }
}