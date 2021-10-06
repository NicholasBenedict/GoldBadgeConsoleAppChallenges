using DoorBadges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DoorBadgesTests
{
    [TestClass]
    public class DoorMethodsTests
    {
        [TestMethod]
        public void AddBadgeToRepo_ShouldReturnCorrectBoolValueIfBadgeAddedToRepo()
        {
            BadgeClass badge = new BadgeClass();
            BadgesRepo repo = new BadgesRepo();

            bool success = repo.AddContentToDirectory(badge);

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void GetBadge_ShouldReturnCorrectBoolValueIfTheBadgesWereGottenFromRepo()
        {
            int badgeNumber = 12345;
            List<string> doorNumbers = new List<string>();

            doorNumbers.Add("A6");
            doorNumbers.Add("A7");
            doorNumbers.Add("A8");

            BadgeClass badge = new BadgeClass(badgeNumber, doorNumbers);
            BadgesRepo badgesRepo = new BadgesRepo();

            badgesRepo.AddContentToDirectory(badge);

            Dictionary<int, List<string>> badgesList = badgesRepo.GetContents();

            bool success = badgesList.ContainsKey(badgeNumber);

            Assert.IsTrue(success);
        }
        [TestMethod]
        public void RemoveRoomFromBadge_ShouldReturnCorrectValueIfRoomWasRemovedFromBadge()
        {
            int badgeNumber = 12345;
            List<string> doorNumbers = new List<string>();
            string doorNum = "A6";
            doorNumbers.Add("A6");
            doorNumbers.Add("A7");
            doorNumbers.Add("A8");

            BadgeClass badge = new BadgeClass(badgeNumber, doorNumbers);
            BadgesRepo badgeRepo = new BadgesRepo();
            BadgesRepo badgeRepo2 = new BadgesRepo();

            badgeRepo2.AddContentToDirectory(badge);
            badgeRepo.AddContentToDirectory(badge);

            badgeRepo.RemoveRoomFromBadge(doorNumbers, doorNum, badgeNumber);

            Assert.AreNotEqual(badgeRepo2, badgeRepo);
        }
        [TestMethod]
        public void AddRoomToBadge_ShouldReturnCorrectValueIfRoomWasAddedToBadge()
        {
            int badgeNumber = 12345;
            List<string> doorNumbers = new List<string>();
            string doorNum = "A6";
            doorNumbers.Add("A7");
            doorNumbers.Add("A8");

            BadgeClass badge = new BadgeClass(badgeNumber, doorNumbers);
            BadgesRepo badgeRepo = new BadgesRepo();
            BadgesRepo badgeRepo2 = new BadgesRepo();

            badgeRepo2.AddContentToDirectory(badge);
            badgeRepo.AddContentToDirectory(badge);

            badgeRepo.AddRoomToBadge(doorNum, badgeNumber, doorNumbers);

            Assert.AreNotEqual(badgeRepo2, badgeRepo);
        }
    }
}
