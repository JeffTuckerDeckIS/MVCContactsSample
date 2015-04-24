using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SampleMvcContacts.Utilities
{
    public static class Logger
    {
        /// <summary>
        /// Write Error Log to the Log File specified in 
        /// Web.Config file > AppSettings 
        /// Key = "ErrorLogFile"
        /// </summary>
        /// <param name="errorMessage">Error Message to be written to the log file</param>
        public static void Log(string errorMessage)
        {           
                string fileLocation = ConfigurationManager.AppSettings["ErrorLogFile"];
                string logFile = MakeDateFile(fileLocation);

                System.IO.StreamWriter sw = System.IO.File.AppendText(logFile);
                sw.WriteLine("ApplicationError: " + System.DateTime.Now.ToString());                
                sw.WriteLine(errorMessage);
                sw.Close();        
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