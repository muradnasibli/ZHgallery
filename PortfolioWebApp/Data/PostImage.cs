using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApp.Data
{
    public class PostImage
    {
        public int Id { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
