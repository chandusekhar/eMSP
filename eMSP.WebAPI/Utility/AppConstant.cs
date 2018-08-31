using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace eMSP.WebAPI.Utility
{
    public class AppConstant
    {
        static string filename =  HttpContext.Current.Server.MapPath(String.Format("{0}{1}.txt",ConfigurationManager.AppSettings["logFileName"] , DateTime.Now.ToString("yyyyMMdd")));
        static string _apppath = HttpContext.Current.Server.MapPath("~/");
        static string _password = ConfigurationManager.AppSettings["CustomPassword"];



        public static string AppPath
        {
            get { return _apppath; }
            
        }

        public static string AppLogPath
        {
            get { return filename; }

        }

        public static string FileUploadPath
        {
            get { return ConfigurationManager.AppSettings["baseUploadPath"]; }

        }

        public static string AppPassword
        {
            get { return _password; }

        }

        
    }

}