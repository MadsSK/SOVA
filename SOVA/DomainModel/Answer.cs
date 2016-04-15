using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    public class Answer : Post
    {
        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
    }
}
