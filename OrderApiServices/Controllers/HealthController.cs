using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderApiServices.Controllers
{
    [Route("Health")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Health()
        {
            return Ok("success!!!");
        }
    }
}