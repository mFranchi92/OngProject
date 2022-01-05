using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Entities
{
    public class Organization : EntityBase
    {
        [Required]
        [StringLength(255, ErrorMessage = "255 max char alowed")]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "20 max char allowed")]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [StringLength(320, ErrorMessage = "320 max char alowed")]
        public string Email { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "500 max char alowed")]
        public string WelcomeText { get; set; }
        [StringLength(2000, ErrorMessage = "2000 max char alowed")]
        public string AboutUsText { get; set; }

        [DataType(DataType.Url)]
        [MaxLength(255)]
        public string FacebookUrl { get; set; }

        [DataType(DataType.Url)]
        [MaxLength(255)]
        public string InstagramUrl { get; set; }

        [DataType(DataType.Url)]
        [MaxLength(255)]
        public string LinkedInUrl { get; set; }
        
    }
}
