using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Task3Classs
    {
        enum tickets { Silver, Gold, Diamond }
        int silverTicketRate;
        int goldTicketRate;
        int diamondTicketRate;

        int totalCost;

        public void ticketBaseRate(int silverRate, int goldRate, int diamondRate)
        {
            silverTicketRate = silverRate;
            goldTicketRate = goldRate;
            diamondTicketRate = diamondRate;
        }
        public void displayTicketOption()
        {

            foreach (tickets i in Enum.GetValues(typeof(tickets)))
            {
                switch (i)
                {
                    case tickets.Silver:
                        Console.WriteLine($"{i}     : Rs.{silverTicketRate}");
                        break;
                    case tickets.Gold:
                        Console.WriteLine($"{i}       : Rs.{goldTicketRate}");
                        break;
                    case tickets.Diamond:
                        Console.WriteLine($"{i}    : Rs.{diamondTicketRate}");
                        break;
                }

            }
        }


        public int totalTicketCost(string ticketType, int noOfTicket)
        {

            if (noOfTicket < 0)
            {
                Console.WriteLine("**INVALID NO.OF TICKETS!**");
            }
            else
            {

                switch (ticketType)
                {
                    case "s":
                        totalCost = silverTicketRate * noOfTicket;
                        break;
                    case "g":
                        totalCost = goldTicketRate * noOfTicket;
                        break;
                    case "d":
                        totalCost = diamondTicketRate * noOfTicket;
                        break;

                }
            }

            return totalCost;
        }

    }
}
