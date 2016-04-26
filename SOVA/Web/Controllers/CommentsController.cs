using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using Web.Models;

namespace Web.Controllers
{
    public class CommentsController : BaseApiController
    {
        private readonly IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(int id)
        {
            var commentModel = ModelFactory.Map(_repository.FindComment(id), Url);

            if (commentModel == null)
            {
                return NotFound();
            }

            return Ok(commentModel);
        }
        /*
        public IHttpActionResult Get()
        {
            var comments = _repository.GetComments().Select(p => ModelFactory.Map(p, Url));

            var result = GetAll(comments);

            return Ok(result);
        }

        public IHttpActionResult Get(string searchString)
        {
            var comments = _repository.GetComments(searchString).Select(p => ModelFactory.Map(p, Url));

            var result = GetAll(comments);

            return Ok(result);
        }
        */
    }
}
