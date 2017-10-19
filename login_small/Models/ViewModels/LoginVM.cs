using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace login_small.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "*")]
        public string Username { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}