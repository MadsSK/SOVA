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
    public class PostsController : BaseApiController
    {
        private readonly IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get()
        {
            var posts = _repository.GetPosts().Select(p => ModelFactory.Map(p, Url));

            var result = GetAll(posts);

            return Ok(result);
        }

        public IHttpActionResult Get(string searchString)
        {
            var posts = _repository.GetPosts(searchString).Select(p => ModelFactory.Map(p, Url));

            var result = GetAll(posts);

            return Ok(result);
        }

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
