﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdSourcing.Application.Web.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }       
        public string Role { get; set; }
    }
}