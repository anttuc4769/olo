using NUnit.Framework;
using olo.Services;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var wordWrap = TextService.WordWrap("Anthony Test", 3);
            Assert.Pass();
        }
    }
}