using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings
{
    public class OutingsRepo
    {
        private readonly List<OutingsClass> _outingRepo = new List<OutingsClass>();

        public bool AddOutingToRepo(OutingsClass outing)
        {
            int startingCount = _outingRepo.Count;

            _outingRepo.Add(outing);

            bool wasAdded = _outingRepo.Count > startingCount;

            return wasAdded;
        }
        
        public List<OutingsClass> GetContents()
        {
            return _outingRepo;
        }
    }
}
