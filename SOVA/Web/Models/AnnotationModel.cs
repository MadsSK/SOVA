using System;
using System.Collections;


namespace Web.Models
{
    public class AnnotationModel
    {
        public string Url { get; set; }
        public string Body { get; set; }
        public int MarkingStart { get; set; }
        public int MarkingEnd { get; set; }
        public int? PostId { get; set; }
        public int? CommentId { get; set; }
        public int SearchUserId { get; set; }
        public string QuestionUrl { get; set; }
        public string AnswerUrl { get; set; }
        public string CommentUrl { get; set; }
        public string SearchUserUrl { get; set; }

    }
}