using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class SearchUsersFavoritesController : BaseApiController
    {
        private readonly IRepository _repository;

        public SearchUsersFavoritesController(IRepository _repository)
        {
            this._repository = _repository;
        }

        public IHttpActionResult Get(int searchUserId, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetQuestionsWithSearchUserId(searchUserId, pagesize, page * pagesize).Select(su => ModelFactory.Map(su, Url));

            if (!data.Any()) return NotFound();

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfFavoritesWithSearchUserId(searchUserId),
                Config.SearchUsersFavoritesRoute);

            return Ok(result);
        }
    }
}