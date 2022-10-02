using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class WishlistController : ApiController
    {
        IWishlistRepository WishlistRep;
        public WishlistController()
        {
            WishlistRep = new WishlistService();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = WishlistRep.ViewWishlist();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(Wishlist wishlist)
        {
            var data = WishlistRep.AddtoWishlist(wishlist);
            return Ok(data);

        }
        [HttpDelete]
        public IHttpActionResult Delete(string uname, int bid)
        {
            WishlistRep.DeletefromWishlist(uname, bid);
            return Ok();
        }
    }
}
