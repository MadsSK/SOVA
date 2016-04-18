using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public DateTime CreateDate { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public virtual ICollection<Annotation> Annotations { get; set; }
    }
}
