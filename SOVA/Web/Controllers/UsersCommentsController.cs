using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class UsersCommentsController : BaseApiController
    {
        private int answersPage = 0;
        private readonly IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(int userId, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            List<CommentModel> data = new List<CommentModel>();
            var comments = _repository.GetCommentsWithUserId(userId, page, pagesize*page);

            if (!comments.Any()) { return NotFound(); }

            foreach (var comment in comments)
            {
                if (_repository.GetQuestion(comment.PostId) != null)
                {
                    data.Add(ModelFactory.Map(comment, true, Url));
                }
                else
                {
                    data.Add(ModelFactory.Map(comment, false, Url));
                }
            }

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumbersOfCommentsWithUserId(userId),
                Config.CommentsRoute);

            return Ok(result);
        }
    }
}