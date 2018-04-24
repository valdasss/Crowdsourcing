﻿using System.ComponentModel.DataAnnotations;

namespace CrowdSourcing.Application.Web.ViewModels
{
    public class LoginVM
    {
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}