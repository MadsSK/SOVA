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
    public class QuestionsController : BaseApiController
    {
        private readonly IRepository _repository;

        public QuestionsController(IRepository _repository)
        {
            this._repository = _repository;
        }
        
        public IHttpActionResult Get(int id )
        {
            var result = ModelFactory.Map(_repository.GetQuestion(id), Url);

            if (result == null){return NotFound();}

            return Ok(result);
        }

        public IHttpActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetQuestionsWithPaging(pagesize, page * pagesize).Select(q => ModelFactory.Map(q, Url));
        
            if (!data.Any()) return NotFound();

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfQuestions(),
                Config.QuestionsRoute);

            return Ok(result);
        }

        public IHttpActionResult Get(int questionId, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetAnswersWithQuestionId(questionId, pagesize, page * pagesize).Select(q => ModelFactory.Map(q, Url));

            if (!data.Any()) return NotFound();

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfAnswersWithQuestionId(questionId),
                Config.TagsRoute);

            return Ok(result);
        }

        public IHttpActionResult Get(int questionId, int searchUserId, int page = 0, int pagesize = Config.DefaultPageSize)
            {
            var data = _repository.GetAnnotationsOnQuestionWithQuestionIdSearchUserId(questionId, searchUserId, pagesize, page * pagesize).Select(q => ModelFactory.Map(q, true, Url));

            if (!data.Any()) return NotFound();

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfAnnotationsOnQuestionWithQuestionIdSearchUserId(questionId, searchUserId),
                Config.TagsRoute);

            return Ok(result);
        }
    }
}