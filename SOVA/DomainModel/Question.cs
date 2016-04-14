using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    public class Question : Post
    {
        public string Title { get; set; }
        public DateTime CloseDate { get; set; }
        public int AcceptedAnswerId { get; set; }

        [ForeignKey("AcceptedAnswerId")]
        public virtual Post Post { get; set; }   
    }
}
