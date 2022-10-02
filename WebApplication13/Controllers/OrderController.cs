using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class OrderController : ApiController
    {
        IOrderRepository OrderRep;
        public OrderController()
        {
            OrderRep = new OrderService();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = OrderRep.GetAllOrders();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(Order order)
        {
            var data = OrderRep.AddOrder(order);
            return Ok(data);

        }
        [HttpPut]
        public IHttpActionResult Update(string status, int orderId)
        {
            OrderRep.OrderStatus(status, orderId);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(Order order)
        {
            var data = OrderRep.GetOrderPrice(order);
            return Ok(data);
        }
    }
}

