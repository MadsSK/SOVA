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
    public class QuestionsSearchController : BaseApiController
    {
        private readonly IRepository _repository;

        public QuestionsSearchController(IRepository _repository)
        {
            this._repository = _repository;
        }
        
        
        public IHttpActionResult Get(string searchString)
        {
            var result = _repository.SearchQuestionsRes(searchString);

            if (result == null)
            {
                return Ok(new{bla = "ha ha "});
            }
            var nResult = ModelFactory.Map(result);

            return Ok(nResult);
        }       
    }
}