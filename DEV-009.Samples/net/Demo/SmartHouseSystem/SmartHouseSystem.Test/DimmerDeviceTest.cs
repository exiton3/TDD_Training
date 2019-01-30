using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseSystem.Test
{
    [TestFixture]
    public class DimmerDeviceTest : DeviceTest
    {
        protected DimmerDevice testDimmerDevice;
        [SetUp]
        public override void Setup()
        {
            testDevice = new DimmerDevice();
            testDimmerDevice = (DimmerDevice) testDevice;
        }

        //[Test]
        //public void turnOnStateShouldBeTrue()
        //{
        //    Device testDevice = new DimmerDevice();
        //    testDevice.turnOn();
        //    Assert.That(testDevice.Status, Is.True);
        //}
        //[Test]
        //public void turnOffStateShouldBeFalse()
        //{
        //    Device testDevice = new DimmerDevice();
        //    testDevice.turnOff();
        //    Assert.That(testDevice.Status, Is.False);
        //}
        [Test]
        public void SetBrigtnessShouldBeEqual()
        {
            
            testDimmerDevice.SetBrightness(50);
            Assert.That(testDimmerDevice.Brightness, Is.EqualTo(50));
        }
        [Test]
        public void SetBrightnessToNegativeShouldBeArgumentOutOfRangeException()
        {
            
            Assert.Throws(typeof(ArgumentOutOfRangeException), 
                               () => testDimmerDevice.SetBrightness(-5));    
        }
        [Test(Description ="Brightness greather then 100")]
        public void SetBrightnessGreatherThen100ShouldBeArgumentOutOfRangeException()
        {
            
            Assert.Throws(typeof(ArgumentOutOfRangeException),
                               () => testDimmerDevice.SetBrightness(200));
        }
    }
}
