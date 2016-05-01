using System;
using System.Collections;
using System.Collections.Generic;


namespace Web.Models
{
    public class QuestionModel
    {
        public string Url { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string UserUri { get; set; }

        public DateTime? ClosedDate { get; set; }
        public int AcceptedAnswerId { get; set; }

        public string TagsUri { get; set; }
        public string CommentsUri { get; set; }
        public string LinkedPostsUri { get; set; }

        public string AnswersUri { get; set; }
    }
}