using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Annotation
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int CommentId { get; set; }
        public int SearchUserId { get; set; }
        public int PostId { get; set; }
    }
}
