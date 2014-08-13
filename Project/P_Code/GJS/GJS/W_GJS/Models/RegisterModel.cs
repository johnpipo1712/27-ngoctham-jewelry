using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Data.Entity;


namespace W_GJS.Models
{
    public class RegisterModel
    {
        public string USER_NAME { get; set; }

        public string USER_PASS { get; set; }

        public string EMAIL { get; set; }

        public string FIRST_NAME { get; set; }

        public string LAST_NAME { get; set; }

        public string SEX { get; set; }

        public static bool Register(RegisterModel MODEL)
        {
            GJSEntities Db_gsj = new GJSEntities();
            try
            {
                // store user entity: username, password, active = 1, create date = now, status = 1 (user normal always)
                S_USER USER = new S_USER();
                USER.ACTIVE = true;
                USER.STATUS = 1;
                USER.CREATEDATE = DateTime.Now;
                USER.USER_NAME = MODEL.USER_NAME;
                USER.USER_PASS = MODEL.USER_PASS;

                Db_gsj.Entry(USER).State = EntityState.Added;
                Db_gsj.SaveChanges();

                // store customer entity: email, first name, last name, sex, active = 1, create date = now
                O_CUSTOMER CUSTOMER = new O_CUSTOMER();
                CUSTOMER.ACTIVE = true;
                CUSTOMER.STATUS = 1; // henxui
                CUSTOMER.CREATEDATE = DateTime.Now;
                CUSTOMER.EMAIL = MODEL.EMAIL;
                //first name, last name, sex,
                Db_gsj.Entry(CUSTOMER).State = EntityState.Added;
                Db_gsj.SaveChanges();

                // link user and customer
                O_USER_CUSTOMER USER_CUSTOMER = new O_USER_CUSTOMER();
                USER_CUSTOMER.ACTIVE = true;
                USER_CUSTOMER.STATUS = 1; // henxui
                USER_CUSTOMER.CREATEDATE = DateTime.Now;
                USER_CUSTOMER.CUSTOMER_CD = CUSTOMER.CUSTOMER_CD; // Tu co???
                USER_CUSTOMER.USER_CD = USER.USER_CD; // Tu co???

                Db_gsj.Entry(USER_CUSTOMER).State = EntityState.Added;
                Db_gsj.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}