using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W_GJS.Models
{
    public class ProductCategoryModel
    {
        public long Identified { get; set; }
        public string HtmlProductListString { get; set; }
        public long ItemOrderFrom { get; set; }
        public long ItemOrderTo { get; set; }
        public long TotalItems { get; set; }
        public long CurrentPage { get; set; }
        public long TotalPages { get; set; }
    }
}