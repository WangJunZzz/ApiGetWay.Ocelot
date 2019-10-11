using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApiServices.Dtos;

namespace OrderApiServices.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult GetOrders()
        {
            return Ok(new
            {
                orderId = "1",
                name = "PUBG",
                price = "99"
            });
        }

        [HttpPost("")]
        public IActionResult Apply(OrderDto model)
        {
            return Ok(model);
        }
    }
}