using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSS_Data.Models
{
    public class Route
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public TimeSpan StartingTime { get; set; }
        public int Interval { get; set; }

    }
}
