﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ArthaShikshaBusinessModel.LoginModel
{
    public class PortalLoginModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string EmailId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        //[MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; } = string.Empty;
    }
}
