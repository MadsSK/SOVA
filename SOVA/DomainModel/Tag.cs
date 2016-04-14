using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Body { get; set; }

        public virtual ICollection<Post> Posts { get; set; } 
    }
}
