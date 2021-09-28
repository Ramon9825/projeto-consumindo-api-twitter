using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Web.Models
{
    public class SelectViewModel
    {
        public string Id { get; set; }
        public IEnumerable<SelectListItem> List { get; set; }
    }
}
