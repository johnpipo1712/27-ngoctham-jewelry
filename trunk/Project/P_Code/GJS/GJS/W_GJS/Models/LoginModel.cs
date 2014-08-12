using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace W_GJS.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        [DataType(DataType.Text)]
        [Display(Name = "Tên đăng nhập")]
        [RegularExpression(@"\w\w*\b(?=(\s|\r|\n|$))", ErrorMessage = "Vui lòng không nhập kí tự đặt biệt")]
        public string USER_NAME { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        [RegularExpression(@"\w\w*\b(?=(\s|\r|\n|$))", ErrorMessage = "Vui lòng không nhập kí tự đặt biệt")]
        [Display(Name = "Mật khẩu")]
        public string USER_PASS { get; set; }

    }
}