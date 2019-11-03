using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSS_Data.Models
{
    public class StopStation
    {
        public int ID { get; set; }
        public String Name { get; set; }
        
        public int DistanceFromPreviewsStop { get; set; }
        public List<RouteSchedule> RouteSchedules { get; set; }
    }
}
