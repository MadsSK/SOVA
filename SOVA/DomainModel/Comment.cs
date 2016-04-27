using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    public class Comment
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public DateTime CreateDate { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }

        public Post Post { get; set; }

        public User User { get; set; }

        public virtual ICollection<Annotation> Annotations { get; set; }
    }
}
