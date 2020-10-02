using System;
using System.Collections.Generic;
using System.IO;
using NLog.Web;
using System.Linq;

namespace TicketSystem
{
    public class TicketFile {
        public string filePath { get; set; }

        public List<Ticket> Tickets { get; set; }

        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public TicketFile(string ticketFilePath){

        filePath = ticketFilePath;
        Tickets = new List<Ticket>();


        try {
            StreamReader sr = new StreamReader(filePath);
            sr.ReadLine();

            while (!sr.EndOfStream){
                Ticket ticket = new Ticket();
                string line = sr.ReadLine();

                string[] ticketDetails = line.Split(',');
                ticket.ticketId = UInt64.Parse(ticketDetails[0]);
                ticket.summary = ticketDetails[1];
                ticket.status = ticketDetails[2];
                ticket.priority = ticketDetails[3];
                ticket.submitter = ticketDetails[4];
                ticket.assigned = ticketDetails[5];
                ticket.peopleWatching = ticketDetails[6].Split('|').ToList();

                Tickets.Add(ticket);
            }
            sr.Close();
            logger.Info("Tickets in file {count}", Tickets.Count);
            
        } catch (Exception ex)
        {
            logger.Error(ex.Message);
        }

        }
    }
}