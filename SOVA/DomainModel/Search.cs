using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    public class Search
    {
        public int Id { get; set; }
        public string SearchString { get; set; }
        public DateTime DateTime { get; set; }
        public int SearchUserId { get; set; }

        public virtual SearchUser SearchUser { get; set; }
    }
}
