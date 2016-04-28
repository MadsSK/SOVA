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
        public string Body { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime? ClosedDate { get; set; }
        public int AcceptedAnswerId { get; set; }

        public virtual IList<TagModel> QuestionTags { get; set; }
        /*
        public virtual ICollection<AnswerModel> Answers { get; set; }
        
        public virtual ICollection<CommentModel> Comments { get; set; }
        public virtual ICollection<AnnotationModel> Annotations { get; set; }
        public virtual ICollection<SearchUserModel> SearchUsers{ get; set; }
        */
    }
}