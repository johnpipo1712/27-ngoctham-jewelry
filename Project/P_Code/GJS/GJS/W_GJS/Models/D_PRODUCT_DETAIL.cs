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
    
    public partial class D_PRODUCT_DETAIL
    {
        public long PRODUCT_DETAIL_CD { get; set; }
        public Nullable<long> PRODUCT_CD { get; set; }
        public string URL_IMAGE { get; set; }
        public Nullable<long> STATUS { get; set; }
        public Nullable<bool> ACTIVE { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
    
        public virtual O_PRODUCT O_PRODUCT { get; set; }
    }
}