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
    
    public partial class O_CUSTOMER
    {
        public O_CUSTOMER()
        {
            this.O_ORDER = new HashSet<O_ORDER>();
            this.O_USER_CUSTOMER = new HashSet<O_USER_CUSTOMER>();
        }
        [Display(Name = "Khách hàng")]
        public long CUSTOMER_CD { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin !!!")]
        [DataType(DataType.Text)]
        [Display(Name = "Mã khách hàng")]
        public string CUSTOMER_CODE { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin !!!")]
        [DataType(DataType.Text)]
        [Display(Name = "Tên khách hàng")]
        public string CUSTOMER_NAME { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin !!!")]
        [DataType(DataType.Text)]
        [Display(Name = "Tên")]
        public string CUSTOMER_FIRST_NAME { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin !!!")]
        [DataType(DataType.Text)]
        [Display(Name = "Họ")]
        public string CUSTOMER_LAST_NAME { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin !!!")]
        [DataType(DataType.Text)]
        [Display(Name = "Địa chỉ")]
        public string ADDRESS { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin !!!")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Vui lòng nhập đúng Email")]
        [Display(Name = "Email")]
        public string EMAIL { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin !!!")]
        [DataType(DataType.Text)]
        [Display(Name = "Giới tính")]
        public string SEX { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin !!!")]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày sinh")]
        public Nullable<System.DateTime> BIRTHDAY { get; set; }
        public Nullable<long> STATUS { get; set; }
        public Nullable<bool> SUBSCRIBE { get; set; }
        public Nullable<bool> ACTIVE { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin !!!")]
        [DataType(DataType.Text)]
        [Display(Name = "SĐT")]
        public string PHONE { get; set; }
    
        public virtual ICollection<O_ORDER> O_ORDER { get; set; }
        public virtual ICollection<O_USER_CUSTOMER> O_USER_CUSTOMER { get; set; }
    }
}
