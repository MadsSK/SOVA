using System.Web.Http;
using DataAccessLayer;
using Web.Models;

namespace Web.Controllers
{
    public class CommentsController : ApiController
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
    }
}
