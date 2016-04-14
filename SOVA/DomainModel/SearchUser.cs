using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class SearchUser
    {
        [Key]
        public int Id { get; set; }
        public string MacAdresse { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
        public virtual IEnumerable<Annotation> Annotations { get; set; }
        public virtual IEnumerable<Search> Searches { get; set; }
    }
}
