using System;
using System.Collections.Generic;
using System.Text;

namespace Apportionment
{
    public class State
    {
        private int _numberOfSeats = 1;

        public string Name { get; set; }
        public int CensusPop { get; set; }
        public int CurrentPop { get; set; }
        public int NumberOfSeats
        {
            get
            {
                return _numberOfSeats;
            }
            set
            {
                _numberOfSeats = value;
                Calculate();
            }
        }

        public decimal PeoplePerSeat { get; set; }
        public void Calculate()
        {
            PeoplePerSeat = CurrentPop / NumberOfSeats;
        }

        public void AddSeat()
        {
            NumberOfSeats += 1;
        }
    }
}
