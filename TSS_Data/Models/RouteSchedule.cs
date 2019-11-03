using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSS_Data.Models
{
    public class RouteSchedule
    {
        public int ID { get; set; }
        public List<int> Schedules { get; set; }

        public int RouteID { get; set; }

        public string TheRouteName { get; set; }

    }
}
