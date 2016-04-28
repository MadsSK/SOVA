using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    public class Annotation
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int MarkingStart { get; set; }
        public int MarkingEnd { get; set; }
        public int? PostId { get; set; }
        public int? CommentId { get; set; }
        public int SearchUserId { get; set; }

        public Post Post { get; set; }

        public Comment Comment { get; set; }

        public SearchUser SearchUser { get; set; }
    }
}
