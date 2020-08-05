using System;
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

            localDirectory = System.Configuration.ConfigurationManager.AppSettings["localDirectory"].ToString();
            EscreverLog("Configurando localDirectory");

        }

        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            ConfigSettings();


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
