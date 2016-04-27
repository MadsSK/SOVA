using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }

        public User User { get; set; } 

        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Annotation> Annotations { get; set; } 
        public virtual ICollection<SearchUser> SearchUsers { get; set; }
        public virtual ICollection<Post> LinkedPosts { get; set; }
    }
}
