using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBadges
{
    public class BadgeUI
    {
        private BadgesRepo _badgesRepo = new BadgesRepo();
        public void Run()
        {
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
                        "1. Add a badge\n" +
                        "2. Edit a badge\n" +
                        "3. List all badges\n" +
                        "4. Exit"
                    );
                string input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        CreateNewBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        ShowAllBadges();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                }
            }
        }
        private void CreateNewBadge()
        {
            Console.Clear();
            BadgeClass badge = new BadgeClass();
            List<string> doorNumberHolder = new List<string>();
            bool userQuestion = true;

            Console.WriteLine("What is the number on the badge: ");
            int badgeNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("List a door that it needes access to: ");
            doorNumberHolder.Add(Console.ReadLine());

            while (userQuestion)
            {
                Console.WriteLine("Any other doors the badge needs acces to?(y/n): ");
                string answer = Console.ReadLine().ToLower();

                if(answer == "y")
                {
                    Console.Clear();
                    Console.WriteLine("List a door that it needs access to: ");
                    doorNumberHolder.Add(Console.ReadLine());
                }
                else
                {
                    userQuestion = false;
                }
            }
            badge.BadgeID = badgeNumber;
            badge.DoorNames = doorNumberHolder;
            _badgesRepo.AddContentToDirectory(badge);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void ShowAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> listOfBadges = _badgesRepo.GetContents();

            for(int i = 0; i < listOfBadges.Count; i++)
            {
                var badge = listOfBadges.ElementAt(i);
                var badgeKey = badge.Key;
                var badgeValue = badge.Value;
                string holder = "";
                Console.WriteLine("----------------------------");
                Console.WriteLine("BadgeNumber  |   RoomNumbers");
                Console.WriteLine("----------------------------");
                foreach (string roomNumber in badgeValue)
                {
                    holder = holder + " " + roomNumber;
                }

                Console.WriteLine(string.Format("{0,-12} | {1, 12}", badgeKey, holder));
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void UpdateBadge()
        {
            Console.Clear();
            ShowAllBadges();
            Console.WriteLine("What is the badge number to update?: ");
            int badgeNumber = Convert.ToInt32(Console.ReadLine());

                List<string> roomNumbers = _badgesRepo.GetContentByBadge(badgeNumber);

                Console.WriteLine("What would you like to do?\n" +
                    "1. Remove a door\n" +
                    "2. Add a door");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Which door would you like to remove?: ");
                        string input = Console.ReadLine();
                        _badgesRepo.RemoveRoomFromBadge(roomNumbers, input, badgeNumber);
                        break;
                    case "2":
                    Console.WriteLine("What is the door number to be added to the badge?: ");
                    string doorNumber = Console.ReadLine();
                    _badgesRepo.AddRoomToBadge(doorNumber, badgeNumber, roomNumbers);
                        break;
                }
            
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}
