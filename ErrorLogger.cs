
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StegWaterMark {
    static class ErrorLogger {
        public static void Log(string msg, Exception ex = null) {
            msg = " --> " + msg + " --> " + ex?.Message;
            WriteLog(@"Resource\ErrorLog.txt", msg);
        }

        private static void ShowLog(StreamReader r) {
            string line;
            while ((line = r.ReadLine()) != null) {
                Console.WriteLine(line);
            }
        }

        private static void WriteLog(string relpath, string text) {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), relpath);
            using (StreamWriter w = File.AppendText(path)) {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", text);
                w.WriteLine("-------------------------------");
            }

            using (StreamReader r = File.OpenText(path)) {
                ShowLog(r);
            }
        }
    }
}
