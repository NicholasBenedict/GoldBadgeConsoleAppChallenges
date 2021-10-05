using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsClasses
{
    public class ClaimsRepo
    {
        private readonly Queue<InsuranceClaims> _claimsQueue = new Queue<InsuranceClaims>();

        //Create
        public bool AddClaimsToDirectory(InsuranceClaims claim)
        {
            int startingCount = _claimsQueue.Count;

            _claimsQueue.Enqueue(claim);

            bool wasAdded = (_claimsQueue.Count > startingCount) ? true : false;

            return wasAdded;
        }

        //Read
        public Queue<InsuranceClaims> GetClaims()
        {
            return _claimsQueue;
        }

    }
}
