using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    public class Question : Post
    {
        public string Title { get; set; }
        public DateTime? ClosedDate { get; set; }
        public int AcceptedAnswerId { get; set; }

        public virtual List<Answer> Answers { get; set; }
    }
}
