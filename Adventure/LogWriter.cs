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
        public static void Write(string logMessage)
        {
            string outputPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Adventure\\";
            try
            {
                using (StreamWriter w = File.AppendText(outputPath + "log.txt"))
                {
                    try
                    {
                        w.Write("\r\nLog Entry : ");
                        w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                            DateTime.Now.ToLongDateString());
                        w.WriteLine("  :");
                        w.WriteLine("  :{0}", logMessage);
                        w.WriteLine("-------------------------------");
                    }
                    catch
                    {
                        // Do nothing for now
                    }
                }
            }
            catch
            {
                // Do nothing for now
            }
        }
    }
}
