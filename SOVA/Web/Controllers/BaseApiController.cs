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
        protected object GetAll<T>(IEnumerable<T> data)
        {
            var result = new
            {
                Data = data
            };
            return result;
        }
    }
}
