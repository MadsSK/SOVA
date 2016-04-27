using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class SearchUser
    {
        public int Id { get; set; }
        public string MacAdresse { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Annotation> Annotations { get; set; }
        public virtual ICollection<Search> Searches { get; set; }
    }
}
