using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Web.Models
{
    public class CommonViewModel
    {
        public IEnumerable<TrendsViewModel> TrendsViewModel { get; set; }
        public IEnumerable<SelectListItem> ListaCidadesPorPaises { get; set; }
        public ItemViewModel ItemViewModel { get; set; }
    }
}
