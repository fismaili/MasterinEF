using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasteringEF.Models
{
    public class Blog
    {
        public int id { get; set; }
        public string Url { get; set; }
        public ICollection<Post>Posts { get; set; }
    }
}
