using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class SearchController : BaseApiController
    {
        private readonly IRepository _repository;

        public SearchController(IRepository _repository)
        {
            this._repository = _repository;
        }

        public IHttpActionResult Get(string searchString = "", int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.SearchWithPaging(searchString, pagesize*page, pagesize).Select(s => ModelFactory.Map(s, Url));

            if (!data.Any() || data == null) return NotFound();

            var result = SearchWithPaging(
                data,
                searchString,
                pagesize,
                page,
                _repository.GetNumberOfSeachResult(searchString),
                Config.SearchRoute);

            return Ok(result);
        }
    }
}