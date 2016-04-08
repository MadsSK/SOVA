using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public partial class Post
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public int OwnerUserId { get; set; }
        public virtual ICollection<Favorit> Favorites { get; set; }
        public virtual ICollection<TagPost> TagPosts { get; set; }
    }
}
