using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Entities.AuthModel
{
    /// <summary>
    /// ViewModel for Login Function
    /// </summary>
    public class LoginUserModel
    {
        /// <summary>
        /// Registered User Email
        /// </summary>
        [Required]
        [EmailAddress]
        [MaxLength(320)]
        public string Email { get; set; }

        /// <summary>
        /// Registered user password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
