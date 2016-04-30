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

        public IHttpActionResult Post(AnnotationModel annotationModel)
        {
            if (annotationModel==null)return BadRequest("Annotation contains no values");
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
            return Created(Config.AnnotationsRoute, ModelFactory.Map(annotation, Url));
        }

        public IHttpActionResult Delete(int id)
        {
            if (!_repository.DeleteAnnotation(id)) return NotFound();
            return Ok();
        }

        public IHttpActionResult Put(int id, AnnotationModel annotationModel)
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