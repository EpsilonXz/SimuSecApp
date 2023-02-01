using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SimuSecApp
{
    public class Logger
    {
        public void CurrentPathChange(string currLog)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            config.AppSettings.Settings.Remove("CurrentPath");
            config.AppSettings.Settings.Add("CurrentPath", System.IO.Directory.GetCurrentDirectory() + "\\Logs\\" + currLog);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        public static void WriteLog(string message, string currLog)
        {
            

            string logPath = ConfigurationManager.AppSettings["CurrentPath"];


            using (StreamWriter writer = new StreamWriter(logPath, true)) {
                writer.WriteLine($"{DateTime.Now} >> {message}");
            }
        }

        public static void ClearLog()
        {
            string logPath = ConfigurationManager.AppSettings["CurrentPath"];

            using (StreamWriter writer = new StreamWriter(logPath, false))
            {
                writer.WriteLine("");
            }
        }
    }
}
