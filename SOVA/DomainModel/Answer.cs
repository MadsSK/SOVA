using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    public class Answer : Post
    {
        public int ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Post Post { get; set; }
    }
}
