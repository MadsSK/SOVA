using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public partial class Favorit
    {
        [Key, ForeignKey("SearchUser"), Column(Order = 0)]
        public int SearchUserId { get; set; }

        [Key, ForeignKey("Post"), Column(Order = 1)]
        public int PostId { get; set; }

        public virtual SearchUser SearchUser { get; set; }
        public virtual Post Post { get; set; }
    }
}
