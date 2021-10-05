using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBadges
{
    public class BadgesRepo
    {
        private readonly Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        //Create
        public bool AddContentToDirectory(BadgeClass badge)
        {
            int startingCount = _badgeDictionary.Count();

            _badgeDictionary.Add(badge.BadgeID, badge.DoorNames);

            bool wasAdded = (_badgeDictionary.Count > startingCount) ? true : false;

            return wasAdded;
        }
        //Read
        public Dictionary<int, List<string>> GetContents()
        {
            return _badgeDictionary;
        }
        //Get by Badge #

        public List<string> GetContentByBadge(int badgeNumber)
        {
            List<string> roomNumberHolder = new List<string>();
            for (int i = 0; i < _badgeDictionary.Count; i++)
            {
                var badge = _badgeDictionary.ElementAt(i);
                var badgeKey = badge.Key;
                var badgeValue = badge.Value;
                
                if (badgeNumber == badgeKey)
                {
                    foreach(string roomNumber in badgeValue)
                    {
                        roomNumberHolder.Add(roomNumber);
                    }
                }
            }

            return roomNumberHolder;
        }

        public void RemoveRoomFromBadge(List<string> roomNumbers, string roomNumber, int badgeNumber)
        {
            for(int i = 0; i < roomNumbers.Count; i++)
            {
                if(roomNumbers.Contains(roomNumber))
                {
                    roomNumbers.Remove(roomNumber);
                }
            }
            _badgeDictionary.Remove(badgeNumber);
            _badgeDictionary.Add(badgeNumber, roomNumbers);            
        }

        public void AddRoomToBadge(string roomNumber, int badgeNumber, List<string> roomNumbers)
        {
                if(roomNumbers.Contains(roomNumber))
                {
                    Console.WriteLine("That badge already has access to that room!");
                }
                else
                {
                    roomNumbers.Add(roomNumber);
                }
            _badgeDictionary.Remove(badgeNumber);
            _badgeDictionary.Add(badgeNumber, roomNumbers);
        }
    }
}
