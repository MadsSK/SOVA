using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class AnswersController : BaseApiController
    {
        private readonly IRepository _repository;

        public AnswersController(IRepository _repository)
        {
            this._repository = _repository;
        }

        public IHttpActionResult Get(int id)
        {
            var result = ModelFactory.Map(_repository.GetAnswer(id), Url);

            if (result == null){return NotFound();}

            return Ok(result);
        }

        public IHttpActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetAnswersWithPaging(pagesize, pagesize * page).Select(a => ModelFactory.Map(a, Url));

            if (!data.Any()){return NotFound();}

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfAnswers(),
                Config.AnswersRoute);

            return Ok(result);
        }

        public IHttpActionResult Get(int answerId, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetCommentsWithAnswerId(answerId, pagesize, page * pagesize).Select(a => ModelFactory.Map(a, false, Url));

            if (!data.Any()) return NotFound();

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfCommentsWithAnswerId(answerId),
                Config.CommentsRoute);

            return Ok(result);
        }

        public IHttpActionResult Get(int answerId, int searchUserId, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetAnnotationsWithAnswerIdSearchUserId(answerId, searchUserId, pagesize, page * pagesize).Select(q => ModelFactory.Map(q, false, Url));

            if (!data.Any()) return NotFound();

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfAnnotationsWithAnswerIdSearchUserId(answerId, searchUserId),
                Config.CommentsRoute);

            return Ok(result);
        }
    }
}
