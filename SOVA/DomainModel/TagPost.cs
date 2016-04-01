using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class TagPost
    {
        [Key, ForeignKey("Post"), Column(Order = 0)]
        public int PostId { get; set; }
        
        [Key, ForeignKey("Tag"), Column(Order = 1)]
        public int TagId { get; set; }
        
        public virtual Tag Tag { get; set; }
        public virtual Post Post { get; set; }
    }
}
