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

        /// <summary>
        /// Metodo para Gravar Log em arquivos de Texto
        /// </summary>
        /// <param name="texto">String do log que será gravado.</param>
        /// <param name="arquivoLog">Nome do arquivo do log que sera gravado o texo. Por Default esse campo é null, grava sempre no mesmo arquivo.</param>
        public static void escreveLog(string texto, string arquivoLog = null)
        {
            try
            {
                #region Verifica Pasta onde será salvo os Log.
                string path = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + "\\Logs";

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                #endregion

                if (arquivoLog != null)
                {
                    if (!File.Exists(path + "\\" + arquivoLog))
                        File.Create(path + "\\" + arquivoLog).Close();

                    string content = File.ReadAllText(path + "\\" + arquivoLog);
                    File.WriteAllText(path + "\\" + arquivoLog, content + " \r\n " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ": " + texto);
                }
                else
                {
                    if (!File.Exists(path + "\\" + NomeLog))
                        File.Create(path + "\\" + NomeLog).Close();

                    string content = File.ReadAllText(path + "\\" + NomeLog);
                    File.WriteAllText(path + "\\" + NomeLog, content + " \r\n " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ": " + texto);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
