using NUnit.Framework;

namespace TheInternet.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldPass()
        {
            Assert.Pass("Setup complete :)");
        }
    }
}