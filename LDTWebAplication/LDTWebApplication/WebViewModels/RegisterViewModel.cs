using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebViewModels
{
   public class RegisterViewModel
    {
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmePassword { get; set; }
        [Required]
        public string Username { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
    }
}
