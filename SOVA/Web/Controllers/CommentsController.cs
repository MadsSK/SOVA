using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class CommentsController : BaseApiController
    {
        private readonly IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(int id)
        {
            var result = _repository.FindComment(id);
            var commentModel = ModelFactory.Map(result, _repository.IsPostAQuestion(result.PostId), Url);

            if (commentModel == null){return NotFound();}

            return Ok(commentModel);
        }

        public IHttpActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetCommentsWithPaging(pagesize, page * pagesize).Select(c => ModelFactory.Map(c, _repository.IsPostAQuestion(c.PostId), Url));

            if (!data.Any()) { return NotFound();}

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfComments(),
                Config.CommentsRoute);

            return Ok(result);
        }

        public IHttpActionResult Get(int commentId, int searchUserId, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetAnnotationsWithCommentIdSearchUserId(commentId, searchUserId, pagesize, page * pagesize).Select(a => ModelFactory.Map(a, false, Url));

            if (!data.Any()) return NotFound();

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfAnnotationsWithCommentIdSearchUserId(commentId, searchUserId),
                Config.CommentsRoute);

            return Ok(result);
        }

        /*
        public IHttpActionResult Get(int questionId, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetCommentsWithQuestionId(questionId, pagesize, page * pagesize).Select(q => ModelFactory.Map(q, Url));

            if (!data.Any()) return NotFound();

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfCommentsWithQuestionId(questionId),
                Config.CommentsRoute);

            return Ok(result);
        }

        public IHttpActionResult Get(int questionId, int answerId, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetCommentsWithQuestionIdAnswerId(questionId, answerId, pagesize, page * pagesize).Select(q => ModelFactory.Map(q, Url));

            if (!data.Any()) return NotFound();

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfCommentsWithQuestionIdAnswerId(questionId, answerId),
                Config.CommentsRoute);

            return Ok(result);
        }
        
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
