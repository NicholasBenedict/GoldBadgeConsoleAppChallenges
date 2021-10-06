using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings
{
    public class OutingsUI
    {
        private OutingsRepo _repo = new OutingsRepo();
        public void Run()
        {
            SeedData();
            RunMenu();
            
        }
        private void RunMenu()
        {
            bool isRunning = true;

            while(isRunning)
            {
                Console.Clear();
                Console.WriteLine
                    (
                        "Enter the number of your selection: \n" +
                        "1. Display all outings\n" +
                        "2. Add an outing to the list\n" +
                        "3. Display Cost of All Outings\n" +
                        "4. Display Cost of Outing by Type\n" +
                        "5. Exit"
                    );
                string input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        DisplayOutings();
                        break;
                    case "2":
                        CreateNewOuting();
                        break;
                    case "3":
                        CostOfAllOutings();
                        break;
                    case "4":
                        CostOfOutingByType();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                }
            }
        }

        private void CreateNewOuting()
        {
            Console.Clear();
            OutingsClass outing = new OutingsClass();

            Console.WriteLine("Select an outing Type(1-4\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert");
            int typeOfOuting = Convert.ToInt32(Console.ReadLine());
            outing.EventType = (TypeOfEvent)typeOfOuting;

            Console.WriteLine("How many people attended the event?: ");
            int people = Convert.ToInt32(Console.ReadLine());
            outing.NumberOfPeople = people;

            Console.WriteLine("What date did the outing happen(MM/DD/YYYY): ");
            DateTime dateOfEvent = Convert.ToDateTime(Console.ReadLine());

            outing.DateOfEvent = dateOfEvent;

            Console.WriteLine("What was the cost per person of the event?: ");
            decimal costPerPerson = Convert.ToDecimal(Console.ReadLine());
            outing.CostPerPerson = costPerPerson * people;

            Console.WriteLine("What was the total cost of the event?: ");
            decimal totalCost = Convert.ToDecimal(Console.ReadLine());
            if (totalCost < costPerPerson * people)
            {
                Console.WriteLine("Check the numbers the total cost shouldn't be lower than the cost per person");
            }
            else
            {
                outing.CostOfEvent = totalCost;
                _repo.AddOutingToRepo(outing);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void DisplayOutings()
        {
            Console.Clear();

            List<OutingsClass> listOfOutings = _repo.GetContents();

            foreach(OutingsClass outing in listOfOutings)
            {
                DisplayContent(outing);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void CostOfAllOutings()
        {
            Console.Clear();
            List<OutingsClass> listOfOutings = _repo.GetContents();
            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            DateTime lastDay = new DateTime(year, 12, 31);
            decimal totalCosts = 0.0m;
            foreach(OutingsClass outing in listOfOutings)
            {
                if(outing.DateOfEvent > firstDay && outing.DateOfEvent < lastDay)
                {
                    totalCosts += outing.CostOfEvent;
                }
            }
            Console.WriteLine($"The combined costs of all events for the year {year} is {totalCosts}");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void CostOfOutingByType()
        {
            Console.Clear();
            List<OutingsClass> listOfOutings = _repo.GetContents();
            decimal golfCosts = 0.0m;
            decimal bowlingCosts = 0.0m;
            decimal aParkCosts = 0.0m;
            decimal concertCosts = 0.0m;

            foreach(OutingsClass outing in listOfOutings)
            {
                if(outing.EventType.Equals(TypeOfEvent.Golf))
                {
                    golfCosts += outing.CostOfEvent;
                }
                else if(outing.EventType.Equals(TypeOfEvent.Bowling))
                {
                    bowlingCosts += outing.CostOfEvent;
                }
                else if(outing.EventType.Equals(TypeOfEvent.AmusementPark))
                {
                    aParkCosts += outing.CostOfEvent;
                }
                else
                {
                    concertCosts += outing.CostOfEvent;
                }
            }
            Console.WriteLine
                (
                    $"The costs by type of event are as follows: \n" +
                    $"Golf: {golfCosts}\n" +
                    $"Bowling: {bowlingCosts}\n" +
                    $"Amusement Park: {aParkCosts}\n" +
                    $"Concerts: {concertCosts}"
                );
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void DisplayContent(OutingsClass outing)
        {
            Console.WriteLine
                (
                    $"Type of event: {outing.EventType}\n" +
                    $"Number of Attendies: {outing.NumberOfPeople}\n" +
                    $"Date of the Event: {outing.DateOfEvent}\n" +
                    $"Total cost per person of the event: {outing.CostPerPerson}\n" +
                    $"Total cost of the event: {outing.CostOfEvent}"
                );
        }

        private void SeedData()
        {
            DateTime eventDate = new DateTime(2021, 05, 15);
            OutingsClass event1 = new OutingsClass(TypeOfEvent.Golf, 10, eventDate, 25, 500);
            OutingsClass event2 = new OutingsClass(TypeOfEvent.Golf, 20, eventDate, 25, 750);
            OutingsClass event3 = new OutingsClass(TypeOfEvent.AmusementPark, 100, eventDate, 15, 2000);
            OutingsClass event4 = new OutingsClass(TypeOfEvent.AmusementPark, 200, eventDate, 25, 7500);
            OutingsClass event5 = new OutingsClass(TypeOfEvent.Bowling, 10, eventDate, 25, 500);
            OutingsClass event6 = new OutingsClass(TypeOfEvent.Concert, 10, eventDate, 25, 500);

            _repo.AddOutingToRepo(event1);
            _repo.AddOutingToRepo(event2);
            _repo.AddOutingToRepo(event3);
            _repo.AddOutingToRepo(event4);
            _repo.AddOutingToRepo(event5);
            _repo.AddOutingToRepo(event6);

        }
    }
}
