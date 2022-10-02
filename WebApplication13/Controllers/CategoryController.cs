using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class CategoryController : ApiController
    {
        private ICategoryRepository category;
        public CategoryController()
        {
            category = new CategoryService();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = category.GetAllCategory();
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Post(Category cat)
        {
            var data = category.AddCategory(cat);
            return Ok(data);

        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            category.DeleteCategory(id);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(Category cat)
        {
            category.UpdateCategory(cat);
            return Ok();
        }



    }
}
