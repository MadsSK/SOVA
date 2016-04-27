using System;
using DomainModel;


namespace Web.Models
{
    public class AnswerModel
    {
        public string Url { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public Question Question { get; set; }
    }
}