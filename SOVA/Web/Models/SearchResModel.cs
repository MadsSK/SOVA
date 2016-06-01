using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SearchResModel
    {
        public string Url { get; set; }
        public int Rank { get; set; }
        public string Word { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}