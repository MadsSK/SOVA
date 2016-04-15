using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreationDate { get; set; }
        public string Location { get; set; }
        public int Age { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
