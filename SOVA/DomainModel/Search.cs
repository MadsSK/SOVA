using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Search
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SearchString { get; set; }
        public DateTime DateTime { get; set; }
    }
}
