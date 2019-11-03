using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TSS_Server.Controllers;
using TSS_Data.Models;

namespace TSS_UnitTest
{
    class TSSScheduleControllerTest
    {
        [Test]
        public void Get()
        {
            TSSScheduleController controler = new TSSScheduleController();
            IEnumerable<StopStation> stops = controler.Get();
            Assert.IsTrue(stops != null);
            Assert.IsTrue(stops is List<StopStation>);
            Assert.AreEqual(2,((List<StopStation>)stops).Count);
            Assert.AreEqual(3, ((List<StopStation>)stops)[0].RouteSchedules.Count);
            Assert.AreEqual(3, ((List<StopStation>)stops)[1].RouteSchedules.Count);
        }
    }
}
