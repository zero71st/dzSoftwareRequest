using System;
using System.ComponentModel.DataAnnotations;

namespace  dz.SoftwareRequest.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}