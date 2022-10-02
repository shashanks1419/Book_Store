using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    public interface ICartRepository
    {
        Cart AddtoCart(Cart cart);
        void DeletefromCart(string uname, int bid);
        List<Cart> ViewCart();

    }
}