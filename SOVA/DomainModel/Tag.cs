using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Tag
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public virtual ICollection<TagPost> TagPosts { get; set; } 
    }
}
