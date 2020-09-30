using System;
using System.IO;

namespace Ticketcsv
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates name for file
            string file = "TicketsCSV.txt";
            string input;
            // Loop to go down correct path based on input entered
            do{
                Console.WriteLine("1: Read File.");
                Console.WriteLine("2: Enter Ticket.");
                Console.WriteLine("Enter any other key to exit.");

                input = Console.ReadLine();
                // Condition to go to path 1
                if(input == "1"){
                    // If file exists, read file
                    if (File.Exists(file)) {
                        StreamReader sr = new StreamReader(file);
                        // Creates and displays array information with file information
                        while(!sr.EndOfStream) {
                            string line = sr.ReadLine();
                            string [] arr = line.Split(",");
                            Console.WriteLine("Ticket ID: " + arr[0] + " Summary: " + arr[1] + " Status: " + arr[2] + " Priority: " + arr[3] + " Submitter: " + arr[4] + " Assigned to: " + arr[5] + " Watching: " + arr[6]);
                        }
                        // Closes the file writer
                        sr.Close();
                    }
                    // If file doesn't exist, display message
                 else {
                     Console.WriteLine("File does not exist");
                     } 
                 }
                 // Condition to go to path 2
                else if (input == "2") {
                    // Creates file if not already there
                    // If file is there, append new information into it
                     StreamWriter sw = new StreamWriter(file, append:true);
                    // For loop to display and capture information for ticket
                     for (int i = 0; i < 1; i++){
                         // Asks for the ticket ID and has user input information
                        Console.WriteLine("Enter the ticket ID.");
                        string ticketID = Console.ReadLine();  
                        // Asks and takes information for ticket summary
                        Console.WriteLine("Enter a summary of the ticket.");                       
                        string summary = Console.ReadLine();
                        // Asks and takes information for ticket status
                        Console.WriteLine("Enter status of ticket.");
                        string status = Console.ReadLine();
                        // Asks and takes information for priorty level
                        Console.WriteLine("Enter priority level of ticket.");
                        string priority = Console.ReadLine();
                        // Asks and takes information of ticket submitter
                        Console.WriteLine("Enter name of person submitting ticket.");
                        string submitter = Console.ReadLine();
                        // Asks and takes infomrmation of who is assigned the ticket
                        Console.WriteLine("Enter name of person ticket is assigned to.");
                        string assigned = Console.ReadLine();
                        // Asks and takes information for all people watching ticket
                        Console.WriteLine("Enter names of people watching the ticket.");
                        Console.WriteLine("If multiple, Use (John Smith | Jane Doe) Format.");
                        string peopleWatching = Console.ReadLine();                    
                        // displays ticket information into console
                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", ticketID, summary, status, priority, submitter, assigned, peopleWatching);
                     }
                     // Closes file writer
                    sw.Close();
                }
                // While condition for Do While loop
            } while (input == "1" || input == "2");
        }
    }
}