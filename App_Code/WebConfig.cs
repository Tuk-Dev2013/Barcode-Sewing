using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PicklistBOM
{
    public class WebConfig
    {

        public static string GetconnectionLeanBarcode()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBLeanBarcode"].ConnectionString;
            //   return ConfigurationManager.AppSettings("DBConnectionString");
        }

        //public static string GetconnectionAccpac()
        //{
        //    return System.Configuration.ConfigurationManager.ConnectionStrings["DBAccpac"].ConnectionString;
        //    //   return ConfigurationManager.AppSettings("DBConnectionString");
        //}

        public static string GetconnectionBarcode()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBBarcode"].ConnectionString;
            //   return ConfigurationManager.AppSettings("DBConnectionString");
        }

        public static string GetconnectionAccpac()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBAccpac"].ConnectionString;
            //   return ConfigurationManager.AppSettings("DBConnectionString");
        }

        public static string GetconnectionAccess()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBEXPORTConnectionString"].ConnectionString;
            //   return ConfigurationManager.AppSettings("DBConnectionString");
        }
        public static string GetconnectionAccesslocal()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBEXPORTConnectionStringlocal"].ConnectionString;
            //   return ConfigurationManager.AppSettings("DBConnectionString");
        }
    }
}