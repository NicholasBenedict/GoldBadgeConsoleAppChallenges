using KomodoClaimsClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoClaimsTests
{
    [TestClass]
    public class ClaimsTesting
    {
        [TestMethod]
        public void AddClaim_ShouldGetCorrectBooleanValueReturned()
        {
            InsuranceClaims claim = new InsuranceClaims();
            ClaimsRepo repo = new ClaimsRepo();

            bool success = repo.AddClaimsToDirectory(claim);

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void GetClaim_ShouldReturnCorrectListofClaims()
        {
            DateTime dateOfAccident = DateTime.Parse("09/21/2021");
            DateTime dateOfClaim = DateTime.Parse("10/4/2021");
            InsuranceClaims claim = new InsuranceClaims(1, TypeOfClaim.Car, "car fire", 750m, dateOfAccident, dateOfClaim, true);
            ClaimsRepo repo = new ClaimsRepo();
            repo.AddClaimsToDirectory(claim);

            Queue<InsuranceClaims> claims = repo.GetClaims();

            bool success = claims.Contains(claim);

            Assert.IsTrue(success);
        }
    }
}
