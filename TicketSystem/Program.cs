using System;
using NLog.Web;
using System.IO;

namespace TicketSystem
{
    class Program
    {
        // create static instance of Logger
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            logger.Info("Program started");
            
            string ticketFilePath = "ticket.csv";

            logger.Info("Program ended");
        }
    }
}
