using KomodoOutings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace OutingsTests
{
    [TestClass]
    public class OutingsTests
    {
        
        [TestMethod]
        public void GetAllOutings_ShouldReturnBoolValueofTrueOnceAllContentsAddedToRepo()
        {
            OutingsRepo repo = new OutingsRepo();
            OutingsClass outing = new OutingsClass();

            bool success = repo.AddOutingToRepo(outing);

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void GetOutingsShouldGetAllOutingsAndReturnTrueValueOnceComplete()
        {
            DateTime eventDate = new DateTime(2021, 05, 15);
            OutingsRepo repo = new OutingsRepo();
            OutingsClass event1 = new OutingsClass(TypeOfEvent.Golf, 10, eventDate, 25, 500);

            repo.AddOutingToRepo(event1);
            List<OutingsClass> outings = repo.GetContents();
            bool success = outings.Contains(event1);

            Assert.IsTrue(success);

        }
    }
}
