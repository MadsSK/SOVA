using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class SearchUsersController : BaseApiController
    {
        private readonly IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(int id)
        {
            var result = ModelFactory.Map(_repository.FindSearchUser(id), Url);

            if (result == null){return NotFound();}

            return Ok(result);
        }

        public IHttpActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetAllSearchUsers(pagesize, page * pagesize).Select(su => ModelFactory.Map(su, Url));

            if (!data.Any()) return NotFound();

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfSearchUsers(),
                Config.SearchUsersRoute);

            return Ok(result);
        }
    }
}