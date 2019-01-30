using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseSystem.Test
{
    [TestFixture]
    public class DeviceTest
    {
        protected Device testDevice;
        [SetUp]
        public virtual void Setup()
        {
            testDevice = new Device();
        }

        [Test]
        public void turnOnStateShouldBeTrue()
        {
            
            testDevice.turnOn();
            Assert.That(testDevice.Status, Is.True);
        }
        [Test]
        public void turnOffStateShouldBeFalse()
        {
            
            testDevice.turnOff();
            Assert.That(testDevice.Status, Is.False);
        }
    }
}
