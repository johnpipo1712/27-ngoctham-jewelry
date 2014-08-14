//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace W_GJS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class O_NEWS
    {
        public O_NEWS()
        {
            this.O_NEWS_HIGHLIGHTS = new HashSet<O_NEWS_HIGHLIGHTS>();
            this.O_NEWS_NEW = new HashSet<O_NEWS_NEW>();
        }
    
        public long NEWS_CD { get; set; }
        public string NEWS_TITLE { get; set; }
        public string NEW_DESCRIPTIONS { get; set; }
        public string NEWS_CONTENT { get; set; }
        public string IMAGE_NEWS { get; set; }
        public Nullable<long> CATEGORY_NEWS_CD { get; set; }
        public string SOURCE_COPY { get; set; }
        public string TAG_ALT { get; set; }
        public Nullable<long> EMPLOYEE_CD { get; set; }
        public Nullable<long> STATUS { get; set; }
        public Nullable<bool> ACTIVE { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
    
        public virtual M_EMPLOYEE M_EMPLOYEE { get; set; }
        public virtual O_CATEGORY_NEWS O_CATEGORY_NEWS { get; set; }
        public virtual ICollection<O_NEWS_HIGHLIGHTS> O_NEWS_HIGHLIGHTS { get; set; }
        public virtual ICollection<O_NEWS_NEW> O_NEWS_NEW { get; set; }
    }
}
