using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdSourcing.Application.Web.ViewModels
{
    public class AccountVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}