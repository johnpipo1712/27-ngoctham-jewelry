﻿using System;
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

        public static int Login(string username, string password)
        {
            GJSEntities Db_gsj = new GJSEntities();
            //check exist user (ensure that no duplicate user)
            S_USER USER_found = Db_gsj.S_USER.Single(t => t.USER_NAME == username);
            if (USER_found == null)
            {
                return 0;
            }

            //check active
            if (USER_found.ACTIVE == false)
            {
                return 0;
            }

            //compare password
            if (password != USER_found.USER_PASS)
            {
                return 0;
            }

            return (int)USER_found.STATUS;
            // 0: fail
            // 1: user normal login
            // 2: user catalog login
            // 3: admin login
        }

        public static void Logout()
        {
            // do nothing
        }
    }
}