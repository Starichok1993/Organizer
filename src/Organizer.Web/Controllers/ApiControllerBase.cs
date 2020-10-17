using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Organizer.Web.Controllers
{
    [Route("api")]    
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}