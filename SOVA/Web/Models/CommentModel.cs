using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class CommentModel
    {
        public string Url { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public DateTime CreateDate { get; set; }
        public string QuestionUrl { get; set; }
        public string AnswerUrl { get; set; }
        public string UserUrl { get; set; }
    }
}