using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Entities.AuthModel
{
    /// <summary>
    /// ViewModel for register a user
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// User first name
        /// </summary>
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string FirstName { get; set; }
        /// <summary>
        /// User last name
        /// </summary>
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string LastName { get; set; }
        /// <summary>
        /// User email
        /// </summary>
        [Required]
        [EmailAddress]
        [MaxLength(320)]
        public string Email { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }

        /// <summary>
        /// User confirm password
        /// </summary>
        [Compare("Password")]
        [NotMapped]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
