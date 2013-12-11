using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace s3auto.Helper
{
    public class Logger
    {
        private static Logger log = null;
        private const string LogFileName = "Log.txt";

        public void WriteLine(string format, params string[] args)
        {
            string line = string.Format(format, args);
            string timestamp = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ");
            line = timestamp + line + "\r\n";
            System.IO.File.AppendAllText(LogFileName, line);
        }

        public static void Log(string format, params string[] args)
        {
            if (log == null)
                log = new Logger();
            log.WriteLine(format, args);
        }
    }
}
