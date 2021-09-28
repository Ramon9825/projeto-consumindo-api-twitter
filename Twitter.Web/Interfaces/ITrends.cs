using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Web.Interfaces
{
    public interface ITrends
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
