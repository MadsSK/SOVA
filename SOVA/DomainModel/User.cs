using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class User
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreationDate { get; set; }
        public string Location { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
