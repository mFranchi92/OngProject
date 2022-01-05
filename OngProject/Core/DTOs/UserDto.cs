using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs
{
    /// <summary>
    /// Dto mapped from User entity
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// User First Name
        /// </summary>
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string FirstName { get; set; }

        /// <summary>
        /// User Last Name
        /// </summary>
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string LastName { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        [Required]
        [StringLength(255, MinimumLength = 3)]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// User photo
        /// </summary>
        [MaxLength(255)]
        public string Photo { get; set; }

    }
}
