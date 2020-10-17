using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Web.Models
{
    public class UpdateToDoRequest
    {       
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
