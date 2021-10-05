using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsClasses
{
    public class ClaimsUI
    {
        private ClaimsRepo _repo = new ClaimsRepo();
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
                    "Enter the number of your selection:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit"        
                );
                string input = Console.ReadLine();
                switch(input)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        EnterANewClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                }
            }
        }

        private void SeeAllClaims()
        {
            Console.Clear();

            Queue<InsuranceClaims> insuranceClaims = _repo.GetClaims();
            
            foreach(InsuranceClaims claim in insuranceClaims)
            {
                DisplayContent(claim);
            }
            Console.WriteLine("Press any Key to continue");
            Console.ReadKey();
        }
        private void EnterANewClaim()
        {
            Console.Clear();
            InsuranceClaims claim = new InsuranceClaims();

            Console.WriteLine("Enter the ClaimID#: ");
            claim.ClaimID = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Select the type of Claim (1-3)\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            int claimTypeID = Convert.ToInt32(Console.ReadLine());
            claim.ClaimType = (TypeOfClaim)claimTypeID;
            
            Console.WriteLine("Enter a claim description: ");
            claim.Description = Console.ReadLine();

            Console.WriteLine("Amount of Damage: ");
            claim.ClaimAmount = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter the Date of the Accident(MM/DD/YYYY): ");
            DateTime accidentDate = DateTime.Parse(Console.ReadLine());
            claim.DateOfIncident = accidentDate;

            Console.WriteLine("Enter the Date of the Claim(MM/DD/YYYY): ");
            DateTime claimDate = DateTime.Parse(Console.ReadLine());
            claim.DateOfClaim = claimDate;

            TimeSpan timeSpan = claimDate - accidentDate;

            if(timeSpan.Days >= 30)
            {
                claim.IsValid = false;
            }
            else
            {
                claim.IsValid = true;
            }
            _repo.AddClaimsToDirectory(claim);


        }
        private void NextClaim()
        {
            Console.Clear();
            Queue<InsuranceClaims> claims = _repo.GetClaims();
            InsuranceClaims claim = new InsuranceClaims();

            if(claims.Count == 0)
            {
                Console.WriteLine("There need to be claims in the queue before we can do anything with them.");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            else
            {
                claim = claims.Peek();

                DisplayContent(claim);

                Console.WriteLine("Would you like to deal with this claim now?(y or n): ");
                string answer = Console.ReadLine().ToLower();

                if (answer == "y")
                {
                    claims.Dequeue();
                }
                else if (answer == "n")
                {
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Please enter a y or an n next time!");
                }
            }

        }

        private void DisplayContent(InsuranceClaims claim)
        {
            Console.WriteLine
                (
                    $"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.ClaimType}\n" +
                    $"Claim Description: {claim.Description}\n" +
                    $"Claim Amount: {claim.ClaimAmount}\n" +
                    $"Date of Accident: {claim.DateOfIncident}\n" +
                    $"Date of Claim: {claim.DateOfClaim}\n" +
                    $"Is the Claim valid? {claim.IsValid}"
                );
        }
    }
}
