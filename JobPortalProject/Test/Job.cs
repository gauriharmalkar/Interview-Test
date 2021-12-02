using NUnit.Framework;
using JobPortalProject.Controllers;
using JobPortalProject.Interface;

namespace Jobs.Test
{
    [TestFixture]
    public class Job
    {
        private  IService _Service;
        /*
        public Job(IService Service)
        {
            _Service = Service;
        }*/
        [SetUp]
        public void Setup(IService Service)
        {
            _Service = Service;
        }
        [Test]
        public void test1()
        {
            try
            {
                LocationController loc = new LocationController(_Service);
                var location = loc.GetLocation(10000);
                Assert.IsNotNull(location);
                    
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}