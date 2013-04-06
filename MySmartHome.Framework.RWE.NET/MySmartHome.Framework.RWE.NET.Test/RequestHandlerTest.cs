using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RWE.NET;

namespace MySmartHome.Framework.RWE.NET.Test
{
    [TestClass]
    public class RequestHandlerTest
    {
        [TestMethod]
        public void TestLogicalDeviceCount()
        {
            MockRequestHandler requestHandler = new MockRequestHandler();
            LogicalDeviceStateManager stateManager = new LogicalDeviceStateManager(requestHandler);
            Assert.AreEqual(17, stateManager.LogicalDeviceStates.Count,"Es wurde nicht die erwartete Anzahl an Geräten ermittelt");
        }
    }
}
