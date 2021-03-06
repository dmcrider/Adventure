﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

// Got this class from https://stackoverflow.com/a/20185061
// Made some changes to make it static with only one method

namespace Adventure
{
    public static class LogWriter
    {
        private static bool IsFirstLog = true;

        public static void Write(string className, string methodName, LogType type, string logMessage)
        {
            try
            {
                string outputPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Adventure\\";

                using (StreamWriter w = File.AppendText(outputPath + "log.txt"))
                {
                    string output = IsFirstLog ? "******************************************\n" : "";
                    output += string.Format("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                    output += string.Format("\t{0}.{1}() | {2} - {3}", className, methodName, type, logMessage);

                    w.WriteLine(output);
                }

                if (IsFirstLog)
                {
                    IsFirstLog = false;
                }
            }
            catch
            {
                // Catch it, but do nothing
                // This way the program won't crash
                // Hopefully...
            }
        }

        public enum LogType
        {
            Error,
            Success,
            Critical,
            Info,
            Warning,
            Debug,
            GamePlay,
            NotYetImplemented
        }
    }
}
