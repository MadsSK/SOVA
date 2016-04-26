using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using Web.Models;

namespace Web.Controllers
{
    public class AnswersController : BaseApiController
    {
        private readonly IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(int id)
        {
            var answerModel = ModelFactory.Map(_repository.GetAnswer(id), Url);

            if (answerModel == null)
            {
                return NotFound();
            }

            return Ok(answerModel);
        }
        /*
        public IHttpActionResult Get()
        {
            var comments = _repository.GetAnswers().Select(p => ModelFactory.Map(p, Url));

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
