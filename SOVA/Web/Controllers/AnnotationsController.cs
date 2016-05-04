using System;
using System.Collections.Generic;
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
            List<AnnotationModel> data = new List<AnnotationModel>();
            var annotations = _repository.GetAnnotationsWithPaging(page, pagesize*page);

            if (!annotations.Any()){return NotFound();}

            foreach (var annotation in annotations)
            {
                if (_repository.GetQuestion((int)annotation.PostId) != null)
                {
                    data.Add(ModelFactory.Map(annotation, true, Url));
                }
                else
                {
                    data.Add(ModelFactory.Map(annotation, false, Url));
                }
            }

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
            bool question = true;
            var result = _repository.FindQuestionAnnotation(id);
            
            if (result == null)
            {
                result = _repository.FindAnswerAnnotation(id);
                question = false;
                if (result == null)
                {
                    result = _repository.FindCommentAnnotation(id);
                }
            }
            var annotationModel = ModelFactory.Map(result, question, Url);

            if (annotationModel == null){return NotFound();}

            return Ok(annotationModel);
        }

        public IHttpActionResult Post(AnnotationModel annotationModel)
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

            bool question = _repository.GetQuestion((int) annotationModel.PostId) != null;

            return Created(Config.AnnotationsRoute, ModelFactory.Map(annotation, question, Url));
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