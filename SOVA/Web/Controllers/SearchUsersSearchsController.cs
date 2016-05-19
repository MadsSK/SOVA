using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class SearchUsersSearchsController : BaseApiController
    {
        private readonly IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(int searchUserId, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetSearchsWithSearchUserId(searchUserId, pagesize, page * pagesize).Select(a => ModelFactory.Map(a, Url));

            if (!data.Any()) return NotFound();

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfSearchsWithSearchUserId(searchUserId),
                Config.SearchUsersRoute);

            return Ok(result);
        }
    }
}