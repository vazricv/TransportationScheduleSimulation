using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TSS_Client.Pages;
using TSS_Data.Models;

namespace TSS_UnitTest
{
    class IndexModelTest
    {
        [Test]
        public async System.Threading.Tasks.Task GetAsync()
        {
            IndexModel index = new IndexModel();
            await index.OnGet();
            foreach (StopStation stop in index.stops)
            {
                Console.Write(stop.Name);
                Console.WriteLine("\tFirst\tSecond");
                foreach (RouteSchedule schedule in stop.RouteSchedules)
                {
                    Console.Write(schedule.TheRouteName+"\t\t");
                    foreach (int minutes in schedule.Schedules)
                    {
                        Console.Write(minutes+"\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
