using System;
using System.IO;
using log4net.Config;

namespace ImportacaoArquivo
{
    class Program
    {

        //static log4net.ILog log = log4net.LogManager.GetLogger("ImportacaoArquivo");
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
        static string localDirectory = string.Empty;
        static string localRepositorio = string.Empty;

        static void ConfigSettings()
        {
            EscreverLog("Configurando localDirectory");
            localDirectory = System.Configuration.ConfigurationManager.AppSettings["localDirectory"].ToString();

            EscreverLog("Configurando localRepositorio");
            localRepositorio = System.Configuration.ConfigurationManager.AppSettings["localRepositorio"].ToString();

            MoverArquivos();

        }

        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            ConfigSettings();


        }

        static void MoverArquivos()
        {
            DirectoryInfo dir = new DirectoryInfo(localDirectory);
            string destino = localRepositorio;

            foreach (FileInfo f in dir.GetFiles("*"))
            {
                EscreverLog("Arquivo sendo transferido" + f.Name);
                File.Move(f.FullName, destino + f.Name);
            }
        }

        public static void EscreverLog(string mensagem, bool logDeErro = false, Exception erro = null)
        {
            if (logDeErro)
                log.Info(mensagem + " - " + ((erro != null) ? erro.Message.ToString() : ""));
            else
                log.Info(mensagem);

        }

    }
}
