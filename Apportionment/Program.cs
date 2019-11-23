using System;

namespace Apportionment
{
    class Program
    {
        static void Main(string[] args)
        {
            StateDetails stateDetails = new StateDetails();
            stateDetails.Load();
            stateDetails.SolveForMostRepresentation();
            Console.WriteLine( stateDetails.RenderJustStatesAndSeats());
        }
    }
}
