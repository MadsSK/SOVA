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
        public string QuestionUri { get; set; }
        public string AnswerUri { get; set; }
        public string CommentUri { get; set; }
        public string SearchUserUri { get; set; }

        /*
        public virtual PostModel Post { get; set; }

        public virtual CommentModel Comment { get; set; }

        public virtual SearchUserModel SearchUser { get; set; }
        */
    }
}