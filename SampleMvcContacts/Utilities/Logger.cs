using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SampleMvcContacts.Utilities
{
    public static class Logger
    {
        public static void Log(string errorMessage)
        {
            try
            {
                string logFile = MakeDateFile(@"c:\temp\SampleMVCContactLog-yyyy.MM.dd.txt");

                System.IO.StreamWriter w = System.IO.File.AppendText(logFile);
                w.WriteLine(errorMessage);
                w.Close();
            }
            catch
            { 
                // Please allow ASP.NET, IISUSER, or EVERYONE access to C:\temp directory.
            }           

        }

        /// <summary>
        /// Help FileName to add Date and Time
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns>File Name with Date Time info</returns>
        private static string MakeDateFile(string filepath)
        {
            filepath = filepath.Replace("yyyy", System.DateTime.Now.ToString("yyyy"));
            filepath = filepath.Replace("MM", System.DateTime.Now.ToString("MM"));
            filepath = filepath.Replace("mm", System.DateTime.Now.ToString("MM"));
            filepath = filepath.Replace("dd", System.DateTime.Now.ToString("dd"));
            return filepath;
        }
    }
}