using System;
using System.Collections.Generic;
using System.IO;
using NLog.Web;
using System.Linq;

namespace TicketSystem
{
    public class TicketFile {

        // public property
        public string filePath { get; set; }

        public List<Ticket> Tickets { get; set; }

        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        // ticket file function for reading and writing to file
        // invoked when an instance of a class is created
        public TicketFile(string ticketFilePath){

        filePath = ticketFilePath;
        Tickets = new List<Ticket>();

        // populates list with data and reads file
        try {
            StreamReader sr = new StreamReader(filePath);
            sr.ReadLine();

            while (!sr.EndOfStream){
                // Creates ticket class
                Ticket ticket = new Ticket();
                string line = sr.ReadLine();
                // creates array of comma delimited file
                string[] ticketDetails = line.Split(',');
                // stores each index of array into correct ticket property
                ticket.ticketId = UInt64.Parse(ticketDetails[0]);
                ticket.summary = ticketDetails[1];
                ticket.status = ticketDetails[2];
                ticket.priority = ticketDetails[3];
                ticket.submitter = ticketDetails[4];
                ticket.assigned = ticketDetails[5];
                ticket.peopleWatching = ticketDetails[6].Split('|').ToList();
                // adds the ticket to the list
                Tickets.Add(ticket);
            }
            sr.Close();
            // logs how many tickets are in file
            logger.Info("Tickets in file {count}", Tickets.Count);
            
        } catch (Exception ex)
        {
            logger.Error(ex.Message);
        }
        }
        // function for adding ticket to file
        public void AddTicket(Ticket ticket){
            try {
                // sets ticket ID equal to 1 more than the previous
                ticket.ticketId = Tickets.Max(t => t.ticketId) + 1;
                // writes to file
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{ticket.ticketId}, {ticket.summary}, {ticket.status}, {ticket.priority}, {ticket.submitter}, {ticket.assigned}, {string.Join("| ", ticket.peopleWatching)}");
                // closes streamwriter 
                sw.Close(); 
                // adds to ticket list to display
                Tickets.Add(ticket);
                // logs ticket id of one entered
                logger.Info("Ticket id {id} added", ticket.ticketId);
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
            }
            
        }

    }                                                                                                                                                
}
