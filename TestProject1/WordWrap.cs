using NUnit.Framework;
using olo.Services;

namespace TestProject1
{
    public class WordWrap
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void VerifyWithLength3()
        {
            var wordWrap = TextService.WordWrap("Anthony Test", 3);
            Assert.True(wordWrap.ConvertedText.Count == 5);
            Assert.True(!wordWrap.IsError);
        }

        [Test]
        public void VerifyWithLength7()
        {
            var wordWrap = TextService.WordWrap("Anthony Test", 7);
            Assert.True(wordWrap.ConvertedText.Count == 2);
            Assert.True(!wordWrap.IsError);
        }

        [Test]
        public void RandomChars()
        {
            var wordWrap = TextService.WordWrap("Anthony's Test &123", 7);
            Assert.True(wordWrap.ConvertedText.Count == 4);
            Assert.True(!wordWrap.IsError);
        }

        [Test]
        public void ExceptionLength()
        {
            var wordWrap = TextService.WordWrap("Anthony's Test &123", 0);
            Assert.True(wordWrap.IsError);
            Assert.True(wordWrap.Msg == "Length cannot be 0");
        }

        [Test]
        public void ExceptionString()
        {
            var wordWrap = TextService.WordWrap("", 10);
            Assert.True(wordWrap.IsError);
            Assert.True(wordWrap.Msg == "text - cannot be null");
        }
    }
}