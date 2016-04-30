using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(string searchString = "", int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.SearchUsersWithPaging(searchString, pagesize, page * pagesize).Select(u => ModelFactory.Map(u, Url));

            var result = SearchWithPaging(
                data,
                searchString,
                pagesize,
                page,
                _repository.GetNumberOfUsersSearchResults(searchString),
                Config.UsersRoute);

            return Ok(result);
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

        public IHttpActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetUsers(pagesize, page * pagesize).Select(u => ModelFactory.Map(u, Url));

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumbersOfUsers(),
                Config.UsersRoute);

            return Ok(result);
        }
        */
    }
}