using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class UsersQuestionsController : BaseApiController
    {
        private readonly IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(int userId, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetQuestionsWithUserId(userId, pagesize, page * pagesize).Select(u => ModelFactory.Map(u, Url));

            if (!data.Any()){ return NotFound();}

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumbersOfQuestionsWithUserId(userId),
                Config.UsersQuestionsRoute);

            return Ok(result);
        }
    }
}