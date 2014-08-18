using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W_GJS.General
{
    public class Process
    {
       
        public static bool CheckExtensionImg(string extension)
        {
            string[] extensions = { "jpg", "jpeg", "gif", "png", "bmp", "jpe", "jfif", "tif", "JPG", "JPEG", "GIF", "PNG", "BMP", "JPE", "JFIF", "TIF" };

            int count = 0;
            foreach (string item in extensions)
            {
                if (extension == item)
                    count++;
            }
            if (count == 1)
                return true;

            return false;
        }
    }
}