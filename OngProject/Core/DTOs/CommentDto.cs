using System;

namespace OngProject.Core.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}