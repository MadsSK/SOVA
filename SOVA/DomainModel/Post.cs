using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public int OwnerUserId { get; set; }

        [ForeignKey("OwnerUserId")]
        public User User { get; set; } 

        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<SearchUser> SearchUsers { get; set; } 
    }
}
