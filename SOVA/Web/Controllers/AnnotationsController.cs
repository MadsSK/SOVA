using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class AnnotationsController : BaseApiController
    {
        private readonly IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetAnnotationsWithPaging(page, pagesize * page).Select(a => ModelFactory.Map(a, Url));

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfAnnotations(),
                Config.AnnotationsRoute);

            return Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = ModelFactory.Map(_repository.FindAnnotation(id), Url);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}