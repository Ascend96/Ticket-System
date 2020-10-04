using System;
using NLog.Web;
using System.IO;
using System.Collections.Generic;

namespace TicketSystem
{
    class Program
    {
        // create static instance of Logger
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            // logs program has started
            logger.Info("Program started");
            // sets file path
            string ticketFilePath = "ticket.csv";
            // creates ticket file object
            TicketFile ticketFile = new TicketFile(ticketFilePath);
            // sets choice variable to route to correct path
            string choice = "";
          
          // do while loop for menu

            do {
                // 1 adds new ticket
                Console.WriteLine("1) Add Ticket");
                // 2 displays tickts in correct format
                Console.WriteLine("2) Display all tickets");
                // enter ends program
                Console.WriteLine("Enter to quit");
                // sets choice equal to users input
                choice = Console.ReadLine();

                // logs what choice user entered
                logger.Info("User choice: {choice}", choice);
                // if choice is equal to 1, create new ticket object
                if(choice == "1"){
                    Ticket ticket = new Ticket();
                    // asks for summary of ticket
                    Console.WriteLine("Enter Ticket Summary");
                    // takes users input and sets it equal to tickets summary
                    ticket.summary = Console.ReadLine();
                    // asks for status of ticket ("Complete" or "Working")
                    Console.WriteLine("Enter Ticket Status");
                    // takes users input and sets it equal to ticket status
                    ticket.status = Console.ReadLine();
                    // asks for priority level of ticket 
                    Console.WriteLine("Enter Priority Level");
                    // takes users input and sets it equal to ticket priority
                    ticket.priority = Console.ReadLine();
                    // asks for name of who submitted ticket
                    Console.WriteLine("Name of ticket submitter");
                    // takes users input and sets it equal to ticket submitter
                    ticket.submitter = Console.ReadLine();
                    // asks for name of person assigned to ticekt       
                    Console.WriteLine("Enter name of person assigned to this ticket");
                    // takes user input and sets it equal to ticket assigned
                    ticket.assigned = Console.ReadLine();
                    // creates input variable for if statement
                    string input;
                    // do while loop for entering multiple names watching the ticket
                   do{ 
                       // asks for name of people watching the ticket
                        Console.WriteLine("Enter Name of person(s) watching the ticket(Enter done to quit)");
                        // sets input equal to users input
                        input = Console.ReadLine();
                        // if it doesnt equal done and its greater than zero, add it to ticket peopleWatching
                        if(input != "done" && input.Length > 0){
                            ticket.peopleWatching.Add(input);
                        }

                    // if user enters "done" quit loop and add nobody is listed watching
                    }while (input != "done"); 
                        if(ticket.peopleWatching.Count == 0){
                            ticket.peopleWatching.Add("No listed watchers"); } 

                       // adds ticket to ticketFile to process streamwriter 
                       ticketFile.AddTicket(ticket); 
                     // if choice is equal to "2", display all tickets
                } else if(choice == "2"){
                    foreach(Ticket t in ticketFile.Tickets){
                        Console.WriteLine(t.Display());
                    }
                }

                // while condition for menu
            } while(choice == "1" || choice == "2");
            // logs program has ended
            logger.Info("Program ended");
        }
    }
}
