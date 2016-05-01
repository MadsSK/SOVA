using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SearchModel
    {
        public string Url { get; set; }
        public string SearchString { get; set; }
        public DateTime DateTime { get; set; }
        public string SearchUserUri { get; set; }
    }
}