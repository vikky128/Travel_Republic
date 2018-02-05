using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelRepublic.FlightCodingTest
{
    public class Client
    {
        private IFlightService _service;

        public Client(IFlightService service)
        {
            this._service = service;
        }

        public List<Flight> StartFlightService()
        {
            return this._service.GetCurrentFlight();
        }
    }

    public class FilterCount
    {
        public int count { get; set; }
        public Flight flight { get; set; }
    }
}
