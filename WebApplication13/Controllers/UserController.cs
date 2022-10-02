using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class UserController : ApiController
    {
        private IUserRepository UserRep;
        public UserController()
        {
            UserRep = new UserService();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = UserRep.GetAllUsers();
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(string name)
        {
            UserRep.DeleteUser(name);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(User user)
        {
            UserRep.UpdateUser(user);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(string name, string status)
        {
            UserRep.UserStatus(name, status);
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult Post(User user)
        {
            var data = UserRep.AddUser(user);
            return Ok(data);

        }
        [HttpGet]
        public IHttpActionResult Get(string name)
        {
            var data = UserRep.GetUserByUserName(name);
            return Ok(data);
        }

    }
}
