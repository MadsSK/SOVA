using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SearchUserModel
    {
        public string Url { get; set; }
        public string MacAdresse { get; set; }
        public string AnnotationsUrl { get; set; }
        public string FavoritesUrl { get; set; }
        public string SearchsUrl { get; set; }
    }
}