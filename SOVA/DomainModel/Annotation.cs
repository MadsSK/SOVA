using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    public class Annotation
    {
        [Key]
        public int Id { get; set; }
        public string Body { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public int SearchUserId { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }

        [ForeignKey("CommentId")]
        public Comment Comment { get; set; }

        [ForeignKey("SearchUserId")]
        public SearchUser SearchUser { get; set; }
    }
}
