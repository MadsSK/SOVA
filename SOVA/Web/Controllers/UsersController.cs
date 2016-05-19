using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IRepository _repository;

        public UsersController(IRepository _repository)
        {
            this._repository = _repository;
        }

        public IHttpActionResult Get(int id)
        {
            var result = ModelFactory.Map(_repository.FindUser(id), Url);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        public IHttpActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetUsers(pagesize, page * pagesize).Select(u => ModelFactory.Map(u, Url));

            if (!data.Any()){ return NotFound();}

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumbersOfUsers(),
                Config.UsersRoute);

            return Ok(result);
        }
    }
}