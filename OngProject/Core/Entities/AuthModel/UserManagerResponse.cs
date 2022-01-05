using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Entities.AuthModel
{
    /// <summary>
    /// Response for login and register
    /// </summary>
    public class UserManagerResponse
    {
        /// <summary>
        /// If action is success, message contains validation token
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Bool property to confirm response
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Array of errors if not success
        /// </summary>
        public IEnumerable<string> Errors { get; set; }
    }
}
