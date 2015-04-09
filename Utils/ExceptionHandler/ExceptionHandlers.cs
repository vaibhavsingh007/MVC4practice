using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Diagnostics;

namespace ExceptionFacade
{
    public class ExceptionHandlers
    {

        /// <summary>
        /// Sets error filename prefix. Default is "ErrorLog_"
        /// </summary>
        internal static string ErrorFilenamePrefix = "ErrorLog_";

        /// <summary>
        /// Sets error folder path
        /// </summary>
        internal static string ErrorFolderPath = string.Empty;


        /// <summary>
        /// Inserts the exception message into error log file
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="errorFldrPath"></param>
        /// <param name="completeErrorMessage"></param>
        public static void LogException(Exception ex, string errorFldrPath, bool completeErrorMessage)
        {
            string ErrorMessage = ex.Message;
            string ErrorDescription = string.Empty;

            // preserve error folder path
            ExceptionHandlers.ErrorFolderPath = errorFldrPath;

            // get error description
            if (completeErrorMessage)
            {
                ErrorDescription = ex.ToString();
            }

            // write into log file only if value of error folder path is given by the client application
            if (!string.IsNullOrEmpty(ExceptionHandlers.ErrorFolderPath))
            {
                string temp = ErrorLogHelper.FileNamePrefix;
                ErrorLogHelper.FileNamePrefix = ExceptionHandlers.ErrorFilenamePrefix;
                ErrorLogHelper.WriteLog(ErrorMessage, ExceptionHandlers.ErrorFolderPath, ErrorDescription);
                ErrorLogHelper.FileNamePrefix = temp;
            }

            // throw exception so that it will be displayed on error view page
            throw ex;
        }

        
        /// <summary>
        /// Inserts the message into a log file
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="logFilePath"></param>
        public static void Log(string ex, string logFilePath)
        {
            string errorMessage = ex;
            ErrorLogHelper.WriteLog(errorMessage, logFilePath, String.Empty);
        }
    }
}


