using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;
using DataAccessLayer;
using DomainModel;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class HomieController : BaseApiController
    {
        private readonly IRepository _repository;
        
        public HomieController(IRepository _repository)
        {
            this._repository = _repository;
        }

        public IHttpActionResult Index()
        {
            var result = new HomeModel()
            {
                QuestionsUrl = Url.Link(Config.QuestionsRoute, null),
                AnswersUrl = Url.Link(Config.AnswersRoute, null),
                CommentsUrl = Url.Link(Config.CommentsRoute, null),
                TagsUrl = Url.Link(Config.TagsRoute, null),
                UsersUrl = Url.Link(Config.UsersRoute, null),
                SearchUsersUrl = Url.Link(Config.SearchUsersRoute, null),
                SearchesUrl = Url.Link(Config.SearchesRoute, null),
                AnnotationsUrl = Url.Link(Config.AnnotationsRoute, null)
            };
            return Ok(result);
        }
    }
}