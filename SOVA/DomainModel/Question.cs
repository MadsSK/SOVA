using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    public class Question : Post
    {
        public string Title { get; set; }
        public DateTime CloseDate { get; set; }
        public int AcceptedAnswerId { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
