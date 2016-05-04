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
    public class QuestionsTagsController : BaseApiController
    {
        private readonly IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(int questionId, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetTagsWithQuestionId(questionId, pagesize, page * pagesize).Select(q => ModelFactory.Map(q, Url));

            if (!data.Any()) return NotFound();

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumbersOfTagsWithQuestionId(questionId),
                Config.TagsRoute);

            return Ok(result);
        }
    }
}