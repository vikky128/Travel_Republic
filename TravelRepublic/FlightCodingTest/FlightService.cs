using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelRepublic.FlightCodingTest
{
    public class FlightService : IFlightService
    {
        public List<Flight> GetCurrentFlight()
        {
            FlightBuilder fb = new FlightBuilder();
            List<Flight> lstFlight = new List<Flight>();
            List<FilterCount> filterCount = new List<FilterCount>();
            foreach (var flight in fb.GetFlights())
            {
                int sLenght = flight.Segments.Count;
                int mCount = 0;
                int count = 0;
                foreach (var item in flight.Segments)
                {
                    count++;
                    //Depart before the current date/time
                    if (item.DepartureDate < DateTime.Now)
                    {
                        mCount++;
                    }
                    //Have a segment with an arrival date before the departure date
                    if (item.ArrivalDate < item.DepartureDate)
                    {
                        mCount++;
                    }
                    //Spend more than 2 hours on the ground
                    if (sLenght > 1 && count < sLenght)
                    {
                        //Ground Time
                        double groundTime = flight.Segments[count].DepartureDate.Subtract(item.ArrivalDate).TotalMinutes;
                        if (groundTime > 120)
                        {
                            mCount++;
                        }
                    }
                }
                if (mCount > 0)
                {
                    filterCount.Add(new FilterCount { count = mCount, flight = flight });
                }
            }
            filterCount = filterCount.OrderByDescending(t => t.count).ToList();
            return filterCount.Select(t => t.flight).ToList();
        }
    }

}
