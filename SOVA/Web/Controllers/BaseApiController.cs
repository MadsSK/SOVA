using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers
{
    public class BaseApiController : ApiController
    {
        protected object GetWithPaging<T>(IEnumerable<T> data, int pagesize, int page, int total, string route)
        {
            var lastpage = total/pagesize;

            var prev = page <= 0 ? null : Url.Link(route, new { page = page - 1, pagesize});
            var next = page >= lastpage ? null : Url.Link(route, new { page = page + 1, pagesize });

            var result = new
            {
                Total = total,
                Prev = prev,
                Next = next,
                Data = data
            };
            return result;
        }
        protected object SearchWithPaging<T>(IEnumerable<T> data, string searchString, int pagesize, int page, int total, string route)
        {
            var lastpage = total / pagesize;

            var prev = page <= 0 ? null : Url.Link(route, new { searchString, page = page - 1, pagesize });
            var next = page >= lastpage ? null : Url.Link(route, new { searchString, page = page + 1, pagesize });

            var result = new
            {
                Total = total,
                Prev = prev,
                Next = next,
                Data = data
            };
            return result;
        }
    }
}
