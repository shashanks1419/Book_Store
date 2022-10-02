using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    internal interface IOrderRepository
    {
        Order AddOrder(Order order);

        List<Order> GetAllOrders();
        void OrderStatus(string status, int OrderId);
        int GetOrderPrice(Order order);
    }
}
