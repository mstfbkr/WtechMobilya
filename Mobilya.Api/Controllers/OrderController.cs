using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobilya.Api.Helpers;
using Mobilya.Business.Abstract;
using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobilya.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [HttpPost("GetAll")]
        public async Task<Response<IEnumerable<Order>>> GetAll()
        {
            var orders = await _orderService.GetAllOrder();
            if (!orders.Any())
            {
                return new Response<IEnumerable<Order>>().NoContent();
            }
            
            return new Response<IEnumerable<Order>>().Ok(orders.Count(), orders);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Post([FromBody] Order order)
        {
            var createorder = _orderService.CreateOrder(order);
            return Ok(createorder);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Order order)
        {
            _orderService.DeleteOrder(order);
            return Ok("Order Deleted");
        }


        [HttpPut]
        public IActionResult Put([FromBody]Order order)
        {
            if (_orderService.GetOrderById(order.OrderId) != null)
            {
                return Ok(_orderService.UpdateOrder(order));
            }
            return NotFound();
        }
    }
}
