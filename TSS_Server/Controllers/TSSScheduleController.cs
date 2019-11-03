using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TSS_Data.Models;

namespace TSS_Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TSSScheduleController : ControllerBase
    {
        List<StopStation> tempStops = new List<StopStation>() {
        new StopStation(){ ID =1 , Name = "First Stop", DistanceFromPreviewsStop =0},
        new StopStation(){ ID =2 , Name = "Second Stop", DistanceFromPreviewsStop = 2} };

        List<Route> tempRoute = new List<Route>()
        {
            new Route() { ID = 1, Name = "Route 1", Interval= 15, StartingTime = new TimeSpan(0,0,0)},
            new Route() { ID = 2, Name = "Route 2", Interval= 15, StartingTime = new TimeSpan(0,2,0)},
            new Route() { ID = 3, Name = "Route 3", Interval= 15, StartingTime = new TimeSpan(0,4,0)}
        };

        [HttpGet]
        public IEnumerable<StopStation> Get()
        {
            int distanceFromPreviewsStops = 0;
            List<StopStation> results = new List<StopStation>();
            foreach(StopStation stop in tempStops.OrderBy(s=>s.ID))
            {
                stop.RouteSchedules = new List<RouteSchedule>();
                distanceFromPreviewsStops += stop.DistanceFromPreviewsStop;
                foreach (Route route in tempRoute)
                {
                    int minutesToArive = 0;
                    int minutesFromStartTime = (DateTime.Now.TimeOfDay - route.StartingTime).Minutes;
                    minutesToArive = route.Interval -(minutesFromStartTime % route.Interval);
                    
                    stop.RouteSchedules.Add(
                        new RouteSchedule()
                        {
                            ID = 1,
                            RouteID = route.ID,
                            TheRouteName = route.Name,
                            Schedules = new List<int>() {
                            distanceFromPreviewsStops + minutesToArive,
                            distanceFromPreviewsStops + minutesToArive + route.Interval
                        }
                        }
                    );
                }

                results.Add(stop);
                
            }
            return results;
        }
    }
}
