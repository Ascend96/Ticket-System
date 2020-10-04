using System;
using System.Collections.Generic;

namespace TicketSystem
{

    public class Ticket
    {
        public UInt64 ticketId { get; set;}
        
        public string summary {get; set;}

        public string status {get; set;}

        public string priority {get; set;}

        public string submitter { get; set; }

        public string assigned { get; set; }

        public List<string> peopleWatching { get; set; }

        // constructor
        public Ticket(){
            peopleWatching = new List<string>();
        } 

        // display function for tickets
        public string Display(){
            return $"Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitted by: {submitter}\nAssigned to: {assigned}\nPerson(s) Watching: {string.Join(", ", peopleWatching)}\n";
            
        }

        
    }
}