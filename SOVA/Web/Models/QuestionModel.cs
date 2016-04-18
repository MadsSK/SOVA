using System;
using System.Collections;


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
        public DateTime CloseDate { get; set; }
        public int AcceptedAnswerId { get; set; }
    }
}