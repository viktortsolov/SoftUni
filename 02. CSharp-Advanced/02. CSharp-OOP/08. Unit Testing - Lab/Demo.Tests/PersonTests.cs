using NUnit.Framework;
using System;

namespace Demo.Tests
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        [TestCase("Stoyan")]
        public void DoesWhatsMyNameWorksProperly(string name)
        {
            Person person = new Person("Stoyan", 10);

            person.WhatsMyName();

            Assert.Throws<Exception>(() => person.WhatsMyName());
        }
    }
}