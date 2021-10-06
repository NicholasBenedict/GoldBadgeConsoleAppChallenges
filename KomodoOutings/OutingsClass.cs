using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings
{
    public class OutingsClass
    {
        public OutingsClass() { }

        public OutingsClass(TypeOfEvent eventType, int numPeople, DateTime dateEvent, decimal costPerson, decimal costEvent)
        {
            EventType = eventType;
            NumberOfPeople = numPeople;
            DateOfEvent = dateEvent;
            CostPerPerson = costPerson;
            CostOfEvent = costEvent;
        }

        public TypeOfEvent EventType { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime DateOfEvent { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal CostOfEvent { get; set; }

    }

    public enum TypeOfEvent
    {
        Golf = 1, Bowling, AmusementPark, Concert
    }
}
