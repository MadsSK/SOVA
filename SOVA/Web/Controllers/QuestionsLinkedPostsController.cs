using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Razor.Generator;
using DataAccessLayer;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class QuestionsLinkedPostsController : BaseApiController
    {
        private readonly IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(int questionId, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            IEnumerable<Object> data = new List<Object>();
            var answerData = _repository.GetAnswersWithLinkedPostId(questionId, pagesize / 2, page * pagesize / 2).Select(q => ModelFactory.Map(q, Url));
            var questionData = _repository.GetQuestionsWithLinkPostId(questionId, pagesize - answerData.Count(), page * pagesize - answerData.Count()).Select(q => ModelFactory.Map(q, Url));

            if (!answerData.Any() && !questionData.Any()) { return NotFound(); }
            else if (!answerData.Any()) { data = questionData; }
            else if (!questionData.Any()) { data = answerData; }
            else { data = questionData.Concat<Object>(answerData); }

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfLinkedPosts(questionId),
                Config.QuestionsLinkedPostsRoute);

            return Ok(result);
        }
    }
}