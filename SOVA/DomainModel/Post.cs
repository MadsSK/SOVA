using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } 

        public virtual IEnumerable<Tag> Tags { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
        public virtual IEnumerable<Annotation> Annotations { get; set; } 
        public virtual IEnumerable<SearchUser> SearchUsers { get; set; }
        public virtual IEnumerable<Post> LinkedPosts { get; set; }
    }
}
