using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataAccessLayer;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class SearchUsersAnnotationsController : BaseApiController
    {
        private readonly IRepository _repository = new MySqlRepository();

        public IHttpActionResult Get(int searchUserId, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            List<AnnotationModel> data = new List<AnnotationModel>();
            var annotations = _repository.GetAnnotationsWithSearchUserId(searchUserId, page, pagesize * page);

            if (!annotations.Any()) { return NotFound(); }

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

            if (!data.Any()) { return NotFound(); }

            var result = GetWithPaging(
                data,
                pagesize,
                page,
                _repository.GetNumberOfAnnotationsWithSearchUserId(searchUserId),
                Config.SearchUsersAnnotationsRoute);

            return Ok(result);
        }
    }
}