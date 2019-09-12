using System;
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
        public static void Write(string className, string methodName, string logMessage)
        {
            try
            {
                string outputPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Adventure\\";
                using (StreamWriter w = File.AppendText(outputPath + "log.txt"))
                {
                    string output = "";
                    output += string.Format("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                    output += string.Format("\t{0}.{1}() | {2}", className, methodName, logMessage);

                    w.WriteLine(output);
                }
            }
            catch(Exception e)
            {
                // Catch it, but do nothing
                // This way the program won't crash
                // Hopefully...
            }
        }
    }
}
