using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdSourcing.Application.Web.ViewModels
{
    public class ChangeSolutionStatusVM
    {
        public int SolutionId { get; set; }
        public int StatusId { get; set; }
        public string Comment { get; set; }
    }
}