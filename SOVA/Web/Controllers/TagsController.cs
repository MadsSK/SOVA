using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class TagsController : BaseApiController
    {
        private readonly IRepository _repository;

        public TagsController(IRepository _repository)
        {
            this._repository = _repository;
        }

        public IHttpActionResult Get(int id)
        {
            var result = ModelFactory.Map(_repository.FindTag(id), Url);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        public IHttpActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetTags(pagesize, page * pagesize).Select(q => ModelFactory.Map(q, Url));

            if (!data.Any()) { return NotFound();}

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfTags(),
                Config.TagsRoute);

            return Ok(result);
        }

        public IHttpActionResult Get(int tagId, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetQuestionsWithTagId(tagId, pagesize, page * pagesize).Select(q => ModelFactory.Map(q, Url));

            if (!data.Any()) return NotFound();

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfQuestionsWithTagId(tagId),
                Config.TagsRoute);

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