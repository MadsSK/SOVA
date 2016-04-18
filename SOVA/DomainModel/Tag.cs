using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Body { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; } 
    }
}
