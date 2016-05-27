using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class SearchesController : BaseApiController
    {
        private readonly IRepository _repository;

        public SearchesController(IRepository _repository)
        {
            this._repository = _repository;
        }

        public IHttpActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetSearchsWithPaging(pagesize, page * pagesize).Select(s => ModelFactory.Map(s, Url));

            if (!data.Any()){return NotFound();}

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfSearchs(),
                Config.QuestionsRoute);

            return Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = ModelFactory.Map(_repository.FindSearch(id), Url);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /*
        public IHttpActionResult Get()
        {
            var result = _repository.GetAllQuestions().Select(p => ModelFactory.Map(p, Url));

            return Ok(result);
        }

        public IHttpActionResult Get(string searchString)
        {
            var result = _repository.SearchQuestions(searchString).Select(q => ModelFactory.Map(q, Url));

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        

        public IHttpActionResult Get(string searchString, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.SearchQuestionsWithPaging(searchString, pagesize, page * pagesize).Select(q => ModelFactory.Map(q, Url));

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumbersOfQuestions(),
                Config.QuestionsRoute);

            return Ok(result);
        }
        */
    }
}