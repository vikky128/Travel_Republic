using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelRepublic.FlightCodingTest
{
    public interface IFlightService
    {
        List<Flight> GetCurrentFlight();
    }
}
