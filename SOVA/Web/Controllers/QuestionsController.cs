﻿using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class QuestionsController : BaseApiController
    {
        private readonly IRepository _repository = new MySqlRepository();

        /*
        public IHttpActionResult Get(string searchString)
        {
            var result = _repository.SearchQuestions(searchString).Select(q => ModelFactory.Map(q, Url));

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        */
        public IHttpActionResult Get(string searchString = "", int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.SearchQuestionsWithPaging(searchString, pagesize, page * pagesize).Select(q => ModelFactory.Map(q, Url));

            var result = SearchWithPaging(
                data,
                searchString,
                pagesize,
                page,
                _repository.GetNumberOfQuestionsSearchResults(searchString),
                Config.QuestionsRoute);

            return Ok(result);
        }
        
        public IHttpActionResult Get(int id)
        {
            var result = ModelFactory.Map(_repository.GetQuestion(id), Url);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }       
    }
}