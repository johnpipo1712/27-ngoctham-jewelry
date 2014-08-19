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
    
    public partial class D_CITIES_DETAIL
    {
        public D_CITIES_DETAIL()
        {
            this.O_BRANCH = new HashSet<O_BRANCH>();
        }

        [Required(ErrorMessage = "Vui lòng nhập thông tin !!!")]
        [Display(Name = "Thành phố")]
        public long CITIES_DETAIL_CD { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin !!!")]
        [Display(Name = "Khu vực")]
        public Nullable<long> CITIES_CD { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin !!!")]
        [DataType(DataType.Text)]
        [Display(Name = "Mã thành phố")]
        public string CITIES_DETAIL_CODE { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin !!!")]
        [DataType(DataType.Text)]
        [Display(Name = "Tên thành phố")]
        public string CITIES_DETAIL_NAME { get; set; }

        public Nullable<long> STATUS { get; set; }
        public Nullable<bool> ACTIVE { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
    
        public virtual O_CITIES O_CITIES { get; set; }
        public virtual ICollection<O_BRANCH> O_BRANCH { get; set; }
    }
}
