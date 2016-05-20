using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class CommentsController : BaseApiController
    {
        private readonly IRepository _repository;

        public CommentsController(IRepository _repository)
        {
            this._repository = _repository;
        }

        public IHttpActionResult Get(int id)
        {
            bool question = true;
            var result = _repository.FindCommentOnQuestion(id);

            if (result == null)
            {
                result = _repository.FindCommentOnAnswer(id);
                question = false;
            }
            var commentModel = ModelFactory.Map(result, question, Url);

            if (commentModel == null) { return NotFound(); }

            return Ok(commentModel);
        }

        public IHttpActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            List<CommentModel> data = new List<CommentModel>();
            var comments = _repository.GetCommentsWithPaging(pagesize, pagesize*page);

            if (!comments.Any() || comments == null) { return NotFound(); }

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
