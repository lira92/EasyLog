using System;
using System.IO;

namespace EasyLog
{
    public class Log
    {
        private static string _nomeLog;

        public static string NomeLog
        {
            get
            {
                if (String.IsNullOrEmpty(_nomeLog))
                {
                    _nomeLog = "Log_" + DateTime.Now.ToString("ddMMyyyyHHmm") + ".txt";
                }
                return _nomeLog;
            }
            set { _nomeLog = value; }
        }

        public static void escreveLog(string texto)
        {
            try
            {
                string path = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + "\\Logs";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (!File.Exists(path + "\\" + NomeLog))
                {
                    File.Create(path + "\\" + NomeLog).Close();
                }
                string content = File.ReadAllText(path + "\\" + NomeLog);
                File.WriteAllText(path + "\\" + NomeLog, content + " \r\n " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ": " + texto);
            }
            catch
            {
                throw;
            }
        }
    }
}
