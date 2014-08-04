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
    
    public partial class O_PRODUCT
    {
        public O_PRODUCT()
        {
            this.D_ORDER_DETAIL = new HashSet<D_ORDER_DETAIL>();
            this.D_PRODUCT_DETAIL = new HashSet<D_PRODUCT_DETAIL>();
        }
    
        public long PRODUCT_CD { get; set; }
        public string PRODUCT_CODE { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string PRODUCT_TITLE { get; set; }
        public string PRODUCT_CONTENT { get; set; }
        public Nullable<long> CATEGORY_PRODUCT_CD { get; set; }
        public Nullable<long> QUANTITY { get; set; }
        public Nullable<decimal> PRICE { get; set; }
        public string TAG_ALT { get; set; }
        public Nullable<long> STATUS { get; set; }
        public Nullable<bool> ACTIVE { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
    
        public virtual ICollection<D_ORDER_DETAIL> D_ORDER_DETAIL { get; set; }
        public virtual ICollection<D_PRODUCT_DETAIL> D_PRODUCT_DETAIL { get; set; }
        public virtual O_CATEGORY_PRODUCT O_CATEGORY_PRODUCT { get; set; }
    }
}
