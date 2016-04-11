using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;
using Web.Models;

namespace Web.Controllers
{
    public class PostsController : ApiController
    {
        private readonly IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(int id)
        {
            var postModel = ModelFactory.Map(_repository.FindPost(id), Url);

            if (postModel == null)
            {
                return NotFound();
            }

            return Ok(postModel);
        }
    }
}
