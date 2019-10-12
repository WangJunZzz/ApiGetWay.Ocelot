using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductApiServices.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult GetProducts()
        {
            return Ok(new
            {
                id = "1",
                name = "PUBG",
                price = "99",
                number = 100
            });
        }

        [HttpGet("exp")]
        public IActionResult Exp()
        {
            throw new Exception("test exception"); 
        }
    }
}