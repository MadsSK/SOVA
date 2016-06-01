using System;
using System.Collections;
using System.Collections.Generic;


namespace Web.Models
{
    public class QuestionModel
    {
        public string Url { get; set; }
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string UserUrl { get; set; }

        public DateTime? ClosedDate { get; set; }
        public int AcceptedAnswerId { get; set; }

        public string TagsUrl { get; set; }
        public string CommentsUrl { get; set; }
        public string LinkedPostsUrl { get; set; }

        public string AnswersUrl { get; set; }
    }
}