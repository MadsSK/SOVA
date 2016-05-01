using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using DomainModel;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class AnnotationsController : BaseApiController
    {
        private readonly IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetAnnotationsWithPaging(page, pagesize * page).Select(a => ModelFactory.Map(a, _repository.IsPostAQuestion(a.PostId), Url));

            if (!data.Any()){return NotFound();}

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

            var result = _repository.FindAnnotation(id);
            var annotationModel = ModelFactory.Map(result, _repository.IsPostAQuestion(result.PostId), Url);

            if (annotationModel == null){return NotFound();}

            return Ok(annotationModel);
        }

        public IHttpActionResult Get(string Route, int postId, int searchUserId, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetAnnotationsWithPostIdSearchUserId(postId, searchUserId, pagesize, page * pagesize).Select(a => ModelFactory.Map(a, _repository.IsPostAQuestion(a.PostId), Url));

            if (!data.Any()) return NotFound();

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfAnnotationsWithPostIdSearchUserId(postId, searchUserId),
                Route);

            return Ok(result);
        }
        
        public IHttpActionResult Get(int commentId, int searchUserId, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = _repository.GetAnnotationsWithCommentIdSearchUserId(commentId, searchUserId, pagesize, page * pagesize).Select(a => ModelFactory.Map(a, _repository.IsPostAQuestion(a.PostId), Url));

            if (!data.Any()) return NotFound();

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfAnnotationsWithCommentIdSearchUserId(commentId, searchUserId),
                Config.CommentsAnnotationsRoute);

            return Ok(result);
        }

        public IHttpActionResult Post(AnnotationEditModel annotationModel)
        {
            if (annotationModel == null)return BadRequest("Annotation contains no values");
            var annotation = new Annotation
            {
                Body = annotationModel.Body,
                MarkingStart = annotationModel.MarkingStart,
                MarkingEnd = annotationModel.MarkingEnd,
                PostId = annotationModel.PostId,
                CommentId = annotationModel.CommentId,
                SearchUserId = annotationModel.SearchUserId
            };
            _repository.Insert(annotation);

            var question = _repository.IsPostAQuestion(annotationModel.PostId);

            return Created(Config.AnnotationsRoute, ModelFactory.Map(annotation, question, Url));
        }

        public IHttpActionResult Delete(int id)
        {
            if (!_repository.DeleteAnnotation(id)) return NotFound();
            return Ok();
        }

        public IHttpActionResult Put(int id, AnnotationEditModel annotationModel)
        {
            var annotation = new Annotation
            {
                Body = annotationModel.Body,
                MarkingStart = annotationModel.MarkingStart,
                MarkingEnd = annotationModel.MarkingEnd,
                PostId = annotationModel.PostId,
                CommentId = annotationModel.CommentId,
                SearchUserId = annotationModel.SearchUserId
            };

            if (!_repository.Update(annotation)) return NotFound();
            return Ok();
        }
    }
}