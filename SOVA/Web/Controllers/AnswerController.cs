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
    }
}
