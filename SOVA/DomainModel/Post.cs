using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public DateTime CloseDate { get; set; }
        public string Title { get; set; }
        public int OwnerUserId { get; set; }
    }
}
