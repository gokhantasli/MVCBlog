using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;

namespace MVCBlog.App_Classes
{
    public class Settings
    {

        public static Size SmallImage
        {
            get
            {
                Size result = new Size();
                result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["SmallWide"]);
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["SmallHeight"]);
                return result;
            }
        }
        public static Size MediumImage
        {
            get
            {
                Size result = new Size();
                result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["MediumWide"]);
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["MediumHeight"]);
                return result;
            }
        }
        public static Size BigImage
        {
            get
            {
                Size result = new Size();
                result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["BigWide"]);
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["BigHeight"]);
                return result;
            }
        }
    }
}