using System;
using System.Collections;
using System.Collections.Generic;


namespace Web.Models
{
    public class AnswerModel
    {
        public string Url { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public string UserUri { get; set; }

        public string QuestionUri { get; set; }

        public string CommentsUri { get; set; }
        
    }
}