﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel.DataAnnotations;
    
    public partial class O_CATEGORY_NEWS
    {
        public O_CATEGORY_NEWS()
        {
            this.O_NEWS = new HashSet<O_NEWS>();
        }
        [Display(Name = "Danh mục tin tức")]
        public long CATEGORY_NEWS_CD { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin !!!")]
        [DataType(DataType.Text)]
        [Display(Name = "Mã danh mục tin tức")]
        public string CATEGORY_NEWS_CODE { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin !!!")]
        [DataType(DataType.Text)]
        [Display(Name = "Tên danh mục tin tức")]
        public string CATEGORY_NEWS_NAME { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Thẻ alt")]
        public string TAG_ALT { get; set; }
        public Nullable<long> STATUS { get; set; }
        public Nullable<bool> ACTIVE { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
    
        public virtual ICollection<O_NEWS> O_NEWS { get; set; }
    }
}
