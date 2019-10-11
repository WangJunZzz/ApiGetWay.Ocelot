using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApiServices.Dtos
{
    public class OrderDto
    {
        public string Id { get; set; }

        public string Price { get; set; }

        public string ApplyName { get; set; }
    }
}
