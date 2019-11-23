using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apportionment
{
    public class StateDetails
    {
        List<State> _states = new List<State>();

        public void Load()
        {

            using (System.IO.StreamReader sr = new System.IO.StreamReader("state_data.json"))
            {
                var allStateData = sr.ReadToEnd();

                _states = System.Text.Json.JsonSerializer.Deserialize<List<State>>(allStateData);
                foreach(var state in _states)
                {
                    // everyone gets a seat at first.
                    state.NumberOfSeats = 1;
                }
            }
        }

        public void SolveForMostRepresentation()
        {
            // we stop when there are 435!
            while(_states.Sum(x => x.NumberOfSeats) < 435)
            {
                // find the state with the worst representation
                _states.Sort(SortByReps);
                _states.First().AddSeat();
                
            }
        }

        public string RenderResultsJson()
        {
            _states.Sort(SortBySeats);
            return System.Text.Json.JsonSerializer.Serialize(_states);
        }

        public string RenderCSV()
        {
            _states.Sort(SortBySeats);
            StringBuilder stb = new StringBuilder();
            foreach(var state in _states)
            {
                stb.AppendLine($"{state.Name}, {state.CensusPop}, {state.CurrentPop}, {state.NumberOfSeats}, {state.PeoplePerSeat}");
            }

            return stb.ToString();
        }

        public string RenderJustStatesAndSeats()
        {
            _states.Sort(SortBySeats);
            StringBuilder stb = new StringBuilder();
            foreach (var state in _states)
            {
                stb.AppendLine($"{state.Name}, {state.NumberOfSeats}");
            }

            return stb.ToString();
        }


        // sort the least represented to the top. basically "descending"
        private int SortByReps(State state1, State state2)
        {
            if(state1.PeoplePerSeat < state2.PeoplePerSeat)
            {
                return 1;
            }

            if(state1.PeoplePerSeat > state2.PeoplePerSeat)
            {
                return -1;
            }

            return 0;
        }

        private int SortBySeats(State state1, State state2)
        {
            if(state1.NumberOfSeats < state2.NumberOfSeats)
            {
                return 1;
            }
            if(state1.NumberOfSeats > state2.NumberOfSeats)
            {
                return -1;
            }

            return 0;
        }


    }
}
