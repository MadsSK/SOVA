using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class AnswersController : BaseApiController
    {
        private readonly IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetAnswersWithPaging(pagesize, pagesize * page).Select(a => ModelFactory.Map(a, Url));

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfAnswers(),
                Config.AnswersRoute);

            return Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = ModelFactory.Map(_repository.GetAnswer(id), Url);

            if (result == null)
            {
                return NotFound();
            }

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
                Config.CommentsRoute);

            return Ok(result);
        }
    }
}
