using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Entities
{
    public class Comment : EntityBase
    {   
        [Required]
        public string Body { get; set; }
        
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
        
        [Required]
        public int PostId { get; set; }
        //public Post Post { get; set; }
    }
}